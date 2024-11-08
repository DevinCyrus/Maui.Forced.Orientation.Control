using Maui.Forced.Orientation.Control.ViewModels;

namespace Maui.Forced.Orientation.Control
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }
    }

}
