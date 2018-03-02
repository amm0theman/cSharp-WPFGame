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
        public WindowVM()
        {
            //setup sound here

            //Initialize spaceman and enemy locations here
            MajorToms = new ObservableCollection<MajorTomVMB>();
            //For random placement of major tom
            var rand = new Random();
            MajorToms.Add(new MajorTomVMB(200, 200));

            moveLeft = new testCommand(O => MajorToms[0].MoveLeft());
            jump = new testCommand(O => MajorToms[0].Jump());

            //start thread
            var thread = new Thread(UpdateThread)
            {
                IsBackground = true
            };

            thread.Start();

            
        }

        private void UpdateThread()
        {
            while (true)
            {
                for (int i = 0; i < MajorToms.Count; i++)
                {
                    //For Major Tom movement
                    var Tom = MajorToms[i];

                    //Get key presses


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
        public testCommand moveLeft { get; }
        public testCommand jump { get; }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                MajorToms[0].Y = 300;
            }
        }


       /* public void MoveLeft()
        {
            MajorToms[0].MoveLeft();
        }*/
    }
}
