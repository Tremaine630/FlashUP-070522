using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tutor.pagemodelsbase;

namespace tutor.services.Navigation
{
    public interface INavigationServices
    {
        /// <summary>
        /// navigation method to push onto the navigation stack
        /// </summary>
        /// <typeparam name="TPageModel"></typeparam>
        /// <param name="navigationData"></param>
        /// <param name="setRoot"></param>
        /// <returns></returns>
        Task NavigatigateToAsync<TPageModel>(object navigationData = null, bool setRoot = false)
            where TPageModel:PageModelBase;

        /// <summary>
        /// navigation method to pop off of the navigation stack
        /// </summary>
        /// <returns></returns>
        Task GoBackAsync();
    }
}
