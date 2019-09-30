﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DragKnifeApplication.Model
{

    public class DXFDisplayModel { }


    public class DisplayField : INotifyPropertyChanged
    {
        private double width;
        private double height;
        private double positionTop;
        private double positionLeft;

        
        public double Width
        {
            get
            {
                return width;
            }

            set
            {
                if (width != value)
                {
                    width = value;
                    RaisePropertyChanged("Width");
                }
            }
        }

        public double Height
        {
            get
            {
                return height;
            }

            set
            {
                if (height != value)
                {
                    height = value;
                    RaisePropertyChanged("Height");
                }
            }
        }
        //notifies view of property changes
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        //getter/setter
        public double PositionTop
        {
            get
            {
                return positionTop;
            }
            set
            {
                positionTop = value;
            }
        }
        //getter/setter
        public double PositionLeft
        {
            get
            {
                return positionLeft;
            }
            set
            {
                positionLeft = value;
            }
        }

    }

    //singe dxf line object
    public class DXFLine
    {
        private double startX;
        private double startY;
        private double endX;
        private double endY;

        public double StartX
        {
            get
            {
                return startX;
            }
            set
            {
                startX = value;
            }
        }

        public double StartY
        {
            get
            {
                return startY;
            }
            set
            {
                startY = value;
            }
        }

        public double EndX
        {
            get
            {
                return endX;
            }
            set
            {
                endX = value;
            }
        }

        public double EndY
        {
            get
            {
                return endY;
            }
            set
            {
                endY = value;
            }
        }

    }

}
