$(document).ready(function () {
    getCameras();
});

function getCameras() {
    $.getJSON('/Content/ADOT/cameras.json', function (data) {
        for (i = 0; i < data.cameras.length; i++) {
            addImg(data.cameras[i].Url);
        }
    });
}

function addImg(url) {
    $('#camerasDiv').append($('<div class="row"><div class="text-center"><img src="' + url + '" style="max-width: 100%;" /></div></div>'));
}


