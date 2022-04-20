using BlazorBarcodeScanner.ZXing.JS;
using BlazorStaticDemo.Models;
using Microsoft.AspNetCore.Components.Web;
using BrowserInterop.Extensions;
using BrowserInterop.Geolocation;
using Microsoft.JSInterop;
using BrowserInterop;
using BrowserInterop.Geolocation;
using System.Globalization;

namespace BlazorStaticDemo.Components;

public partial class ZXingQrScanner
{
    private BarcodeReader _reader;
    private int _streamWidth = 320;
    private int _streamHeight = 320;

    private string _localBarcodeText;
    private int _scanCount = 0;
    private int _currentVideoSourceIdx = 0;
    private List<ScanItem> _scanResults { get; set; } = new();
    
    private WindowInterop window;
    private WindowNavigator navigator;
    private IAsyncDisposable connectionChangeEventHandler;
    private IAsyncDisposable geopositionWatcher;
    private int connectionChangedEventHandled = 0;
    private GeolocationResult geolocationResult;
    private int geopositionChanged;

    protected override async void OnInitialized()
    {
        window = await JsRuntime.Window();
        navigator = await window.Navigator();

    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            if (!string.IsNullOrWhiteSpace(_reader.SelectedVideoInputId))
            {
                _currentVideoSourceIdx = SourceIndexFromId();
            }
        }
    }

    private int SourceIndexFromId()
    {
        int result;
        var inputs = _reader.VideoInputDevices.ToList();
        for (result = 0; result < inputs.Count; result++)
        {
            if (inputs[result].DeviceId.Equals(_reader.SelectedVideoInputId))
            {
                break;
            }
        }
        return result;
    }

    private async void LocalReceivedBarcodeText(BarcodeReceivedEventArgs args)
    {
        await InvokeAsync(() =>
        {
            this._scanCount++;
            InsertScanItem(_scanCount, args.BarcodeText);
            //this._localBarcodeText = args.BarcodeText;
        });
    }

    private void OnVideoSourceNext(MouseEventArgs args)
    {
        var inputs = _reader.VideoInputDevices.ToList();

        if (inputs.Count == 0)
        {
            return;
        }

        _currentVideoSourceIdx++;
        if (_currentVideoSourceIdx >= inputs.Count)
        {
            _currentVideoSourceIdx = 0;
        }

        _reader.SelectVideoInput(inputs[_currentVideoSourceIdx]);
    }

    private void InsertScanItem(int scanCount, string scanResult)
    {
        string coords = string.Empty;
        if (geolocationResult?.Location?.Coords != null)
        {
            coords = $"{geolocationResult.Location.Coords.Latitude.ToString(CultureInfo.InvariantCulture)}, {geolocationResult.Location.Coords.Longitude.ToString(CultureInfo.InvariantCulture)}";
        }

        var scanItem = new ScanItem()
        {
            Id = scanCount,
            ScanResult = scanResult,
            ScanTime = DateTime.Now,
            Coordinates = coords ?? string.Empty
        };
        _scanResults.Add(scanItem);
        StateHasChanged();
    }

    public async Task GetGeolocation()
    {
        geolocationResult = await navigator.Geolocation.GetCurrentPosition(new PositionOptions()
        {
            EnableHighAccuracy = true,
            MaximumAgeTimeSpan = TimeSpan.FromHours(1),
            TimeoutTimeSpan = TimeSpan.FromMinutes(1)
        });
        geopositionWatcher = await navigator.Geolocation.WatchPosition(async (p) =>
        {
            geopositionChanged++;
            StateHasChanged();
            await window.Console.Log(p);
        }
        );
    }

}
