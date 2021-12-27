using Cau1.BAL;
using Cau1.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Cau1
{
    public partial class Form1 : Form
    {
        QLBHBAL cusBAL = new QLBHBAL();
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // hiiooooooooooooooo
            // cái này test nha
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<QlbhBEL> lstCus = cusBAL.ReadCustomer();
            foreach (QlbhBEL cus in lstCus)
            {
                dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.PhoneNumber, cus.MS);
            }


        }

        private void dgvCustomer_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvCustomer.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbid.Text = row.Cells[0].Value.ToString();
                tbname.Text = row.Cells[1].Value.ToString();
                tbsdt.Text = row.Cells[2].Value.ToString();
                tbno.Text = row.Cells[3].Value.ToString();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            QlbhBEL cus = new QlbhBEL();
            cus.Id = int.Parse(tbid.Text);
            cus.Name = tbname.Text;
            cus.PhoneNumber = int.Parse(tbsdt.Text);
            cus.MS = decimal.Parse(tbno.Text);
            cusBAL.NewCustomer(cus);

            dgvCustomer.Rows.Add(cus.Id, cus.Name, cus.PhoneNumber, cus.MS);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvCustomer.CurrentRow;
            if (row != null)
            {
                QlbhBEL cus = new QlbhBEL();
                cus.Id = int.Parse(tbid.Text);
                cus.Name = tbname.Text;
                cus.PhoneNumber = int.Parse(tbsdt.Text);
                cus.MS = decimal.Parse(tbno.Text);

                cusBAL.EditCustomer(cus);


                row.Cells[0].Value = cus.Id;
                row.Cells[1].Value = cus.Name;
                row.Cells[2].Value = cus.PhoneNumber;
                row.Cells[3].Value = cus.MS;


            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            QlbhBEL cus = new QlbhBEL();
            cus.Id = int.Parse(tbid.Text);
            cus.Name = tbname.Text;

            cusBAL.DeleteCustomer(cus);
            int idx = dgvCustomer.CurrentCell.RowIndex;
            dgvCustomer.Rows.RemoveAt(idx);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Dispose();
            }
        }
    }
}
