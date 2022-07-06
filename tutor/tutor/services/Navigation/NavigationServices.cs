using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tutor.pagemodels;
using tutor.pagemodelsbase;
using Xamarin.Forms;

namespace tutor.services.Navigation
{
    public class NavigationServices : INavigationServices
    {
        public Task GoBackAsync()
        {
            return App.Current.MainPage.Navigation.PopAsync();
        }

        public async Task NavigatigateToAsync<TPageModelBase>(object navigationData = null, bool setRoot = false)
            where TPageModelBase : PageModelBase
        {
            var page = PageModelLocator.CreatePageFor(typeof(TPageModelBase));

            if (setRoot)
            {
                if (page is TabbedPage tabbedPage)
                {
                    App.Current.MainPage = tabbedPage;
                }
                else
                {
                    App.Current.MainPage = new NavigationPage(page);
                }
            }
            else
            {
                if (page is TabbedPage tabPage)
                {
                    App.Current.MainPage = tabPage;
                }
                else if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.PushAsync(page);
                }
                else
                {
                    App.Current.MainPage=new NavigationPage(page);
                }
            }

            if (page.BindingContext is PageModelBase pmBase)
            {
                await pmBase.InitializeAsync(navigationData);
            }
        }
    }
}
