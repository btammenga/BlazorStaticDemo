function onScanSuccess(qrCodeMessage) {
    DotNet.invokeMethodAsync("BlazorStaticDemo", "AddScanResult", qrCodeMessage);
}
function onScanError(errorMessage) {
    //handle scan error
}
var html5QrcodeScanner = new Html5QrcodeScanner("reader", { fps: 10, qrbox: 300 });

html5QrcodeScanner.render(onScanSuccess, onScanError);