/**
 * Created by 001264912 on 4/25/2016.
 */
$(function() {
   //alert("hi");
    var list = [];
   $('#button').click(function(){
       //alert("hi");
      var item = $('#item').val();
       //alert(item);
       if (item != "") {
           list.push(item);
       }
       //alert(list.length);
       if($('ul').length === 0) {
           $('<ul></ul>').appendTo('#list');
       }
       $('<li>' + item + '</li>').appendTo('ul');

       //alert(JSON.stringify(list));
       localStorage['list'] = (JSON.stringify(list));
       alert(localStorage['list']);
   });

    //fname = window.localStorage.getItem("fName");
    //fname = localStorage["fName"];
    //localStorage.setItem('fName', 'Mike');
    //localStorage['fName'] = "Mike";


    /*if(!localStorage['person']) {
        alert("Nothing Here!");
        var person = {};
        person.fname = "Mike";
        person.lname = "Dobachesky";
        person.age = 24;
        localStorage['person'] = (JSON.stringify(person));
    }
    alert(localStorage['person']);*/
    var arr = ["Mike", "Dobachesky", 24];
    localStorage["stringed"] = JSON.stringify(arr);
    var foo = JSON.parse(localStorage["stringed"]);
    alert(foo.length);



});