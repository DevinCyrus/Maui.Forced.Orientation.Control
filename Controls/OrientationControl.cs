namespace Maui.Forced.Orientation.Control.Controls
{
    public class OrientationControl : View
    {
        public static readonly BindableProperty DeviceOrientationProperty =
        BindableProperty.Create(
            nameof(DeviceOrientation),
            typeof(DeviceOrientation),
            typeof(OrientationControl),
            DeviceOrientation.Undefined,
            propertyChanged: OnOrientationChanged);


        public DeviceOrientation DeviceOrientation
        {
            get => (DeviceOrientation)GetValue(DeviceOrientationProperty);
            set => SetValue(DeviceOrientationProperty, value);
        }

        private static void OnOrientationChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is OrientationControl orientationControl)
            {
                orientationControl.OnOrientationChanged((DeviceOrientation)newValue);
            }
        }

        public event Action<DeviceOrientation> OrientationChanged;

        private void OnOrientationChanged(DeviceOrientation newOrientation)
        {
            OrientationChanged?.Invoke(newOrientation);
        }
    }

    public enum DeviceOrientation
    {
        Undefined,
        Portrait,
        Landscape
    }
}
