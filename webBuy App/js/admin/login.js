$(document).ready(()=>{
    $( "#login" ).click(()=>{
        var email=$("input[name='email']" ).val();
        var password= $("input[name='password']" ).val();
        $.ajax({
            url:"http://localhost:59162/api/login",
            headers:{
                "Authorization":"Basic "+btoa(""+email+":"+password+"")
            },
            method:"get",
            data:{
                "email": email,
                "password": password
            },
            complete:(xmlHttp,status)=>{
                if(xmlHttp.status==200)
                {
                    var data=xmlHttp.responseJSON;
                    if(data.role=="admin"){
                        Cookies.set('userProfile', JSON.stringify(data));
                        $(location). attr('href',"views/layout/_adminLayout.html");
                    }
                    else{
                        alert(data.role);
                    }
                }
                else
                {
                    $("#error-msg").addClass("alert-danger");
                    $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
                }
            }
        });    

    
    });
    
    
    
});
    
        