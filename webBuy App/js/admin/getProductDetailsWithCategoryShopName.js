function urlId( id){
    //rating 
    $.ajax({
        url:"http://localhost:59162/api/admin/GetProductRating/"+id+"",
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                //chart
                var ctx = document.getElementById('myChart').getContext('2d');
                var myChart = new Chart(ctx, {
                    type: 'doughnut',
                    data: {
                        labels: ['1✮ |', '2✮ |', '3✮ |', '4✮ |', '5✮'],
                        datasets: [{
                            label: 'Reviews',
                            data: xmlHttp.responseJSON,
                            backgroundColor: [
                                'rgb(255, 99, 132)',
                                'rgb(54, 162, 235)',
                                'rgb(255, 205, 86)',
                                'rgb(54, 150, 155)',
                                'rgb(200, 24, 50)'
                            ],
                            borderColor: [
                                'rgb(255, 99, 132)',
                                'rgb(54, 162, 235)',
                                'rgb(255, 205, 86)',
                                'rgb(54, 150, 155)',
                            ],
                            borderWidth: 1
                        }]
                    },
                    options: {}
                });
                //chart
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 

    //details
    $.ajax({
        url:"http://localhost:59162/api/admin/GetProductDetailsWithCategoryShopName/"+id+"",
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $('#productImage').attr("src", "/webBuy App/src/products/"+xmlHttp.responseJSON.productImage);

                $("#productName").html(xmlHttp.responseJSON.productName);
                $("#unitPrice").html(xmlHttp.responseJSON.unitPrice+ ' Taka');
                $("#quantity").html(xmlHttp.responseJSON.quantity);
                $("#categoryName").html(xmlHttp.responseJSON.categoryName);
                if(xmlHttp.responseJSON.productStatus==1){
                    $("#productStatus").html('Available');
                }else{
                    $("#productStatus").html('Not available');
                }
                
                $("#shopName").html(xmlHttp.responseJSON.shopName);
                $("#productAddedDate").html(xmlHttp.responseJSON.productAddedDate);
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 




    $("#title").html("Product with Rating Shop name");
	$("#body").load("../admin/ProductDetailsWithRatingShopName.html");
}