using System;
using System.Collections.Generic;
using System.Text;
using TinyIoC;
using tutor.pagemodelsbase;
using tutor.pages;
using tutor.services.Navigation;
using Xamarin.Forms;

namespace tutor.pagemodels
{
    public class PageModelLocator
    {
        static TinyIoCContainer _container;
        static Dictionary<Type, Type> _viewLookup;

        static PageModelLocator()
        {
             _container = new TinyIoCContainer();
             _viewLookup = new Dictionary<Type, Type>();

            //register pages and models
            Register<DashboardPageModel, DasboardPage>();
            Register<FlashUpPageModel, FlashUpPage>();
            Register<SubjectsPageModel, SubjectsPage>();
            Register<SettingsPageModel, SettingsPage>();
            Register<FlashUp1PageModel, FlashUp1Page>();



            //register services(services are registered as singletons default)
            _container.Register<INavigationServices, NavigationServices>();
         }
        public static T resolve<T>() where T : class
        {
             return _container.Resolve<T>();
        }

        public static Page CreatePageFor(Type pageModelType)
        {
            var pageType=_viewLookup[pageModelType];
            var page = (Page)Activator.CreateInstance(pageType);
            var pageModel = _container.Resolve(pageModelType);
            page.BindingContext = pageModel;
            return page;
        }

        static void Register<TpageModel, Tpage>() where TpageModel : PageModelBase where Tpage : Page
        {
            _viewLookup.Add(typeof(TpageModel), typeof(Tpage));
            _container.Register<TpageModel>();
        }
    }
}
