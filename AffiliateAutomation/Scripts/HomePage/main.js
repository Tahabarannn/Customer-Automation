/*==================== MENU SHOW Y HIDDEN ====================*/
const navMenu = document.getElementById("nav-menu"),
navToggle = document.getElementById("nav-toggle"),
navClose = document.getElementById("nav-close")

/*===== MENU SHOW =====*/
/* Validate if constant exists */
if(navToggle){
    navToggle.addEventListener("click", () =>{
        navMenu.classList.add("show-menu")
    })
}

/*===== MENU HIDDEN =====*/
/* Validate if constant exists */
if(navClose){
    navClose.addEventListener("click", () =>{
        navMenu.classList.remove("show-menu")
    })
}


/*==================== REMOVE MENU MOBILE ====================*/
const navLink = document.querySelectorAll(".nav__link")

function linkAction(){
    const navMenu = document.getElementById("nav-menu")
    navMenu.classList.remove("show-menu")
}

navLink.forEach(n => n.addEventListener("click", linkAction))

/*==================== POPUP  ====================*/
const popupScreen = document.querySelector(".popup__container");
const popupBox = document.querySelector(".popup__content");
const closeBtn = document.querySelector(".popup__close");

window.addEventListener("load", () => {
    setTimeout(() => {
        popupScreen.classList.add("active")
    }, 1500); //Popup the screen in 02 seconds after the page is loaded.
})

closeBtn.addEventListener("click", () => {
    popupScreen.classList.remove("active"); //Close the popup screen on click the close button.
})


/*==================== PORTFOLIO SWIPER  ====================*/
let swiperPortfolio = new Swiper('.portfolio__container', {
    cssMode: true,
    loop: true,

    navigation: {
      nextEl: '.swiper-button-next',
      prevEl: '.swiper-button-prev',
    },
    pagination: {
      el: '.swiper-pagination',
      clickable: true,
    },
});

/*==================== TESTIMONIAL ====================*/
let swiperTestimonial = new Swiper('.testimonial__container', {
    loop: true,
    grabCursor: true,
    spaceBetween: 48,

    pagination: {
      el: '.swiper-pagination',
      clickable: true,
      dynamicBullets: true,
    },
    breakpoints:{
        568:{
            slidesPerView: 2,
        }
    }
});

/*==================== SCROLL SECTIONS ACTIVE LINK ====================*/
const sections = document.querySelectorAll("section[id]")

function scrollActive(){
    const scrollY = window.pageYOffset

    sections.forEach(current =>{
        const sectionHeight = current.offsetHeight
        const sectionTop = current.offsetTop - 50;
        sectionId = current.getAttribute("id")

        if(scrollY > sectionTop && scrollY <= sectionTop + sectionHeight){
            document.querySelector(".nav__menu a[href*=" + sectionId +"]").classList.add("active-link")
        }else{
            document.querySelector(".nav__menu a[href*=" + sectionId +"]").classList.remove("active-link")
        }
    })
}
window.addEventListener("scroll", scrollActive)
/*==================== CHANGE BACKGROUND HEADER ====================*/ 
function scrollHeader(){
    const nav = document.getElementById('header')
    // When the scroll is greater than 200 viewport height, add the scroll-header class to the header tag
    if(this.scrollY >= 80) nav.classList.add('scroll-header'); else nav.classList.remove('scroll-header')
}
window.addEventListener('scroll', scrollHeader)

/*==================== SHOW SCROLL UP ====================*/ 
function scrollUp(){
    const scrollUp = document.getElementById('scroll-up');
    // When the scroll is higher than 560 viewport height, add the show-scroll class to the a tag with the scroll-top class
    if(this.scrollY >= 560) scrollUp.classList.add('show-scroll'); else scrollUp.classList.remove('show-scroll')
}
window.addEventListener('scroll', scrollUp)

/*==================== DARK LIGHT THEME ====================*/ 
const themeButton = document.getElementById('theme-button')
const darkTheme = 'dark-theme'
const iconTheme = 'uil-sun'

// Previously selected topic (if user selected)
const selectedTheme = localStorage.getItem('selected-theme')
const selectedIcon = localStorage.getItem('selected-icon')

// We obtain the current theme that the interface has by validating the dark-theme class
const getCurrentTheme = () => document.body.classList.contains(darkTheme) ? 'dark' : 'light'
const getCurrentIcon = () => themeButton.classList.contains(iconTheme) ? 'uil-moon' : 'uil-sun'

