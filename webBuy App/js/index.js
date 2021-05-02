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