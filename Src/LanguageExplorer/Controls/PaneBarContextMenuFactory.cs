// Copyright (c) 2016 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System;
using System.Drawing;
using System.Windows.Forms;
using SIL.FieldWorks.Common.FwUtils;

namespace LanguageExplorer.Controls
{
	/// <summary>
	/// Factory that creates an instance of ToolStripMenuItem.
	/// </summary>
	internal static class PaneBarContextMenuFactory
	{
		/// <summary>
		/// Create a new ToolStripMenuItem and place it in the menu strip.
		/// </summary>
		internal static ToolStripMenuItem CreateToolStripMenuItem(ContextMenuStrip contextMenuStrip, string menuText, Image image, EventHandler eventHandler, string menuTooltip)
		{
			var toolStripMenuItem = new ToolStripMenuItem(FwUtils.ReplaceUnderlineWithAmpersand(menuText), image, eventHandler)
			{
				ToolTipText = menuTooltip
			};
			contextMenuStrip.Items.Add(toolStripMenuItem);

			return toolStripMenuItem;
		}
	}
}