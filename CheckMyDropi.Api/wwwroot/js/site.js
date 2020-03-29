// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

import { Zoom } from "swiper/js/swiper.esm";

// Write your JavaScript code.

$(document).ready(function () {
    $("#searchButton").click(function (event) {
        event.preventDefault();
        const url = encodeURI($("#textUrlSearch").val());
        $.ajax({
            url: '/api/v1/url/'+url+'/check',
            type: 'GET',
            error: function () {
                $('#info').html('<p>An error has occurred</p>');
            },
            success: function (data) {
                if (data) {

                }
                alert(data);
            }
        });
    });
});