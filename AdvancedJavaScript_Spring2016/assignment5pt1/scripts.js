/**
 * Created by Michael on 4/18/2016.
 */

//declare some variables
var $form = document.forms['myForm'];
var $fname = $form['fName'];
var $lname = $form['lName'];
var $birthMonth = $form['birthMonth'];
var $birthYear = $form['birthYear'];
var $birthDay = $form['birthDay'];
var $gender = $form['gender'];
var $genres = $form['genres'];
var $addBtn = $form['submit'];
var $updateBtn = $form['update'];
var $deleteBtn = $form['delete'];
var $male = $form['male'];
var $female = $form['female'];
var $actors = document.getElementById('actors');
var $error = document.getElementById("error");
var actorObject = {};
var actorArray = [];
var linkIndex;
var errorHtml;
var stringifyObject;

//function that returns the number of days in a month
function daysInMonth(firstDate) {
    return new Date(firstDate.getYear(), firstDate.getMonth() + 1, 0).getDate();
}

//function that displays the days in the month for the selected year and month
function getDays(event) {
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

//function used to help validate
function validate(content) {
    if (content != "") {
        return true;
    } else {
        return false;
    }
}

//function that hides a parameter
function hide(element) {
    element.style.display = "none";
}

//function that shows a parameter
function show(element) {
    element.style.display = "inline-block";
}

//function that shows the edit and delete buttons and hides the add button
function showEditDelete() {
    show($updateBtn);
    show($deleteBtn);
    hide($addBtn);
}

//function that shows the add button and hides the edit and delete
function showAdd() {
    show($addBtn);
    hide($updateBtn);
    hide($deleteBtn);
}

//function that clears the form
function clearForm() {
    $fname.value = "";
    $lname.value = "";
    $birthMonth.value = "Month";
    $birthYear.value = "Year";
    $birthDay.value = "Day";
    $male.checked = false;
    $female.checked = false;
    for (i = 0; i < 4; i++) {
        $genres[i].checked = false;
    }
}

//function that fills the form
function fillForm(linkId) {
    var info = actorArray[linkId];
    var a = 0;
    var b = 0;
    var c = 0;
    var d = 0;

    $fname.value = info.fname;
    $lname.value = info.lname;
    $birthMonth.value = info.birthMonth;
    $birthYear.value = info.birthYear;
    getDays();
    $birthDay.value = info.birthDay;
    $gender.value = info.gender;

    for (i = 0; i < info.genres.length; i++) {
        if ($genres[0].value === info.genres[i]) {
            $genres[0].checked = true;
            a = 1;
        } else {
            if (a === 0) {
                $genres[0].checked = false;
            }
        }
        if ($genres[1].value === info.genres[i]) {
            $genres[1].checked = true;
            b = 1;
        } else {
            if (b === 0) {
                $genres[1].checked = false;
            }
        }
        if ($genres[2].value === info.genres[i]) {
            $genres[2].checked = true;
            c = 1;
        } else {
            if (c === 0) {
                $genres[2].checked = false;
            }
        }
        if ($genres[3].value === info.genres[i]) {
            $genres[3].checked = true;
            d = 1;
        } else {
            if (d === 0) {
                $genres[3].checked = false;
            }
        }
    }
}

//function that fills the actor object and returns any errors encountered with validation
function fillActorObject() {
    var validation = {};
    var switched = 0;
    var errorHtml = "<p>";
    actorObject = {};

    if (validate($fname.value)) {
        actorObject.fname = $fname.value;
    } else {
        errorHtml += "Please fill in a first name</p><p>";
        switched = 1;
    }
    if (validate($lname.value)) {
        actorObject.lname = $lname.value;
    } else {
        errorHtml += "Please fill in a last name</p><p>";
        switched = 1;
    }
    if ($birthMonth.value === "Month") {
        errorHtml += "Please choose a birth month</p><p>";
        switched = 1;
    } else {
        actorObject.birthMonth = $birthMonth.value;
    }
    if ($birthYear.value === "Year") {
        errorHtml += "Please choose a birth year</p><p>";
        switched = 1
    } else {
        actorObject.birthYear = $birthYear.value;
    }
    if ($birthDay.value === "Day") {
        errorHtml += "Please choose a birth day</p><p>";
        switched = 1;
    } else {
        actorObject.birthDay = $birthDay.value;
    }
    if (validate($gender.value)) {
        actorObject.gender = $gender.value;
    } else {
        errorHtml += "Please check off a gender</p><p>";
        switched = 1;
    }
    actorObject.genres = [];
    for (i = 0; i < $genres.length; i++) {
        if ($genres[i].checked) {
            actorObject.genres.push($genres[i].value);
        }
    }
    if (actorObject.genres.length === 0) {
        errorHtml += "Please check off atleast one genre</p><p>";
        switched = 1;
    }

    errorHtml += "</p>";

    validation.switched = switched;
    validation.errorHtml = errorHtml;
    return validation;
}

//function that creates links
function createLink(actor, linkIndex) {
    $actors.innerHTML += "<a id='" + linkIndex + "' name='myLink' href='javascript: linkClick(" + linkIndex + ")'>" + actor.fname + " " + actor.lname + "</a><br />";
}

//function that adds a JSON string object to an array
function add(event) {
    errorHtml = "";
    $error.innerHTML = errorHtml;
    $actors.innerHTML = "";

    var validation = fillActorObject();

    if (validation.switched === 0) {
        actorArray.push(actorObject);
        stringifyObject = JSON.stringify(actorArray);
        localStorage['actors'] = stringifyObject;
    } else {
        $error.innerHTML = validation.errorHtml;
    }

    for (var index in actorArray) {
        var linkAdd = (actorArray.length - 1);
        createLink(actorArray[index], linkAdd);
    }

    $actors.innerHTML = "";

    for (var index in actorArray) {
        if (actorArray[index] != "") {
            linkIndex = index;
            createLink(actorArray[index], linkIndex);
        }
    }

    clearForm();
    event.preventDefault();
};

//function that runs when a link is clicked, it also holds the update and delete functions
function linkClick(linkId) {
    errorHtml = "";
    $error.innerHTML = errorHtml;
    $actors.innerHTML = "";

    showEditDelete();
    hide($actors);

    fillForm(linkId);
    $updateBtn.addEventListener('click', update);
    $deleteBtn.addEventListener('click', del);

    //nested function that updates a JSON string object from its container array
    function update(event) {
        errorHtml = "";
        $error.innerHTML = errorHtml;

        var validation = fillActorObject();

        if (validation.switched === 0) {
            actorArray.splice(linkId, 1, actorObject);
            stringifyObject = JSON.stringify(actorArray);
            localStorage['actors'] = stringifyObject;
            actorArray = JSON.parse(localStorage['actors']);
        } else {
            $error.innerHTML = validation.errorHtml;
        }

        for (var index in actorArray) {
            if (actorArray[index] != "") {
                linkIndex = index;
                createLink(actorArray[index], linkIndex);
            }
        }

        $updateBtn.removeEventListener('click', update);
        $deleteBtn.removeEventListener('click', del);

        showAdd();
        clearForm();
        show($actors);
        event.preventDefault();
    }

    //nested function that deletes a JSON string object in a container array
    function del(event) {
        actorArray.splice(linkId, 1);
        stringifyObject = JSON.stringify(actorArray);
        localStorage['actors'] = stringifyObject;
        actorArray = JSON.parse(localStorage['actors']);

        for (var index in actorArray) {
            if (actorArray[index] != "") {
                linkIndex = index;
                createLink(actorArray[index], linkIndex);
            }
        }

        $updateBtn.removeEventListener('click', update);
        $deleteBtn.removeEventListener('click', del);

        showAdd();
        clearForm();
        show($actors);
        event.preventDefault();
    }
}

window.onload = function () {
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

    //show the add button and hide the update and delete buttons
    showAdd();

    //fill the actor array with the local storage if it exitsts
    if (localStorage['actors'] != null) {
        actorArray = JSON.parse(localStorage['actors']);
    }

    //create links for all items in the actor array
    for (var index in actorArray) {
        if (actorArray[index] != "") {
            linkIndex = index;
            createLink(actorArray[index], linkIndex);
        }
    }

    //add event listener to the add button
    $addBtn.addEventListener('click', add);
};