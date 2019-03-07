using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Matthias Otto, NMIT, 2010-2016
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _artistList;

        private void UpdateDisplay()
        {
            string[] lcDisplayList = new string[_artistList.Count];

            lstArtists.DataSource = null;
            _artistList.Keys.CopyTo(lcDisplayList, 0);
            lstArtists.DataSource = lcDisplayList;
            lblValue.Text = Convert.ToString(_artistList.GetTotalValue());
        }

        private void btnAdd_Click(object prSender, EventArgs e)
        {
            bool lcResult = _artistList.NewArtist();
            if(lcResult == true)
            {
                MessageBox.Show("Artist added!");
            }
            else if (lcResult == false)
            {
                MessageBox.Show("Duplicate Key!");
            }
            UpdateDisplay();
        }

        private void lstArtists_DoubleClick(object prSender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                bool lcResult = _artistList.EditArtist(lcKey);

                if (lcResult == false)
                {
                    MessageBox.Show("Sorry no artist by this name");
                }
                UpdateDisplay();
            }
        }

        private void btnQuit_Click(object prSender, EventArgs e)
        {
            Exception lcResult = _artistList.Save();
            if(lcResult != null)
            {
                MessageBox.Show(lcResult.Message, "File Save Error");
            }
            Close();
        }

        private void btnDelete_Click(object prSender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
            {
                lstArtists.ClearSelected();
                _artistList.Remove(lcKey);
                UpdateDisplay();
            }
        }



        private void frmMain_Load(object prSender, EventArgs e)
        {
            Exception lcExceptionResult = null;
            _artistList = clsArtistList.Retrieve(lcExceptionResult);
            if (lcExceptionResult != null)
            {
                MessageBox.Show(lcExceptionResult.Message, "File Retrieve Error");
            }
            UpdateDisplay();
        }
    }
}
