//function getLocation()
//{
//    var longitude = "";
//    var latitude = "";
//    if (navigator.geolocation) {
//        navigator.geolocation.getCurrentPosition(function (p) {
//            console.log(longitude);
//            longitude.text(p.coords.longitude);
//            latitude.text(p.coords.latitude);
//            return latitude.text, longitude.text

//        });
//        //} else {
//        //    alert('Location feature is not supported in this browser.');
//        //}
//    }
//}


function onScanSuccess(qrCodeMessage) {
    DotNet.invokeMethodAsync("BlazorStaticDemo", "QrAddScanResult", qrCodeMessage);
}

function onScanError(errorMessage) {
    //handle scan error
}
var html5QrcodeScanner = new Html5QrcodeScanner(
    "reader",
    {
        fps: 5,
        qrbox: 200,
        experimentalFeatures: {
            useBarCodeDetectorIfSupported: true
        }
    });

html5QrcodeScanner.render(onScanSuccess, onScanError);