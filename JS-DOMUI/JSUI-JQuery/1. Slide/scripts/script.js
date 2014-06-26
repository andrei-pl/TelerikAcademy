/// <reference path="jquery/src/jquery.js" />
(function () {
    var slides = [
        '<img src = "imgs/squirrel.png" />',
        '<h1>Lorem ipsum</h1><p>Tincidunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.dunt integer eu augue augue nunc elit dolor, luctus placerat scelerisque euismod, iaculis eu lacus nunc mi elit, vehicula ut laoreet ac, aliquam sit amet justo nunc tempor, metus vel.</p>',
        '<a href="#">Some link</a><br /><a href="#">Some link</a><br /><a href="#">Some link</a><br /><a href="#">Some link</a><br /><a href="#">Some link</a>',
        '<input type="text" /><label>Enter some text</label><br /><button>No need to click me</button>'
    ],
    slider = $("#slider"),
    currentSlide = 0;

    setSlide();
    animation = setInterval(slideElements, 5000);

    $("#prevBtn").on('click', prevSlide);

    $("#nextBtn").on('click', nextSlide);

    function prevSlide() {
        currentSlide -= 1;
        if (currentSlide === -1) {
            currentSlide = 3;
        }
        setSlide();
        resetTimer();
    };

    function nextSlide() {
        currentSlide += 1;
        if (currentSlide === 4) {
            currentSlide = 0;
        }
        setSlide();
        resetTimer();
    };

    function resetTimer() {
        clearInterval(animation);
        animation = setInterval(slideElements, 5000);
    }

    function setSlide() {
        slider.html(slides[currentSlide]);
    }

    function slideElements() {
        if (currentSlide == 3) {
            currentSlide = -1;
        }
        slider.html(slides[++currentSlide]);
    }
})();