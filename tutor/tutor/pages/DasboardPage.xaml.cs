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
    public partial class DasboardPage : TabbedPage
    {
        public DasboardPage()
        {
            InitializeComponent();
        }
    }
}