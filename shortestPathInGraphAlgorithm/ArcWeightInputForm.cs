using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shortestPathInGraphAlgorithm
{
    public partial class ArcWeightInputForm : Form
    {
        public ArcWeightInputForm()
        {
            InitializeComponent();
        }
        public int Weight { get; set; }
        private void buttonDone_Click(object sender, EventArgs e)
        {
            if (textBoxWeight.Text != string.Empty)
            {
                try
                {
                    if (int.Parse(textBoxWeight.Text) < 0)
                    {
                        MessageBox.Show("You must enter positive number!");                        
                    }
                    else
                    {
                        Weight = int.Parse(textBoxWeight.Text);
                        this.DialogResult = DialogResult.OK;
                    }

                }
                catch
                {
                    MessageBox.Show("You must enter an integer!");
                }
            }
            else
                MessageBox.Show("Enter value!");
        }
    }
}
