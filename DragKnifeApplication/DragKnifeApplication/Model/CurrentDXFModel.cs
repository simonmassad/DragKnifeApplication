using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using System.ComponentModel;

namespace DragKnifeApplication.Model
{
    public class CurrentDXFModel : INotifyPropertyChanged 
    {

         //selected dxf
        private DxfDocument dxf;
        
        //  getter/setter
        public DxfDocument DXF
        {
            get
            {
                return dxf;
            }
            set
            {
                dxf = value;
                RaisePropertyChanged("CurrentDXF");
                RaisePropertyChanged("CurrentFileName");
            }
        }
        //current file name
        public string currentFileName = "Current DXF: ";
        //getter/setter
        public string CurrentFileName
        {
            get
            {
                return "Current DXF: " + dxf.Name + ".dxf";//file name formatting with .dxf extention
            }
            set
            {
                CurrentFileName = value;
                RaisePropertyChanged("CurrentFileName");
            }
        }
        //alerts view that proprties have changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

    }

}
