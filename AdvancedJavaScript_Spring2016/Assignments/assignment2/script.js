/**
 * Created by Michael on 4/4/2016.
 */

var randomNum = function (number) {
	return Math.floor(number * Math.random()) +1;
}

var randomOperation = function() {
	var oneToFour;
	
	oneToFour = Math.floor(4 * Math.random()) +1;
	if (oneToFour === 1) {
		return "+";
	}
	else if (oneToFour === 2) {
		return "-";
	}
	else if (oneToFour === 3) {
		return "*";
	}
	else {
		return "/";
	}
}

var randomEquation = function (randomNum, randomOperation){
	var first, operator, second, problem, solution, equation;
	
	first = randomNum(100);
	operator = randomOperation();
	second = randomNum(10);
	
	problem = first + " " + operator + " " + second;

	if (operator === "+") {
		solution = eval(first.toString() + "+" + second.toString());
	}
	else if (operator === "-") {
		solution = eval(first.toString() + "-" + second.toString());
	}
	else if (operator === "*") {
		solution = eval(first.toString() + "*" + second.toString());
	}
	else {
		solution = eval(first.toString() + "/" + second.toString());
	}
	
	solution = Math.round(solution * 100) / 100;
	equation = [problem, solution];
	return equation;
}
var mathProblems = [], equation;

for (var i = 0; i < 20; i++) {
	equation = randomEquation(randomNum, randomOperation);
mathProblems.push({problem: equation[0], answer: equation[1] });
}

var displayProblems = function(problems) {
    var i = 0, problems, col, row;
    var htm = "<table class='table-condensed'>";

    for (col = 0; col < 5; col++) {
        htm += "<tr>";
        for (row = 0; row < 4; row++) {
               htm += "<td><td style='text-align: right' id='mathNums_" + i + "'>" + mathProblems[i].problem + "</td><td><input type='text' class='solution' id='solution_" + i + "' /></td></td>";
               //htm += "<td></td>";
            i++;
        }
        htm += "</tr>";
    }

    htm += "</table>";

    document.getElementById("problems").innerHTML = htm;
}

var numberCorrect = function () {
    var i, right = 0, answer;
    for (i = 0; i < mathProblems.length; i++) {
        answer = document.getElementById("solution_" + i).value;
        if (parseFloat(answer) === mathProblems[i].answer) {
            right++;
			wrong = document.getElementById("mathNums_" + i); 
			wrong.classList.remove("wrong");
        	wrong.classList.add("right");
        }
         else {
        	wrong = document.getElementById("mathNums_" + i); 
			wrong.classList.remove("right");
        	wrong.classList.add("wrong");
        }
    }
    return right;
}

var totalScore = function (correct) {
    return correct * 5;
}

var summary = function (right, score) {
    return "<p>You answered " + right + " out of " + mathProblems.length + " questions correctly. Grade: " + score + ".</p>";
}

window.onload = function() {
    displayProblems();

    document.getElementById("checkAnswers").onclick = function () {
        var right, score, para;
        right = numberCorrect();
        score = totalScore(right);
        para = summary(right, score);

        document.getElementById("grade").innerHTML = para;
    }
}