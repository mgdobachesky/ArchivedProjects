var days = ["Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"];

function calendar(month, year) {
	var firstDay = month + "/1/" + year;
	var firstDate = new Date(firstDay);
	var monthDays = cuantosDias(firstDate);
	var firstOfMonth = firstDate.getDay();
	
	var htmlCode = "<table id='rad'>";
	var displayDay = 0;
	
	htmlCode += "<tr>";
	
	for(var blank = 0; blank < firstOfMonth; blank++) {
		htmlCode += "<td class='blank'></td>";
	}

	for(var i = 1; i <= monthDays; i++) {
		htmlCode += "<td class='day'>" + i + "</td>";
		if((i+blank) % 7 === 0) {
			htmlCode += "</tr><tr>";
		}
	}
	htmlCode += "</tr>";
	
	htmlCode += "</table>";
	
	$("#results").html(htmlCode);
	
	$("#rad").delegate(".day", "click", function(event){
		if($(this).hasClass("green") || $(this).hasClass("greenAll")){
			$(this).removeClass("green");
			$(this).removeClass("greenAll");
			$(this).addClass("red");
		} else if ($(this).hasClass("red") || $(this).hasClass("redAll")) {
			$(this).removeClass("red");
			$(this).removeClass("redAll");
			$(this).removeClass("green");
			$(this).removeClass("greenAll");
		} else {
			$(this).removeClass("red");
			$(this).removeClass("redAll");
			$(this).addClass("green");
		}
	});
	
	$("#yes").click(function(event){
		$(".day").removeClass("red");
		$(".day").removeClass("green");
		$(".day").removeClass("redAll");
		if(!$(".day").hasClass("greenAll")) {
			$(".day").toggleClass("greenAll");
		} else {
			$(".day").removeClass("greenAll");
		}
		
	});
	var green = function () {
		
	}
	$("#no").click(function(event){
		$(".day").removeClass("green");
		$(".day").removeClass("red");
		$(".day").removeClass("greenAll");
		if(!$(".day").hasClass("redAll")) {
			$(".day").toggleClass("redAll");
		} else {
			$(".day").removeClass("redAll");
		}
	});
}

function cuantosDias(firstDate){
	return new Date(firstDate.getYear(), firstDate.getMonth()+1, 0).getDate();
}

$(document).ready(function(){
	var date = new Date();
	var month = date.getMonth()+1;
	var year = date.getFullYear();
	
	$("#month").val(month);
	$("#year").val(year);
	
	calendar(month, year);
	
	$("#month, #year").click(function(event){
		calendar($("#month").val(), $("#year").val());
	});
	
});