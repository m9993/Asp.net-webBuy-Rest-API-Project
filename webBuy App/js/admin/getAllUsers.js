$(document).ready(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/GetAllUsers",
        method:"get",
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var getData=xmlHttp.responseJSON;
                var str='';
                getData.forEach( function(item){
                    var userStatus='';
                    var action='';
                    if (item.userStatus==0) {userStatus='Banned';}else {userStatus='Unbaned';};
                    if (item.userStatus == 1)
                    {
                        action="<a class='text-success h4 mx-1' href='#' onclick='banUser("+item.userId+")'><i class='fas fa-check-circle'></i></a>";
                    }else
                    {
                        action="<a class='text-danger h4 mx-1' href='#' onclick='unbanUser("+item.userId+")'><i class='fas fa-ban'></i></a>";
                    }

                    var value="<tr>"+
                        "<td>"+
                            item.email+
                        "</td>"+
                        "<td>"+
                           item.name+
                        "</td>"+
                        "<td>"+
                           item.phone+
                        "</td>"+
                        "<td>"+
                            item.address+
                        "</td>"+
                        "<td>"+
                            item.role+
                        "</td>"+
                        "<td>"+
                            userStatus+
                        "</td>"+
                        "<td>"+
                            action+
                        "</td>"+
                   "</tr>";
                   str+=value;
                });
                $("#tbody").html(str);
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    });    
});