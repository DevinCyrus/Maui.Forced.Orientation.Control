using Foundation;
using Maui.Forced.Orientation.Control.Controls;
using Microsoft.Maui.Handlers;
using UIKit;

namespace Maui.Forced.Orientation.Control.Platforms.iOS.Handlers
{
    public class OrientationControlHandler : ViewHandler<OrientationControl, UIView>
    {
        public static IPropertyMapper<OrientationControl, OrientationControlHandler> Mapper = new PropertyMapper<OrientationControl, OrientationControlHandler>(ViewHandler.ViewMapper)
        {
            // Map properties as needed for OrientationControl
        };

        public static CommandMapper<OrientationControl, OrientationControlHandler> CommandMapper = new(ViewHandler.ViewCommandMapper)
        {
            // Map commands as needed
        };

        public OrientationControlHandler() : base(Mapper, CommandMapper)
        {
        }

        protected override UIView CreatePlatformView()
        {
            // Return the iOS view for this handler
            return new UIView();
        }

        protected override void ConnectHandler(UIView platformView)
        {
            base.ConnectHandler(platformView);

            // Subscribe to the OrientationChanged event
            VirtualView.OrientationChanged += OnOrientationChanged;

            UpdateOrientation();
        }

        protected override void DisconnectHandler(UIView platformView)
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

            var device = UIDevice.CurrentDevice;
            if (orientation == DeviceOrientation.Landscape)
            {
                device.SetValueForKey(NSNumber.FromNInt((int)UIInterfaceOrientation.LandscapeRight), new NSString("orientation"));
                UIViewController.AttemptRotationToDeviceOrientation();
            }
            else if (orientation == DeviceOrientation.Portrait)
            {
                device.SetValueForKey(NSNumber.FromNInt((int)UIInterfaceOrientation.Portrait), new NSString("orientation"));
                UIViewController.AttemptRotationToDeviceOrientation();
            }
        }
    }
}
