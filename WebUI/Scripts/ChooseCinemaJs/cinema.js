$(function () {
    $('.header-nav__link--div').mouseover(function () {
        $('.div').css({
            "opacity": "1",
            "transition": "all 600ms linear 0s"
        });
    }).mouseout(function () {
        $('.div').css({
            "opacity": "0",
            "transition": "all 600ms linear 0s"
        });
    });

    $('.header-tooblar__search--text').focus(function () {
        var text = $(this).val();
        if (text == "找影视剧、影院、导演") {
            $(this).val("");
        }
        $(this).css("border-color", "brown");
    });
    $('.header-tooblar__search--text').blur(function () {
        var text = $(this).val();
        if (text == "") {
            $(this).val("找影视剧、影院、导演");
        }
        $(this).css("border-color", "lightgray");
    });

    $('.content--select__brand ul li').click(function () {
        $('.content--select__brand ul li').removeClass("content--select__brand--active");
        $(this).addClass("content--select__brand--active");
    });
    $('.content--select__district ul li').click(function () {
        $('.content--select__district ul li').removeClass("content--select__district--active");
        $(this).addClass("content--select__district--active");
    });
    $('.content--select__special ul li').click(function () {
        $('.content--select__special ul li').removeClass("content--select__special--active");
        $(this).addClass("content--select__special--active");
    });
});