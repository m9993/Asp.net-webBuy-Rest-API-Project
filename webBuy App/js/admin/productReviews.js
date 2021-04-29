$(document).ready(function(){
    $.ajax({
        url:"http://localhost:59162/api/admin/GetAllProductReviews",
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var str='';
                xmlHttp.responseJSON.forEach( function(item){
                    data="<tr>"+
                        "<th scope='row'>" +item.productId+"</th>"
                        +"<td>"+item.productName+"</td>"
                        + "<td>" + item.review+"</td>"
                        + "<td>" + item.rating+"</td>"
                        + "<td>" + item.userId+"</td>"
                        + "<td>" + item.shopName+"</td>"
                        + "<td><a href='#' onclick='sendUrlId(" +item.productId+")'>Details</a></td>"
                    "</tr>";
                    str+=data;
                });

                $('tbody').html(str);
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 
    
    //sort
    $("#orderBy").change(function () {
        $.ajax({
            url:"http://localhost:59162/api/admin/GetAllProductReviewsOrderByDesc/"+$("#orderBy").val()+"",
            method:"get",
            data:{
            },
            complete:(xmlHttp,status)=>{
                if(xmlHttp.status==200)
                {
                    var str='';
                    xmlHttp.responseJSON.forEach( function(item){
                        data="<tr>"+
                            "<th scope='row'>" +item.productId+"</th>"
                            +"<td>"+item.productName+"</td>"
                            + "<td>" + item.review+"</td>"
                            + "<td>" + item.rating+"</td>"
                            + "<td>" + item.userId+"</td>"
                            + "<td>" + item.shopName+"</td>"
                            + "<td><a href='#' onclick='sendUrlId(" +item.productId+")'>Details</a></td>"
                        "</tr>";
                        str+=data;
                    });
    
                    $('tbody').html(str);
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