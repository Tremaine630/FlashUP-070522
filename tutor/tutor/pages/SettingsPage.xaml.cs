using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tutor.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            //Enter Setting text here
            string settingtext1 = "Dark Mode (currently does not work)";
            string settingtext2 = "Setting 2";
            string settingtext3 = "Setting 3";

            //Enter space away from top of banner
            double transYtop = 40;
            settingStack.TranslationY = transYtop;

            bool on = true;
            //Not sure if I need these yet or if I can just pass in the "on" bool to functions.
            //bool set1 = true;
            //bool set2 = true;
            //bool set3 = true;
            string whitespace = "          ";

            StackLayout setting1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };
            
            StackLayout setting2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };
            StackLayout setting3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
            };

            //———————————————————————————————————————————— SETTING # 1 ————————————————————————————————————————————//
            Label lblSet1 = new Label();
            lblSet1.Text = whitespace + settingtext1;
            lblSet1.HorizontalOptions = LayoutOptions.StartAndExpand;

            Switch swSet1 = new Switch {
                IsToggled = false,
                OnColor = Color.Green,
                ThumbColor = Color.WhiteSmoke
            };
            swSet1.Toggled += (sender, e) =>
            {
                //Switch the button ON/OFF
                if (on)
                {
                    
                    //Call function here(on).
                    on = false;
                }
                else
                {
                    //Call function here(on).
                    on = true;
                }
            };

            setting1.Children.Add(lblSet1);
            setting1.Children.Add(swSet1);


            //———————————————————————————————————————————— SETTING # 2 ————————————————————————————————————————————//
            Label lblSet2 = new Label();
            lblSet2.Text = whitespace + settingtext2;
            lblSet2.HorizontalOptions = LayoutOptions.StartAndExpand;

            Switch swSet2 = new Switch
            {
                IsToggled = false,
                OnColor = Color.Green,
                ThumbColor = Color.WhiteSmoke
            };
            swSet2.Toggled += (sender, e) =>
            {
                //Switch the button ON/OFF
                if (on)
                {

                    //Call function here(on).
                    on = false;
                }
                else
                {
                    //Call function here(on).
                    on = true;
                }
            };
            setting2.Children.Add(lblSet2);
            setting2.Children.Add(swSet2);


            //———————————————————————————————————————————— SETTING # 3 ————————————————————————————————————————————//
            Label lblSet3 = new Label();
            lblSet3.Text = whitespace + settingtext3;
            lblSet3.HorizontalOptions = LayoutOptions.StartAndExpand;

            Switch swSet3 = new Switch
            {
                IsToggled = false,
                OnColor = Color.Green,
                ThumbColor = Color.WhiteSmoke
            };
            swSet3.Toggled += (sender, e) =>
            {
                //Switch the button ON/OFF
                if (on)
                {
                    //Call function here(on).
                    on = false;
                }
                else
                {
                    //Call function here(on).
                    on = true;
                }
            };
            setting3.Children.Add(lblSet3);
            setting3.Children.Add(swSet3);


            //———————————————————————————————————————————— SETTING STACK ————————————————————————————————————————————//
            settingStack.Children.Add(setting1);
            settingStack.Children.Add(setting2);
            settingStack.Children.Add(setting3);
        }
    }
}