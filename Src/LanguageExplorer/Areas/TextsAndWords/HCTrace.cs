// Copyright (c) 2015 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System.IO;
using System.Xml.Linq;
using System.Xml.Xsl;
using SIL.FieldWorks.Common.FwUtils;
using SIL.FieldWorks.FDO;

namespace LanguageExplorer.Areas.TextsAndWords
{
	internal sealed class HCTrace : IParserTrace
	{
		private static ParserTraceUITransform s_traceTransform;
		private static ParserTraceUITransform TraceTransform
		{
			get
			{
				if (s_traceTransform == null)
					s_traceTransform = new ParserTraceUITransform("FormatHCTrace");
				return s_traceTransform;
			}
		}

		public string CreateResultPage(IPropertyTable propertyTable, XDocument result, bool isTrace)
		{
			var args = new XsltArgumentList();
			args.AddParam("prmHCTraceLoadErrorFile", "", Path.Combine(Path.GetTempPath(), propertyTable.GetValue<FdoCache>("cache").ProjectId.Name + "HCLoadErrors.xml"));
			args.AddParam("prmShowTrace", "", isTrace.ToString().ToLowerInvariant());
			return TraceTransform.Transform(propertyTable, result, isTrace ? "HCTrace" : "HCParse", args);
		}
	}
}
