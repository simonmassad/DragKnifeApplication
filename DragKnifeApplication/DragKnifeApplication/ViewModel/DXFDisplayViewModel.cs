using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using DragKnifeApplication.Model;
using System.Collections.ObjectModel;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using netDxf;


namespace DragKnifeApplication.ViewModel
{
    public class DXFDisplayViewModel
    {
        private double dxfWindowHeight = 1000;
        private double dxfWindowWidth = 1000;
        private double xShift = 0;
        private double yShift = 0;
        private double xScaleFactor = 1;
        private double yScaleFactor = 1;
        private double maxX;
        private double maxY;

        //getter
        public double MaxX
        {
            get
            {
                return (maxX + xShift) * xScaleFactor;
            }
        }

        //getter
        public double MaxY
        {
            get
            {
                return dxfWindowHeight - ((maxY + yShift) * yScaleFactor);
            }
        }

        //getter
        public double MinX
        {
            get
            {
                return 0;
            }
        }

        //getter
        public double MinY
        {
            get
            {
                return dxfWindowHeight;
            }
        }


        //getter/setter
        public DisplayField DisplayDXFWindow
        {
            get;
            set;
        }


        //default contructor
        public void DisplayField()
        {
            DisplayField displayField = new DisplayField();
            displayField.Height = dxfWindowHeight;
            displayField.Width = dxfWindowWidth;
            displayField.PositionLeft = 200;
            displayField.PositionTop = 10;
            DisplayDXFWindow = displayField;
        }

        //getter/setter
        public ObservableCollection<DXFLine> DXFLines
        {
            get;
            set;
        }

        //loads dxf lines and draws them in the display area
        public void LoadDXFLines(string dxfFileName)
        {
            ObservableCollection<DXFLine> dxfLines = new ObservableCollection<DXFLine>();

            DxfDocument dxf = DxfDocument.Load(dxfFileName);

            FindXYshift(dxf);
            FindLineScaleFactor(dxf);

            foreach (netDxf.Entities.Line line in dxf.Lines)
            {
                dxfLines.Add(new DXFLine { StartX = (line.StartPoint.X + xShift) * xScaleFactor, StartY = DisplayDXFWindow.Height - ((line.StartPoint.Y + yShift) * yScaleFactor), EndX = (line.EndPoint.X + xShift) * xScaleFactor, EndY = DisplayDXFWindow.Height - ((line.EndPoint.Y + yShift) * yScaleFactor) });
            }


            DXFLines = dxfLines;
        }

        //aligns the origin of the dxf drawing to zero
        private void FindXYshift(DxfDocument dxf)
        {
            double minX = 0;
            if (dxf.Lines.Count > 0)
            {
                minX = dxf.Lines[0].StartPoint.X;
            }

            foreach (netDxf.Entities.Line line in dxf.Lines)
            {
                if (line.StartPoint.X < minX)
                {
                    minX = line.StartPoint.X;
                }
                if (line.EndPoint.X < minX)
                {
                    minX = line.EndPoint.X;
                }
            }

            xShift = 0 - minX;

            double minY = 0;
            if (dxf.Lines.Count > 0)
            {
                minY = dxf.Lines[0].StartPoint.Y;
            }

            foreach (netDxf.Entities.Line line in dxf.Lines)
            {
                if (line.StartPoint.Y < minY)
                {
                    minY = line.StartPoint.Y;
                }
                if (line.EndPoint.Y < minY)
                {
                    minY = line.EndPoint.Y;
                }
            }

            yShift = 0 - minY;

        }

        //scales dxf drawing to fill the display window area
        private void FindLineScaleFactor(DxfDocument dxf)
        {
            
            if (dxf.Lines.Count > 0)
            {
                maxX = dxf.Lines[0].StartPoint.X;
            }

            foreach (netDxf.Entities.Line line in dxf.Lines)
            {
                if (line.StartPoint.X > maxX)
                {
                    maxX = line.StartPoint.X;
                }
                if (line.EndPoint.X > maxX)
                {
                    maxX = line.EndPoint.X;
                }
            }

            xScaleFactor = dxfWindowWidth / (maxX + xShift);

            
            if (dxf.Lines.Count > 0)
            {
                maxY = dxf.Lines[0].StartPoint.Y;
            }

            foreach (netDxf.Entities.Line line in dxf.Lines)
            {
                if (line.StartPoint.Y > maxY)
                {
                    maxY = line.StartPoint.Y;
                }
                if (line.EndPoint.Y > maxY)
                {
                    maxY = line.EndPoint.Y;
                }
            }

            yScaleFactor = dxfWindowHeight / (maxY + yShift);

            if (yScaleFactor < xScaleFactor)
            {
                xScaleFactor = yScaleFactor;
            }
            else
            {
                yScaleFactor = xScaleFactor;
            }



        }

    } 
}
