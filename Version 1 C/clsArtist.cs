using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string _name;
        private string _speciality;
        private string _phone;
        
        private decimal _totalValue;

        private clsWorksList _worksList;
        private clsArtistList _artistList;
        
        private static frmArtist artistDialog = new frmArtist();

        public string Name { get => _name; set => _name = value; }
        public string Speciality { get => _speciality; set => _speciality = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public decimal TotalValue { get => _totalValue; set => _totalValue = value; }
        public clsWorksList WorksList { get => _worksList; set => _worksList = value; }

        public clsArtist(clsArtistList prArtistList)
        {
            WorksList = new clsWorksList();
            _artistList = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(this);

            TotalValue = WorksList.GetTotalValue();
            
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _artistList.ContainsKey(prArtistName);
        }
    }
}
