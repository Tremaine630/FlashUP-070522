using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tutor.pagemodelsbase;

namespace tutor.pagemodels
{
    public class DashboardPageModel:PageModelBase
    {

        private FlashUpPageModel _flashupPM;
        public FlashUpPageModel FlashUpPageModel
        {
            get { return _flashupPM; }
            set { _flashupPM = value; }
        }

        private FlashUp1PageModel _flashup1PM;
        public FlashUp1PageModel FlashUp1PageModel
        {
            get { return _flashup1PM; }
            set { _flashup1PM = value; }
        }

        private SubjectsPageModel _subjectsPM;
        public SubjectsPageModel SubjectsPageModel
        {
            get { return _subjectsPM; }
            set { _subjectsPM = value; }
        }

        private SettingsPageModel _settingsPM;
        public SettingsPageModel SettingsPageModel
        {
            get { return _settingsPM; }
            set { _settingsPM = value; }
        }


        public DashboardPageModel(FlashUpPageModel flashupPM, FlashUp1PageModel flashup1PM, SubjectsPageModel subjectsPM, SettingsPageModel settingsPM)
        {
            FlashUpPageModel = flashupPM;
            FlashUp1PageModel = flashup1PM;
            SubjectsPageModel = subjectsPM;
            SettingsPageModel = settingsPM;
        }

        public override Task InitializeAsync(object navigatonDate)
        {
            return Task.WhenAny(base.InitializeAsync(navigatonDate),
                FlashUpPageModel.InitializeAsync(null),
                FlashUp1PageModel.InitializeAsync(null),
                SubjectsPageModel.InitializeAsync(null),
                SettingsPageModel.InitializeAsync(null)
                );
        }
    }
}
