using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CTripOSS.Baiji.Editor.Properties;
using CTripOSS.Baiji.IDLParser;
using FastColoredTextBoxNS;
using Irony;
using Resources = CTripOSS.Baiji.Editor.Properties.Resources;

namespace CTripOSS.Baiji.Editor
{
    public partial class MainForm : Form
    {
        #region [Configurations]
        private const int MaxRecentFileCount = 9;

        private const string FileExtension = ".bjsc";
        #endregion

        #region [Private Fields]
        /// <summary>
        /// The current working document.
        /// </summary>
        private Document m_Document;

        private AutocompleteMenu m_AutocompleteMenu;
        #endregion

        #region [Constructor]
        public MainForm()
        {
            InitializeComponent();
            InitializeTextBox();
            InitializeFileDialogs();
            UpdateRecentFilesDisplay();
            New_Click(null, EventArgs.Empty);
            Icon = Resources.Icon;
        }
        #endregion

        #region [UI Event Handler]

        #region [Form Events]
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !CloseDocument();
        }
        #endregion

        #region [TextBox Events]
        private void m_TextBox_TextChangedDelayed(object sender, TextChangedEventArgs e)
        {
            UpdateDocumentNameDisplay();
            UpdateParserMessages();
        }

        private void m_TextBox_SelectionChangedDelayed(object sender, EventArgs e)
        {
            UpdateMenuToolBarStatus();
            UpdateStatusBar();
        }

