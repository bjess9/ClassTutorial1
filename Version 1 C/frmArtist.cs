using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        private clsArtist _artist; 
        //private clsArtistList _artistList;
        private clsWorksList _worksList;
        //private byte _sortOrder; // 0 = Name, 1 = Date

        private void updateForm()
        {
            txtName.Text = _artist.Name;
            txtPhone.Text = _artist.Phone;
            txtSpeciality.Text = _artist.Speciality;

        }

        private void pushData()
        {
            _artist.Name = txtName.Text;
            _artist.Phone = txtPhone.Text;
            _artist.Speciality = txtSpeciality.Text;
        }

        private void updateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_worksList.SortOrder == 0)
            {
                _worksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _worksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _worksList;
            lblTotal.Text = Convert.ToString(_worksList.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _artist = prArtist;
            if(_worksList == null)
            {
                _worksList = new clsWorksList();
            }
            updateForm();
            updateDisplay();
            ShowDialog();
        }

        private void btnDelete_Click(object prSender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _worksList.DeleteWork(lstWorks.SelectedIndex);
            }
            
            updateDisplay();
        }

        private void btnAdd_Click(object prSender, EventArgs e)
        {
            if(_worksList == null)
            {
                _worksList = new clsWorksList();
            }

            char lcReply;
            InputBox lcInputBox = new InputBox("Enter P for Painting, S for Sculpture and H for Photograph");
            //inputBox.ShowDialog();
            //if (inputBox.getAction() == true)
            if (lcInputBox.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                lcReply = Convert.ToChar(lcInputBox.getAnswer());
                bool lcResult = _worksList.AddWork(lcReply);
                if(lcResult == false)
                {
                    MessageBox.Show("Incorrect Work Type, Please enter P for Painting, S for Sculpture and H for Photograph");
                }
            }
            else
            {
                lcInputBox.Close();
            }
            updateDisplay();
        }

        private void btnClose_Click(object prSender, EventArgs e)
        {
            pushData();
            if (isValid())
            {
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object prSender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                bool lcResult = _worksList.EditWork(lcIndex);
                if (lcResult == false)
                {
                    MessageBox.Show("Sorry no work selected #" + Convert.ToString(lcIndex));
                }
                updateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object prSender, EventArgs e)
        {
            _worksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }

    }
}
