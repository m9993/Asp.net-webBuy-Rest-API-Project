$(document).ready(function(){
	
	if(Cookies.get('userProfile')==undefined){
		$(location). attr('href',"/webBuy App");
		$("#error-msg").addClass("alert-danger");
		$("#error-msg").html("Please login  first");
	}else{
		$("#nav-name").html(JSON.parse(Cookies.get('userProfile')).name);
		$("#title").html("Home");
		$("#body").load("../admin/home.html");

		$("#UpdateUserProfile").click(()=>{
			$("#title").html("Update Profile");
			$("#body").load("../admin/UpdateUserProfile.html");
		});
		
		

		// $("#a").click(()=>{
		// 	$("#error-msg").addClass("alert-danger");
		// 	$("#error-msg").html("alert-danger");
		// });
	}
	
})