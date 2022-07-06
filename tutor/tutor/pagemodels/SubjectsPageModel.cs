using System;
using System.Collections.Generic;
using System.Text;
using tutor.pagemodelsbase;

namespace tutor.pagemodels
{
    public class SubjectsPageModel:PageModelBase
    {


        /* //IGNORE THIS - NEEDED FOR REFRENCING
        private Subject1PageModel _Sub1PM;
        public Subject1PageModel Subject1PageModel
        {
            get => _Sub1PM;
            set =>SetProperty(ref _Sub1PM, value);
        }
        
        public SubjectsPageModel(Subject1PageModel Sub1PM)
        {
            Subject1PageModel = Sub1PM;

        }

        public override Task InitializeAsync(object navigatonDate)
        {
            return Task.WhenAny(base.InitializeAsync(navigatonDate),
                Subject1PageModel.InitializeAsync(null));

        }
        */

    }
}
