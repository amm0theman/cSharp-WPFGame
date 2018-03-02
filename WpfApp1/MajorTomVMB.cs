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
            verticalVelocity = _vertical = 0;
            horizontalVelocity = _horizontal = 0;
            Size = 50;
        }

        //**********************************************************************************************\\
        //                                          MEMBERS                                             \\
        //______________________________________________________________________________________________\\

        double _x;
        double _y;
        double _vertical;
        double _horizontal;
        double maxVelocityRight = 1;
        double maxVelocityLeft = -1;

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
        bool isRunning = false;
        public bool IsRunning { get => isRunning; set => isRunning = value; }

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

        public double horizontalVelocity
        {
            get => _horizontal;
            set
            {
                if (_horizontal == value) return;
                _horizontal = value;
                FirePropertyChanged();
            }
        }

        //**********************************************************************************************\\
        //                                      FUNCTIONS                                               \\
        //______________________________________________________________________________________________\\

        //Movement Related functions
        public void MoveRight()
        {
            if(horizontalVelocity <= maxVelocityRight)
            {
                if (Grounded())
                    horizontalVelocity += .1;
                else
                    horizontalVelocity += .01;
            }
        }

        public void MoveLeft()
        {
            if (horizontalVelocity >= maxVelocityLeft)
            {
                if (Grounded())
                    horizontalVelocity -= .1;
                else
                    horizontalVelocity -= .01;
            }
        }

        public void Jump()
        {
            if (Y <= 402 && Y >= 398)
            {
                Y -= 40;
                verticalVelocity = -1;
            }
        }

        //Status related functions
        public bool Grounded()
        {
            if (Y == 400)
            {
                return true;
            }
            else
                return false;
        }

        //_______________________________________________________
        //                      UPDATE                          -
        //‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾
        //Collision functions
        public bool willCollideVertical()
        {
            if (Y + verticalVelocity <= 400)
            {
                return false;
            }
            else
                return true;
        }

        public bool willCollideHorizontal()
        {
            return false;
        }
    }
}
