/**
 * Created by Michael on 3/29/2016.
 */
window.onload = function() {
    var button = document.getElementById('gridSize');
    button.onclick = function(e) {
        var randNum = [];
        var index = 0;
        var result = document.getElementById('result');
        var num = parseInt(document.getElementById('myNo').value);
        if (isNaN(num)) {
            alert("Please type a number");
        }
        var str = "<table border='1'>";
        for (var row = 0; row < num; row++) {
            str += "<tr>";
            for (var col = 0; col < num; col++) {
                randNum.push(randomNumber(1, 100));
                if(randNum[index] % 3 === 0) {
                    str += "<td style='background-color:red;'>";
                } else if(randNum[index] % 2 === 0) {
                    str += "<td style='background-color:blue;'>";
                } else {
                    str += "<td>";
                }

                str += randNum[index];
                str += "</td>";
                index++;
            }
            str+= "</tr>";
        }
        str += "</table>";

        var sum = 0;
        for (var i = 0; i < randNum.length; i++) {
            sum += randNum[i];
        }

        var average = sum / randNum.length;
        str += ("<p>The average is " + Math.floor(average) + "</p>");

        result.innerHTML = str;
    }


};

var randomNumber = function(min, max) {
    return Math.floor(Math.random() * (max - min + 1)) + min;
}