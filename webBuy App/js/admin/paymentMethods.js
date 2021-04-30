$(document).ready(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/GetPaymentMethods",
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
                            item.paymentMethod+
                        "</td>"+
                        "<td>"+
                            item.deliveryCharge+
                        "</td>"+
                        "<td>"+
                            "<a class='text-warning px-2 h5' href='#' onclick='editPaymentMethod("+item.paymentId+")'><i class='fas fa-edit'></i></a>|"+
                            "<a class='text-danger px-2 h5' href='#' onclick='deletePaymentMethod("+item.paymentId+")'><i class='fas fa-trash-alt'></i></a>"+
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
function editPaymentMethod(id){
    $.ajax({
        url:"http://localhost:59162/api/admin/GetPaymentMethod/"+id,
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var data= xmlHttp.responseJSON;
                $('#editPaymentMethod').val(data.paymentMethod);
                $('#editDeliveryCharge').val(data.deliveryCharge);
                $('#PaymentMethodEdit').modal('show');

                $('#submitEditPaymentMethod').click(()=>{
                    //update
                    $.ajax({
                        url:"http://localhost:59162/api/admin/PaymentMethodEdit",
                        method:"put",
                        data:{
                            "paymentId": data.paymentId,
                            "paymentMethod": $('#editPaymentMethod').val(),
                            "deliveryCharge": $('#editDeliveryCharge').val()
                        },
                        complete:(xmlHttp,status)=>{
                            if(xmlHttp.status==200)
                            {
                                $('#PaymentMethodEdit .close').click();
                                $("#error-msg").addClass("alert-success");
                                $("#error-msg").html(" Payment method updated");
                                setTimeout(function() {
                                    $("#title").html("Payment Methods");
                                    $("#body").load("../admin/PaymentMethods.html");
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



// delete
function deletePaymentMethod(id){
    $.ajax({
        url:"http://localhost:59162/api/admin/PaymentMethodDelete/"+id,
        method:"delete",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(" Payment method deleted");
                setTimeout(function() {
                    $("#title").html("Payment Methods");
                    $("#body").load("../admin/PaymentMethods.html");
                    }, 1000);
            }
            else
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html(xmlHttp.status+":"+xmlHttp.statusText);
            }
        }
    }); 
}


//add
$('#submitAddPaymentMethod').click(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/PaymentMethodAdd",
        method:"post",
        data:{
            "paymentId":1,
            "paymentMethod": $('#addPaymentMethod').val(),
            "deliveryCharge": $('#addDeliveryCharge').val()
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $('#PaymentMethodAdd .close').click();
                $("#error-msg").addClass("alert-success");
                $("#error-msg").html(" Payment method added");
                setTimeout(function() {
                    $("#title").html("Payment Methods");
                    $("#body").load("../admin/PaymentMethods.html");
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
