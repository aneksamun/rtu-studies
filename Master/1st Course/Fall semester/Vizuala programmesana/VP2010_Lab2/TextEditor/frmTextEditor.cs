using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace TextEditor {
    public partial class frmTextEditor : Form {

        /// <summary>
        /// Pazīme, ka teksts nav saglabāts.
        /// </summary>
        private bool bNewFile = true;

        /// <summary>
        /// Pazīme, ka teksts ir izmainīts.
        /// </summary>
        private bool bDirty = false;

        /// <summary>
        /// Teksta redaktorā ielādētā faila vārds.
        /// </summary>
        private string sFileName;

        // īslaicīga teksta glabāšana drukāšanas procesa atbalstam
        private string sTextToPrint;

        private const string csFileDialogFilter = 
            "Teksta faili|*.txt|Visi faili|*.*";

        public frmTextEditor() {
            InitializeComponent();
            NewFile();
        }

        public bool Dirty {
            get { return bDirty; }
            set {
                bDirty = value;
                stlStatus.Text = !bDirty ? "" : "Izmainīts.";
            }
        }

        public string OpenedFileName {
            get { return sFileName.Length == 0 ? "jauns.txt" : sFileName; }
            set {
                sFileName = ((string)value).Length > 0 ? 
                    sFileName = value : "jauns.txt";
            }
        }

        private void SetTitle(string sDocName) {
            object[] attributes =
                Assembly.GetExecutingAssembly().GetCustomAttributes(
                typeof(AssemblyProductAttribute), false);

            this.Text = String.Format("{0} - {1}",
                ((AssemblyProductAttribute)attributes[0]).Product, sDocName);
        }

        private void NewFile() {
            
            if (!SaveFile(true))
                return;

            txtContent.Clear();
            Dirty = false;
            bNewFile = true;
            sFileName = "";
            SetTitle(OpenedFileName);
        }

        public bool SaveFileAs() {

            //ja teksts vispār nav ievadīts
            if (bNewFile && txtContent.TextLength == 0)
                return true;

            dlgSaveFile.Title = "Saglabāt kā";
            dlgSaveFile.Filter = csFileDialogFilter;
            dlgSaveFile.InitialDirectory = Path.GetDirectoryName(OpenedFileName);
            dlgSaveFile.FileName = Path.GetFileName(OpenedFileName);

            if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                return false;

            OpenedFileName = dlgSaveFile.FileName;

            File.WriteAllText(OpenedFileName, txtContent.Text);
            bNewFile = false;
            Dirty = false;
            SetTitle(OpenedFileName);

            return true;
        }

        public bool SaveFile(bool bConfirm) {

            //ja teksts nav mainīts, vai arī vispār nav ievadīts
            if (!Dirty || (bNewFile && txtContent.TextLength == 0))
                return true;

            if (bConfirm) {
                DialogResult result = MessageBox.Show("Vai saglabāt izmaiņas?", "",
                    MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.No) {
                    return true;
                } else if (result == DialogResult.Cancel) {
                    return false;
                }
            }

            if (bNewFile) {
                dlgSaveFile.Title = "Saglabāt";
                dlgSaveFile.Filter = csFileDialogFilter;
                dlgSaveFile.FileName = Path.GetFileName(OpenedFileName);

                if (dlgSaveFile.ShowDialog() != DialogResult.OK)
                    return false;

                OpenedFileName = dlgSaveFile.FileName;
                bNewFile = false;
            }

            File.WriteAllText(OpenedFileName, txtContent.Text);
            Dirty = false;
            SetTitle(OpenedFileName);

            return true;
        }

        private void LoadFile() {

            if (!SaveFile(true))
                return;

            dlgOpenFile.FileName = "";
            dlgOpenFile.Title = "Atvērt";
            dlgOpenFile.Filter = csFileDialogFilter;

            if (dlgOpenFile.ShowDialog() == DialogResult.OK)
                if (File.Exists(dlgOpenFile.FileName)) {
                    txtContent.Text = File.ReadAllText(dlgOpenFile.FileName);
                    bNewFile = false;
                    Dirty = false;
                    OpenedFileName = dlgOpenFile.FileName;
                    SetTitle(OpenedFileName);
                }
        }

        private void txtContent_TextChanged(object sender, EventArgs e) {
            Dirty = true;
        }

        private void mnuNew_Click(object sender, EventArgs e) {
            try {
                NewFile();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuOpen_Click(object sender, EventArgs e) {
            try {
                LoadFile();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSave_Click(object sender, EventArgs e) {
            try {
                SaveFile(false);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSaveAs_Click(object sender, EventArgs e) {
            try {
                SaveFileAs();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuClose_Click(object sender, EventArgs e) {
            Close();
        }

        private void mnuPrint_Click(object sender, EventArgs e) {
            sTextToPrint = txtContent.Text;

            //printera izvēles dialoga atvēršana
            dlgPrintDocument.DocumentName = this.Text;
            dlgPrint.Document = dlgPrintDocument;
            DialogResult result = dlgPrint.ShowDialog();
            if (result != DialogResult.OK)
                return;

            //dokumenta priekšapskates dialoga atvēršana
            dlgPrintPreview.Document = dlgPrintDocument;
            dlgPrintPreview.ShowDialog();
        }

        private void mnuExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void mnuCopy_Click(object sender, EventArgs e) {
            if (txtContent.SelectionLength > 0)
                txtContent.Copy();
        }

        private void mnuCut_Click(object sender, EventArgs e) {
            if (txtContent.SelectionLength > 0)
                txtContent.Cut();
        }

        private void mnuPaste_Click(object sender, EventArgs e) {
            if (!Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                return;

            txtContent.Paste();
        }

        private void mnuFont_Click(object sender, EventArgs e) {
            dlgFont.Font = txtContent.Font;

            if (dlgFont.ShowDialog() == DialogResult.OK)
                txtContent.Font = dlgFont.Font;
        }

        private void mnuAbout_Click(object sender, EventArgs e) {
            (new frmAboutTextEditor()).ShowDialog();
        }

        private void dlgPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e) {
            int nSymbols = 0;
            int nLines = 0;

            e.Graphics.MeasureString(sTextToPrint, txtContent.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out nSymbols, out nLines);

            e.Graphics.DrawString(sTextToPrint, txtContent.Font, Brushes.Black,
                e.MarginBounds, StringFormat.GenericTypographic);

            sTextToPrint = sTextToPrint.Substring(nSymbols);

            e.HasMorePages = (sTextToPrint.Length > 0);

            if (!e.HasMorePages)
                sTextToPrint = txtContent.Text;
        }

        private void frmTextEditor_FormClosing(object sender, FormClosingEventArgs e) {
            if (!SaveFile(true))
                e.Cancel = true;
        }

        private void mnuPrintPriew_Click(object sender, EventArgs e) {
            sTextToPrint = txtContent.Text;
            dlgPrintDocument.DocumentName = this.Text;
            dlgPrintPreview.Document = dlgPrintDocument;
            dlgPrintPreview.ShowDialog();
        }

        private void mnuUndo_Click(object sender, EventArgs e) {
            if (txtContent.CanUndo) {
                txtContent.Undo();
                txtContent.ClearUndo();
            }
        }
    }
}
