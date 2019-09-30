using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.IO.Ports;



namespace DragKnifeApplication
{
    public partial class MainWindow : Window
    {

        private DragKnifeApplication.ViewModel.MainWindowViewModel mainWindowViewModelObject = new ViewModel.MainWindowViewModel();

        public MainWindow()
        {
            this.DataContext = mainWindowViewModelObject;
            InitializeComponent();
        }

        //Loads the field that displays the opened DXF drawing
        private void DisplayViewControl_Loaded(object sender, RoutedEventArgs e)
        {
            DragKnifeApplication.ViewModel.DXFDisplayViewModel dxfDisplayViewModelObject = new DragKnifeApplication.ViewModel.DXFDisplayViewModel();
            dxfDisplayViewModelObject.DisplayField();
            DXFDisplayViewControl.DataContext = dxfDisplayViewModelObject;
        }

        //opens a dialog window so the user can select their DXF drawing
        public void OpenDXF_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDXFDialog = new OpenFileDialog();

            openDXFDialog.InitialDirectory = "c:\\";
            openDXFDialog.Filter = "DXF files (*.dxf)|*.dxf";
            openDXFDialog.FilterIndex = 1;
            openDXFDialog.RestoreDirectory = true;

            if (openDXFDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                DragKnifeApplication.ViewModel.DXFDisplayViewModel dxfDisplayViewModelObject = new DragKnifeApplication.ViewModel.DXFDisplayViewModel();
                dxfDisplayViewModelObject.DisplayField();
                dxfDisplayViewModelObject.LoadDXFLines(openDXFDialog.FileName);

                DXFDisplayViewControl.DataContext = dxfDisplayViewModelObject;

                mainWindowViewModelObject.UpdateDxf(openDXFDialog.FileName);
                mainWindowViewModelObject.FileName = null;
            }


        }

        //sends the GCode to the printer if a DXF file has been loaded
        public void SendGCode_Click(object sender, RoutedEventArgs e)
        {
            if (mainWindowViewModelObject.ActiveDxf != null)
            {
                mainWindowViewModelObject.SendGcode();
            }
        }
    }
}