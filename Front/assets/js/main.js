
$(document).ready(function(){


    $(document).ready(function(){
        $(".owl-carousel").owlCarousel();
      });

      $('.owl-carusel-last-seen').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        responsive:{
            0:{
                items:1
            },
            768:{
                items:3
            },
            972:{
                items:4
            }
        }

       
    })

    $('.owl-carousel-product').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        responsive:{
            0:{
                items:1
            },
            768:{
                items:1
            },
            1000:{
                items:1
            }
        }

       
    })

    $(document).on('change', '.selectpicker', function(e){
        e.preventDefault();
    
        window.location = $(this).find('option:selected').val();
    });

    $("#basket").click(function(){
        $("#basket-toggle").toggleClass("basket-clicked");
        $("")
      });

    // Initialize and add the map
function initMap() {
    // The location of Uluru
    const uluru = { lat: -25.344, lng: 131.031 };
    // The map, centered at Uluru
    const map = new google.maps.Map(document.getElementById("map"), {
      zoom: 4,
      center: uluru,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
      position: uluru,
      map: map,
    });
  }
  
  window.initMap = initMap;

  });