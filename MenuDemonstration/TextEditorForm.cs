using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDemonstration
{
    public partial class TextEditorForm : Form
    {
        public static int DOCUMENTCOUNT = 0; // document counter

        public string Filepath // store files path
        {
            get
            {
                return filepath;
            }
            set
            {
                filepath = value;
                this.Text = filepath;
            }
        }

        private string filepath = null;

        private bool fileSaved = true; // Checks to see if file was saved since last changes

        private bool closeRequested = false; // Lets us know if closeFile was called before the closing event

        public TextEditorForm()
        {
            InitializeComponent();            
        }

        // Set text to default filename
        public TextEditorForm(Form mdiParent):this()
        {
            this.MdiParent = mdiParent;

            this.Text = $"untitled{++DOCUMENTCOUNT}.txt";            
        }

        // Set filepath to given path
        public TextEditorForm(Form mdiParent, string filepath):this()
        {
            this.MdiParent = mdiParent;
            Filepath = filepath;
            this.Text = filepath;
        }

        // Saves file. If no filepath, or save as requested, opens dialog
        public void SaveFile(bool saveAs = false)
        {
            if (Filepath == null || saveAs == true)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Text File|*.txt",
                    DefaultExt = ".txt",
                    Title = "Save as .."
                };
                if (Filepath != null)
                {
                    saveFileDialog.InitialDirectory = filepath;
                }
                DialogResult result = saveFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Filepath = saveFileDialog.FileName;
                    this.SaveFile(Filepath);
                }
            }
            else
            {
                this.SaveFile(filepath);
            }
        }


        // Opens file dialog to load file
        public void LoadFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text File|*.txt",
                DefaultExt = ".txt",
                Title = "Load file .."
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Filepath = openFileDialog.FileName;
                this.LoadFile(Filepath);
                fileSaved = true;
            }
            else
            {
                this.Close();
            }
        }

        // CLoses file
        public void CloseFile(MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNoCancel)
        {
            closeRequested = true; // Lets file closing method know this method was called
            // If file wasn't saved since last change, give dialog
            if (!fileSaved)
            {
                DialogResult result = MessageBox.Show("File has not been saved. Would you like to save file before closing?",$"Save {this.Text}",messageBoxButtons);
                if (result == DialogResult.Cancel)
                {
                    closeRequested = false; // Close file cancelled so return this to false
                    return;
                }
                else if (result == DialogResult.No)
                {
                    this.Close();
                }
                else
                {
                    SaveFile(true);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        // Actually saves file with filepath. Helper method.
        private void SaveFile(string filepath)
        {
            StreamWriter input = null;
            try
            {
                input = new StreamWriter(filepath);
                input.Write(mainTextBox.Text);
                input.Close();
                this.Text = filepath;
                fileSaved = true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Could not write file " + filepath + ". " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error in writing " + filepath + ". " + ex.Message);
            }
        }

        // Actually loads file. Helper method.
        private void LoadFile(string filepath)
        {
            StreamReader input = null;
            try
            {
                input = new StreamReader(filepath);
                mainTextBox.Text = input.ReadToEnd();
                input.Close();
                this.Text = filepath;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Could not find file " + filepath + ". " + ex.Message);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error in reading " + filepath+". "+ex.Message);
            }    
            
        }

        // Changes text color from context menu.
        private void TextEditColourChanged(object sender, EventArgs e)
        {
            mainTextBox.ForeColor = Color.FromName(((ToolStripMenuItem) sender).Tag.ToString());
        }

        // Lets us know that file has been changed for save logic
        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSaved = false;
        }

        // Form closing logic
        private void TextEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Allows parent dialog box to show before this form closes
            if (e.CloseReason == CloseReason.MdiFormClosing)
            {
                e.Cancel = true;
                return;
            }
            // If close requested by red x close button, show dialog box to confirm for save.
            // If closeFile called, dialog was already shown
            if (closeRequested==false && !fileSaved)
            {
                DialogResult result = MessageBox.Show("File has not been saved. Would you like to save file before closing?", $"Save {this.Text}", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    SaveFile(true);
                }
            }
        }
    }
}
