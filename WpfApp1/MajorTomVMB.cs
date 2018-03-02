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

        public MajorTomVMB(double x, double y)
        {
            X = x;
            Y = y;
            verticalVelocity = _vertical;
            Size = 50;
        }
        double _x;
        double _y;
        double _vertical;

        public double Size { get; set; }

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

        public Boolean isGrounded()
        {
            if (Y == 0)
            {
                return true;
            }
            else
                return false;
        }


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
