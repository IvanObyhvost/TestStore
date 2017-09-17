var map;

function initialize() {
    var mapOptions = {
        zoom: 10,
        center: { lat: 51.5684959, lng: 0.0091416 }
    };

    map = new google.maps.Map(document.getElementById('map-canvas'),
        mapOptions);

    var infoWindow = new google.maps.InfoWindow({ map: map });

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(function (position) {
            var pos = new google.maps.LatLng(
                position.coords.latitude,
                position.coords.longitude
                );

            infoWindow.setPosition(pos);
            infoWindow.setContent('Location found.');
            map.setCenter(pos);
        }, function () {
            handleNoGeolocation(true, infoWindow, map.getCenter());
        });
    } else {
        // Browser doesn't support Geolocation
        handleNoGeolocation(false, infoWindow, map.getCenter());
    }
}

function handleNoGeolocation(errorFlag, infoWindow, pos) {

    infoWindow.setPosition(pos);
    infoWindow.setContent(errorFlag ?
                        '46 Church Lane  Leytonstone London  E11 1HE' :
                        'Error: The Geolocation service failed.');
}

google.maps.event.addDomListener(window, 'load', initialize);