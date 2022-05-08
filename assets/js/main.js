
$(document).ready(function(){
    $(document).ready(function(){
        $(".owl-carousel").owlCarousel();
      });

      $('.owl-carousel').owlCarousel({
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
  });