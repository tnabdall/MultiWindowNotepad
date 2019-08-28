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
        public static int DOCUMENTCOUNT = 0;

        public string Filepath
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
        private bool fileSaved = true;

        public TextEditorForm()
        {
            InitializeComponent();            
        }

        public TextEditorForm(Form mdiParent):this()
        {
            this.MdiParent = mdiParent;

            this.Text = $"untitled{++DOCUMENTCOUNT}.txt";            
        }

        public TextEditorForm(Form mdiParent, string filepath):this()
        {
            this.MdiParent = mdiParent;
            Filepath = filepath;
            this.Text = filepath;
        }

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

        public void CloseFile(MessageBoxButtons messageBoxButtons = MessageBoxButtons.YesNoCancel)
        {
            if (!fileSaved)
            {
                DialogResult result = MessageBox.Show("File has not been saved. Would you like to save file before closing?",$"Save {this.Text}",messageBoxButtons);
                if (result == DialogResult.Cancel)
                {
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

        private void TextEditColourChanged(object sender, EventArgs e)
        {
            mainTextBox.ForeColor = Color.FromName(((ToolStripMenuItem) sender).Tag.ToString());
        }

        private void mainTextBox_TextChanged(object sender, EventArgs e)
        {
            fileSaved = false;
        }
    }
}
