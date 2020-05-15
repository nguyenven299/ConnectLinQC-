using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectLinQ
{
    public partial class frmchinh : Form
    {
      
        List<DemoLinQ> demoLinQs;
        public frmchinh()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // db = new DataClasses1DataContext();
            /* var var = (from DemoLinQ in db.DemoLinQs
                        where DemoLinQ.id == 1
                         select  DemoLinQ).FirstOrDefault();*/
            using (DataLinqDataContext db = new DataLinqDataContext())
            {
                dataGridView1.DataSource = db.DemoLinQs.Select(p => p).ToList();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataLinqDataContext db = new DataLinqDataContext();
            DemoLinQ demoLinQ = new DemoLinQ();
            demoLinQ.id =Int32.Parse( txtId.Text);
            demoLinQ.name = txtName.Text;
            demoLinQ.sdt = txtPhone.Text;
            db.DemoLinQs.InsertOnSubmit(demoLinQ);
            db.SubmitChanges();
            dataGridView1.DataSource = db.DemoLinQs.Select(p => p).ToList();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            txtId.Text = dataGridView1.Rows[index].Cells[0].Value.ToString();
        }
    }
}
