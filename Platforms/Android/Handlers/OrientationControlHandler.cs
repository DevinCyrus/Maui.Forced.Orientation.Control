using Maui.Forced.Orientation.Control.Controls;
using Microsoft.Maui.Handlers;
using Android.Content.PM;
using AndroidView = Android.Views.View;


namespace Maui.Forced.Orientation.Control.Platforms.Android.Handlers
{
    public class OrientationControlHandler : ViewHandler<OrientationControl, AndroidView>
    {
        public static IPropertyMapper<OrientationControl, OrientationControlHandler> Mapper = new PropertyMapper<OrientationControl, OrientationControlHandler>(ViewHandler.ViewMapper)
        {
            // Map properties here if needed, e.g., nameof(OrientationControl.SomeProperty) => MapSomeProperty
        };

        public static CommandMapper<OrientationControl, OrientationControlHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {
            // Map commands here if needed
        };

        public OrientationControlHandler() : base(Mapper, CommandMapper)
        {
        }

        protected override AndroidView CreatePlatformView()
        {
            // Return the Android view for this handler
            return new AndroidView(Context);
        }

        protected override void ConnectHandler(AndroidView platformView)
        {
            base.ConnectHandler(platformView);

            // Subscribe to the OrientationChanged event
            VirtualView.OrientationChanged += OnOrientationChanged;

            UpdateOrientation();
        }

        protected override void DisconnectHandler(AndroidView platformView)
        {
            base.DisconnectHandler(platformView);

            // Unsubscribe from the event when handler is disconnected
            VirtualView.OrientationChanged -= OnOrientationChanged;
        }

        // Event handler that is triggered when the orientation changes
        private void OnOrientationChanged(DeviceOrientation newOrientation)
        {
            // This will ensure that the orientation update happens on the platform view
            UpdateOrientation();
        }

        public static void MapDeviceOrientation(OrientationControlHandler handler, OrientationControl control)
        {
            handler.UpdateOrientation();
        }

        private void UpdateOrientation()
        {
            var orientation = VirtualView.DeviceOrientation;
            var activity = Microsoft.Maui.ApplicationModel.Platform.CurrentActivity;

            switch (orientation)
            {
                case DeviceOrientation.Landscape:
                    activity.RequestedOrientation = ScreenOrientation.Landscape;
                    break;
                case DeviceOrientation.Portrait:
                    activity.RequestedOrientation = ScreenOrientation.Portrait;
                    break;
                default:
                    activity.RequestedOrientation = ScreenOrientation.Unspecified;
                    break;
            }
        }
    }
}
