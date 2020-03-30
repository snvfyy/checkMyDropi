// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    $("#formCheck").on("submit", function (event) {
        event.preventDefault();
        if ($("#textUrlSearch").val()) {
            var url = encodeURI($("#textUrlSearch").val());
            if (url.indexOf("http") > -1) {
                url = url.split("/")[2];
            } else {
                url = url.split("/")[0];
            }
            url = encodeURI(url);
            $.ajax({
                url: '/api/v1/url/' + url + '/check',
                type: 'GET',
                error: function () {
                    $('#info').html('<p>An error has occurred</p>');
                },
                success: function (data) {
                    if (data.malicius) {
                        $('#info').html('<p class="danger">This site has been flagged by DROPi as suspicious,\nplease proceed with caution as this could be a phishing link or fake news!</p>');
                    } else {
                        $('#info').html('<p class="good">This site is clean and good to go!</p>');
                    }
                }
            });
        } else {
            $('#info').html('<p class="empty-url">There is not an url!</p>');
        }
    });
});