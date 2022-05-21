
$(document).ready(function () {
    let getData = $('#getData');

    cookie = $.cookie('basket');
    basketIcon = $("#icon-basket");
    tableBasket = $("#tableBasket");
    basketChild = $(".basket-child");
    basketParent = $("#basket-parent")


    let basketChildImg = ("#basket-child-img")
    let basketChildName = ("#basket-child-name")

    if (cookie == null) {
        $(basketIcon).removeClass("d-none");
        $(tableBasket).addClass("d-none");
    } else {
        $(basketIcon).addClass("d-none");
        $(tableBasket).removeClass("d-none");

        cookieJson = JSON.parse(cookie);
        for (var i = 0; i < cookieJson.length; i++) {
            var newTr = document.createElement('tr')
            $(basketParent).append(newTr)
            $(newTr).html('<td><img  src="/assets/img/products/' + cookieJson[i].Image + '" style="width:50px;height:50px"/></td>'
                + '<td>' + cookieJson[i].Name + '</td>')
        }
    }






    let tableChild = ("#table-child");
    let tableChildImg = ("#basket-child-img")


    $("#basket").click(function () {
        $("#basket-toggle").toggleClass("basket-clicked");

    });

    $(document).on("click", "#addBasket", function (e) {
        e.preventDefault();
        let id = $("#product-id").val();

        //let getData = $('#getData');

        $.ajax({
            url: "/productdetail/addbasket?productId=" + id,
            type: "Post",
            success: function (data) {

                $(basketIcon).addClass("d-none");
                $(tableBasket).removeClass("d-none");


                debugger

                if (cookie != null) {
                    for (var i = 0; i < cookieJson.length; i++) {

                        if (cookieJson[i].Id == data.id) {
                            return
                        } 
                    }
                }
                var newTr = document.createElement('tr')
                $(basketParent).append(newTr)
                $(basketParent).append(newTr)
                $(newTr).html('<td><img  src="/assets/img/products/' + data.image
                                 + '" style="width:50px;height:50px"/></td>'
                                 + '<td>' + data.name + '</td>')
                
                
                
            }
        })

    })




    $(document).on('change', '.selectpicker', function (e) {
        e.preventDefault();

        window.location = $(this).find('option:selected').val();
    });



    $(document).ready(function () {
        $(".owl-carousel").owlCarousel();
    });

    $('.owl-carusel-last-seen').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 3
            },
            972: {
                items: 4
            }
        }


    })

    $('.owl-carousel-product').owlCarousel({
        loop: true,
        margin: 10,
        nav: true,
        responsive: {
            0: {
                items: 1
            },
            768: {
                items: 1
            },
            1000: {
                items: 1
            }
        }


    })




});