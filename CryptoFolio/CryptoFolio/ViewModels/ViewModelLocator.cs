using System;

using CryptoFolio.Services;
using CryptoFolio.Views;

using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

namespace CryptoFolio.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(() => new NavigationServiceEx());
            SimpleIoc.Default.Register<ShellViewModel>();
            Register<MainViewModel, MainPage>();
            Register<RegisterViewModel, RegisterPage>();
            Register<LoginViewModel, LoginPage>();
            Register<AddCoinViewModel, AddCoinPage>();
            Register<ChartViewModel, ChartPage>();
            Register<NewsPageViewModel, NewsPage>();
        }
        public NewsPageViewModel NewsPageViewModel => ServiceLocator.Current.GetInstance<NewsPageViewModel>();
        public ChartViewModel ChartViewModel => ServiceLocator.Current.GetInstance<ChartViewModel>();

        public AddCoinViewModel AddCoinViewModel => ServiceLocator.Current.GetInstance<AddCoinViewModel>();

        public LoginViewModel LoginViewModel => ServiceLocator.Current.GetInstance<LoginViewModel>();

        public RegisterViewModel RegisterViewModel => ServiceLocator.Current.GetInstance<RegisterViewModel>();

       

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        public void Register<VM, V>()
            where VM : class
        {
            SimpleIoc.Default.Register<VM>();

            NavigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
