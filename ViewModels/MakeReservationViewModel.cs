using Reservoom.Command;
using Reservoom.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Reservoom.Service;
using Reservoom.Stores;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase,INotifyDataErrorInfo
    {
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private  Dictionary<String, List<String>> _propertyNameToErrorsDictionary;
        private string _username="";

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private int _floorNumber = 1;
        public int FloorNumber
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private int _roomNumber=3;
        public int RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private DateTime _startDate = new DateTime(2021, 1, 1);
        public DateTime StartDate
        {
            get
            {
                return _startDate;
            }
            set
            {
                _startDate = value;
                ClearErrors(nameof(EndDate));
                ClearErrors(nameof(StartDate));
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                if (EndDate < StartDate)
                {
                    AddErrors("The start date cannot be after the end date. ", nameof(StartDate));


                }

            }
        }

        private DateTime _endDate = new DateTime(2021, 1, 8);

        

        public DateTime EndDate
        {
            get
            {
                return _endDate;
            }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
                OnPropertyChanged(nameof(StartDate));
                ClearErrors(nameof(EndDate));
                ClearErrors(nameof(StartDate));
                if (EndDate < StartDate)
                {
                    AddErrors("The end date cannot be before the start date. ", nameof(EndDate));
                   

                }
            }
        }

        private void AddErrors(String errorMessage,String propertyName)
        {
            if (!_propertyNameToErrorsDictionary.ContainsKey(propertyName)) {
                _propertyNameToErrorsDictionary.Add(propertyName, new List<string>());
            }


            _propertyNameToErrorsDictionary[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(String propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        private void ClearErrors(String propertyName)
        {
             GetPropertyNameToErrorsDictionary().Remove(propertyName);
            OnErrorsChanged(propertyName);
        }
        private Dictionary<string, List<string>> GetPropertyNameToErrorsDictionary()
        {
            return _propertyNameToErrorsDictionary;
        }

        public ICommand CommandSubmit { get; }
        public ICommand CommandCancel { get; }

        public bool HasErrors => _propertyNameToErrorsDictionary.Any();

        public MakeReservationViewModel(HotelStore hotel, NavigationService<ReservationListingViewModel> navigationService) 
        { 
            CommandCancel = new NavigationCommand<ReservationListingViewModel>(navigationService);
            CommandSubmit = new MakeReservationCommand(hotel, this);
            _propertyNameToErrorsDictionary = new Dictionary<string, List<string>>();

        }

        public IEnumerable GetErrors(string propertyName)
        {
           return _propertyNameToErrorsDictionary.GetValueOrDefault(propertyName, new List<String>() );
        }
    }
}
