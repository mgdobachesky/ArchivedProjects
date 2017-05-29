(function() {
	htmlString = "<li><a href='http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/index.php'>Home</a></li><li class='active'>Login</li>";
	document.getElementById('breadCrumbs').innerHTML = htmlString;
	$(document).ready(function(){
		$(function(){
			$('#loginForm').on('submit', function(event){
				document.getElementById('loginFeedback').innerHTML = "";
				var loginDetails = $(this).serialize();
				//console.log(signUp);
				$.ajax({
					url: "http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/index.php?action=loggingIn",
					method: "POST",
					data: loginDetails
				})
				.done(function(data){
					//console.log(data);
					if(data == ""){
                       //alert("You are now logged in. You will now be redirected to the home page.");
					   window.location.assign("http://ict.neit.edu/001264912/public_html/se251/bubbaLyrics/index.php");
                        
					} else {
						document.getElementById('loginFeedback').innerHTML = data;   
					}
                    
				});
				event.preventDefault();
			});
		});
	});
}())