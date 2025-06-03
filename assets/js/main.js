document.addEventListener("DOMContentLoaded", function () {
  const navbar = document.getElementById("navbar_top");
  const toggler = document.getElementById("navbarSideCollapse");
  const navbarNav = document.getElementById("main_nav");
  const overlay = document.getElementById("navbarOverlay");

  // Fixed navbar on scroll
  window.addEventListener("scroll", function () {
    if (window.scrollY > 200) {
      navbar.classList.add("fixed-top");
      let navbar_height = document.querySelector(".navbar").offsetHeight;
      document.body.style.paddingTop = navbar_height + "px";
    } else {
      navbar.classList.remove("fixed-top");
      document.body.style.paddingTop = "0";
    }
  });

  // Toggle navbar on mobile
  toggler.addEventListener("click", function () {
    navbarNav.classList.toggle("open");
    overlay.classList.toggle("show");
  });

  // Close on overlay click
  overlay.addEventListener("click", function () {
    navbarNav.classList.remove("open");
    overlay.classList.remove("show");
  });

  // Close on nav item click (optional for single-page UX)
  document.querySelectorAll('.nav-link').forEach(link => {
    link.addEventListener('click', () => {
      if (navbarNav.classList.contains('open')) {
        navbarNav.classList.remove('open');
        overlay.classList.remove('show');
      }
    });
  });
});


// Hero Slider
$('.heroSlider').owlCarousel({
    loop:true,
    margin:0,
    dots:true,
    nav:true,
    mouseDrag:true,
    autoplay:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    animateOut: 'slideOutUp',
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

// Insta Post Slider
$('.instaPost').owlCarousel({
    loop:true,
    margin:0,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

// FacebookPost Slider
$('.fbPostSlider').owlCarousel({
    loop:true,
    margin:0,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

$('.management').owlCarousel({
    loop:true,
    margin:20,
    dots:false,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:false,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:2
        },
        1000:{
            items:3
        }
    }
});
$('.pTestimonies').owlCarousel({
    loop:true,
    margin:20,
    dots:true,
    nav:true,
    navText: ["<i class='fa-solid fa-arrow-left'></i>", "<i class='fa-solid fa-arrow-right'></i>"],
    mouseDrag:true,
    autoplay:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
});

// News 
document.getElementById('campusSort').addEventListener('change', function() {
  const selectedCampus = this.value;

  document.querySelectorAll('.media-items').forEach(function(container) {
    container.querySelectorAll('.media-item').forEach(function(item) {
      if (selectedCampus === 'all' || item.getAttribute('data-campus') === selectedCampus) {
        item.style.display = '';
      } else {
        item.style.display = 'none';
      }
    });
  });
});
