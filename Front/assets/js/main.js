
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

    
  });