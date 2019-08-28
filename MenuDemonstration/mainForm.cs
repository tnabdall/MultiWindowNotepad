using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuDemonstration
{
    public partial class mainForm : Form
    {
        
        public mainForm()
        {
            InitializeComponent();
        }

        private void createNewForm()
        {
            TextEditorForm newDocument = new TextEditorForm(this);

            newDocument.Show();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewForm();

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            createNewForm();
            if (ActiveMdiChild is TextEditorForm)
            {                
                ((TextEditorForm) ActiveMdiChild).LoadFile();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((TextEditorForm) ActiveMdiChild).SaveFile();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((TextEditorForm) ActiveMdiChild).SaveFile(true);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ((TextEditorForm) ActiveMdiChild).CloseFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = MessageBox.Show("Are you sure you want to exit?","Confirm Exit?", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK)
            {
                foreach (Form child in MdiChildren)
                {
                    if (child is TextEditorForm)
                    {
                        ((TextEditorForm) child).CloseFile(MessageBoxButtons.YesNo);
                    }
                }
                Application.Exit();
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void aboutThisApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You need help.","Critical Warning");
        }
    }
}
