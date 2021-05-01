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
			$('#sideMenuButton').click();
			$("#title").html("Banned Users");
			$("#body").load("../admin/Users.html");
			$('<script>').attr({
				src: '../../js/admin/getBannedUsers.js',
				type: 'text/javascript'}).appendTo('body');
		});
		$("#GetAllUsers").click(()=>{
			$('#sideMenuButton').click();
			$("#title").html("All Users");
			$("#body").load("../admin/Users.html");
			$('<script>').attr({
				src: '../../js/admin/getAllUsers.js',
				type: 'text/javascript'}).appendTo('body');
		});
		$("#GetAllProductReviews").click(()=>{
			$('#sideMenuButton').click();
			$("#title").html("Product Reviews");
			$("#body").load("../admin/ProductReviews.html");
		});
		$("#PaymentMethods").click(()=>{
			$('#sideMenuButton').click();
			$("#title").html("Payment Methods");
			$("#body").load("../admin/PaymentMethods.html");
		});
		$("#GetCategories").click(()=>{
			$('#sideMenuButton').click();
			$("#title").html("Categories");
			$("#body").load("../admin/Categories.html");
		});
		$("#AllShops").click(()=>{
			$('#sideMenuButton').click();
			$("#title").html("All Shops");
			$("#body").load("../admin/AllShops.html");
		});
		

		// $("#a").click(()=>{
		// 	$("#error-msg").addClass("alert-danger");
		// 	$("#error-msg").html("alert-danger");
		// });
	}
	
});