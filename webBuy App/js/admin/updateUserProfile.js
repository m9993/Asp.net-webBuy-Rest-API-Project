$(document).ready(()=>{
    // $('#sidemenu').click();
    var userProfile=JSON.parse(Cookies.get('userProfile'));
    $("input[name='email']" ).val(userProfile.email);
    $("input[name='name']" ).val(userProfile.name);
    $("input[name='phone']" ).val(userProfile.phone);
    $("input[name='address']" ).val(userProfile.address);
    $("#role").val(userProfile.role);
    $("#userStatus").val(userProfile.userStatus);

    $("#submitUpdateUserProfile").click(()=>{
        
        $.ajax({
            url:"http://localhost:59162/api/admin/UpdateUserProfile",
            headers:{
                "Authorization":"Basic "+btoa(""+JSON.parse(Cookies.get('userProfile')).email+":"+JSON.parse(Cookies.get('userProfile')).password+"")
            },
            method:"put",
            data:{
                "userId": userProfile.userId,
                "email": $("input[name='email']" ).val(),
                "name":  $("input[name='name']" ).val(),
                "password": userProfile.password,
                "phone":$("input[name='phone']" ).val(),
                "address": $("input[name='address']" ).val(),
                "role": $("#role").val(),
                "userStatus": $("#userStatus").val()
            },
            complete:(xmlHttp,status)=>{
                if(xmlHttp.status==200)
                {
                    userProfile.email=$("input[name='email']" ).val();
                    userProfile.name=$("input[name='name']" ).val();
                    userProfile.phone=$("input[name='phone']" ).val();
                    userProfile.address=$("input[name='address']" ).val();
                    userProfile.role=$("#role").val();
                    userProfile.userStatus=$("#userStatus").val();
                    Cookies.set('userProfile', JSON.stringify(userProfile))

                    $("#body").load("../admin/home.html");
                    $("#title").html("Home");
                    $("#nav-name").html(JSON.parse(Cookies.get('userProfile')).name);
                    $("#error-msg").addClass("alert-success");
                    $("#error-msg").html("Profile Updated");
                }
                else
                {
                    $("#error-msg").addClass("alert-warning");
                    $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
                }
            }
        });    
    });
});