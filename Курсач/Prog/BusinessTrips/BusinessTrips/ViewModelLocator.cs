using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;

namespace BusinessTrips
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            // Регистрация ViewModels
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ReportViewModel>();
        }

        public LoginViewModel LoginVM => SimpleIoc.Default.GetInstance<LoginViewModel>();
        public MainViewModel MainVM => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ReportViewModel ReportVM => SimpleIoc.Default.GetInstance<ReportViewModel>();
    }
}
