$(function(){
$('#myForm').on('submit', function(event){
	var actor = $(this).serialize();
	//alert(actor);
	$.ajax({
		url: "index.php?action=ajaxAddActor",
		method: "POST",
		data: actor
	})
	.done(function(act){
		var newActor = $.parseJSON(act);
		var addString = '<tr><td>' + newActor.actorId + '</td>';
		addString += '<td>' + newActor.firstName + '</td>';
		addString += '<td>' + newActor.lastName + '</td>';
		//alert(act);
		$('#actorLinks').append(addString);
	});
	event.preventDefault();
});
});

window.onload = function () {
	var $form = document.forms['myForm'];
	var $fname = $form['fName'];
	var $lname = $form['lName'];
	var $birthMonth = $form['birthMonth'];
	var $birthYear = $form['birthYear'];
	var $birthDay = $form['birthDay'];
	var $gender = $form['gender'];
	var $genres = $form['genres'];
	var $addBtn = $form['submit'];
	
	//function that returns the number of days in a month
var daysInMonth = function(firstDate) {
    return new Date(firstDate.getYear(), firstDate.getMonth() + 1, 0).getDate();
}

//function that displays the days in the month for the selected year and month
var getDays = function(event) {
    var month = $birthMonth.value;
    var year = $birthYear.value;
    var dateValue = month + "/1/" + year;
    dateValue = new Date(dateValue);
    var days = daysInMonth(dateValue);

    var dayHtml = "<select name=birthDay>";
    dayHtml += "<option selected>Day</option>";
    for (var i = 1; i <= days; i++) {
        dayHtml += "<option value='" + i + "'>" + i + "</option>";
    }
    dayHtml += "</select>";
    document.getElementById("birthDay").innerHTML = dayHtml;
}
	
    //display a list of the past 100 years to use in the birth year dropdown
    var hundredYears = new Date().getFullYear() - 100;
    var todayYears = new Date().getFullYear();
    var yearHtml = "<select name=birthYear>";
    yearHtml += "<option selected>Year</option>";
    for (var i = todayYears; i >= hundredYears; i--) {
        yearHtml += "<option value='" + i + "'>" + i + "</option>";
    }
    yearHtml += "</select>";
    document.getElementById("birthYear").innerHTML = yearHtml;

    //add event listeners to make the birthday dropdowns work properly
    $birthDay.addEventListener('mouseover', function () {
        getDays();
    });
    $birthMonth.addEventListener('click', function () {
        getDays();
    });
    $birthYear.addEventListener('click', function () {
        getDays();
    });
};