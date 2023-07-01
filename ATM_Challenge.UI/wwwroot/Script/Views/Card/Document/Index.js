$(document).ready(function () {
    $("#btnFiltro").click(fadeIndex);    
    fadeIndex();
});
/*$(document).ready(function () {
    $("#btnFiltro").click(function () {
        $("#div1").load("/Index?handler=PartialViewTable");
    });
});*/
src = "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js" 
$(document).ready(function () {
    $("btnFiltro").click(function () {
        $("#div1").get("PartialViewTable.cshtml", function (responseTxt, statusTxt, xhr) {
            if (statusTxt == "success")
                alert("External content loaded successfully!");
            if (statusTxt == "error")
                alert("Error: " + xhr.status + ": " + xhr.statusText);
        });
    });
});
$.ajax({
    url: URLGetMovie,
    data: '{ "movieId": "' + Movieid + '"}',
    dataType: "json",
    type: "POST",
    contentType: "application/json; charset=utf-8",
});
//FUNCTIONS
function fadeIndex()
{    
    $("#model").fadeOut(200);
    $("#model").fadeIn(200);
}