/**
 * Created by calexande on 4/28/2016.
 */
function getUsers() {
    var str = "";
    var url = "http://jsonplaceholder.typicode.com/users";
    $.getJSON( url, {action:"/"}, function(users){
        str += "<ul>";
        for(i=0; i<users.length; i++) {
           str += "<li>" + users[i].address.zipcode + "</li>";
        }
        str += "</ul>";
        $('#results').html(str);
    });

}

$(function(){
    getUsers();
});