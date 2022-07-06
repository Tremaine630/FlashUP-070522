using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace tutor.pagemodelsbase
{ 

    public class PageModelBase : ExtendedBindableObject
    {
         string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public virtual Task InitializeAsync(object navigatonDate=null)
        {
            return Task.CompletedTask;
        } 
    }
}