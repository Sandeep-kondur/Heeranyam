//GlobalUrl = "http://staging.heeranyam.com";
GlobalUrl = "http://localhost:35690"

function GetMaunMenus() {
    $("#MainMenu").load("/Home/RenderMenu");
}
function GetCart(id) {
    $("#CartData").load("/Home/RenderCart?id=" + id);
}
$(document).ready(function () {
    var cuid = $('#cuid').val();
    
    GetMaunMenus(); 
    GetCart(cuid);
});

 
    function ShowDelete(id) {

        swal("Are you sure?", {
            buttons: {
                yes: {
                    text: "Yes",
                    value: "yes"
                },
                no: {
                    text: "No",
                    value: "no"
                }
            }
        }).then((value) => {
            if (value === "yes") {
                $.ajax({
                    url: GlobalUrl + "/User/DeleteUserType?id=" + id,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr["success"]("Successuflly deleted!");
                        window.location.href = window.location.href;
                    }
                });
            }
            else {
                toastr["error"]("Delete cancelled!")
            }
            return false;
        });


        //swal.fire({
        //    title: 'Do you want to Delete?',
        //    showDenyButton: true,
        //    showCancelButton: true,
        //    confirmButtonText: `Delete`,
        //}).then((result) => {
        //    /* Read more about isConfirmed, isDenied below */
        //    if (result.isConfirmed) {


        //        toastr["success"]("Successuflly deleted!")
        //    } else if (result.isDenied) {

        //        toastr["error"]("You have cancelled!")
        //    }
        //});
} 

function AddToCart(prid, detid, item) {
    var userid    = $('#cuid').val();
    if (userid == 0) {
        toastr["error"]("Login first to add to cart!");
    }
    else
    {
        swal("Are you sure to add this to Cart ?", {
            buttons: {
                yes: {
                    text: "Yes",
                    value: "yes"
                },
                no: {
                    text: "No",
                    value: "no"
                }
            }
        }).then((value) => {
            if (value === "yes") {
                if (item == -1) {
                    item = $('#prdQty').val();
                }
                $.ajax({
                    url: GlobalUrl + "/Home/AddToCart?userId=" + $('#cuid').val() + "&productId=" + prid + "&detailId=" + detid + "&numberOfItems=" + item,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr["success"]("Successuflly Added!");
                        window.location.href = window.location.href;
                        var cuid = $('#cuid').val();
                        $('.notification,span').val(result.result.cartcount);
                        GetCart(cuid);

                    }
                });
            }
            else {
                toastr["error"]("Add to cart Cancelled!")
            }
            return false;
        });
    }
    

 
} 


function AddToWishList(prid, userid, detid) {
    var userid = $('#cuid').val();
    if (userid == 0) {
        toastr["error"]("Login first to add to Wishlist!");
    }
    else {
        swal("Are you sure to add this to Wishlist ?", {
            buttons: {
                yes: {
                    text: "Yes",
                    value: "yes"
                },
                no: {
                    text: "No",
                    value: "no"
                }
            }
        }).then((value) => {
            if (value === "yes") {
                 
                $.ajax({
                    url: GlobalUrl + "/Home/AddToWishlist?userId=" + $('#cuid').val() + "&productId=" + prid + "&detailId=" + detid,
                    type: 'post',
                    data: '{}',
                    success: function (result) {
                        toastr["success"]("Successuflly Added!");
                        window.location.href = window.location.href;
                    }
                });
            }
            else {
                toastr["error"]("Add to cart Cancelled!")
            }
            return false;
        });
    }



} 