// We validate if the user previously chose a topic
if (selectedTheme) {
  // If the validation is fulfilled, we ask what the issue was to know if we activated or deactivated the dark
  document.body.classList[selectedTheme === 'dark' ? 'add' : 'remove'](darkTheme)
  themeButton.classList[selectedIcon === 'uil-moon' ? 'add' : 'remove'](iconTheme)
}

// Activate / deactivate the theme manually with the button
themeButton.addEventListener('click', () => {
    // Add or remove the dark / icon theme
    document.body.classList.toggle(darkTheme)
    themeButton.classList.toggle(iconTheme)
    // We save the theme and the current icon that the user chose
    localStorage.setItem('selected-theme', getCurrentTheme())
    localStorage.setItem('selected-icon', getCurrentIcon())
})

/*==================== Disable Click ====================*/ 

// disable right click
document.addEventListener('contextmenu', event => event.preventDefault());
 
document.onkeydown = function (e) {

    // disable F12 key
    if(e.keyCode == 123) {
        return false;
    }

    // disable I key
    if(e.ctrlKey && e.shiftKey && e.keyCode == 73){
        return false;
    }

    // disable J key
    if(e.ctrlKey && e.shiftKey && e.keyCode == 74) {
        return false;
    }

    // disable U key
    if(e.ctrlKey && e.keyCode == 85) {
        return false;
    }
}

/*==================== SOCIAL LINK ====================*/ 

var countre=1;

function add_more_twitter(){
    countre+=1
    html = '<div class="tile" id="twitter">\
        <i class="fa-solid fa-square-plus" onclick="add_more_twitter()"></i>\
        <input type="text" class="social options" name="SocialMedia" value="https://twitter.com/" autocomplete="off" />\
    </div >'

    var tile = document.getElementById('twitter')
    tile.innerHTML+=html
}

function add_more_facebook(){
    countre+=1
    html = '<div class="tile" id="facebook">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_facebook()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://www.facebook.com/" autocomplete="off" />\
    </div >'

    var tile = document.getElementById('facebook')
    tile.innerHTML+=html
}

function add_more_telegram(){
    countre+=1
    html = '<div class="tile" id="telegram">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_telegram()"></i>\
        <input type="text" class="social options" name="SocialMedia" value="https://t.me/" autocomplete="off" />\
    </div>'

    var tile = document.getElementById('telegram')
    tile.innerHTML+=html
}

function add_more_instagram(){
    countre+=1
    html = '<div class="tile" id="instagram">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_instagram()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://www.instagram.com/" autocomplete="off" />\
    </div >'

    var tile = document.getElementById('instagram')
    tile.innerHTML+=html
}

function add_more_youtube(){
    countre+=1
    html = '<div class="tile" id="youtube">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_youtube()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://www.youtube.com/" autocomplete="off" />\
    </div > '

    var tile = document.getElementById('youtube')
    tile.innerHTML+=html
}

function add_more_twitch(){
    countre+=1
    html = '<div class="tile" id="twitch">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_twitch()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://www.twitch.tv/" autocomplete="off" />\
    </div >'

    var tile = document.getElementById('twitch')
    tile.innerHTML+=html
}

function add_more_discord(){
    countre+=1
    html = '<div class="tile" id="discord">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_discord()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://discord.com/" autocomplete="off" />\
    </div > '

    var tile = document.getElementById('discord')
    tile.innerHTML+=html
}

function add_more_tiktok(){
    countre+=1
    html = '<div class="tile" id="tiktok">\
        <i class="fa-solid fa-square-plus" onclick ="add_more_tiktok()"></i>\
        <input type="text" class="social" name="SocialMedia" value="https://www.tiktok.com/" autocomplete="off" />\
    </div > '

    var tile = document.getElementById('tiktok')
    tile.innerHTML+=html
}

function add_more_web(){
    countre+=1
    html = '<div class="tile" id="web'+countre+'">\
        <i class="fa-solid fa-square-plus" onclick="add_more_web()"></i>\
        <input type="text" class="social" name="SocialMedia" placeholder="Web sitesi (http(s)://..)" autocomplete="off"/>\
    </div>'

    var tile = document.getElementById('web')
    tile.innerHTML+=html
}

