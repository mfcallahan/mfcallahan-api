var map;

document.addEventListener('DOMContentLoaded', function () {
    setupMap();
    getRepeaters();
});

function setupMap() {
    map = L.map('myGmrsMap').setView([39.83, -98.58], 4);
    
    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox.streets',
        accessToken: 'pk.eyJ1IjoibWNhbGxhaGFuIiwiYSI6ImNqand5MTZnY2E3NGszcGxmc2o2ZnB3b2oifQ.-NZxzxhWN1QMB2C9dYd7qw'
    }).addTo(map);
}

function getRepeaters() {
    var success = function (result) {
        addLayer(result);
    };

    var error = function (result) {        
        console.log(result);
        alert('Error fetching points.');
    };

    $.ajax({
        url: '/Gmrs/GetMyGmrsRepeaters',
        type: 'GET',
        success: success,
        error: error,
        cache: false,
        contentType: false,
        processData: false
    });
}

function addLayer(result) {
    var response = JSON.parse(result);
    var markerClusters = L.markerClusterGroup();

    for (var i = 0; i < response.repeaters.length; i++) {
        var popup = response.repeaters[i].name + '<br/>' + response.repeaters[i].frequencyOut;

        var markerIcon = L.icon({
            iconUrl: 'https://unpkg.com/leaflet@1.3.3/dist/images/marker-icon.png'
        });

        var m = L.marker([response.repeaters[i].location.latitude, response.repeaters[i].location.longitude], { icon: markerIcon }).bindPopup(popup);

        markerClusters.addLayer(m);
    }  

    map.addLayer(markerClusters);
}
