using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MajorTom
    {
        double X;
        double Y;
        double width;
        double height;

        int health;
        double mass;

        public Boolean isGrounded()
        {
            if (Y == 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}
