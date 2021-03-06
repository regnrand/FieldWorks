// Copyright (c) 2005-2013 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)
//
// File: FilterBookDialogTests.cs
// Responsibility:
// Last reviewed:
//
// <remarks>
// </remarks>

using System.Windows.Forms;

using NUnit.Framework;

using SIL.LCModel;
using SIL.FieldWorks.Common.Controls;

namespace SIL.FieldWorks.TE
{
	#region DummyFilterBookDialog
	/// ----------------------------------------------------------------------------------------
	/// <summary>
	/// Exposes FilterBookDialog stuff for testing
	/// </summary>
	/// ----------------------------------------------------------------------------------------
	public class DummyFilterBookDialog : FilterBookDialog
	{
		/// -----------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="FilterBookDialog"/> class.
		/// </summary>
		/// <param name="cache"></param>
		/// <param name="bookList">A list of books to check as an array</param>
		/// -----------------------------------------------------------------------------------
		public DummyFilterBookDialog(LcmCache cache, IScrBook[] bookList): base(cache, bookList, null)
		{
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Creates the dialog
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public void DontShow()
		{
			CreateHandle();
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Gets the OK button
		/// </summary>
		/// ------------------------------------------------------------------------------------
		public Button OKButton
		{
			get { return m_btnOK; }
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		/// Select a book in the list
		/// </summary>
		/// <param name="book"></param>
		/// <param name="state"></param>
		/// ------------------------------------------------------------------------------------
		public void SelectBook(IScrBook book, TriStateTreeView.CheckState state)
		{
			m_treeTexts.CheckNodeByTag(book, state);
		}
	}
	#endregion

	/// <summary>
	/// Tests for FilterBookDialog
	/// </summary>
	[TestFixture]
	public class FilterBookDialogTests : ScrInMemoryLcmTestBase
	{
		#region Member variables
		private IScrBook m_genesis;
		#endregion

		#region Test setup
		/// ------------------------------------------------------------------------------------
		/// <summary>
		///
		/// </summary>
		/// ------------------------------------------------------------------------------------
		[TearDown]
		public override void TestTearDown()
		{
			//m_dialog.Close();
			//m_dialog = null;
			m_genesis = null;

			base.TestTearDown();
		}

		/// ------------------------------------------------------------------------------------
		/// <summary>
		///
		/// </summary>
		/// ------------------------------------------------------------------------------------
		protected override void CreateTestData()
		{
			m_genesis = AddBookToMockedScripture(1, "Genesis");
			AddBookToMockedScripture(2, "Exodus");
			AddBookToMockedScripture(3, "Leviticus");
		}
		#endregion

		/// -----------------------------------------------------------------------------------
		/// <summary>
		/// Tests that the OK button is disabled if no books are selected to show.
		/// </summary>
		/// -----------------------------------------------------------------------------------
		[Test]
		public void OkButtonDisabledIfNothingSelected()
		{
			using (DummyFilterBookDialog dialog = new DummyFilterBookDialog(Cache, new IScrBook[] { }))
			{
				dialog.DontShow();
				Assert.IsFalse(dialog.OKButton.Enabled);
			}
		}

		/// -----------------------------------------------------------------------------------
		/// <summary>
		/// Tests that the OK button is enabled if books are in the filter
		/// </summary>
		/// -----------------------------------------------------------------------------------
		[Test]
		public void OkButtonEnabledIfSomethingSelected()
		{
			using (DummyFilterBookDialog dialog = new DummyFilterBookDialog(Cache, new IScrBook[] { m_genesis }))
			{
				dialog.DontShow();
				Assert.IsTrue(dialog.OKButton.Enabled);
			}
		}

		/// -----------------------------------------------------------------------------------
		/// <summary>
		/// Tests that OK button gets enabled when something gets selected
		/// </summary>
		/// -----------------------------------------------------------------------------------
		[Test]
		public void OkButtonGetsEnabledIfSelected()
		{
			using (DummyFilterBookDialog dialog = new DummyFilterBookDialog(Cache, new IScrBook[] { }))
			{
				dialog.DontShow();
				dialog.SelectBook(m_genesis, TriStateTreeView.CheckState.Checked);

				Assert.IsTrue(dialog.OKButton.Enabled);
			}
		}

		/// -----------------------------------------------------------------------------------
		/// <summary>
		/// Tests that the OK button gets disabled if all books are removed from filter
		/// </summary>
		/// -----------------------------------------------------------------------------------
		[Test]
		public void OkButtonGetsDisabledIfNothingSelected()
		{
			using (DummyFilterBookDialog dialog = new DummyFilterBookDialog(Cache, new IScrBook[] { m_genesis }))
			{
				dialog.DontShow();
				dialog.SelectBook(m_genesis, TriStateTreeView.CheckState.Unchecked);

				Assert.IsFalse(dialog.OKButton.Enabled);
			}
		}
	}
}
