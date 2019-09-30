using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using netDxf;
using System.IO.Ports;

namespace DragKnifeApplication.Model
{
    public class SendGcodeModel
    {
        private DxfDocument dxf;
        private int baudRate;
        private string comPort;
        //sets dxf to print as well as baud rate and com port
        public SendGcodeModel(DxfDocument d, int b, string c)
        {
            dxf = d;
            baudRate = b;
            comPort = c;
        }
        //sends the gcode to the printer
        public void SendGcode()
        {
            SerialPort port = new SerialPort(
                  comPort, baudRate, Parity.None, 8, StopBits.One);

            try
            {
                port.Open();//opens serial port


                port.WriteLine("G1 Z+0");//sets printer Z axis height to zero

                while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                {
                    Console.WriteLine(port.ReadLine());
                }

                foreach (netDxf.Entities.Line line in dxf.Lines)
                {
                    port.WriteLine("G1 Z+5");//lifts printer z axis
                    while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                    {
                        Console.WriteLine("waiting");
                    }
                    port.WriteLine("G1 X+" + (line.StartPoint.X + xShift) + "Y+" + (line.StartPoint.Y + yShift));//moves printer to start of line
                    while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                    {
                        Console.WriteLine("waiting");
                    }
                    port.WriteLine("G1 Z+0");//drops printer x axis to zero
                    while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                    {
                        Console.WriteLine("waiting");
                    }
                    port.WriteLine("G1 X+" + (line.EndPoint.X + xShift) + "Y+" + (line.EndPoint.Y + yShift));// moves printer to end of line (since z axis is at zero this makes a cut
                    while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                    {
                        Console.WriteLine("waiting");
                    }
                }

                port.WriteLine("G1 Z+5");//lifts printer
                while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                {
                    Console.WriteLine("waiting");
                }
                port.WriteLine("G1X+0Y+0");//returns printer XY axis to zero position
                while (port.ReadLine() != "ok")//waits for "ok" signel sent when the printer receives a line of gcode 
                {
                    Console.WriteLine("waiting");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());//exception handler if there is a problem communicating with the printer
            }

            port.Close();
        }

        //aligns the origin of the dxf drawing to zero
        private double xShift = 0;
        private double yShift = 0;

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
    }
}
