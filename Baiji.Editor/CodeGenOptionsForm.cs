using System;
using System.Windows.Forms;
using CTripOSS.Baiji.Editor.Properties;

namespace CTripOSS.Baiji.Editor
{
    public partial class CodeGenOptionsForm : Form
    {
        public CodeGenOptionsForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        private void m_SaveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void LoadSettings()
        {
            m_CSharpGenCommentsCheckBox.Checked = Settings.Default.GenComment_CSharp;
            m_JavaGenCommentsCheckBox.Checked = Settings.Default.GenComment_Java;
            m_JavaGenPublicFieldsCheckBox.Checked = Settings.Default.GenPublicFields_Java;
            m_CSharpGenIncludesCheckBox.Checked = Settings.Default.GenIncludes_CSharp;
            m_JavaGenIncludesCheckBox.Checked = Settings.Default.GenIncludes_Java;
            m_OCGenCommentsCheckBox.Checked = Settings.Default.GenComment_OC;
            m_OCGenIncludesCheckBox.Checked = Settings.Default.GenIncludes_OC;
            m_OCAutoReleaseCheckBox.Checked = Settings.Default.GenAutoRelease_OC;
        }

        private void SaveSettings()
        {
            Settings.Default.GenComment_CSharp = m_CSharpGenCommentsCheckBox.Checked;
            Settings.Default.GenComment_Java = m_JavaGenCommentsCheckBox.Checked;
            Settings.Default.GenPublicFields_Java = m_JavaGenPublicFieldsCheckBox.Checked;
            Settings.Default.GenIncludes_CSharp = m_CSharpGenIncludesCheckBox.Checked;
            Settings.Default.GenIncludes_Java = m_JavaGenIncludesCheckBox.Checked;
            Settings.Default.GenComment_OC = m_OCGenCommentsCheckBox.Checked;
            Settings.Default.GenIncludes_OC = m_OCGenIncludesCheckBox.Checked;
            Settings.Default.GenAutoRelease_OC = m_OCAutoReleaseCheckBox.Checked;
            Settings.Default.Save();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}