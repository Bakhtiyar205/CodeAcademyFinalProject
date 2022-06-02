
$(document).ready(function () {
    let getData = $('#getData');

    //cookie
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
    }
    else {
        $(basketIcon).addClass("d-none");
        $(tableBasket).removeClass("d-none");

        cookieJson = JSON.parse(cookie);

        if (cookieJson.length == 0) {
            $(basketIcon).removeClass("d-none");
            $(tableBasket).addClass("d-none");
        }

        for (var i = 0; i < cookieJson.length; i++) {
            var newTr = document.createElement('tr')
            $(basketParent).append(newTr)
            $(newTr).html('<td><img  src="/assets/img/products/' + cookieJson[i].Image + '" style="width:50px;height:50px"/></td>'
                + '<td>' + cookieJson[i].Name + '</td>')
        }
    }



    //search-field
    let searchClick = $("#search-click");
    let searhcField = $(".search-field");
    let searchNoProduct = $("#searchNoProduct");
    let searchProducts = $(".search-products");
    let searchProductHeader = $(".search-product-header");
    let searchTable = $("#table-search");

    $(searchClick).click(function (e) {
        e.preventDefault();

        $(searhcField).toggleClass("d-none")

    });

    $(searchClick).on('keyup',function (e) {
        e.preventDefault();

        $(searchNoProduct).addClass("d-none");
        $(searchProducts).removeClass("d-none");
        $(searchProductHeader).removeClass("d-none");

        $.ajax({
            url: "/search/products?search=" + searchClick.val(),
            type: "Get",
            success: function (data) {
                $(searchTable).empty()
                console.log(data);

                for (var i = 0; i < data.length; i++) {

                    var newTr = document.createElement('tr')
                    $(newTr).addClass("search-products")
                    $(searchTable).append(newTr)
                    $(newTr).html('<td class="search-img-field"><a href="/ProductDetail?productId=' + data[i].id + '"><img  src="/assets/img/products/'
                        + data[i].productImages[0].image + '" style="width:50px;height:50px"/></a></td>'
                        + '<td class="search-product-field"><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].name + '</a></td>'
                        + ' <td class="search-price-field text-end"><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].realPrice + 'Azn/ededi</a></td >')

                }

            }
        })
    })






    let tableChild = ("#table-child");
    let tableChildImg = ("#basket-child-img")

    //Basket
    $("#basket").click(function () {
        $("#basket-toggle").toggleClass("basket-clicked");

    });

    $(document).on("click", "#addBasket", function (e) {
        e.preventDefault();

        swal("Product is added to Basket!", "More Information Visit Basket!", "success");
        let id = $("#product-id").val();
        let productCount = $("#product-count").val();
        console.log(productCount);

        $.ajax({
            url: "/productdetail/addbasket?productId=" + id + "&productCount=" + productCount,
            type: "Post",
            success: function (data) {

                console.log(data)

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

                if ($('.data-id').text() == data.id) {
                    return
                }


                var newTr = document.createElement('tr')
                $(basketParent).append(newTr)
                $(basketParent).append(newTr)
                $(newTr).html('<td class="data-id" style="display:none;">'+data.id +'</td><td><img  src="/assets/img/products/' + data.image
                                 + '" style="width:50px;height:50px"/></td>'
                                 + '<td>' + data.name + '</td>')
                
                
                
            }
        })

    })


    //RemoveProduct
    //productdetail/removeproduct?productId=2

    $('body').on('click', ".basket-remove", function (e) {
        e.preventDefault;
        swal("Product is Removed from Basket!", "", "warning");
        let productId = Number(this.id);
        let tableId = $('#table-basket');
        let tableMainId = $('#table-main-id');
        let tableResponsive = $('#table-responsive');
        //let totalPrice = parseInt($('#total-price').text());

        let priceAjax = 0;
        //totalPrice = 0;
        $.ajax({
            url: "/productdetail/removeproduct?productId=" + productId,
            type: "Post",
            success: function (data) {
                debugger
                
                $(tableId).empty()
                

                console.log(typeof ($('#total-price').text()));

                for (var i = 0; i < data.length; i++) {

                    priceAjax += data[i].price
                    var newTr = document.createElement('tr')
                    $(tableId).append(newTr)
                    $(newTr).html('<td><a href="/ProductDetail?productId=' + data[i].id + '"><img  src="/assets/img/products/'
                        + data[i].image + '" style="width:50px;height:50px"/></a></td>'
                        + '<td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].name + '</a></td>'
                        + '<td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].count + '</a></td>'
                        + ' <td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].price + '</a></td >'
                        + '<td><a class="basket-remove" id="' + data[i].id + '" >X</a></td >')
                    //totalPrice += priceAjax;
                }
                if (priceAjax > 0) {
                    $('#total-price').text(priceAjax.toString())
                } else {
                    tableMainId.addClass('d-none')
                    var newP = document.createElement('p')
                    tableResponsive.append(newP)
                    $(newP).html('<p>There is not product in Basket</p>')
                    $('#total-price').addClass('d-none')
                    $('#letter-total-price').addClass('d-none')
                }
                

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