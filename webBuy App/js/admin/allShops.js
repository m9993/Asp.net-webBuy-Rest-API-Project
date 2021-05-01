$(document).ready(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/GetShops",
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var str='';
                xmlHttp.responseJSON.forEach( function(item){
                    data = "<tr>"+
                        "<td>"+
                            item.name+
                        "</td>"+
                        "<td>"+
                            item.email+
                        "</td>"+
                        "<td>"+
                            item.shopStatus+
                        "</td>"+
                        "<td>"+
                            item.balance+
                        "</td>"+
                        "<td>"+
                            item.setComission+
                        "</td>"+
                        "<td>"+
                            "<a class='text-warning px-2 h5' href='#' onclick='editShop("+item.shopId+")'><i class='fas fa-edit'></i></a> | "+
                            "<a class='px-2' href='#' onclick='viewShopProducts("+item.shopId+")'>View Products</a>"
                        "</td>"+
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


// edit
function editShop(id){
    $.ajax({
        url:"http://localhost:59162/api/admin/GetShop/"+id,
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var data= xmlHttp.responseJSON;
                $('#setComission').val(data.setComission);
                $('#shopStatus').val(data.shopStatus);
                $('#ShopEdit').modal('show');

                $('#submitShopEdit').click(()=>{
                    //update
                    $.ajax({
                        url:"http://localhost:59162/api/admin/ShopUpdate",
                        method:"put",
                        data:{
                            "shopId": data.shopId,
                            "name": data.name,
                            "email": data.email,
                            "shopStatus": $('#shopStatus').val(),
                            "balance": data.balance,
                            "setComission": $('#setComission').val()
                        },
                        complete:(xmlHttp,status)=>{
                            if(xmlHttp.status==200)
                            {
                                $('#ShopEdit .close').click();
                                $("#error-msg").addClass("alert-success");
                                $("#error-msg").html("Shop updated");
                                setTimeout(function() {
                                    $("#title").html("All Shops");
                                    $("#body").load("../admin/AllShops.html");
                                  }, 1000);
                            }
                            else
                            {
                                $("#error-msg").addClass("alert-warning");
                                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
                            }
                        }
                    }); 
                });

            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 
}


// view shop products
function viewShopProducts(id){
    $("#title").html("Shop Products");
    $("#body").load("../admin/ShopProducts.html");
    $.ajax({
        url:"http://localhost:59162/api/admin/GetProducts",
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var products=xmlHttp.responseJSON;
                str='';
                products.forEach ((item)=>{
                    if(item.productId==id){
                        var productStatus='';
                        if(item.productStatus==1){
                            productStatus='Available';
                        }
                        else{
                            productStatus='Not available';
                        }
                        var data="<div class='card bg-dark m-2' style='width: 16rem;'>"+
                        "<img class='card-img-top mt-3 col-md-6' src='/webBuy App/src/products/"+item.image+"' alt='Card image cap'>"+
                        "<div class='card-body'>"+
                            "<h5 class='card-title'>"+item.name+"</h5>"+
                            "<p class='card-text  my-0 py-0'><b>Price: </b> "+item.unitPrice+" $</p>"+
                            "<p class='card-text my-0 py-0'><b>Available:</b> "+item.quantity+"</p>"+
                            "<p class='card-text my-0 py-0'><b>Status: </b> <span class='text-danger'>"+productStatus+"</span></p>"+
                            "<p class='card-text my-0 py-0'><b>Last Updated:</b> "+item.date+"</p>"+
                        "</div>"+
                    "</div>";
                    str+=data;
                    }
                });
                $("#productCart").html(str);
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 

    
    
    
}