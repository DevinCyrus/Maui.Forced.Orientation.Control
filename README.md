# Maui Forced Orientation

This project demonstrates forced orientation handling in a .NET MAUI application using MVVM and custom controls.

## Features
- Custom `OrientationControl` for setting and toggling device orientation.
- Integration with .NET MAUI's MVVM Toolkit for clean architecture.
- Platform-specific orientation handling for Android, iOS, and Windows.

## Prerequisites
- .NET SDK 8.0.109 or later
- Microsoft Windows SDK (version 10.0.19041.41 or later) for Windows platform development

## Setup

1. Clone this repository to your local machine:
    ```bash
    git clone https://github.com/yourusername/Maui.Forced.Orientation.git
    ```

2. Navigate to the project directory:
    ```bash
    cd Maui.Forced.Orientation
    ```

3. Restore the NuGet packages:
    ```bash
    dotnet restore
    ```

4. Open the solution in Visual Studio or your preferred IDE.

## Running the Project

1. **Android/iOS:** Build and run the project on an Android or iOS device/emulator.
2. **Windows:** Build and run on Windows platform.

## Usage

- The app features a custom control `OrientationControl` that binds to a `DeviceOrientation` property in the view model.
- The `OrientationControl` allows users to toggle between portrait and landscape orientations.

### Example XAML Usage:
```xml
<controls:OrientationControl DeviceOrientation="{Binding Orientation}" />

### Example ViewModel:
```csharp
public class MainPageViewModel : BaseViewModel
{
    private DeviceOrientation _orientation = DeviceOrientation.Portrait;

    public DeviceOrientation Orientation
    {
        get => _orientation;
        set => SetProperty(ref _orientation, value);
    }
}
```

## Troubleshooting

- Ensure you are using .NET SDK 8.0.109 or later.
- If using Windows, verify that `Microsoft.Windows.SDK.NET.Ref` is set to `10.0.19041.41` or later in your `.csproj`.
