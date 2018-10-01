var map;
var mapLayers = [];

var leaftletUrl = 'https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}';
var attr = 'Map data &copy; <a href="https://www.openstreetmap.org/">OpenStreetMap</a> contributors, <a href="https://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="https://www.mapbox.com/">Mapbox</a>';
var accessToken = 'pk.eyJ1IjoibWNhbGxhaGFuIiwiYSI6ImNqand5MTZnY2E3NGszcGxmc2o2ZnB3b2oifQ.-NZxzxhWN1QMB2C9dYd7qw';

function setupMap() {
    //default layer
    mapLayers.push(L.tileLayer(leaftletUrl,
        {
            attribution: attr,
            id: 'mapbox.streets',
            accessToken: accessToken
        }));
    //google terrain
    mapLayers.push(L.tileLayer('http://{s}.google.com/vt/lyrs=p&x={x}&y={y}&z={z}', { subdomains: ['mt0', 'mt1', 'mt2', 'mt3'] }));
    //google sat
    mapLayers.push(L.tileLayer('http://{s}.google.com/vt/lyrs=s&x={x}&y={y}&z={z}', { subdomains: ['mt0', 'mt1', 'mt2', 'mt3'] }));
    //google hybrid
    mapLayers.push(L.tileLayer('http://{s}.google.com/vt/lyrs=s,h&x={x}&y={y}&z={z}', { subdomains: ['mt0', 'mt1', 'mt2', 'mt3'] }));

    map = L.map('myGmrsMap', {
        center: [39.73, -104.99],
        zoom: 10,
        layers: mapLayers[0]
    }).fitBounds(getExtentUsa());
}

function setupLayerControls() {
    var baseMaps = {
        "Grayscale": grayscale,
        "Streets": streets
    };

    var overlayMaps = {
        "Cities": cities
    };

    L.control.layers(baseMaps, overlayMaps).addTo(map);
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

function getRepeaterInfo(id) {
    var success = function (result) {
        addLayer(result);
    };

    var error = function (result) {
        console.log(result);
        alert('Error fetching points.');
    };

    $.ajax({
        url: '/Gmrs/GetMyGmrsRepeaterInfo?id=' + id,
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
        spiderfyOnMaxZoom: false,
        disableClusteringAtZoom: 9
    });

    for (var i = 0; i < response.repeaters.length; i++) {
        //var popup = response.repeaters[i].name + '<br/>' + response.repeaters[i].frequencyOut;
        var popup = "<div><p><h4>" + response.repeaters[i].name + "</h4></p><p><table class=table><tr><th>Frequency<th>Tone Out<th>Tone In<th>Owner<tr><td>" + response.repeaters[i].frequencyOut + "<td>Login Required<td>Login Required<td>[Owner info here]</table></p><p>Description here.</p></div>";

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

document.addEventListener('DOMContentLoaded', function () {
    setupMap();
    addLayers();
});