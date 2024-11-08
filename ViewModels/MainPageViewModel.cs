using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.Forced.Orientation.Control.Controls;

namespace Maui.Forced.Orientation.Control.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private DeviceOrientation orientation;

        public MainPageViewModel()
        {
            // Initialize the orientation as needed
            Orientation = DeviceOrientation.Undefined;
        }

        [RelayCommand]
        private void ToggleOrientation()
        {
            // If the orientation is Undefined, set it to Landscape, else toggle between landscape and portrait
            Orientation = Orientation == DeviceOrientation.Portrait || Orientation == DeviceOrientation.Undefined
                ? DeviceOrientation.Landscape
                : DeviceOrientation.Portrait;
        }

        [RelayCommand]
        private void ClearOrientation()
        {
            Orientation = DeviceOrientation.Undefined;
        }
    }
}
