namespace CTripOSS.Baiji.Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.m_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.m_FileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_FileMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_RecentFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_EmpyRecentFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RecentFilesMenuSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.m_ClearRecentFilesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_FileMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_UndoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RedoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_EditMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_CutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_EditMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_SelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_EditMenuSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_FindMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_FindNextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ReplaceMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GotoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_NavigateBackwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_NaviageForwardMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GenerateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GenerateCSharpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GenerateJavaMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GenerateOCMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_CodeGenOptionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_HelpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_AboutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.m_NewToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_OpenToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_SaveToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_CutToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_CopyToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_PasteToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_UndoToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_RedoToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_NavigateBackwardToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_NavigateForwardToolButton = new System.Windows.Forms.ToolStripButton();
            this.m_ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.m_GenerateToolButton = new System.Windows.Forms.ToolStripSplitButton();
            this.m_GenerateCSharpToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_GenerateJavaToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MainContainer = new System.Windows.Forms.SplitContainer();
            this.m_TextBox = new FastColoredTextBoxNS.IronyFCTB();
            this.m_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_UndoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_RedoContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ContextMenuSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_CutContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_CopyContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_PasteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_DeleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_ContextMenuSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.m_SelectAllContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_BottomTabControl = new System.Windows.Forms.TabControl();
            this.m_ErrorListTabPage = new System.Windows.Forms.TabPage();
            this.m_ErrorListView = new System.Windows.Forms.ListView();
            this.m_DescriptionColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_LineColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_ColumnColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.m_StatusStrip = new System.Windows.Forms.StatusStrip();
            this.m_ColumnStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_LineStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.m_FolderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.m_OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.m_SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.m_GenerateOCToolMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_MenuStrip.SuspendLayout();
            this.m_ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_MainContainer)).BeginInit();
            this.m_MainContainer.Panel1.SuspendLayout();
            this.m_MainContainer.Panel2.SuspendLayout();
            this.m_MainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_TextBox)).BeginInit();
            this.m_ContextMenu.SuspendLayout();
            this.m_BottomTabControl.SuspendLayout();
            this.m_ErrorListTabPage.SuspendLayout();
            this.m_StatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_MenuStrip
            // 
            this.m_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_FileMenuItem,
            this.m_EditMenuItem,
            this.m_ViewMenuItem,
            this.m_GenerateMenuItem,
            this.m_HelpMenuItem});
            this.m_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.m_MenuStrip.Name = "m_MenuStrip";
            this.m_MenuStrip.Size = new System.Drawing.Size(805, 25);
            this.m_MenuStrip.TabIndex = 0;
            // 
            // m_FileMenuItem
            // 
            this.m_FileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_NewMenuItem,
            this.m_OpenMenuItem,
            this.m_SaveMenuItem,
            this.m_SaveAsMenuItem,
            this.m_FileMenuSeparator1,
            this.m_RecentFilesMenuItem,
            this.m_FileMenuSeparator2,
            this.m_ExitMenuItem});
            this.m_FileMenuItem.Name = "m_FileMenuItem";
            this.m_FileMenuItem.Size = new System.Drawing.Size(39, 21);
            this.m_FileMenuItem.Text = "&File";
            // 
            // m_NewMenuItem
            // 
            this.m_NewMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_New;
            this.m_NewMenuItem.Name = "m_NewMenuItem";
            this.m_NewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.m_NewMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_NewMenuItem.Text = "&New";
            this.m_NewMenuItem.Click += new System.EventHandler(this.New_Click);
            // 
            // m_OpenMenuItem
            // 
            this.m_OpenMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Open;
            this.m_OpenMenuItem.Name = "m_OpenMenuItem";
            this.m_OpenMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.m_OpenMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_OpenMenuItem.Text = "&Open...";
            this.m_OpenMenuItem.Click += new System.EventHandler(this.Open_Click);
            // 
            // m_SaveMenuItem
            // 
            this.m_SaveMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Save;
            this.m_SaveMenuItem.Name = "m_SaveMenuItem";
            this.m_SaveMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.m_SaveMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_SaveMenuItem.Text = "&Save";
            this.m_SaveMenuItem.Click += new System.EventHandler(this.Save_Click);
            // 
            // m_SaveAsMenuItem
            // 
            this.m_SaveAsMenuItem.Name = "m_SaveAsMenuItem";
            this.m_SaveAsMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_SaveAsMenuItem.Text = "Save &As...";
            this.m_SaveAsMenuItem.Click += new System.EventHandler(this.SaveAs_Click);
            // 
            // m_FileMenuSeparator1
            // 
            this.m_FileMenuSeparator1.Name = "m_FileMenuSeparator1";
            this.m_FileMenuSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // m_RecentFilesMenuItem
            // 
            this.m_RecentFilesMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_EmpyRecentFilesMenuItem,
            this.m_RecentFilesMenuSeparator,
            this.m_ClearRecentFilesMenuItem});
            this.m_RecentFilesMenuItem.Name = "m_RecentFilesMenuItem";
            this.m_RecentFilesMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_RecentFilesMenuItem.Text = "&Recent Files";
            // 
            // m_EmpyRecentFilesMenuItem
            // 
            this.m_EmpyRecentFilesMenuItem.Enabled = false;
            this.m_EmpyRecentFilesMenuItem.Name = "m_EmpyRecentFilesMenuItem";
            this.m_EmpyRecentFilesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_EmpyRecentFilesMenuItem.Text = "Empty";
            // 
            // m_RecentFilesMenuSeparator
            // 
            this.m_RecentFilesMenuSeparator.Name = "m_RecentFilesMenuSeparator";
            this.m_RecentFilesMenuSeparator.Size = new System.Drawing.Size(149, 6);
            // 
            // m_ClearRecentFilesMenuItem
            // 
            this.m_ClearRecentFilesMenuItem.Name = "m_ClearRecentFilesMenuItem";
            this.m_ClearRecentFilesMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_ClearRecentFilesMenuItem.Text = "&Clear File List";
            this.m_ClearRecentFilesMenuItem.Click += new System.EventHandler(this.ClearRecentFiles_Click);
            // 
            // m_FileMenuSeparator2
            // 
            this.m_FileMenuSeparator2.Name = "m_FileMenuSeparator2";
            this.m_FileMenuSeparator2.Size = new System.Drawing.Size(161, 6);
            // 
            // m_ExitMenuItem
            // 
            this.m_ExitMenuItem.Name = "m_ExitMenuItem";
            this.m_ExitMenuItem.Size = new System.Drawing.Size(164, 22);
            this.m_ExitMenuItem.Text = "E&xit";
            this.m_ExitMenuItem.Click += new System.EventHandler(this.Exit_Click);
            // 
            // m_EditMenuItem
            // 
            this.m_EditMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_UndoMenuItem,
            this.m_RedoMenuItem,
            this.m_EditMenuSeparator1,
            this.m_CutMenuItem,
            this.m_CopyMenuItem,
            this.m_PasteMenuItem,
            this.m_DeleteMenuItem,
            this.m_EditMenuSeparator2,
            this.m_SelectAllMenuItem,
            this.m_EditMenuSeparator3,
            this.m_FindMenuItem,
            this.m_FindNextMenuItem,
            this.m_ReplaceMenuItem});
            this.m_EditMenuItem.Name = "m_EditMenuItem";
            this.m_EditMenuItem.Size = new System.Drawing.Size(42, 21);
            this.m_EditMenuItem.Text = "&Edit";
            // 
            // m_UndoMenuItem
            // 
            this.m_UndoMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Undo;
            this.m_UndoMenuItem.Name = "m_UndoMenuItem";
            this.m_UndoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.m_UndoMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_UndoMenuItem.Text = "&Undo";
            this.m_UndoMenuItem.Click += new System.EventHandler(this.Undo_Click);
            // 
            // m_RedoMenuItem
            // 
            this.m_RedoMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Redo;
            this.m_RedoMenuItem.Name = "m_RedoMenuItem";
            this.m_RedoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.m_RedoMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_RedoMenuItem.Text = "&Redo";
            this.m_RedoMenuItem.Click += new System.EventHandler(this.Redo_Click);
            // 
            // m_EditMenuSeparator1
            // 
            this.m_EditMenuSeparator1.Name = "m_EditMenuSeparator1";
            this.m_EditMenuSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // m_CutMenuItem
            // 
            this.m_CutMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Cut;
            this.m_CutMenuItem.Name = "m_CutMenuItem";
            this.m_CutMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_CutMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_CutMenuItem.Text = "Cu&t";
            this.m_CutMenuItem.Click += new System.EventHandler(this.Cut_Click);
            // 
            // m_CopyMenuItem
            // 
            this.m_CopyMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Copy;
            this.m_CopyMenuItem.Name = "m_CopyMenuItem";
            this.m_CopyMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.m_CopyMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_CopyMenuItem.Text = "&Copy";
            this.m_CopyMenuItem.Click += new System.EventHandler(this.Copy_Click);
            // 
            // m_PasteMenuItem
            // 
            this.m_PasteMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Paste;
            this.m_PasteMenuItem.Name = "m_PasteMenuItem";
            this.m_PasteMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.m_PasteMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_PasteMenuItem.Text = "&Paste";
            this.m_PasteMenuItem.Click += new System.EventHandler(this.Paste_Click);
            // 
            // m_DeleteMenuItem
            // 
            this.m_DeleteMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Delete;
            this.m_DeleteMenuItem.Name = "m_DeleteMenuItem";
            this.m_DeleteMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.m_DeleteMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_DeleteMenuItem.Text = "&Delete";
            this.m_DeleteMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // m_EditMenuSeparator2
            // 
            this.m_EditMenuSeparator2.Name = "m_EditMenuSeparator2";
            this.m_EditMenuSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // m_SelectAllMenuItem
            // 
            this.m_SelectAllMenuItem.Name = "m_SelectAllMenuItem";
            this.m_SelectAllMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.m_SelectAllMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_SelectAllMenuItem.Text = "Select &All";
            this.m_SelectAllMenuItem.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // m_EditMenuSeparator3
            // 
            this.m_EditMenuSeparator3.Name = "m_EditMenuSeparator3";
            this.m_EditMenuSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // m_FindMenuItem
            // 
            this.m_FindMenuItem.Name = "m_FindMenuItem";
            this.m_FindMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.m_FindMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_FindMenuItem.Text = "&Find";
            this.m_FindMenuItem.Click += new System.EventHandler(this.Find_Click);
            // 
            // m_FindNextMenuItem
            // 
            this.m_FindNextMenuItem.Name = "m_FindNextMenuItem";
            this.m_FindNextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.m_FindNextMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_FindNextMenuItem.Text = "Find &Next";
            this.m_FindNextMenuItem.Click += new System.EventHandler(this.FindNext_Click);
            // 
            // m_ReplaceMenuItem
            // 
            this.m_ReplaceMenuItem.Name = "m_ReplaceMenuItem";
            this.m_ReplaceMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.m_ReplaceMenuItem.Size = new System.Drawing.Size(173, 22);
            this.m_ReplaceMenuItem.Text = "&Replace";
            this.m_ReplaceMenuItem.Click += new System.EventHandler(this.Replace_Click);
            // 
            // m_ViewMenuItem
            // 
            this.m_ViewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_GotoMenuItem,
            this.m_NavigateBackwardMenuItem,
            this.m_NaviageForwardMenuItem});
            this.m_ViewMenuItem.Name = "m_ViewMenuItem";
            this.m_ViewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.m_ViewMenuItem.Size = new System.Drawing.Size(47, 21);
            this.m_ViewMenuItem.Text = "&View";
            // 
            // m_GotoMenuItem
            // 
            this.m_GotoMenuItem.Name = "m_GotoMenuItem";
            this.m_GotoMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.m_GotoMenuItem.Size = new System.Drawing.Size(256, 22);
            this.m_GotoMenuItem.Text = "&Go To...";
            this.m_GotoMenuItem.Click += new System.EventHandler(this.Goto_Click);
            // 
            // m_NavigateBackwardMenuItem
            // 
            this.m_NavigateBackwardMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_NavigateBackward;
            this.m_NavigateBackwardMenuItem.Name = "m_NavigateBackwardMenuItem";
            this.m_NavigateBackwardMenuItem.ShortcutKeyDisplayString = "Ctrl+-";
            this.m_NavigateBackwardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.OemMinus)));
            this.m_NavigateBackwardMenuItem.Size = new System.Drawing.Size(256, 22);
            this.m_NavigateBackwardMenuItem.Text = "Navigate &Backward";
            this.m_NavigateBackwardMenuItem.Click += new System.EventHandler(this.NavigateBackward_Click);
            // 
            // m_NaviageForwardMenuItem
            // 
            this.m_NaviageForwardMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_NavigateForward;
            this.m_NaviageForwardMenuItem.Name = "m_NaviageForwardMenuItem";
            this.m_NaviageForwardMenuItem.ShortcutKeyDisplayString = "Ctrl+Shift+-";
            this.m_NaviageForwardMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.OemMinus)));
            this.m_NaviageForwardMenuItem.Size = new System.Drawing.Size(256, 22);
            this.m_NaviageForwardMenuItem.Text = "Navigate &Forward";
            this.m_NaviageForwardMenuItem.Click += new System.EventHandler(this.NavigateForward_Click);
            // 
            // m_GenerateMenuItem
            // 
            this.m_GenerateMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_GenerateCSharpMenuItem,
            this.m_GenerateJavaMenuItem,
            this.m_GenerateOCMenuItem,
            this.m_CodeGenOptionsMenuItem});
            this.m_GenerateMenuItem.Name = "m_GenerateMenuItem";
            this.m_GenerateMenuItem.Size = new System.Drawing.Size(73, 21);
            this.m_GenerateMenuItem.Text = "&Generate";
            // 
            // m_GenerateCSharpMenuItem
            // 
            this.m_GenerateCSharpMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_CSharp;
            this.m_GenerateCSharpMenuItem.Name = "m_GenerateCSharpMenuItem";
            this.m_GenerateCSharpMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateCSharpMenuItem.Text = "Generate &C# Code...";
            this.m_GenerateCSharpMenuItem.Click += new System.EventHandler(this.GenerateCSharp_Click);
            // 
            // m_GenerateJavaMenuItem
            // 
            this.m_GenerateJavaMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Java;
            this.m_GenerateJavaMenuItem.Name = "m_GenerateJavaMenuItem";
            this.m_GenerateJavaMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateJavaMenuItem.Text = "Generate &Java Code...";
            this.m_GenerateJavaMenuItem.Click += new System.EventHandler(this.GenerateJava_Click);
            // 
            // m_GenerateOCMenuItem
            // 
            this.m_GenerateOCMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_OC;
            this.m_GenerateOCMenuItem.Name = "m_GenerateOCMenuItem";
            this.m_GenerateOCMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateOCMenuItem.Text = "Generate Objective-C Code...";
            this.m_GenerateOCMenuItem.Click += new System.EventHandler(this.GenerateOC_Click);
            // 
            // m_CodeGenOptionsMenuItem
            // 
            this.m_CodeGenOptionsMenuItem.Name = "m_CodeGenOptionsMenuItem";
            this.m_CodeGenOptionsMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_CodeGenOptionsMenuItem.Text = "&Options...";
            this.m_CodeGenOptionsMenuItem.Click += new System.EventHandler(this.m_CodeGenOptionsMenuItem_Click);
            // 
            // m_HelpMenuItem
            // 
            this.m_HelpMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_AboutMenuItem});
            this.m_HelpMenuItem.Name = "m_HelpMenuItem";
            this.m_HelpMenuItem.Size = new System.Drawing.Size(47, 21);
            this.m_HelpMenuItem.Text = "&Help";
            // 
            // m_AboutMenuItem
            // 
            this.m_AboutMenuItem.Name = "m_AboutMenuItem";
            this.m_AboutMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_AboutMenuItem.Text = "&About";
            this.m_AboutMenuItem.Click += new System.EventHandler(this.About_Click);
            // 
            // m_ToolStrip
            // 
            this.m_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_NewToolButton,
            this.m_OpenToolButton,
            this.m_SaveToolButton,
            this.m_ToolStripSeparator1,
            this.m_CutToolButton,
            this.m_CopyToolButton,
            this.m_PasteToolButton,
            this.m_ToolStripSeparator2,
            this.m_UndoToolButton,
            this.m_RedoToolButton,
            this.m_NavigateBackwardToolButton,
            this.m_NavigateForwardToolButton,
            this.m_ToolStripSeparator3,
            this.m_GenerateToolButton});
            this.m_ToolStrip.Location = new System.Drawing.Point(0, 25);
            this.m_ToolStrip.Name = "m_ToolStrip";
            this.m_ToolStrip.Size = new System.Drawing.Size(805, 25);
            this.m_ToolStrip.TabIndex = 3;
            this.m_ToolStrip.Text = "toolStrip1";
            // 
            // m_NewToolButton
            // 
            this.m_NewToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_NewToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_New;
            this.m_NewToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_NewToolButton.Name = "m_NewToolButton";
            this.m_NewToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_NewToolButton.ToolTipText = "New (Ctrl + N)";
            this.m_NewToolButton.Click += new System.EventHandler(this.New_Click);
            // 
            // m_OpenToolButton
            // 
            this.m_OpenToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_OpenToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Open;
            this.m_OpenToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_OpenToolButton.Name = "m_OpenToolButton";
            this.m_OpenToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_OpenToolButton.Text = "toolStripButton2";
            this.m_OpenToolButton.ToolTipText = "Open (Ctrl + O)";
            this.m_OpenToolButton.Click += new System.EventHandler(this.Open_Click);
            // 
            // m_SaveToolButton
            // 
            this.m_SaveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_SaveToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Save;
            this.m_SaveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_SaveToolButton.Name = "m_SaveToolButton";
            this.m_SaveToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_SaveToolButton.Text = "Save (Ctrl + S)";
            this.m_SaveToolButton.Click += new System.EventHandler(this.Save_Click);
            // 
            // m_ToolStripSeparator1
            // 
            this.m_ToolStripSeparator1.Name = "m_ToolStripSeparator1";
            this.m_ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // m_CutToolButton
            // 
            this.m_CutToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_CutToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Cut;
            this.m_CutToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_CutToolButton.Name = "m_CutToolButton";
            this.m_CutToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_CutToolButton.Text = "Cut (Ctrl + X)";
            this.m_CutToolButton.Click += new System.EventHandler(this.Cut_Click);
            // 
            // m_CopyToolButton
            // 
            this.m_CopyToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_CopyToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Copy;
            this.m_CopyToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_CopyToolButton.Name = "m_CopyToolButton";
            this.m_CopyToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_CopyToolButton.Text = "Copy (Ctrl + C)";
            this.m_CopyToolButton.Click += new System.EventHandler(this.Copy_Click);
            // 
            // m_PasteToolButton
            // 
            this.m_PasteToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_PasteToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Paste;
            this.m_PasteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_PasteToolButton.Name = "m_PasteToolButton";
            this.m_PasteToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_PasteToolButton.Text = "Paste (Ctrl + V)";
            this.m_PasteToolButton.Click += new System.EventHandler(this.Paste_Click);
            // 
            // m_ToolStripSeparator2
            // 
            this.m_ToolStripSeparator2.Name = "m_ToolStripSeparator2";
            this.m_ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // m_UndoToolButton
            // 
            this.m_UndoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_UndoToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Undo;
            this.m_UndoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_UndoToolButton.Name = "m_UndoToolButton";
            this.m_UndoToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_UndoToolButton.Text = "Undo (Ctrl + Z)";
            this.m_UndoToolButton.Click += new System.EventHandler(this.Undo_Click);
            // 
            // m_RedoToolButton
            // 
            this.m_RedoToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_RedoToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Redo;
            this.m_RedoToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_RedoToolButton.Name = "m_RedoToolButton";
            this.m_RedoToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_RedoToolButton.Text = "Redo (Ctrl + Y)";
            this.m_RedoToolButton.Click += new System.EventHandler(this.Redo_Click);
            // 
            // m_NavigateBackwardToolButton
            // 
            this.m_NavigateBackwardToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_NavigateBackwardToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_NavigateBackward;
            this.m_NavigateBackwardToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_NavigateBackwardToolButton.Name = "m_NavigateBackwardToolButton";
            this.m_NavigateBackwardToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_NavigateBackwardToolButton.Text = "Navigate Backward (Ctrl + -)";
            this.m_NavigateBackwardToolButton.Click += new System.EventHandler(this.NavigateBackward_Click);
            // 
            // m_NavigateForwardToolButton
            // 
            this.m_NavigateForwardToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_NavigateForwardToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_NavigateForward;
            this.m_NavigateForwardToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_NavigateForwardToolButton.Name = "m_NavigateForwardToolButton";
            this.m_NavigateForwardToolButton.Size = new System.Drawing.Size(23, 22);
            this.m_NavigateForwardToolButton.Text = "Navigate Forward (Ctrl+ Shift + -)";
            this.m_NavigateForwardToolButton.Click += new System.EventHandler(this.NavigateForward_Click);
            // 
            // m_ToolStripSeparator3
            // 
            this.m_ToolStripSeparator3.Name = "m_ToolStripSeparator3";
            this.m_ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // m_GenerateToolButton
            // 
            this.m_GenerateToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.m_GenerateToolButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_GenerateCSharpToolMenuItem,
            this.m_GenerateJavaToolMenuItem,
            this.m_GenerateOCToolMenuItem});
            this.m_GenerateToolButton.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Generate;
            this.m_GenerateToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.m_GenerateToolButton.Name = "m_GenerateToolButton";
            this.m_GenerateToolButton.Size = new System.Drawing.Size(32, 22);
            this.m_GenerateToolButton.Text = "Generate";
            this.m_GenerateToolButton.ButtonClick += new System.EventHandler(this.m_GenerateToolButton_ButtonClick);
            // 
            // m_GenerateCSharpToolMenuItem
            // 
            this.m_GenerateCSharpToolMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_CSharp;
            this.m_GenerateCSharpToolMenuItem.Name = "m_GenerateCSharpToolMenuItem";
            this.m_GenerateCSharpToolMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateCSharpToolMenuItem.Text = "Generate C# Code...";
            this.m_GenerateCSharpToolMenuItem.Click += new System.EventHandler(this.GenerateCSharp_Click);
            // 
            // m_GenerateJavaToolMenuItem
            // 
            this.m_GenerateJavaToolMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Java;
            this.m_GenerateJavaToolMenuItem.Name = "m_GenerateJavaToolMenuItem";
            this.m_GenerateJavaToolMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateJavaToolMenuItem.Text = "Generate Java Code...";
            this.m_GenerateJavaToolMenuItem.Click += new System.EventHandler(this.GenerateJava_Click);
            // 
            // m_MainContainer
            // 
            this.m_MainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(89)))), ((int)(((byte)(124)))));
            this.m_MainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_MainContainer.Location = new System.Drawing.Point(0, 50);
            this.m_MainContainer.Name = "m_MainContainer";
            this.m_MainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_MainContainer.Panel1
            // 
            this.m_MainContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.m_MainContainer.Panel1.Controls.Add(this.m_TextBox);
            this.m_MainContainer.Panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            // 
            // m_MainContainer.Panel2
            // 
            this.m_MainContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.m_MainContainer.Panel2.Controls.Add(this.m_BottomTabControl);
            this.m_MainContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.m_MainContainer.Size = new System.Drawing.Size(805, 531);
            this.m_MainContainer.SplitterDistance = 354;
            this.m_MainContainer.TabIndex = 4;
            // 
            // m_TextBox
            // 
            this.m_TextBox.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.m_TextBox.BackBrush = null;
            this.m_TextBox.BackColor = System.Drawing.SystemColors.Window;
            this.m_TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_TextBox.CharHeight = 14;
            this.m_TextBox.CharWidth = 8;
            this.m_TextBox.ContextMenuStrip = this.m_ContextMenu;
            this.m_TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.m_TextBox.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.m_TextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_TextBox.Hotkeys = resources.GetString("m_TextBox.Hotkeys");
            this.m_TextBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_TextBox.IsReplaceMode = false;
            this.m_TextBox.Location = new System.Drawing.Point(0, 0);
            this.m_TextBox.Name = "m_TextBox";
            this.m_TextBox.Paddings = new System.Windows.Forms.Padding(0);
            this.m_TextBox.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_TextBox.Size = new System.Drawing.Size(805, 349);
            this.m_TextBox.TabIndex = 1;
            this.m_TextBox.Zoom = 100;
            this.m_TextBox.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.m_TextBox_TextChangedDelayed);
            this.m_TextBox.SelectionChangedDelayed += new System.EventHandler(this.m_TextBox_SelectionChangedDelayed);
            this.m_TextBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_TextBox_DragDrop);
            this.m_TextBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_TextBox_DragEnter);
            // 
            // m_ContextMenu
            // 
            this.m_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_UndoContextMenuItem,
            this.m_RedoContextMenuItem,
            this.m_ContextMenuSeparator1,
            this.m_CutContextMenuItem,
            this.m_CopyContextMenuItem,
            this.m_PasteContextMenuItem,
            this.m_DeleteContextMenuItem,
            this.m_ContextMenuSeparator2,
            this.m_SelectAllContextMenuItem});
            this.m_ContextMenu.Name = "m_ContextMenu";
            this.m_ContextMenu.Size = new System.Drawing.Size(153, 170);
            // 
            // m_UndoContextMenuItem
            // 
            this.m_UndoContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Undo;
            this.m_UndoContextMenuItem.Name = "m_UndoContextMenuItem";
            this.m_UndoContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.m_UndoContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_UndoContextMenuItem.Text = "&Undo";
            this.m_UndoContextMenuItem.Click += new System.EventHandler(this.Undo_Click);
            // 
            // m_RedoContextMenuItem
            // 
            this.m_RedoContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Redo;
            this.m_RedoContextMenuItem.Name = "m_RedoContextMenuItem";
            this.m_RedoContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.m_RedoContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_RedoContextMenuItem.Text = "&Redo";
            this.m_RedoContextMenuItem.Click += new System.EventHandler(this.Redo_Click);
            // 
            // m_ContextMenuSeparator1
            // 
            this.m_ContextMenuSeparator1.Name = "m_ContextMenuSeparator1";
            this.m_ContextMenuSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // m_CutContextMenuItem
            // 
            this.m_CutContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Cut;
            this.m_CutContextMenuItem.Name = "m_CutContextMenuItem";
            this.m_CutContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.m_CutContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_CutContextMenuItem.Text = "&Cut";
            this.m_CutContextMenuItem.Click += new System.EventHandler(this.Cut_Click);
            // 
            // m_CopyContextMenuItem
            // 
            this.m_CopyContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Copy;
            this.m_CopyContextMenuItem.Name = "m_CopyContextMenuItem";
            this.m_CopyContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.m_CopyContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_CopyContextMenuItem.Text = "C&opy";
            this.m_CopyContextMenuItem.Click += new System.EventHandler(this.Copy_Click);
            // 
            // m_PasteContextMenuItem
            // 
            this.m_PasteContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Paste;
            this.m_PasteContextMenuItem.Name = "m_PasteContextMenuItem";
            this.m_PasteContextMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.m_PasteContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_PasteContextMenuItem.Text = "&Paste";
            this.m_PasteContextMenuItem.Click += new System.EventHandler(this.Paste_Click);
            // 
            // m_DeleteContextMenuItem
            // 
            this.m_DeleteContextMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_Delete;
            this.m_DeleteContextMenuItem.Name = "m_DeleteContextMenuItem";
            this.m_DeleteContextMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.m_DeleteContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_DeleteContextMenuItem.Text = "&Delete";
            this.m_DeleteContextMenuItem.Click += new System.EventHandler(this.Delete_Click);
            // 
            // m_ContextMenuSeparator2
            // 
            this.m_ContextMenuSeparator2.Name = "m_ContextMenuSeparator2";
            this.m_ContextMenuSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // m_SelectAllContextMenuItem
            // 
            this.m_SelectAllContextMenuItem.Name = "m_SelectAllContextMenuItem";
            this.m_SelectAllContextMenuItem.Size = new System.Drawing.Size(152, 22);
            this.m_SelectAllContextMenuItem.Text = "Select &All";
            this.m_SelectAllContextMenuItem.Click += new System.EventHandler(this.SelectAll_Click);
            // 
            // m_BottomTabControl
            // 
            this.m_BottomTabControl.Controls.Add(this.m_ErrorListTabPage);
            this.m_BottomTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_BottomTabControl.Location = new System.Drawing.Point(0, 5);
            this.m_BottomTabControl.Name = "m_BottomTabControl";
            this.m_BottomTabControl.SelectedIndex = 0;
            this.m_BottomTabControl.Size = new System.Drawing.Size(805, 168);
            this.m_BottomTabControl.TabIndex = 0;
            // 
            // m_ErrorListTabPage
            // 
            this.m_ErrorListTabPage.Controls.Add(this.m_ErrorListView);
            this.m_ErrorListTabPage.Location = new System.Drawing.Point(4, 22);
            this.m_ErrorListTabPage.Name = "m_ErrorListTabPage";
            this.m_ErrorListTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.m_ErrorListTabPage.Size = new System.Drawing.Size(797, 142);
            this.m_ErrorListTabPage.TabIndex = 0;
            this.m_ErrorListTabPage.Text = "Error List";
            this.m_ErrorListTabPage.UseVisualStyleBackColor = true;
            // 
            // m_ErrorListView
            // 
            this.m_ErrorListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_DescriptionColumn,
            this.m_LineColumn,
            this.m_ColumnColumn});
            this.m_ErrorListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ErrorListView.FullRowSelect = true;
            this.m_ErrorListView.GridLines = true;
            this.m_ErrorListView.Location = new System.Drawing.Point(3, 3);
            this.m_ErrorListView.Name = "m_ErrorListView";
            this.m_ErrorListView.Size = new System.Drawing.Size(791, 136);
            this.m_ErrorListView.TabIndex = 0;
            this.m_ErrorListView.UseCompatibleStateImageBehavior = false;
            this.m_ErrorListView.View = System.Windows.Forms.View.Details;
            this.m_ErrorListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_ErrorListView_KeyDown);
            this.m_ErrorListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_ErrorListView_MouseDoubleClick);
            // 
            // m_DescriptionColumn
            // 
            this.m_DescriptionColumn.Text = "Description";
            this.m_DescriptionColumn.Width = 650;
            // 
            // m_LineColumn
            // 
            this.m_LineColumn.Text = "Line";
            // 
            // m_ColumnColumn
            // 
            this.m_ColumnColumn.Text = "Column";
            // 
            // m_StatusStrip
            // 
            this.m_StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_ColumnStatusLabel,
            this.m_LineStatusLabel});
            this.m_StatusStrip.Location = new System.Drawing.Point(0, 581);
            this.m_StatusStrip.Name = "m_StatusStrip";
            this.m_StatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.m_StatusStrip.Size = new System.Drawing.Size(805, 22);
            this.m_StatusStrip.TabIndex = 5;
            this.m_StatusStrip.Text = "statusStrip1";
            // 
            // m_ColumnStatusLabel
            // 
            this.m_ColumnStatusLabel.AutoSize = false;
            this.m_ColumnStatusLabel.Name = "m_ColumnStatusLabel";
            this.m_ColumnStatusLabel.Size = new System.Drawing.Size(80, 17);
            this.m_ColumnStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_LineStatusLabel
            // 
            this.m_LineStatusLabel.AutoSize = false;
            this.m_LineStatusLabel.Name = "m_LineStatusLabel";
            this.m_LineStatusLabel.Size = new System.Drawing.Size(80, 17);
            this.m_LineStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_FolderBrowserDialog
            // 
            this.m_FolderBrowserDialog.SelectedPath = "Please select the output folder of code generation:";
            // 
            // m_OpenFileDialog
            // 
            this.m_OpenFileDialog.Filter = "Baiji IDL files (*.bjsc)|*.bjsc|All files (*.*)|*.*";
            // 
            // m_SaveFileDialog
            // 
            this.m_SaveFileDialog.Filter = "Baiji IDL files (*.bjsc)|*.bjsc|All files (*.*)|*.*";
            // 
            // m_GenerateOCToolMenuItem
            // 
            this.m_GenerateOCToolMenuItem.Image = global::CTripOSS.Baiji.Editor.Properties.Resources.Icon_16x16_OC;
            this.m_GenerateOCToolMenuItem.Name = "m_GenerateOCToolMenuItem";
            this.m_GenerateOCToolMenuItem.Size = new System.Drawing.Size(244, 22);
            this.m_GenerateOCToolMenuItem.Text = "Generate Objective-C Code...";
            this.m_GenerateOCToolMenuItem.Click += new System.EventHandler(this.GenerateOC_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 603);
            this.Controls.Add(this.m_MainContainer);
            this.Controls.Add(this.m_StatusStrip);
            this.Controls.Add(this.m_ToolStrip);
            this.Controls.Add(this.m_MenuStrip);
            this.MainMenuStrip = this.m_MenuStrip;
            this.Name = "MainForm";
            this.Text = "Baiji IDL Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.m_MenuStrip.ResumeLayout(false);
            this.m_MenuStrip.PerformLayout();
            this.m_ToolStrip.ResumeLayout(false);
            this.m_ToolStrip.PerformLayout();
            this.m_MainContainer.Panel1.ResumeLayout(false);
            this.m_MainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_MainContainer)).EndInit();
            this.m_MainContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_TextBox)).EndInit();
            this.m_ContextMenu.ResumeLayout(false);
            this.m_BottomTabControl.ResumeLayout(false);
            this.m_ErrorListTabPage.ResumeLayout(false);
            this.m_StatusStrip.ResumeLayout(false);
            this.m_StatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip m_MenuStrip;
        private FastColoredTextBoxNS.IronyFCTB m_TextBox;
        private System.Windows.Forms.ToolStripMenuItem m_FileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_SaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_FileMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_UndoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_RedoMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_EditMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_CutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_CopyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_PasteMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_DeleteMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_EditMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_SelectAllMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_EditMenuSeparator3;
        private System.Windows.Forms.ToolStripMenuItem m_FindMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_FindNextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_ReplaceMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_HelpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_AboutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateCSharpMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateJavaMenuItem;
        private System.Windows.Forms.ToolStrip m_ToolStrip;
        private System.Windows.Forms.ToolStripButton m_NewToolButton;
        private System.Windows.Forms.ToolStripButton m_OpenToolButton;
        private System.Windows.Forms.ToolStripButton m_SaveToolButton;
        private System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton m_CutToolButton;
        private System.Windows.Forms.ToolStripButton m_CopyToolButton;
        private System.Windows.Forms.ToolStripButton m_PasteToolButton;
        private System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton m_UndoToolButton;
        private System.Windows.Forms.ToolStripButton m_RedoToolButton;
        private System.Windows.Forms.ToolStripButton m_NavigateBackwardToolButton;
        private System.Windows.Forms.ToolStripButton m_NavigateForwardToolButton;
        private System.Windows.Forms.ToolStripSeparator m_ToolStripSeparator3;
        private System.Windows.Forms.SplitContainer m_MainContainer;
        private System.Windows.Forms.TabControl m_BottomTabControl;
        private System.Windows.Forms.TabPage m_ErrorListTabPage;
        private System.Windows.Forms.ListView m_ErrorListView;
        private System.Windows.Forms.ColumnHeader m_DescriptionColumn;
        private System.Windows.Forms.ColumnHeader m_LineColumn;
        private System.Windows.Forms.ColumnHeader m_ColumnColumn;
        private System.Windows.Forms.ToolStripMenuItem m_ViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GotoMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_NavigateBackwardMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_NaviageForwardMenuItem;
        private System.Windows.Forms.StatusStrip m_StatusStrip;
        private System.Windows.Forms.FolderBrowserDialog m_FolderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog m_OpenFileDialog;
        private System.Windows.Forms.SaveFileDialog m_SaveFileDialog;
        private System.Windows.Forms.ToolStripSplitButton m_GenerateToolButton;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateCSharpToolMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateJavaToolMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel m_ColumnStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel m_LineStatusLabel;
        private System.Windows.Forms.ContextMenuStrip m_ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem m_UndoContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_RedoContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_ContextMenuSeparator1;
        private System.Windows.Forms.ToolStripMenuItem m_CutContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_CopyContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_PasteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_DeleteContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_ContextMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_SelectAllContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_RecentFilesMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_EmpyRecentFilesMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_RecentFilesMenuSeparator;
        private System.Windows.Forms.ToolStripMenuItem m_ClearRecentFilesMenuItem;
        private System.Windows.Forms.ToolStripSeparator m_FileMenuSeparator2;
        private System.Windows.Forms.ToolStripMenuItem m_CodeGenOptionsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateOCMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_GenerateOCToolMenuItem;
    }
}

