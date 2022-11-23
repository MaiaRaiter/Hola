// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function MeGustaPelicula(id)
{
$.ajax({
    url: '/Home/MeGustaPelicula',
    type: 'get',
    dataType: 'json',
    data: "idpelicula=" + id,
    success:  HandleMeGustaPelicula
    });
}
function HandleMeGustaPelicula(response)
{
    $("#likespelicula").html(response.cantLikes);
}


function ViewsPelicula(idV)
{
$.ajax({
    url: '/Home/ViewsPelicula',
    type: 'get',
    dataType: 'json',
    data: "idpelicula=" + idV,
    success:  HandleViewsPelicula
    });
}
function HandleViewsPelicula(response)
{
    $("#viewspelicula").html(response.cantViews);
}
