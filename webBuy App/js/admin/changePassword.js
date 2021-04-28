$(document).ready(()=>{
    $( "#submitChangePassword").click(()=>{
        $.ajax({
            url:"http://localhost:59162/api/admin/ChangePassword/"+JSON.parse(Cookies.get('userProfile')).userId+"",
            headers:{
                "Authorization":"Basic "+btoa(""+JSON.parse(Cookies.get('userProfile')).email+":"+JSON.parse(Cookies.get('userProfile')).password+"")
            },
            method:"put",
            data:{
                "OldPassword": $("#oldPassword").val(),
                "newPassword": $("#newPassword").val(),
                "confirmNewPassword": $("#confirmNewPassword").val()
            },
            complete:(xmlHttp,status)=>{
                if(xmlHttp.status==200)
                {
                    var userProfile=JSON.parse(Cookies.get('userProfile'));
                    userProfile.password=$("#newPassword").val();
                    Cookies.set('userProfile', JSON.stringify(userProfile))

                    $("#error-msg").addClass("alert-success");
                    $("#error-msg").html("Password Changed");
                }
                else
                {
                    $("#error-msg").addClass("alert-warning");
                    $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
                }
                $('#ChangePassword .close').click();
            }
        });    
    });
});