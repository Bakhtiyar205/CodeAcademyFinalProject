$(document).ready(function () {
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
        } else {
            for (var i = 0; i < cookieJson.length; i++) {
                var newTr = document.createElement('tr')
                $(basketParent).append(newTr)
                $(newTr).html('<td><img  src="/assets/img/products/' + cookieJson[i].Image + '" style="width:50px;height:50px"/></td>'
                    + '<td>' + cookieJson[i].Name + '</td>')
            }
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
        $(searhcField).toggleClass("d-none");
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
        $.ajax({
            url: "/productdetail/addbasket?productId=" + id + "&productCount=" + productCount,
            type: "Post",
            success: function (data) {
                $(basketIcon).addClass("d-none");
                $(tableBasket).removeClass("d-none");
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

    //RemoveProductBasket
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
                $(basketParent).empty();

                if (data.length)
                for (var i = 0; i < data.length; i++) {
                    priceAjax += data[i].price
                    var newTr = document.createElement('tr')
                    $(tableId).append(newTr)
                    $(newTr).html('<td><a href="/ProductDetail?productId=' + data[i].id + '"><img  src="/assets/img/products/'
                        + data[i].image + '" style="width:50px;height:50px"/></a></td>'
                        + '<td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].name + '</a></td>'
                        + '<td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].count + '</a></td>'
                        + ' <td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].price + ' AZN</a></td >'
                        + '<td><a style="cursor:pointer" class="basket-remove" id="' + data[i].id + '" ><i class="fa-solid fa-circle-xmark" style="color:red;"></i></a></td >')
                    var newTrBasket = document.createElement('tr');
                    $(basketParent).append(newTrBasket)
                    $(newTrBasket).html('<td><img  src="/assets/img/products/' + data[i].image + '" style="width:50px;height:50px"/></td>'
                        + '<td>' + data[i].name + '</td>')
                    //totalPrice += priceAjax;
                }
                if (priceAjax > 0) {
                    $('#total-price').text(priceAjax.toString())
                } else {
                    basketParent.addClass('d-none');
                    basketIcon.removeClass('d-none');
                    tableBasket.addClass('d-none');
                    tableMainId.addClass('d-none')
                    var newP = document.createElement('p')
                    tableResponsive.append(newP)
                    $(newP).html('<p class="text-center btn btn-danger" style="font-size:20px;">There is not product in Basket</p>')
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

    //Products Order By ascending and descending
    $('body').on('change', '#desc-asc', function (e) {
        e.preventDefault();
        let productPrice= parseInt($(this).find('option:selected').val());
        let subcategoryId = $('#subcategory-id').val();
        let productField = $('.product-fields')
        $.ajax({
            url: "/subcategory/getproducts?productPrice=" + productPrice+"&subCategoryId="+subcategoryId,
            type: "Get",
            success: function (data) {
                $(productField).empty();
                console.log(data);
                for (var i = 0; i < data.length; i++) {
                    let newDiv = document.createElement('div');
                    $(newDiv).addClass('col-12 col-md-4 my-3')
                    productField.append(newDiv);
                    if (data[i].discount != 0) {
                        $(newDiv).html('<div class="product-field p-3"><a href="/ProductDetail?productId='
                            + data[i].id +
                            '"><img src="assets/img/products/'
                            + data[i].productImages[0].image +
                            '" alt="image"><br>'
                            + data[i].name + '</a><div class="discounted-price my-2"><span>'
                            + data[i].realPrice * (100 - data[i].discount) / 100 +
                            ' AZN</span>/ededi</div><div class="real-price">' + data[i].realPrice + ' AZN</div><div class="discount-percentage my-2">'
                            + data[i].discount + '% ENDIRIM</div><div class="extra-information"><a class="btn btn-light form-control" href="/ProductDetail?productId='
                            + data[i].id + '">Daha Etrafli</a></div><div class="wish-list text-center mt-2"><form><input type="hidden" name="Id" value="'
                            + data[i].id + '" id="product-wishlist-id" /><button type="submit" class="btn add-wishlist"><svg id="icon-heart" viewBox="0 0 512 512"><path d="m512 147c0-81-62-147-141-147-48 0-89 26-115 62-26-36-67-62-115-62-79 0-141 66-141 147 0 34 11 66 30 91l207 274 40 0-21-27-194-256-8-10c-14-21-22-46-22-72 0-62 48-113 109-113 35 0 69 17 89 49l26 39 26-39c20-30 54-49 89-49 61 0 109 51 109 113 0 26-8 50-22 71l-7 8-153 201-199-259-25 19 203 267 21 28 14-18 171-226c18-24 29-56 29-91z"></path></svg>Istek Listi</button></form></div></div>')

                    } else {
                        $(newDiv).html('<div class="product-field p-3"><a href="/ProductDetail?productId='
                            + data[i].id +
                            '"><img src="assets/img/products/'
                            + data[i].productImages[0].image +
                            '" alt="image"><br>'
                            + data[i].name + '</a><div class="discounted-price my-2"><span>'
                            + data[i].realPrice * (100 - data[i].discount) / 100 +
                            ' AZN</span>/ededi</div><div class="real-price" style="visibility:hidden">'
                            + data[i].realPrice + ' AZN</div><div class="discount-percentage my-2" style="visibility:hidden">'
                            + data[i].discount + '% ENDIRIM</div><div class="extra-information"><a class="btn btn-light form-control" href="/ProductDetail?productId='
                            + data[i].id + '">Daha Etrafli</a></div><div class="wish-list text-center mt-2"><form><input type="hidden" name="Id" value="'
                            + data[i].id + '" id="product-wishlist-id" /><button type="submit" class="btn add-wishlist"><svg id="icon-heart" viewBox="0 0 512 512"><path d="m512 147c0-81-62-147-141-147-48 0-89 26-115 62-26-36-67-62-115-62-79 0-141 66-141 147 0 34 11 66 30 91l207 274 40 0-21-27-194-256-8-10c-14-21-22-46-22-72 0-62 48-113 109-113 35 0 69 17 89 49l26 39 26-39c20-30 54-49 89-49 61 0 109 51 109 113 0 26-8 50-22 71l-7 8-153 201-199-259-25 19 203 267 21 28 14-18 171-226c18-24 29-56 29-91z"></path></svg>Istek Listi</button></form></div></div>')
                    }
                }
            }
        })
    });

    $(document).on('click', '#subscription-button', function (e) {
        let nameSubscriptionHidden = $('#name-subscription-hidden').val();
        let nameSubsctiption = $('#name-subscription').val();
        let emailSubscriptionHidden = $('#email-subscription-hidden').val();
        let emailSubscription = $('#email-subscription').val()
        let nameSubscriptionValid = document.querySelector("#name-subscription");
        let emailSubscriptionValid = document.querySelector("#email-subscription");
        let againSubscriptionValid = document.querySelector("#again-subscription-hidden");
        let againSubscription = $('#again-subscription-hidden').val();
        let validationError = $('#validation-error');
        console.log(typeof(againSubscription));
        if (nameSubsctiption != nameSubscriptionHidden) {
            nameSubscriptionValid.setCustomValidity("Please enter your Username");
        } else {
            nameSubscriptionValid.setCustomValidity("");
            if (emailSubscription != emailSubscriptionHidden) {
                emailSubscriptionValid.setCustomValidity("Please enter your Email");
            } else {
                emailSubscriptionValid.setCustomValidity("");
                if ($(againSubscriptionValid).val() == 'True') {
                    e.preventDefault();
                    validationError.removeClass('d-none');
                    validationError.addClass('d-block');
                    setTimeout(function() {
                        validationError.removeClass('d-block');
                        validationError.addClass('d-none');
                    }, 1000)

                } else {
                    swal("You Subscribed, Please Check Your Email!", "", "success");
                }
            }
        }
    })

    //Comment
    $(document).on('click', '#add-comment-button', function (e) {
        e.preventDefault();
        debugger
        let productId = $('#product-comment-id').val();
        let userName = $('#user-comment-name').val();
        let comment = $('#comment-text').val();
        console.log(productId, userName, comment);
        $.ajax({
            url: "/productdetail/AddComment",
            type: "Post",
            data: {
                productId: productId,
                name: userName,
                comment:comment
            },
            success: function () {
                    swal("You comment added, please wait admin Response!", "", "success");
            }
        })

    })

    //Wishlist Add
    $(document).on('click', '.add-wishlist', function (e) {
        e.preventDefault();
        let productId = $(this).prev().val();
        let wishListCount = $('.wishlist-count');
        $.ajax({
            url: "/wishlist/AddWishList",
            type: "Post",
            data: {
                productId: productId
            },
            success: function (data) {
                swal("Product added Wishlist!", "", "success");
                wishListCount.empty();
                $(wishListCount).html((data));
            }
        })
    })
    //Wishlist Remove
    $(document).on('click', '.wishlis-remove', function (e) {
        e.preventDefault();
        let tableId = $('#table-wishlist')
        let productId = $(this).prev().val();
        let mainTable = $('#table-responsive-wishlist');
        let nullProduct = $('#null-product');
        $.ajax({
            url: "/wishlist/RemoveProduct",
            type: "Post",
            data: {
                productId: productId
            },
            success: function (data) {
                swal("Product removed from Wishlist!", "", "warning");
                if (data.length > 0) {
                    tableId.empty();
                    for (var i = 0; i < data.length; i++) {
                        var newTr = document.createElement('tr')
                        $(tableId).append(newTr)
                        $(newTr).html('<td><a href="/ProductDetail?productId=' + data[i].id + '"><img  src="/assets/img/products/'
                            + data[i].image + '" style="width:50px;height:50px"/></a></td>'
                            + '<td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].name + '</a></td>'
                            + ' <td><a href="/ProductDetail?productId=' + data[i].id + '" style="color:#333;">' + data[i].price + ' Azn</a></td >'
                            + '<td><form><input type="hidden" name="product-wishlist-id" value="'
                            + data[i].id + '"/><button class="wishlis-remove btn" id="'
                            + data[i].id + '" ><i class="fa-solid fa-circle-xmark" style="color:red;"></i></button></form></td >')
                    }
                } else {
                    mainTable.addClass('d-none');
                    nullProduct.removeClass('d-none');
                }
            }
        })

    })

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