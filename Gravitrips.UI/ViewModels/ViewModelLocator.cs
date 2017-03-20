using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Gravitrips.UI.Views;
using Microsoft.Practices.ServiceLocation;

namespace Gravitrips.UI.ViewModels
{
    public class ViewModelLocator
    {
        public const string StartPageKey = "StartPage";
        public const string GamePageKey = "GamePage";

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            var nav = new NavigationService();
            nav.Configure(StartPageKey, typeof(StartPage));
            nav.Configure(GamePageKey, typeof(GamePage));

            SimpleIoc.Default.Register<INavigationService>(() => nav);
            SimpleIoc.Default.Register<StartViewModel>();
            SimpleIoc.Default.Register<GameViewModel>();

        }
        
        public StartViewModel StartPageInstance => ServiceLocator.Current.GetInstance<StartViewModel>();
        public GameViewModel GamePageInstance => ServiceLocator.Current.GetInstance<GameViewModel>();
    }
}
