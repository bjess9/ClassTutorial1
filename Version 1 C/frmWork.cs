using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmWork : Form
    {

        protected clsWork _work;

        public frmWork()
        {
            InitializeComponent();
        }
        protected virtual void updateForm()
        {
            txtName.Text = _work.Name;
            txtCreation.Text = _work.Date.ToShortDateString();
            txtValue.Text = _work.Value.ToString();

        }

        protected virtual void pushData()
        {
            _work.Name = txtName.Text;
            _work.Date = DateTime.Parse(txtCreation.Text);
            _work.Value = decimal.Parse(txtValue.Text);
        }


        public void SetDetails(clsWork prWork)
        {
            _work = prWork;
            updateForm();
            ShowDialog();
        }

        private void btnOK_Click(object prSender, EventArgs e)
        {
            if (isValid() == true)
            {
                pushData();
                Close();
            }
        }
        private void btnCancel_Click(object prSender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        
        public virtual bool isValid()
        {
            return true;
        }
    
    }
}
