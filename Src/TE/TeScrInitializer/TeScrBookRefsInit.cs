// Copyright (c) 2010-2013 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)
//
// File: TeScrBookRefsInit.cs
// Responsibility: FieldWorks Team

using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Diagnostics;
using System.Xml;

using SIL.LCModel.Core.Scripture;
using SIL.LCModel.Core.Text;
using SIL.LCModel.Core.WritingSystems;
using SIL.FieldWorks.Common.Framework;
using SIL.LCModel.Core.KernelInterfaces;
using SIL.LCModel;
using SIL.LCModel.Utils;

namespace SIL.FieldWorks.TE
{
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	/// Class providing static method that TE calls to perform initialization of ScrBookRefs
	/// names
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class TeScrBookRefsInit : SettingsXmlAccessorBase
	{
		#region Constants
		private const string ksScrBookRefsSrc = "ScrBookRefs";
		#endregion

		#region Member variables
		private readonly LcmCache m_cache;
		#endregion

		#region Constructors
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="TeScrBookRefsInit"/> class.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected TeScrBookRefsInit(LcmCache cache)
		{
			m_cache = cache;
		}
		#endregion

		#region Overridden methods
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Process the resources to set the ScrBookRefs names, abbreviations, etc.
		/// </summary>
		/// <param name="dlg">The progress dialog manager.</param>
		/// <param name="doc">The loaded XML document that has the info.</param>
		/// ------------------------------------------------------------------------------------
		protected override void ProcessResources(IThreadedProgress dlg, XmlNode doc)
		{
			dlg.RunTask(SetNamesAndAbbreviations, doc);
		}
		#endregion

		#region Public/internal static methods
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Ensures that the ScrBookRefs have the current versions of all localized names and
		/// abbreviations
		/// </summary>
		/// <param name="cache">The cache</param>
		/// <param name="existingProgressDlg">The existing progress dialog, if any.</param>
		/// ------------------------------------------------------------------------------------
		public static void EnsureFactoryScrBookRefs(LcmCache cache, IThreadedProgress existingProgressDlg)
		{
			TeScrBookRefsInit scrRefInit = new TeScrBookRefsInit(cache);
			scrRefInit.EnsureCurrentResource(existingProgressDlg);
		}

		/// -------------------------------------------------------------------------------------
		/// <summary>
		/// Sets localized names and abbreviations for ScrBookRefs using values from the XML file.
		/// </summary>
		/// <param name="progressDlg">Progress dialog so the user can cancel</param>
		/// <param name="cache">The cache</param>
		/// -------------------------------------------------------------------------------------
		internal static void SetNamesAndAbbreviations(IProgress progressDlg, LcmCache cache)
		{
			TeScrBookRefsInit scrRefInit = new TeScrBookRefsInit(cache);
			scrRefInit.SetNamesAndAbbreviations(progressDlg, scrRefInit.LoadDoc());
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Sets localized names and abbreviations for ScrBookRefs using values from the XML file.
		/// </summary>
		/// <param name="progressDlg">Progress dialog so the user can cancel</param>
		/// <param name="parameters">Only parameter is the XmlNode that holds the publication
		/// information.
		/// </param>
		/// ------------------------------------------------------------------------------------
		protected object SetNamesAndAbbreviations(IProgress progressDlg,
			params object[] parameters)
		{
			Debug.Assert(parameters.Length == 1);
			SetNamesAndAbbreviations(progressDlg, (XmlNode)parameters[0]);
			return null;
		}
		#endregion

		#region Main processing methods
		/// -------------------------------------------------------------------------------------
		/// <summary>
		/// Create publications and header/footer sets (in the DB) from the given XML document.
		/// </summary>
		/// <remarks>tests are able to call this method</remarks>
		/// <param name="progressDlg">Progress dialog</param>
		/// <param name="rootNode">The XmlNode from which to read the publication info</param>
		/// -------------------------------------------------------------------------------------
		protected void SetNamesAndAbbreviations(IProgress progressDlg, XmlNode rootNode)
		{
			IScrRefSystem srs = m_cache.ServiceLocator.GetInstance<IScrRefSystemRepository>().Singleton;
			Debug.Assert(srs != null && srs.BooksOS.Count == BCVRef.LastBook);

			XmlNodeList tagList = rootNode.SelectNodes("/ScrBookRef/writingsystem");
			progressDlg.Minimum = 0;
			progressDlg.Maximum = tagList.Count * BCVRef.LastBook;
			progressDlg.Position = 0;
			progressDlg.Title = TeResourceHelper.GetResourceString("kstidCreatingBookNames");
			CoreWritingSystemDefinition ws;

			foreach (XmlNode writingSystem in tagList)
			{
				XmlAttributeCollection attributes = writingSystem.Attributes;
				string sWsTag = attributes.GetNamedItem("xml:lang").Value;
				m_cache.ServiceLocator.WritingSystemManager.GetOrSet(sWsTag, out ws);

				XmlNodeList WSBooks = writingSystem.SelectNodes("book");
				foreach (XmlNode book in WSBooks)
				{
					XmlAttributeCollection bookAttributes = book.Attributes;
					string sSilBookId = bookAttributes.GetNamedItem("SILBookId").Value;
					Debug.Assert(sSilBookId != null);
					int nCanonicalBookNum = BCVRef.BookToNumber(sSilBookId);
					string sName = bookAttributes.GetNamedItem("Name").Value;
					string sAbbrev = bookAttributes.GetNamedItem("Abbreviation").Value;
					string sAltName = bookAttributes.GetNamedItem("AlternateName").Value;
					progressDlg.Message = string.Format(
						TeResourceHelper.GetResourceString("kstidCreatingBookNamesStatusMsg"), sName);
					progressDlg.Step(0);

					// check for the book id
					IScrBookRef bookRef = srs.BooksOS[nCanonicalBookNum - 1];

					int wsHandle = ws.Handle;
					if (sName != null)
						bookRef.BookName.set_String(wsHandle, TsStringUtils.MakeString(sName, wsHandle));
					if (sAbbrev != null)
						bookRef.BookAbbrev.set_String(wsHandle, TsStringUtils.MakeString(sAbbrev, wsHandle));
					if (sAltName != null)
						bookRef.BookNameAlt.set_String(wsHandle, TsStringUtils.MakeString(sAltName, wsHandle));
				}
			}
			// Finally, update resource version in database.
			SetNewResourceVersion(GetVersion(rootNode));
		}
		#endregion

		#region Properties
		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the required DTD version.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected override string DtdRequiredVersion
		{
			get { return "6CFDEBDD-FF59-4b4d-8E58-9228B8319E0C"; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// The name of the root element in the XmlDocument that contains the root element that
		/// has the DTDVer attribute.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected override string RootNodeName
		{
			get { return "ScrBookRef"; }
		}

		/// -------------------------------------------------------------------------------------
		/// <summary>
		/// Required implementation of abstract property to get the relative path to
		/// configuration file from the FieldWorks install folder.
		/// Note that this is NOT in the Translation Editor subfolder, because it is needed
		/// for 'minimal scripture initialization' when FLEx wants to load Paratext Scripture,
		/// and the Translation Editor folder might not be installed.
		/// </summary>
		/// -------------------------------------------------------------------------------------
		protected override string ResourceFilePathFromFwInstall
		{
			get { return Path.DirectorySeparatorChar + ResourceFileName; }
		}

		/// -------------------------------------------------------------------------------------
		/// <summary>
		/// Required implementation of abstract property to get the name of the configuration\
		/// file.
		/// </summary>
		/// -------------------------------------------------------------------------------------
		protected override string ResourceName
		{
			get { return "ScrBookRef"; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the resource list in which the CmResources are owned.
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected override ILcmOwningCollection<ICmResource> ResourceList
		{
			get { return m_cache.LangProject.TranslatedScriptureOA.ResourcesOC; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the LcmCache
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected override LcmCache Cache
		{
			get { return m_cache; }
		}
		#endregion
	}
}
