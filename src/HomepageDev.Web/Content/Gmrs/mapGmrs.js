var map;

function GetGmrsRepeaters() {

    var success = function (result) {
        SetMap();

        for (var i = 0; i < result.length; i++) {
            marker = new L.marker([result[i].Latitude, result[i].Longitude]).addTo(map);
        }
    };

    var error = function (result) {
        SetMap();
        console.log(result);
        alert("Error fetching points.");
    };

    $.ajax({
        url: "Gmrs/GetGmrsRepeaters",
        type: "POST",
        success: success,
        error: error,
        cache: false,
        contentType: false,
        processData: false
    });
}

function Setup() {
    GetGmrsRepeaters();
}

function SetMap() {
    map = L.map("gmrsMap").setView([34.3, -111.6], 7);

    L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
        maxZoom: 18,
        attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
        '<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
        'Imagery © <a href="http://mapbox.com">Mapbox</a>',
        id: 'mapbox.streets'
    }).addTo(map);
}


$(document).ready(function () {
    Setup();
});