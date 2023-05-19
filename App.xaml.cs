using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.Models;
using Reservoom.Navigation;
using Reservoom.Service.ReservationProviders;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Reservoom.Services.ReservationCreators;
using Reservoom.Services.ReservationProviders;
using Reservoom.Services.ReservationConflictValidators;
using Reservoom.Stores;
using System.Windows.Navigation;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Reservoom.Service;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly String _ConectionString = "Data Source=reservoom.db";
        private IHost _host;

        public App()
        {
           _host =Host.CreateDefaultBuilder().ConfigureServices(Services =>
            {
                Services.AddSingleton(new ReservoomDbContextFactory(_ConectionString));
                Services.AddSingleton<IReservationConflictValidator, DatabaseReservationConflictValidator>();
                Services.AddSingleton<IReservationProvider, DatabaseReservationProvider>();
                Services.AddSingleton<IReservationCreator, DatabaseReservationCreator>();
                Services.AddTransient<ReservationBook>();
                Services.AddSingleton((s) => new Hotel(s.GetRequiredService<ReservationBook>(), " "));
                Services.AddSingleton<HotelStore>();
                Services.AddSingleton<NavigationStore>();
                Services.AddTransient((s)=> CreateReservationListingViewModel(s));
                Services.AddSingleton<Func<ReservationListingViewModel>>((s) => () => s.GetRequiredService<ReservationListingViewModel>());
                Services.AddTransient<MakeReservationViewModel>();
                Services.AddSingleton<Func<MakeReservationViewModel>>((s) => () => s.GetRequiredService<MakeReservationViewModel>());
                Services.AddSingleton<NavigationService<ReservationListingViewModel>>();
                Services.AddSingleton<NavigationService<MakeReservationViewModel>>();
                Services.AddSingleton<MainViewModel>();

                Services.AddSingleton((s)=> new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>()
                });
            }).Build();
        }

        private ReservationListingViewModel CreateReservationListingViewModel(IServiceProvider s)
        {
            return ReservationListingViewModel.LoadViewModel
                (
                s.GetRequiredService<HotelStore>(),s.GetRequiredService<NavigationService<MakeReservationViewModel>>()
                );
        }

        protected override void OnStartup(StartupEventArgs e)
        {

            _host.Start();
            ReservoomDbContextFactory reservoomDbContextFactory = _host.Services.GetRequiredService<ReservoomDbContextFactory>();
            using(ReservoomDbContext dbContext = reservoomDbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }


            NavigationService<ReservationListingViewModel> navigationService = _host.Services.GetRequiredService<NavigationService<ReservationListingViewModel>>();
            navigationService.Navigate();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            
            MainWindow.Show();
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();
            base.OnExit(e);
        }

    }
}
