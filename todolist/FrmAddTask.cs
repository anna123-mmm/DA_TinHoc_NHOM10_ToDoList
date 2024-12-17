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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace todolist
{
    public partial class FrmAddTask : Form
    {
        private Form1 form1;
        public FrmAddTask(Form1 f)
        {
            InitializeComponent();
            form1 = f;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool status = false;
            string task = txtTask.Text;
            DateTime startdate = dtStartDate.Value;
            int remind = Convert.ToInt32(txtRemind.Text);
            string tag = cbTag.Text;
            string note = txtNote.Text;

            form1.addTaskToDGV(status, task, startdate, remind, tag, note);
            this.Close();
        }

        private void btnAddTag_Click(object sender, EventArgs e)
        {
            cbTag.Items.Add(cbTag.Text);
            cbTag.Text = "";
        }

        private void btnDeleteTag_Click(object sender, EventArgs e)
        {
            cbTag.Items.Remove(cbTag.SelectedItem);
        }

        private void FrmAddTask_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("cbTag.txt"))
            {
                foreach (var item in cbTag.Items)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }

        private void loadCBData()
        {
            if (File.Exists("cbTag.txt"))
            {
                using (StreamReader reader = new StreamReader("cbTag.txt"))
                {
                    cbTag.Items.Clear();
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        cbTag.Items.Add(line);
                    }
                }
            }
        }

        private void FrmAddTask_Load(object sender, EventArgs e)
        {
            loadCBData();
        }
    }
}
