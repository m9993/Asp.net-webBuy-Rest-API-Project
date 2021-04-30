$(document).ready(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/GetCategories",
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
                            "<a class='text-warning px-2 h5' href='#' onclick='editCategory("+item.categoryId+")'><i class='fas fa-edit'></i></a>|"+
                            "<a class='text-danger px-2 h5' href='#' onclick='deleteCategory("+item.categoryId+")'><i class='fas fa-trash-alt'></i></a>"+
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
function editCategory(id){
    $.ajax({
        url:"http://localhost:59162/api/admin/GetCategory/"+id,
        method:"get",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                var data= xmlHttp.responseJSON;
                $('#editName').val(data.name);
                $('#CategoryEdit').modal('show');

                $('#submitCategoryEdit').click(()=>{
                    //update
                    $.ajax({
                        url:"http://localhost:59162/api/admin/CategoryEdit",
                        method:"put",
                        data:{
                            "categoryId": data.categoryId,
                            "name": $('#editName').val()
                        },
                        complete:(xmlHttp,status)=>{
                            if(xmlHttp.status==200)
                            {
                                $('#CategoryEdit .close').click();
                                $("#error-msg").addClass("alert-success");
                                $("#error-msg").html("Category updated");
                                setTimeout(function() {
                                    $("#title").html("Categories");
                                    $("#body").load("../admin/Categories.html");
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
function deleteCategory(id){
    $.ajax({
        url:"http://localhost:59162/api/admin/CategoryDelete/"+id,
        method:"delete",
        data:{
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $("#error-msg").addClass("alert-warning");
                $("#error-msg").html("Category deleted");
                setTimeout(function() {
                    $("#title").html("Categories");
                    $("#body").load("../admin/Categories.html");
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
$('#submitCategoryAdd').click(()=>{
    $.ajax({
        url:"http://localhost:59162/api/admin/CategoryAdd",
        method:"post",
        data:{
            "categoryId":1,
            "name": $('#addName').val()
        },
        complete:(xmlHttp,status)=>{
            if(xmlHttp.status==200)
            {
                $('#CategoryAdd .close').click();
                $("#error-msg").addClass("alert-success");
                $("#error-msg").html("Category added");
                setTimeout(function() {
                    $("#title").html("Categories");
                    $("#body").load("../admin/Categories.html");
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
