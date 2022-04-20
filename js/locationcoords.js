function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(success);
    }
    else {
        error('Geo Location is not supported');
    }    
}

function returnCoordinates(position) {
    return position.coords.latitude.toString(), position.coords.longitude.toString();
}