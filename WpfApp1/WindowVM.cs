using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using NAudio.Wave;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;

namespace WpfApp1
{
    public class WindowVM : ViewModelBase
    {

        Dictionary<Key, bool> keyDown= new Dictionary<Key, bool>();


        //**********************************************************************************************\\
        //                                        Initialization                                        \\
        //______________________________________________________________________________________________\\
        public WindowVM()
        {
            //setup sound here UPDATE

            //GAMEOBJECT INITIALIZATION
            MajorToms = new ObservableCollection<MajorTomVMB>();
            
            //PLACEMENT
            var rand = new Random();
            MajorToms.Add(new MajorTomVMB(200, 200));

            //COMMANDS
            jump = new testCommand(O => MajorToms[0].Jump());

            //UTILITY INITIALIZATION
            foreach (var key in Enum.GetValues(typeof(Key)))
            {
                keyDown[(Key)key] = false;
            }

            //START THREAD
            var thread = new Thread(UpdateThread)
            {
                IsBackground = true
            };

            thread.Start();
        }

        //**********************************************************************************************\\
        //                                   KEYPRESS DETECTION                                         \\
        //______________________________________________________________________________________________\\

        public void KeyDown(Key k)
        {
            keyDown[k] = true;
        }

        public void KeyUp(Key k)
        {
            keyDown[k] = false;
            MajorToms[0].IsRunning = false;
        }

        //**********************************************************************************************\\
        //                                        GAME LOOP                                             \\
        //______________________________________________________________________________________________\\

        private void UpdateThread()
        {
            while (true)
            {
                    //GET INPUTS
                    var Tom = MajorToms[0];

                    if (keyDown[Key.A])
                    {
                        Tom.MoveLeft();
                    }
                    if (keyDown[Key.Space])
                    {
                        Tom.Jump();
                    }
                    if(keyDown[Key.D])
                    {
                        Tom.MoveRight();
                    }


                    //_______________________________________________________
                    //                      UPDATE                          -
                    //‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾

                    //IF TOM IS NOT GOING TO COLLIDE WITH ANYTHING VERTICALLY
                    //      INCREASE VERTICAL VELOCITY
                    //IF NOT GOING TO COLLIDE WITH ANYTHING HORIZONTALLY
                    //      DECREASE HORIZONTAL VELOCITY
                    //ELSE IF
                    //      GOING TO COLLIDE VERTICAL verticalVelocity = 0
                    //ELSE IF
                    //      GOING TO COLLIDE HORIZONTALLY horizontalVelocity = 0
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
                    Tom.X = Tom.X + Tom.horizontalVelocity;
                Thread.Sleep(1);
            }
        }


        //**********************************************************************************************\\
        //                                    not sure but necessary                                    \\
        //______________________________________________________________________________________________\\
        public ObservableCollection<MajorTomVMB> MajorToms { get; set; }
        public testCommand jump { get; }
    }
}