        private void m_TextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            var hasSupportedFile = GetFirstValidIdlFile(files) != null;
            e.Effect = hasSupportedFile ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void m_TextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            var files = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (files == null)
            {
                return;
            }
            var fileToOpen = GetFirstValidIdlFile(files);
            OpenDocument(fileToOpen);
        }

        private static string GetFirstValidIdlFile(IEnumerable<string> files)
        {
            if (files == null)
            {
                return null;
            }
            return files.FirstOrDefault(file => Path.GetExtension(file.ToLower()) == FileExtension);
        }
        #endregion

        #region [File Menu & Related ToolBar Buttons Events]
        private void New_Click(object sender, EventArgs e)
        {
            if (!CloseDocument())
            {
                return;
            }
            m_Document = Document.CreateNew(m_TextBox);
            UpdateDocumentNameDisplay();
            UpdateMenuToolBarStatus();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            if (!CloseDocument())
            {
                return;
            }
            var result = m_OpenFileDialog.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            OpenDocument(m_OpenFileDialog.FileName);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDocument(false);
            }
            catch (Exception ex)
            {
                var message = string.Format("Save file failed: {0}", ex.Message);
                MessageBox.Show(this, message, Resources.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateMenuToolBarStatus();
        }

        private void SaveAs_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDocument(true);
            }
            catch (Exception ex)
            {
                var message = string.Format("Save file failed: {0}", ex.Message);
                MessageBox.Show(this, message, Resources.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            UpdateMenuToolBarStatus();
        }

        private void ClearRecentFiles_Click(object sender, EventArgs e)
        {
            Settings.Default.RecentFiles.Clear();
            Settings.Default.Save();
            UpdateRecentFilesDisplay();
        }

        private void RecentFileMenuItem_Click(object sender, EventArgs ex)
        {
            var menuItem = sender as ToolStripMenuItem;
            if (menuItem == null || menuItem.Tag == null)
            {
                return;
            }
            if (!CloseDocument())
            {
                return;
            }
            OpenDocument(menuItem.Tag.ToString());
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region [Edit Menu & Related ToolBar Buttons Events]
        private void Undo_Click(object sender, EventArgs e)
        {
            if (m_TextBox.UndoEnabled)
            {
                m_TextBox.Undo();
            }
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            if (m_TextBox.RedoEnabled)
            {
                m_TextBox.Redo();
            }
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            m_TextBox.Cut();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            m_TextBox.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            m_TextBox.Paste();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            m_TextBox.ClearSelected();
        }

        private void SelectAll_Click(object sender, EventArgs e)
        {
            m_TextBox.Selection.SelectAll();
        }

        private void Find_Click(object sender, EventArgs e)
        {
            m_TextBox.ShowFindDialog();
        }

        private void FindNext_Click(object sender, EventArgs e)
        {
            if (m_TextBox.findForm != null)
            {
                m_TextBox.findForm.FindNext(m_TextBox.findForm.tbFind.Text);
            }
        }

        private void Replace_Click(object sender, EventArgs e)
        {
            m_TextBox.ShowReplaceDialog();
        }
        #endregion

        #region [View Menu & Related ToolBar Buttons Events]
        private void Goto_Click(object sender, EventArgs e)
        {
            m_TextBox.ShowGoToDialog();
        }

        private void NavigateBackward_Click(object sender, EventArgs e)
        {
            m_TextBox.NavigateBackward();
        }

        private void NavigateForward_Click(object sender, EventArgs e)
        {
            m_TextBox.NavigateForward();
        }
        #endregion

        #region [Generate Menu & Related ToolBar Buttons Events]
        private void GenerateCSharp_Click(object sender, EventArgs e)
        {
            if (sender == m_GenerateCSharpToolMenuItem)
            {
                RecordLastUsedGenerationOption((ToolStripMenuItem)sender, GenerateCSharp_Click);
            }

            if (!ValidateBeforeCodeGen())
            {
                return;
            }

            using (var form = new GenerateCSharpForm {IdlFilename = m_Document.Filename})
            {
                form.ShowDialog(this);
            }
        }

        private void GenerateJava_Click(object sender, EventArgs e)
        {
            if (sender == m_GenerateJavaToolMenuItem)
            {
                RecordLastUsedGenerationOption((ToolStripMenuItem)sender, GenerateJava_Click);
            }

            if (!ValidateBeforeCodeGen())
            {
                return;
            }

            using (var form = new GenerateJavaForm {IdlFilename = m_Document.Filename})
            {
                form.ShowDialog(this);
            }
        }

        private void GenerateOC_Click(object sender, EventArgs e)
        {
            if (sender == m_GenerateOCMenuItem)
            {
                RecordLastUsedGenerationOption((ToolStripMenuItem)sender, GenerateOC_Click);
            }

            if (!ValidateBeforeCodeGen())
            {
                return;
            }

            using (var form = new GenerateOCForm { IdlFilename = m_Document.Filename })
            {
                form.ShowDialog(this);
            }
        }

        private bool ValidateBeforeCodeGen()
        {
            if (m_TextBox.ParseTree.HasErrors())
            {
                MessageBox.Show(this, "Please fix all the errors before generating source code.",
                                Resources.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }

            if (m_Document.Filename == null || m_Document.IsDirty)
            {
                MessageBox.Show(this, "Please save the file before generating source code from it.",
                                Resources.ProductName,
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void m_GenerateToolButton_ButtonClick(object sender, EventArgs e)
        {
            var lastUsedGenerationHandler = (EventHandler)m_GenerateToolButton.Tag;
            if (lastUsedGenerationHandler == null)
            {
                m_GenerateToolButton.ShowDropDown();
                return;
            }
            lastUsedGenerationHandler(sender, e);
        }

        private void m_CodeGenOptionsMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new CodeGenOptionsForm())
            {
                form.ShowDialog(this);
            }
        }
        #endregion

        #region [Help Menu Events]
        private void About_Click(object sender, EventArgs e)
        {
            var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            var message = string.Format("{0} v{1}", Resources.ProductName, fileVersion.ProductVersion);
            MessageBox.Show(this, message, Resources.ProductName, MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }
        #endregion

        #region [Error List View Events]
        private void m_ErrorListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hitTestInfo = m_ErrorListView.HitTest(e.Location);
            if (hitTestInfo.Item == null)
            {
                return;
            }
            var parserLogMessage = (LogMessage)hitTestInfo.Item.Tag;
            if (parserLogMessage == null)
            {
                return;
            }
            NavigateByParserLogMessage(parserLogMessage);
        }

        private void m_ErrorListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_ErrorListView.SelectedItems.Count == 0)
            {
                return;
            }
            var selectedItem = m_ErrorListView.SelectedItems[0];
            var parserLogMessage = (LogMessage)selectedItem.Tag;
            if (parserLogMessage == null)
            {
                return;
            }
            NavigateByParserLogMessage(parserLogMessage);
        }
        #endregion

        #endregion

        #region [Private Methods]
        private void InitializeTextBox()
        {
            m_TextBox.Grammar = new IdlGrammar();
            m_AutocompleteMenu = new AutocompleteMenu(m_TextBox)
                {
                    MaximumSize = new Size(200, 300),
                    Width = 200,
                    AppearInterval = 300,
                    AllowTabKey = true
                };
            m_AutocompleteMenu.Items.SetAutocompleteItems(new IdlAutoCompleteCollection(m_AutocompleteMenu, m_TextBox));
        }

        private void InitializeFileDialogs()
        {
            var filter = string.Format("Baiji IDL files (*{0})|*{0}|All files (*.*)|*.*", FileExtension);
            m_SaveFileDialog.Filter = m_OpenFileDialog.Filter = filter;
        }

        private void UpdateDocumentNameDisplay()
        {
            Text = m_Document != null
                       ? string.Format("{0} - {1}{2}", Resources.ProductName, m_Document.DisplayName,
                                       m_Document.IsDirty ? "*" : string.Empty)
                       : Resources.ProductName;
        }

        private void UpdateMenuToolBarStatus()
        {
            m_UndoMenuItem.Enabled = m_UndoToolButton.Enabled = m_UndoContextMenuItem.Enabled = m_TextBox.UndoEnabled;
            m_RedoMenuItem.Enabled = m_RedoToolButton.Enabled = m_RedoContextMenuItem.Enabled = m_TextBox.RedoEnabled;
            m_DeleteMenuItem.Enabled = m_DeleteContextMenuItem.Enabled = !m_TextBox.Selection.IsEmpty;
        }

        private void UpdateStatusBar()
        {
            var caretPosition = m_TextBox.Selection.Start;
            m_LineStatusLabel.Text = string.Concat("Ln ", caretPosition.iLine + 1);
            m_ColumnStatusLabel.Text = string.Concat("Col ", caretPosition.iChar + 1);
        }

        private void UpdateParserMessages()
        {
            var tree = m_TextBox.ParseTree;
            if (tree == null)
            {
                m_ErrorListView.Items.Clear();
                return;
            }
            for (var i = 0; i < tree.ParserMessages.Count; ++i)
            {
                var message = tree.ParserMessages[i];
                var location = message.Location;
                var subItems = new[] { message.Message, location.Line.ToString(), location.Column.ToString() };
                var listViewItem = new ListViewItem(subItems) {Tag = message};
                if (i < m_ErrorListView.Items.Count)
                {
                    m_ErrorListView.Items[i] = listViewItem;
                }
                else
                {
                    m_ErrorListView.Items.Add(listViewItem);
                }
            }
            while (m_ErrorListView.Items.Count > tree.ParserMessages.Count)
            {
                m_ErrorListView.Items.RemoveAt(m_ErrorListView.Items.Count - 1);
            }
        }

        private void RecordLastUsedGenerationOption(ToolStripMenuItem menuItem, EventHandler handler)
        {
            if (menuItem == null)
            {
                m_GenerateToolButton.ToolTipText = "Generate";
                m_GenerateToolButton.Image = Resources.Icon_16x16_Generate;
                m_GenerateToolButton.Tag = null;
                return;
            }
            m_GenerateToolButton.ToolTipText = menuItem.Text;
            m_GenerateToolButton.Image = menuItem.Image;
            m_GenerateToolButton.Tag = handler;
        }

        private void NavigateByParserLogMessage(LogMessage parserLogMessage)
        {
            if (parserLogMessage == null)
            {
                return;
            }
            var location = parserLogMessage.Location;
            m_TextBox.Selection.End = m_TextBox.Selection.Start = new Place(location.Column, location.Line);
            m_TextBox.DoSelectionVisible();
            m_TextBox.Focus();
        }

        private void OpenDocument(string filename)
        {
            if (!File.Exists(filename))
            {
                var message = string.Format("File doesn't exist: {0}", filename);
                MessageBox.Show(this, message, Resources.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                m_Document = Document.CreateFromFile(m_TextBox, filename);
                UpdateDocumentNameDisplay();
                UpdateMenuToolBarStatus();
                AddToRecentFileList(filename);
            }
            catch (Exception ex)
            {
                var message = string.Format("Open file failed: {0}", ex.Message);
                MessageBox.Show(this, message, Resources.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save the current document. If the document is dirty, user will be prompted for saving.
        /// </summary>
        /// <param name="forceNewFile"></param>
        private bool SaveDocument(bool forceNewFile)
        {
            try
            {
                if (m_Document.Filename == null || forceNewFile)
                {
                    var result = m_SaveFileDialog.ShowDialog(this);
                    if (result != DialogResult.OK)
                    {
                        return false;
                    }
                    var filename = m_SaveFileDialog.FileName;
                    m_Document.Save(filename);
                    AddToRecentFileList(filename);
                }
                else
                {
                    m_Document.Save();
                }
                UpdateDocumentNameDisplay();
                UpdateMenuToolBarStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Save file failed: " + ex.Message, Resources.ProductName, MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Close the current document. If the document is dirty, user will be prompted for saving.
        /// </summary>
        /// <returns>Returns <code>true</code> the document is closed. Otherwise, returns <code>false</code>.</returns>
        private bool CloseDocument()
        {
            if (m_Document != null && m_Document.IsDirty)
            {
                var message = string.Format("Save file {0}?", m_Document.DisplayName);
                var result = MessageBox.Show(message, Resources.ProductName, MessageBoxButtons.YesNoCancel,
                                             MessageBoxIcon.Information);
                if (result == DialogResult.Cancel)
                {
                    return false;
                }
                if (result == DialogResult.Yes && !SaveDocument(false))
                {
                    return false;
                }
            }
            return true;
        }

        private void AddToRecentFileList(string filename)
        {
            var recentFiles = Settings.Default.RecentFiles ?? new StringCollection();

            // Check whether the new filename already exists in the list.
            for (var i = 0; i < recentFiles.Count; ++i)
            {
                if (string.Compare(recentFiles[i], filename, StringComparison.OrdinalIgnoreCase) != 0)
                {
                    continue;
                }
                if (i == 0)
                {
                    return;
                }
                recentFiles.RemoveAt(i);
                break;
            }

            recentFiles.Insert(0, filename);

            // Remove overflown files.
            while (recentFiles.Count > MaxRecentFileCount)
            {
                recentFiles.RemoveAt(MaxRecentFileCount);
            }

            Settings.Default.RecentFiles = recentFiles;
            Settings.Default.Save();
            UpdateRecentFilesDisplay();
        }

        private void UpdateRecentFilesDisplay()
        {
            var recentFiles = Settings.Default.RecentFiles ?? new StringCollection();
            var dropDownItems = m_RecentFilesMenuItem.DropDownItems;
            var prependItemCount = dropDownItems.IndexOf(m_EmpyRecentFilesMenuItem) + 1;
            var trailingItemCount = dropDownItems.Count - dropDownItems.IndexOf(m_RecentFilesMenuSeparator);
            for (int i = 0, j = prependItemCount; i < recentFiles.Count; ++i, ++j)
            {
                ToolStripItem item;
                if (j < dropDownItems.Count - trailingItemCount)
                {
                    item = dropDownItems[j];
                }
                else
                {
                    item = new ToolStripMenuItem();
                    item.Click += RecentFileMenuItem_Click;
                    dropDownItems.Insert(j, item);
                }
                item.Text = string.Concat("&", i + 1, " ", recentFiles[i]);
                item.Tag = recentFiles[i];
            }
            while (dropDownItems.Count > recentFiles.Count + trailingItemCount + prependItemCount)
            {
                dropDownItems.RemoveAt(dropDownItems.Count - trailingItemCount - 1);
            }
            m_EmpyRecentFilesMenuItem.Visible = recentFiles.Count == 0;
            m_RecentFilesMenuSeparator.Visible = recentFiles.Count != 0;
            m_ClearRecentFilesMenuItem.Visible = recentFiles.Count != 0;
        }
        #endregion

        #region [Inner Class - IdlAutoCompleteCollection]
        private class IdlAutoCompleteCollection : IEnumerable<AutocompleteItem>
        {
            #region [Private Fields]
            private static readonly AutocompleteItem[] BuiltInKeywords;

            private static readonly char[] Punctuations; 

            private readonly AutocompleteMenu m_AutocompleteMenu;

            private readonly IronyFCTB m_TextBox;
            #endregion

            #region [Constructors]
            static IdlAutoCompleteCollection()
            {
                BuiltInKeywords = new[]
                    {
                        new AutocompleteItem("include"),
                        new AutocompleteItem("namespace"),
                        new AutocompleteItem("enum"),
                        new AutocompleteItem("struct"),
                        new AutocompleteItem("service"),
                        new AutocompleteItem("required"),
                        new AutocompleteItem("optional"),
                        new AutocompleteItem("bool"),
                        new AutocompleteItem("i32"),
                        new AutocompleteItem("i64"),
                        new AutocompleteItem("string"),
                        new AutocompleteItem("binary"),
                        new AutocompleteItem("datetime"),
                        new AutocompleteItem("map"),
                        new AutocompleteItem("list")
                    };
                foreach (var builtInKeyword in BuiltInKeywords)
                {
                    builtInKeyword.ToolTipText = builtInKeyword.Text;
                    builtInKeyword.Text += " ";
                }
                Punctuations = new[] {'=', '{', '}', '(', ')', '<', '>', ',', '[', ']', ':'};
            }

            public IdlAutoCompleteCollection(AutocompleteMenu autocompleteMenu, IronyFCTB textBox)
            {
                m_AutocompleteMenu = autocompleteMenu;
                m_TextBox = textBox;
            }
            #endregion

            #region Implementation of IEnumerable
            /// <summary>
            /// Returns an enumerator that iterates through the collection.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
            /// </returns>
            public IEnumerator<AutocompleteItem> GetEnumerator()
            {
                // Get the text fragment for auto complete intellisense
                var text = m_AutocompleteMenu.Fragment.Text;
                var lastPuntucationIndex = text.LastIndexOfAny(Punctuations);
                if (lastPuntucationIndex != -1)
                {
                    text = text.Substring(lastPuntucationIndex + 1);
                }

                var returnedItems = new HashSet<string>();

                foreach (var builtInKeyword in BuiltInKeywords)
                {
                    if (builtInKeyword.Text.StartsWith(text))
                    {
                        returnedItems.Add(builtInKeyword.Text);
                        yield return builtInKeyword;
                    }
                }

                foreach (var token in m_TextBox.ParseTree.Tokens)
                {
                    if (token.Terminal.Name == "TIdentifier" && token.Text.StartsWith(text) && token.Text != text && !returnedItems.Contains(token.Text))
                    {
                        returnedItems.Add(token.Text);
                        yield return new AutocompleteItem(token.Text + " ") {ToolTipText = token.Text};
                    }
                }
            }

            /// <summary>
            /// Returns an enumerator that iterates through a collection.
            /// </summary>
            /// <returns>
            /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
            /// </returns>
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            #endregion
        }
        #endregion

    }
}