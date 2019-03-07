using System;
using System.Collections.Generic;
//using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsWorksList : List<clsWork>
    {

        private byte _sortOrder;

        private static clsNameComparer nameComparer = new clsNameComparer();
        private static clsDateComparer dateComparer = new clsDateComparer();

        public byte SortOrder { get => _sortOrder; set => _sortOrder = value; }

        public bool AddWork(char prWorkType)
        {
            clsWork lcWork = null;
            switch (char.ToUpper(prWorkType))
            {
                case 'P': lcWork = new clsPainting();
                    break;
                case 'S': lcWork = new clsSculpture();
                    break;
                case 'H': lcWork = new clsPhotograph();
                    break;
                default: return false;
            }
            
            if (lcWork != null)
            {
                Add(lcWork);
                return true;
            }
            else
            {
                return false;
            }
        }
       
        public void DeleteWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                this.RemoveAt(prIndex);
            }
        }
        
        public bool EditWork(int prIndex)
        {
            if (prIndex >= 0 && prIndex < this.Count)
            {
                clsWork lcWork = (clsWork)this[prIndex];
                lcWork.EditDetails();
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetTotalValue()
        {
            decimal lcTotal = 0;
            foreach (clsWork lcWork in this)
            {
                lcTotal += lcWork.Value;
            }
            return lcTotal;
        }

         public void SortByName()
         {
             Sort(nameComparer);
         }
    
        public void SortByDate()
        {
            Sort(dateComparer);
        }
    }
}
