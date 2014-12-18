using System;
using System.IO;
using System.Text;
using CTripOSS.Baiji.Helper;
using FastColoredTextBoxNS;

namespace CTripOSS.Baiji.Editor
{
    public class Document
    {
        #region [Static Fields]
        /// <summary>
        /// Default encoding of Baiji IDL files.
        /// </summary>
        private static readonly Encoding FileEncoding = new UTF8Encoding(false);
        #endregion

        #region [Private Fields]
        private readonly FastColoredTextBox m_TextBox;
        #endregion

        #region [Constructor]
        private Document(FastColoredTextBox textBox)
        {
            Enforce.IsNotNull(textBox, "textBox");
            m_TextBox = textBox;
            m_TextBox.IsChanged = false;
        }
        #endregion

        #region [Public Properties]
        /// <summary>
        /// Gets the display name of the document.
        /// </summary>
        public string DisplayName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the filename associated of the document.
        /// Returns <code>null</code> when the document isn't loaded from file and hasn't been saved yet.
        /// </summary>
        public string Filename
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets or sets the content of the document.
        /// </summary>
        public string Content
        {
            get
            {
                return m_TextBox.Text;
            }
            set
            {
                m_TextBox.Text = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the document has changes which haven't been saved.
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return m_TextBox.IsChanged;
            }
            private set
            {
                m_TextBox.IsChanged = value;
            }
        }
        #endregion

        #region [Static Creation Methods]
        /// <summary>
        /// Creates a new document.
        /// </summary>
        /// <param name="textBox">The text box used to edit the document.</param>
        /// <returns>The created document.</returns>
        public static Document CreateNew(FastColoredTextBox textBox)
        {
            var document = new Document(textBox) {DisplayName = "Untitled", Content = string.Empty};
            textBox.IsChanged = false;
            textBox.ClearUndo();
            return document;
        }

        /// <summary>
        /// Creates a new document and loads its content from the specified file.
        /// </summary>
        /// <param name="textBox">The text box used to edit the document.</param>
        /// <param name="filename">The filename from which the content shall be loaded.</param>
        /// <returns>The created document.</returns>
        public static Document CreateFromFile(FastColoredTextBox textBox, string filename)
        {
            var document = new Document(textBox);
            document.Load(filename);
            textBox.IsChanged = false;
            textBox.ClearUndo();
            return document;
        }
        #endregion

        #region [Public Methods]
        /// <summary>
        /// Loads document content from the specified file.
        /// </summary>
        /// <param name="filename">The filename from which the content shall be loaded.</param>
        public void Load(string filename)
        {
            Enforce.IsNotNull(filename, "filename");
            Content = File.ReadAllText(filename, FileEncoding);
            Filename = filename;
            DisplayName = Path.GetFileName(filename);
            IsDirty = false;
        }

        /// <summary>
        /// Saves the document content to the associated file.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Occurs when no filename is associated with this document.
        /// </exception>
        public void Save()
        {
            var filename = Filename;
            if (string.IsNullOrEmpty(filename))
            {
                throw new InvalidOperationException("No filename is associated with this document.");
            }
            Save(filename);
        }

        /// <summary>
        /// Saves the document content to the specified file. The filename association shall be updated.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        /// Occurs when no filename is associated with this document.
        /// </exception>
        public void Save(string filename)
        {
            File.WriteAllText(filename, Content, FileEncoding);
            Filename = filename;
            DisplayName = Path.GetFileName(filename);
            IsDirty = false;
        }
        #endregion
    }
}