using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tutor.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlashUp1Page : ContentPage
    {
        public FlashUp1Page(int pm, int pi)
        {
            InitializeComponent();

            //TESTING PURPOSES
            //Console.WriteLine("fu1-pm: " + pm); 
            //Console.WriteLine("fu1-pi: " + pi); 

            //Create a Progress Bar
            ProgressBar pb = new ProgressBar();
            pb.WidthRequest = 200;
            pb.HeightRequest = 30;
            pb.IsVisible = false;

            //initialize variables to send through to a function
            uint pbduration = 0;    //Progress Bar Duration
            int tduration = 0;      //Timer Duration (constant)
            int tcount = 0;         //Timer Count (Counts every interval until selected is reached)
            int lblcountdown = 0;   //countdown for the Label Text
            string lcount = "";     //Label Countdown Text for backwards Timer Duration Countdown


            //Switch case for 'pm' & 'pi' selection
            switch (pm)
            {
                case 0:
                    //code to input into FlashUp1Page (TIMED)
                    pb.IsVisible = true;
                    break;
                case 1:
                    //code to input into FlashUp1Page (RANDMIZED)
                    break;
            }

            switch (pi)
            {
                case 0:
                    if (pm == 0)
                    {
                        //If mode = Timed
                        //code to input into progress ring
                        pbduration = 180000; //Duration = 3 Minutes (in milliseconds)
                        tduration = 180;
                        lblcountdown = tduration;
                        break;
                    }
                    if (pm == 1)
                    {
                        //If mode = Randomized
                        //code to input into progress ring
                        break;
                    }
                    break;
                case 1:
                    if (pm == 0)
                    {
                        //If mode = Timed
                        //code to input into progress ring
                        pbduration = 300000; //Duration = 5 Minutes (in milliseconds)
                        tduration = 300; //Duration (in Seconds)
                        lblcountdown = tduration;
                        break;
                    }
                    if (pm == 1)
                    {
                        //If mode = Randomized
                        //code to input into progress ring
                        break;
                    }
                    break;
                case 2:
                    if (pm == 0)
                    {
                        //If mode = Timed
                        //code to input into progress ring
                        pbduration = 600000; //Duration = 10 Minutes (in milliseconds)
                        tduration = 600; //Duration (in Seconds)
                        lblcountdown = tduration;
                        break;
                    }
                    if (pm == 1)
                    {
                        //If mode = Randomized
                        //code to input into progress ring
                        break;
                    }
                    break;
            }

            //Creates a Timer/Label for the progress bar
            Label lblTimer = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                Text = lcount
            };
            flashUp1Stack.Children.Add(lblTimer);


            //Progressbar Settings
            pbSettings(pbduration, tduration, lblcountdown); //The function called initiates the timer and the progress bar at the same time
            async void pbSettings(uint duration, int durationtimer, int lblcd)
            {
                //Timer setup
                Timer t = new Timer(TimerCallback, null, 0, 1000); //Calls function every 1000ms or 1sec

                void TimerCallback(object o)
                {
                    if (tcount >= tduration) //it counts every second until the selected index interval is reached
                    {

                        Device.BeginInvokeOnMainThread(() =>
                        {
                            pb.IsVisible = false;
                            lblTimer.Text = "TIME'S UP!";
                        });


                        //When the progress bar is filled, this timer should also be completed at the same time, so the code here would
                        //clear the screen and/or open a new page that just has a big "Time's Up!"

                    }
                    else
                    {
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            //This sets a countdown in seconds for the Label Text
                            lblTimer.Text = lblcd.ToString();
                            lblcd--;
                        });
                    }
                    //This increases the count increment until the selected Timed Interval is reached.
                    tcount++;
                }

                //PB setup
                flashUp1Stack.Children.Add(pb);
                await pb.ProgressTo(1, duration, Easing.Linear);
                t.Dispose();
            }
        }
    }
}