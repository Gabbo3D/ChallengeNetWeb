$(document).ready(function () {
    $("#GenreId").change(toggleCountry);
    toggleCountry();
});

$(document).ready(function () {
    $("#btnAdd").click(addActor);
});

$(document).ready(function () {
    $("#btnRemove").click(removeActor);
});

$(document).ready(function () {
    $("#ddlCast").click(removeCast);
    removeCast();
});

function removeCast()
{   
   //$('#ddlCast option').filter(':selected').remove();
}

$(document).ready(function () {
    $("#ddlActors").click(addCast);
    addCast(); 
});

function addCast() {
    //$('#ddlCast option').add($('#ddlActors option').filter(':selected').value)
}

function toggleCountry()
{
    document.getElementById("CountryDiv").style.display = "none";
    if ($('#GenreId option').filter(':selected').text() == "Western")
    {
        $("#CountryDiv").fadeIn(300);
        document.getElementById("CountryDiv").style.display = "block";       
    }
}

function addActor()
{ 
    //document.getElementById("txtArea").value += "," + $('#ddlActors option').filter(':selected').val();
    $('#ddlActors option').options.Add(new  { Text= "1", Value = "1" });
}

function removeActor()
{
    //document.getElementById("txtArea").value = document.getElementById("txtArea").value.replace(","+ $('#ddlActors option').filter(':selected').val(),'');
}