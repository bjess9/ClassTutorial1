using System;
//using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsPainting : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        [NonSerialized()]
        private static frmPainting _paintDialog;

        public float Width { get => _width; set => _width = value; }
        public float Height { get => _height; set => _height = value; }
        public string Type { get => _type; set => _type = value; }

        public override void EditDetails()
        {
            if (_paintDialog == null)
            {
                _paintDialog = new frmPainting();
                _paintDialog.SetDetails(this);
            }
        }
    }
}
