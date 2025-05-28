document.addEventListener("DOMContentLoaded", function () {

  window.addEventListener('scroll', function () {

    if (window.scrollY > 200) {
      document.getElementById('navbar_top').classList.add('fixed-top');
      // add padding top to show content behind navbar
      navbar_height = document.querySelector('.navbar').offsetHeight;
      document.body.style.paddingTop = navbar_height + 'px';
    } else {
      document.getElementById('navbar_top').classList.remove('fixed-top');
      // remove padding top from body
      document.body.style.paddingTop = '0';
    }
  });
});

// Header JS Ends

jQuery(document).ready(function () {
  jQuery(".glimpse-carousel").owlCarousel();
  jQuery(".cambride-carousel").owlCarousel();
  jQuery(".recognition-carousel").owlCarousel();
});


jQuery('.recognition-carousel').owlCarousel({
  loop: true,
  margin: 30,
  nav: false,
  autoplay: 3000,
  dots: true,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    1000: {
      items: 3
    }
  }
})

$('.glimpse-carousel').owlCarousel({
  loop: true,
  margin: 10,
  nav: false,
  dots: true,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 3
    },
    1000: {
      items: 5
    }
  }
})


$('.cambride-carousel').owlCarousel({
  loop: true,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 2
    },
    1000: {
      items: 3
    }
  }
})

$('.pg-alfa-numeracy').owlCarousel({
  loop: true,
  margin: 20,
  nav: true,
  dots: false,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 1
    },
    1000: {
      items: 2
    }
  }
})

$('.interaction-videos').owlCarousel({
  loop: true,
  margin: 20,
  nav: true,
  navText: ['<i class="fa-solid fa-angle-left"></i>', '<i class="fa-solid fa-angle-right"></i>'],
  dots: false,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 3
    },
    1000: {
      items: 4
    }
  }
})

$('.testimonial-carousel').owlCarousel({
  loop: true,
  margin: 10,
  nav: true,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 1
    },
    1000: {
      items: 1
    }
  }
})

$('.hero-slider').owlCarousel({
  loop: true,
  margin: 0,
  nav: true,
  dots: false,
  autoplay: true,
  navText: ['<i class="fa-solid fa-angle-left"></i>', '<i class="fa-solid fa-angle-right"></i>'],
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 1
    },
    1000: {
      items: 1
    }
  }
})

$('.facility-slider').owlCarousel({
  loop: true,
  margin: 20,
  nav: false,
  dots: true,
  autoplay: true,
  autoplayTimeout: 5000,
  smartSpeed: 800,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 3
    },
    1000: {
      items: 4
    }
  }
})

$('.cis-toppers').owlCarousel({
  loop: true,
  margin: 20,
  nav: true,
  navText: ['<i class="fa-solid fa-arrow-left"></i>', '<i class="fa-solid fa-arrow-right"></i>'],
  dots: false,
  autoplay: false,
  autoplayTimeout: 5000,
  smartSpeed: 800,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 3
    },
    1000: {
      items: 5
    }
  }
})

$('.university').owlCarousel({
  loop: true,
  margin: 20,
  nav: true,
  navText: ['<i class="fa-solid fa-arrow-left"></i>', '<i class="fa-solid fa-arrow-right"></i>'],
  dots: false,
  autoplay: true,
  autoplayTimeout: 5000,
  smartSpeed: 800,
  responsive: {
    0: {
      items: 1
    },
    600: {
      items: 3
    },
    1000: {
      items: 4
    }
  }
})

jQuery(function () {
  jQuery("#header").load("include/header.html");
  jQuery("#footer").load("include/footer.html");
});

// Loader while loading

window.addEventListener('load', function () {
  document.getElementById('loader').style.display = 'none';
});

jQuery('.counter-count').each(function () {
  jQuery(this).prop('Counter', 0).animate({
    Counter: jQuery(this).text()
  }, {
    duration: 5000,
    easing: 'swing',
    step: function (now) {
      jQuery(this).text(Math.ceil(now));
    }
  });
});



$(document).ready(function () {
  $(".tab").click(function () {
    $(".tab").removeClass("active");
    $(".content").removeClass("active");

    $(this).addClass("active");

    var tabIndex = $(this).index();
    $(".content").eq(tabIndex).addClass("active");
  });

  $(".tab:first").addClass("active");
  $(".content:first").addClass("active");
});


$(document).ready(function () {
  showPopup();
});


function showPopup() {
  if (localStorage.getItem('YesBtn') !== 1) {
    setTimeout(() => {
      $('#registerModal').modal('show');
      $('#popup-yes').on('click', function () {
        localStorage.setItem('YesBtn', 1);
        $('#registerModal').modal('hide');
      })
    }, 5000);
  }
}