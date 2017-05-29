/**
 * Created by 001264912 on 4/11/2016.
 */
//.ready shortcut
/*$(function() {
 alert('ready');
 });*/

//sometimes use jQuery instead of $
/*jQuery(document).ready(function() {
    alert("hi");
});*/

//document.getElementById === $('tr') && $('#cars')

/*$(document).ready(function() {
   $('#celebs tbody tr:even').addClass('zebra');
    $('#hideButton').click(function() {

        //if ($('#disclaimer').is(':visible')) {
            //$('#disclaimer').hide();
        //}
        //else {
            //$('#disclaimer').show();
        //}

        $('#disclaimer').toggle();

        if ($('#disclaimer').is(':visible')) {
            $(this).val("Hide");
        }
        else {
            $(this).val("Show");
        }
    });

});*/

$(function() {
    /*$('<input type="button" value="toggle" id="toggleButton" />').insertAfter('#disclaimer');
    $('#toggleButton').click(function() {
        $('#disclaimer').slideToggle('slow');
});
    $('<strong>START!</strong>').prependTo('#disclaimer');
    $('<strong>END!</strong>').appendTo('#disclaimer');*/

    $('#disclaimer').slideToggle('slow', function() {
        alert("Poof!");
    });
});

