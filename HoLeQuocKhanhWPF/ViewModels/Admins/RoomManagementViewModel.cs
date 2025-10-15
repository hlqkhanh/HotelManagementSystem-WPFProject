using BLL.IServices;
using BLL.Services;
using BussinessObjects.Models;
using HoLeQuocKhanhWPF.ViewModels.Base;
using HoLeQuocKhanhWPF.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace HoLeQuocKhanhWPF.ViewModels.Admins
{
    public class RoomManagementViewModel : ViewModelBase
    {
        private readonly IRoomInformationService _roomService;
        private ObservableCollection<RoomInformation> _rooms;
        private RoomInformation _selectedRoom;
        private string _searchText;

        public ObservableCollection<RoomInformation> Rooms
        {
            get => _rooms;
            set
            {
                _rooms = value;
                OnPropertyChanged();
            }
        }

        public RoomInformation SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddRoomCommand { get; }
        public ICommand EditRoomCommand { get; }
        public ICommand DeleteRoomCommand { get; }
        public ICommand SearchCommand { get; }

        public RoomManagementViewModel()
        {
            _roomService = new RoomInformationService();
            LoadRooms();

            AddRoomCommand = new RelayCommand<object>(p => AddRoom());
            EditRoomCommand = new RelayCommand<RoomInformation>(EditRoom);
            DeleteRoomCommand = new RelayCommand<RoomInformation>(DeleteRoom);
            SearchCommand = new RelayCommand<object>(p => Search());
        }

        private void LoadRooms()
        {
            Rooms = new ObservableCollection<RoomInformation>(_roomService.GetRoomInformationList());
        }

        private void AddRoom()
        {
            var dialog = new RoomDialog();
            if (dialog.ShowDialog() == true)
            {
                LoadRooms();
            }
        }

        private void EditRoom(RoomInformation room)
        {
            if (room != null)
            {
                var dialog = new RoomDialog(room);
                if (dialog.ShowDialog() == true)
                {
                    LoadRooms();
                }
            }
        }

        private void DeleteRoom(RoomInformation room)
        {
            if (room != null)
            {
                if (MessageBox.Show("Are you sure you want to delete this room?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    _roomService.DeleteRoomInformation(room);
                    LoadRooms();
                }
            }
        }

        private void Search()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                LoadRooms();
            }
            else
            {
                var searchResult = _roomService.GetRoomInformationList()
                    .Where(r => r.RoomNumber.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase));
                Rooms = new ObservableCollection<RoomInformation>(searchResult);
            }
        }
    }
}