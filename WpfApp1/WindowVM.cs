using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApp1
{
    public class WindowVM : ViewModelBase
    {

        Dictionary<Key, bool> keyDown= new Dictionary<Key, bool>();

        public WindowVM()
        {
            //setup sound here

            //Initialize spaceman and enemy locations here
            MajorToms = new ObservableCollection<MajorTomVMB>();
            //For random placement of major tom
            var rand = new Random();
            MajorToms.Add(new MajorTomVMB(200, 200));

            //moveLeft = new testCommand(O => MajorToms[0].MoveLeft());
            //jump = new testCommand(O => MajorToms[0].Jump());

            //Dictionary Player Movements Initialization
            foreach (var key in Enum.GetValues(typeof(Key)))
            {
                keyDown[(Key)key] = false;
            }

            //start thread
            var thread = new Thread(UpdateThread)
            {
                IsBackground = true
            };

            thread.Start();

            
        }

        public void KeyDown(Key k)
        {
            keyDown[k] = true;
        }

        public void KeyUp(Key k)
        {
            keyDown[k] = false;
        }

        private void UpdateThread()
        {
            while (true)
            {
                for (int i = 0; i < MajorToms.Count; i++)
                {
                    //For Major Tom movement
                    var Tom = MajorToms[i];

                    //USER MOVEMENT
                    if (keyDown[Key.K])
                    {
                        MajorToms[0].MoveLeft();
                    }
                    

                    //If tom is not grounded and won't collide with ground this tick
                    if (Tom.Y + Tom.verticalVelocity + 3 <= 400 && Tom.Y < 397)
                    {
                        Tom.verticalVelocity += .008;
                    }
                    else
                    {
                        Tom.verticalVelocity = 0;
                        Tom.Y = 400;
                    }

                    //Move Tom
                    Tom.Y = Tom.Y + Tom.verticalVelocity;
                }
                Thread.Sleep(1);
            }
        }

        public ObservableCollection<MajorTomVMB> MajorToms { get; set; }
        //public testCommand moveLeft { get; }
        //public testCommand jump { get; } 

       /* public void MoveLeft()
        {
            MajorToms[0].MoveLeft();
        }*/
    }
}
