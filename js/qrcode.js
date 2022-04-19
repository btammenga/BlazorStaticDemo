function onScanSuccess(qrCodeMessage) {
    DotNet.invokeMethodAsync("BlazorStaticDemo", "AddScanResult", qrCodeMessage);
}
function onScanError(errorMessage) {
    //handle scan error
}
var html5QrcodeScanner = new Html5QrcodeScanner(
    "reader",
    {
        fps: 10,
        qrbox: 200,
        experimentalFeatures: {
            useBarCodeDetectorIfSupported: true
        }
    });

html5QrcodeScanner.render(onScanSuccess, onScanError);