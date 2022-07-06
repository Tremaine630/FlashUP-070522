using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tutor.FlashCards;
using tutor.services.File;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace tutor.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sub1Page : ContentPage
    {
        public Sub1Page()
        {
            InitializeComponent();
            string[] CardBack = new string[10];
            string[] CardFront = new string[10];
            string strKB1 = "";
            string strKB2 = "";
            int u = 0;

            //———————————————————————————————————————————— STACK SLOT1 ————————————————————————————————————————————//
            //Creates a stacklayout.
            StackLayout stackAddRem = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            //Adds this stack to the mainStack, allowing it to take up only the first stack space in the mainStack.
            FCsub1Stack.Children.Add(stackAddRem);
            //———————————————————————————————————————————— BUTTON ARRAY ————————————————————————————————————————————//
            //Creates a Button Array and initializes them.
            Button[] btnCard = new Button[10];
            for (int i = 0; i < btnCard.Length; i++)
            {
                btnCard[i] = new Button
                {
                    Text = "",
                    HeightRequest = 150,
                    HorizontalOptions = LayoutOptions.Fill,
                    IsVisible = false
                };
                int p = i;
                //This line calls the BtnSubClick function which is what happens when any Subject button is clicked.
                btnCard[i].Clicked += (sender, EventArgs) => { BtnCardClick(sender, EventArgs, p); };
            }
            
            //———————————————————————————————————————————— ADD SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Add Subject" button
            Button btnAddCard = new Button
            {
                Text = "Add Card",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            //This is what happens when the "Add Subject" button is clicked:
            btnAddCard.Clicked += async (sender, e) =>
            {
                strKB1 = "";
                strKB2 = "";//Empties the string if it is already populated.
                if (btnCard[u].IsVisible == false)
                {
                    btnCard[u].IsVisible = true;
                    //Displays text prompt asking user to enter a Subject Name. Will not accept an empty string.
                    while (strKB1 == "")
                    {
                        strKB1 = await DisplayPromptAsync("Add A Card", "Card Front:", placeholder: "Front Side", keyboard: Keyboard.Chat, maxLength: 150);
                        for (int i = 0; i < CardBack.Length; i++)
                        {
                            if (strKB1 == btnCard[i].Text)
                            {
                                await DisplayAlert("Add Card", "Card already exist", "Ok");
                                strKB1 = "";
                            }
                        }
                    }
                    while (strKB2 == "")
                    {
                       strKB2 = await DisplayPromptAsync("Add A Card", "Card Back:", placeholder: "Back Side", keyboard: Keyboard.Chat, maxLength: 150);
                    }
                    //sets the back side of the card
                    CardBack[u] = strKB2;
                    btnCard[u].Text = strKB1;             //Sets the Button text to the strKB.
                    FCsub1Stack.Children.Add(btnCard[u]);  //Puts the button in the stack to display on screen.
                }
                u++;
            };
            //———————————————————————————————————————————— EDIT SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Edit Subject" button.
            Button btnEditCard = new Button
            {
                Text = "Edit",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            //This is what happens when the "Edit Subject" button is clicked:
            btnEditCard.Clicked += async (sender, e) =>
            {
                string l = await DisplayPromptAsync("Edit", "Which card do you want to edit?:", placeholder: "Front Side", keyboard: Keyboard.Chat, maxLength: 150);
                for (int i = 0; i < CardBack.Length; i++)
                {
                    if (l == btnCard[i].Text)
                    {
                        bool answer = await DisplayAlert("Edit", "Which side do you want to edit?:", "Back", "Front");
                        if (answer == false)
                        {
                            strKB1 = await DisplayPromptAsync("Edit", "Card Front:", placeholder: "Front Side", keyboard: Keyboard.Chat, maxLength: 150);
                            btnCard[i].Text = strKB1;
                        }
                        else if (answer == true)
                        {
                            strKB2 = await DisplayPromptAsync("Edit", "Card Back:", placeholder: "Back Side", keyboard: Keyboard.Chat, maxLength: 150);
                            CardBack[i]= strKB2;
                        }
                    }
                }
            };
            //———————————————————————————————————————————— REMOVE SUBJECT BUTTON ————————————————————————————————————————————//
            //Creates the "Remove Subject" button.
            Button btnRemoveCard = new Button
            {
                Text = "Remove",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            //This is what happens when the "Remove" button is clicked:
            btnRemoveCard.Clicked += async (sender, e) =>
            {
                //Show a drop-down list
                string l = await DisplayPromptAsync("Remove", "Which card do you want to remove?:", placeholder: "Front Side", keyboard: Keyboard.Chat, maxLength: 150);
                for (int i = 0; i < CardBack.Length; i++)
                {
                    if (l == btnCard[i].Text && btnCard[i].IsVisible == true)
                    {
                        btnCard[i].IsVisible = false;
                        btnCard[i].Text = "";
                        CardBack[i]="";
                        FCsub1Stack.Children.Remove(btnCard[i]);
                        await DisplayAlert("Remove", "Card was removed", "ok");
                        break;
                    }
                    else if (i == CardBack.Length)
                    {
                        await DisplayAlert("Remove", "Card was not found", "ok");
                    }
                }
            };
            Button btnSave = new Button()
            {
                Text = "Save",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Fill
            };
            btnSave.Clicked +=  (sender, e) =>
            {
                for (int i = 0; i < btnCard.Length; i++)
                {
                    CardFront[i]=btnCard[i].Text;
                }
                string filename1 = "SaveCardFront1.txt";
                string filename2 = "SaveCardBack1.txt";
                DependencyService.Get<IFileService>().CreateFile(CardFront,filename1);
                DependencyService.Get<IFileService>().CreateFile(CardBack, filename2);

                DisplayAlert("Saved", "Cards Were Saved", "OK");
            };
            


            //———————————————————————————————————————————— STACK1 LAYOUT ————————————————————————————————————————————//
            //Adds these buttons to the first stack.
            stackAddRem.Children.Add(btnAddCard);
            stackAddRem.Children.Add(btnEditCard);
            stackAddRem.Children.Add(btnRemoveCard);
            stackAddRem.Children.Add(btnSave);
            if (File.Exists(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardBack1.txt"))
            {
                int c = 0;
                foreach (string line in File.ReadLines(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardBack1.txt", Encoding.UTF8))
                {
                    CardBack[c]=line;
                    c++;
                }
                /*string[] lines = File.ReadAllLines(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardBack1.txt", Encoding.UTF8);
                for (int i = 0; i < lines.Length; i++)
                {
                    CardBack[i] = lines[i];
                }*/
            }
            if (File.Exists(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardFront1.txt"))
            {
                int c = 0;
                foreach (string line in File.ReadLines(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardBack1.txt", Encoding.UTF8))
                {
                    btnCard[c].Text = line;
                    c++;
                }
                for (int i = 0; i < btnCard.Length; i++)
                {
                    if (btnCard[i].Text != "")
                    {
                        btnCard[i].IsVisible = true;
                    }
                }
                /*string[] lines = File.ReadAllLines(@"/storage/emulated/0/Android/data/com.companyname.tutor/files/SaveCardFront1.txt", Encoding.UTF8);
                for (int i = 0; i < btnCard.Length; i++)
                {
                    btnCard[i].Text = lines[i];
                    btnCard[i].IsVisible = true;
                }*/
            }
            //———————————————————————————————————————————— SUBJECT CLICK ————————————————————————————————————————————//
            //When any Subject button is clicked, it calls this function
            async void BtnCardClick(object sender, System.EventArgs e, int p)
            {
                
                await DisplayAlert("Answer", CardBack[p], "ok");
            }
        }
    }
}