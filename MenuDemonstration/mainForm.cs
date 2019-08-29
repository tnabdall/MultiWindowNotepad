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

        // Creates a new text document, shows it as active
        private void createNewForm()
        {
            TextEditorForm newDocument = new TextEditorForm(this);
            newDocument.Show();
            LayoutMdi(MdiLayout.TileVertical);
            
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
            if (ActiveMdiChild is TextEditorForm)
            {
                ((TextEditorForm) ActiveMdiChild).SaveFile();
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextEditorForm)
            {
                ((TextEditorForm) ActiveMdiChild).SaveFile(true); // true flag for save as
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextEditorForm)
            {
                ((TextEditorForm) ActiveMdiChild).CloseFile();
            }
        }

        // Starts form closing event
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainForm_Closing(this, new FormClosingEventArgs(CloseReason.MdiFormClosing, false));
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void aboutThisApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You need help.","Critical Warning");
        }

        private void mainForm_Closing(object sender, FormClosingEventArgs e)
        {
            // If no child forms open, skip this logic and close
            if (MdiChildren.Count() == 0)
            {
                return;
            }

            // Checks if user really wants to close
            DialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit?", MessageBoxButtons.OKCancel);
            if (DialogResult == DialogResult.OK)
            {
                // Request close for each child form
                foreach (Form child in MdiChildren)
                {
                    if (child is TextEditorForm)
                    {
                        ((TextEditorForm) child).CloseFile(MessageBoxButtons.YesNo);
                    }
                }
                // If no more children are open and child forms were closed, do not cancel close request for parent
                if (MdiChildren.Count() == 0)
                {
                    e.Cancel = false;
                }                   

            }
            else // Cancels closing
            {
                e.Cancel = true;
                
            }
                        
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
    }
}
