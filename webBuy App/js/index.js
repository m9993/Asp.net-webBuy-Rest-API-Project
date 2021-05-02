//load 5 Last Added Products
$.ajax({
    url:"http://localhost:59162/api/admin/GetLastAddedProducts/5",
    method:"get",
    data:{
    },
    complete:(xmlHttp,status)=>{
        if(xmlHttp.status==200)
        {
            $("#title").html("Index");
            var products=xmlHttp.responseJSON;
                var str='';
                var countLastAddedProducts=0;
                var strCountLastAddedProducts='';
                products.forEach ((item)=>{
                    countLastAddedProducts++;
                    strCountLastAddedProducts+="<li data-target='#carouselExampleIndicators' data-slide-to='"+countLastAddedProducts+"'></li>";
                    var data="<div class='carousel-item'>"+
                                "<img style='height: 35rem;opacity: 0.3; -webkit-filter: blur(3px);' src='/webBuy App/src/products/"+item.image+"' class='d-block w-100' alt='...'>"+
                                "<div class='carousel-caption d-none d-md-block mb-4' style='background-color:#22222275;margin-left:20rem;margin-right:20rem'"+
                                    "<h3>New Arrival</h3>"+
                                    "<p class='text-info h5'>"+item.name+"</p>"+
                                    "<p class='text-danger h4'>"+item.unitPrice+" Taka</p>"+
                                "</div>"+
                            "</div>";
                    str+=data;                    
                });
                $("#countLastAddedProducts").append(strCountLastAddedProducts);
                $("#lastAddedProducts").append(str);
        }
        else
        {
            $("#error-msg").addClass("alert-warning");
            $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
        }
    }
}); 


//load Products
$.ajax({
    url:"http://localhost:59162/api/admin/GetAllcategoryProductShopWithAverageRatingView",
    method:"get",
    data:{
    },
    complete:(xmlHttp,status)=>{
        if(xmlHttp.status==200)
        {
            $("#title").html("Index");
            var products=xmlHttp.responseJSON;
                var str='';
                products.forEach ((item)=>{
                    var productStatus='';
                    if(item.productStatus==1){
                        productStatus='Available';
                    }
                    else{
                        productStatus='Not available';
                    }
                    var rating='';
                    for(var i=0; i<item.rating; i++){rating+="<i class='fas fa-star'></i>";}
                    var emptyRating='';
                    for(var i=0; i<5-item.rating; i++){emptyRating+="<i class='far fa-star'></i>";}


                    var data="<div class='card bg-dark m-4' style='width: 16rem;'>"+
                        "<img class='card-img-top m-3 mb-0 w-50' src='/webBuy App/src/products/"+item.productImage+"' alt='Card image cap'>"+
                        "<div class='card-body'>"+
                        "<h5 class='card-title'>"+item.productName+"</h5>"+
                        "<p class='card-text  my-0 py-0'><b>Price: </b> "+item.unitPrice+" $</p>"+
                        "<p class='card-text my-0 py-0'><b>Available:</b> "+item.quantity+"</p>"+
                        "<p class='card-text my-0 py-0'><b>Status: </b> <span class='text-danger'>"+productStatus+"</span></p>"+
                        "<p class='card-text  my-0 py-0'><b>Rating:</b> <span class='text-warning'>"+rating+emptyRating+"</span></p>"+
                        "<p class='card-text my-0 py-0'><b>Last Updated:</b> "+item.productAddedDate+"</p>"+
                        "</div>"+
                        "</div>";
                    str+=data;                    
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

//search Products
$('#searchKey').keyup(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/SerachProduct/"+$('#searchKey').val(),
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $("#title").html("Index");
                var products=xmlHttp.responseJSON;
                    var str='';
                    products.forEach ((item)=>{
                        var productStatus='';
                        if(item.productStatus==1){
                            productStatus='Available';
                        }
                        else{
                            productStatus='Not available';
                        }
                        var rating='';
                        for(var i=0; i<item.rating; i++){rating+="<i class='fas fa-star'></i>";}
                        var emptyRating='';
                        for(var i=0; i<5-item.rating; i++){emptyRating+="<i class='far fa-star'></i>";}
    
    
                        var data="<div class='card bg-dark m-4' style='width: 16rem;'>"+
                            "<img class='card-img-top m-3 mb-0 w-50' src='/webBuy App/src/products/"+item.productImage+"' alt='Card image cap'>"+
                            "<div class='card-body'>"+
                            "<h5 class='card-title'>"+item.productName+"</h5>"+
                            "<p class='card-text  my-0 py-0'><b>Price: </b> "+item.unitPrice+" $</p>"+
                            "<p class='card-text my-0 py-0'><b>Available:</b> "+item.quantity+"</p>"+
                            "<p class='card-text my-0 py-0'><b>Status: </b> <span class='text-danger'>"+productStatus+"</span></p>"+
                            "<p class='card-text  my-0 py-0'><b>Rating:</b> <span class='text-warning'>"+rating+emptyRating+"</span></p>"+
                            "<p class='card-text my-0 py-0'><b>Last Updated:</b> "+item.productAddedDate+"</p>"+
                            "</div>"+
                            "</div>";
                        str+=data;                    
                    });
                    $("#productCart").html(str);
                    if(products==''){$("#productCart").html("<span class='text-danger'>No products!</span>");}
                  
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 
});