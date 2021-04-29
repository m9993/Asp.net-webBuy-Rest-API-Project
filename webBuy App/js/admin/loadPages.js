$(document).ready(function(){
	$("#modalUpdateUserProfile").load("../admin/UpdateUserProfile.html");

	if(Cookies.get('userProfile')==undefined){
		$(location). attr('href',"/webBuy App");
		$("#error-msg").addClass("alert-danger");
		$("#error-msg").html("Please login  first");
	}else{
		$("#nav-name").html(JSON.parse(Cookies.get('userProfile')).name);
		$("#title").html("Home");
		$("#body").load("../admin/home.html");

		// $("#UpdateUserProfile").click(()=>{
		// 	$("#title").html("Update Profile");
		// 	$("#body").load("../admin/UpdateUserProfile.html");
		// });
		$("#GetBannedUsers").click(()=>{
			$("#title").html("Banned Users");
			$("#body").load("../admin/Users.html");
			$('<script>').attr({
				src: '../../js/admin/getBannedUsers.js',
				type: 'text/javascript'}).appendTo('body');
		});
		$("#GetAllUsers").click(()=>{
			$("#title").html("All Users");
			$("#body").load("../admin/Users.html");
			$('<script>').attr({
				src: '../../js/admin/getAllUsers.js',
				type: 'text/javascript'}).appendTo('body');
		});
		$("#GetAllProductReviews").click(()=>{
			$("#title").html("Product Reviews");
			$("#body").load("../admin/ProductReviews.html");
		});
		

		// $("#a").click(()=>{
		// 	$("#error-msg").addClass("alert-danger");
		// 	$("#error-msg").html("alert-danger");
		// });
	}
	
})