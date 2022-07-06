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
    public partial class SubjectsPage : ContentPage
    {
        public SubjectsPage()
        {
            InitializeComponent();
            string strKB = "";
            //———————————————————————————————————————————— STACK SLOT1 ————————————————————————————————————————————//
            //Creates a stacklayout.
            StackLayout stackAddRem = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            //Adds this stack to the mainStack, allowing it to take up only the first stack space in the mainStack.
            mainStack.Children.Add(stackAddRem);
            //———————————————————————————————————————————— BUTTON ARRAY ————————————————————————————————————————————//
            //Creates a Button Array and initializes them.
            Button[] btnSub = new Button[10];
            for (int i = 0; i < btnSub.Length; i++)
            {
                btnSub[i] = new Button
                {
                    Text = "",
                    HeightRequest = 150,
                    HorizontalOptions = LayoutOptions.Fill,
                    IsVisible = false
                };
                //This line calls the BtnSubClick function which is what happens when any Subject button is clicked.
                btnSub[i].Clicked += BtnSubClick;
            }
            //———————————————————————————————————————————— ADD SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Add Subject" button
            Button btnAddSub = new Button
            {
                Text = "Add Subject",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //This is what happens when the "Add Subject" button is clicked:
            btnAddSub.Clicked += async (sender, e) =>
            {
                strKB = ""; //Empties the string if it is already populated.
                //This loop checks through each button in the array and checks its properties to see if it is inside the main Stack Layout.
                for (int i = 0; i < btnSub.Length; i++)
                {
                    if (btnSub[i].IsVisible == true)
                    {
                        continue;
                    }
                    if (btnSub[i].IsVisible == false)
                    {
                        btnSub[i].IsVisible = true;
                        //Displays text prompt asking user to enter a Subject Name. Will not accept an empty string.
                        while (strKB == "")
                        {
                            strKB = await DisplayPromptAsync("Add A Subject", "Subject Name:", placeholder: "Subject", keyboard: Keyboard.Chat, maxLength: 30);
                            for (int y = 0; y < btnSub.Length; y++)
                            {
                                if (strKB == btnSub[y].Text)
                                {
                                    await DisplayAlert("Add Card", "Card already exist", "Ok");
                                    strKB = "";
                                    break;
                                }
                            }
                        }
                        btnSub[i].Text = strKB;             //Sets the Button text to the strKB.
                        mainStack.Children.Add(btnSub[i]);  //Puts the button in the stack to display on screen.
                        break;                              //Breaks the loop
                    }
                    if (btnSub[i].Text == "")
                    {
                        btnSub[i].IsVisible = false;
                        mainStack.Children.Remove(btnSub[i]);
                    }
                }
            };
            //———————————————————————————————————————————— EDIT SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Edit Subject" button.
            Button btnEditSub = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            //This is what happens when the "Edit Subject" button is clicked:
            btnEditSub.Clicked += (sender, e) =>
            {
                //I need to somehow add
            };
            //———————————————————————————————————————————— REMOVE SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Remove Subject" button.
            Button btnRemoveSub = new Button
            {
                Text = "Remove",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            //This is what happens when the "Remove" button is clicked:
            btnRemoveSub.Clicked += (sender, e) =>
            {
                //Show a drop-down list
                //Placeholder loop
                for (int i = mainStack.Children.Count ; i >= 0; i--)
                {
                    //This is temporary/placeholder code
                    if (btnSub[i].IsVisible == false)
                    {
                        continue;
                    }
                    if (btnSub[i].IsVisible == true)
                    {
                        btnSub[i].IsVisible = false;
                        btnSub[i].Text = "";
                        mainStack.Children.Remove(btnSub[i]);
                        break;
                    }
                }
            };
            //———————————————————————————————————————————— STACK1 LAYOUT ————————————————————————————————————————————//
            //Adds these buttons to the first stack.
            stackAddRem.Children.Add(btnAddSub);
            stackAddRem.Children.Add(btnEditSub);
            stackAddRem.Children.Add(btnRemoveSub);
            //———————————————————————————————————————————— SUBJECT CLICK ————————————————————————————————————————————//
            //When any Subject button is clicked, it calls this function
            async void BtnSubClick(object sender, System.EventArgs e)
            {
                //We NEED to figure out a way to figure out which button was pressed in the array and have the assigned FC page follow.
                //This Function will take the user to the Flashcard Page
                await Navigation.PushAsync(new Sub1Page());
            }
        }
    }
}