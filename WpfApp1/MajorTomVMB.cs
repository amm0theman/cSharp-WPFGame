using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace WpfApp1
{
    public class MajorTomVMB : ViewModelBase
    { 
        //Initialization of major tom boiii
        public MajorTomVMB(double x, double y)
        {
            X = x;
            Y = y;
            verticalVelocity = _vertical;
            Size = 50;
        }

        //**********************************************************************************************\\
        //                                    STATUS/PROPERTIES                                         \\
        //______________________________________________________________________________________________\\

        double _x;
        double _y;
        double _vertical;

        public double Size { get; set; }

        //**********************************************************************************************\\
        //                                    STATUS/PROPERTIES                                         \\
        //______________________________________________________________________________________________\\


        //POSITION PROPERTIES
        public double X
        {
            get => _x;
            set
            {
                if (_x == value) return;
                _x = value;
                FirePropertyChanged();
            }
        }

        public double Y
        {
            get => _y;
            set
            {
                if (_y == value) return;
                _y = value;
                FirePropertyChanged();
            }
        }

        //PHYSICAL STATUSES
        public double verticalVelocity
        {
            get => _vertical;
            set
            {
                if (_vertical == value) return;
                _vertical = value;
                FirePropertyChanged();
            }
        }

        //**********************************************************************************************\\
        //                                      FUNCTIONS                                               \\
        //______________________________________________________________________________________________\\

        //Movement Related functions
        public void MoveRight()
        {
            X += .3;   
        }

        public void MoveLeft()
        {
            X -= .3;
        }

        public void Jump()
        {
            Y -= 40;
            verticalVelocity = -1;
        }
    }
}
