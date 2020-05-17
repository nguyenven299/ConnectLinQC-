using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void usersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
           this.tableAdapterManager.UpdateAll(this.databaseTestDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'databaseTestDataSet.users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.databaseTestDataSet.users);
            XuLyButton(true);
        }

        private void usersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.databaseTestDataSet);
            XuLyButton(true);
        }
        public void XuLyButton(bool b)
        {
            this.btnAdd.Enabled = btnDel.Enabled = btnEdit.Enabled = btnExit.Enabled = b;
            btnSave.Enabled = btnCancle.Enabled= groupBox1.Enabled = !b;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.usersBindingSource.CancelEdit();
            XuLyButton(true);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn xóa hay không?","Thông báo",MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.usersBindingSource.RemoveCurrent();
                this.tableAdapterManager.UpdateAll(this.databaseTestDataSet);
            }    
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            XuLyButton(false);
            idUserTextBox.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            XuLyButton(false);
            idUserTextBox.Focus();
            this.usersBindingSource.AddNew();
            this.tableAdapterManager.UpdateAll(this.databaseTestDataSet);
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Bạn có chắc muốn thoát?","Thông Báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question))
            {
                Application.Exit();
            }    
        }
    }
}
