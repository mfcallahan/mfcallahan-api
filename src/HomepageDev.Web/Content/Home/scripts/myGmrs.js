var map;

document.addEventListener('DOMContentLoaded', function () {
    setupMap();
    addLayers();    
});

function setupMap() {
    map = L.map('myGmrsMap').fitBounds(getExtentUsa());
    
    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
        attribution: 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>',
        maxZoom: 18,
        id: 'mapbox.streets',
        accessToken: 'pk.eyJ1IjoibWNhbGxhaGFuIiwiYSI6ImNqand5MTZnY2E3NGszcGxmc2o2ZnB3b2oifQ.-NZxzxhWN1QMB2C9dYd7qw'
    }).addTo(map);

    // google layers
    var googleTerrain = L.tileLayer('http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    });

    var googleSat = L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    });

    var googleHybrid = L.tileLayer('http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}', {
        maxZoom: 20,
        subdomains: ['mt0', 'mt1', 'mt2', 'mt3']
    });
}

function addLayers() {
    getRepeaters();
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

    var markerClusters = L.markerClusterGroup({
        showCoverageOnHover: false,
        zoomToBoundsOnClick: true,
        disableClusteringAtZoom: 10
    });

    for (var i = 0; i < response.repeaters.length; i++) {
        var popup = response.repeaters[i].name + '<br/>' + response.repeaters[i].frequencyOut;

        var markerIcon = L.icon({
            iconUrl: '/Content/Home/img/marker-blue.png'
        });

        var m = L.marker(
            [response.repeaters[i].location.latitude, response.repeaters[i].location.longitude],
            { icon: markerIcon }
        ).bindPopup(popup);

        markerClusters.addLayer(m);
    }  

    map.addLayer(markerClusters);
}

function getExtentUsa() {
    return [
        [23.8, -126.6], //Southwest
        [50.2, -66.1]  //Northeast
    ];
}