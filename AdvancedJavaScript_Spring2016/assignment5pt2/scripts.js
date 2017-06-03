/**
 * Created by Michael on 4/29/2016.
 */
var name = "";
var peopleArray = [];
 
var getPeople = function() {
	peopleArray = [];
	var url = "http://jsonplaceholder.typicode.com/users";
	$.getJSON(url, {action:"/"}, function(people){
		for(var i = 0; i < people.length; i++) {
			peopleArray.push(people[i].name);
		}
		getList();
	});
} 
 
var getName = function(id) {
	var url = "http://jsonplaceholder.typicode.com/users";
	$.getJSON(url, {action:"/"}, function(names){
		for(var i = 0; i < names.length; i++) {
			if(names[i].id == id) {
				name = names[i].name;
			}
		}
		getItems(id);
	});
}

var getList = function() {
    var htmlString = "";
    var url = "http://jsonplaceholder.typicode.com/todos";
    $.getJSON(url, {action:"/"}, function(list){
        var users = 0;
        for (var i = 0; i < list.length; i++) {
            users = list[i].userId;
        }
		
		htmlString += "<h1>To Do Lists</h1>";
        for(var i = 1; i <= users; i++) {
            htmlString += "<a href='javascript:getName(" + i + ");'>" + "To Do List for " + peopleArray[i-1] + "</a><br /><br />";
        }
        $('#items').html(htmlString);
    });
}

var getItems = function(id) {
    var htmlString = "";
    var completed;
    var url = "http://jsonplaceholder.typicode.com/todos?userId=" + id;
    $.getJSON(url, {action:"/"}, function(items){
		htmlString += "<h1>" + "To Do List for " + name + "</h1>";
        htmlString += "<ul>";
        for (var i = 0; i < items.length; i++) {
            if (items[i].completed) {
                completed = "<span class='blue'>Done: </span>";
            } else {
                completed = "<span class='red'>In Progress: </span>";
            }
            htmlString += "<li>" + completed + items[i].title + "</li><br />";
            console.log(items[i].title);
        }
        htmlString += "</ul>";
		htmlString += "<a href='javascript:getList();'>" + "Home" + "</a><br />";
        $('#items').html(htmlString);
    });
}

$(document).ready(function(){
	getPeople();
});

