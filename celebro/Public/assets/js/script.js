$(document).ready(function() {


    $("option").width($("select").width());
    $('li.breakli').nextAll('li').hide();
    $("#showless").hide();


    $("#showless").click(function() {
        $('li.breakli').nextAll('li').hide();
        $("#showless").hide();
        $("#showmore").show();
        $('.titall').css("height", "424px");

    });
    $("#showmore").click(function() {
        $('li.breakli').nextAll('li').show();
        $("#showmore").hide();
        $("#showless").show();
        $('.titall').css("height", "524px");
        // $('li').eq(14).css("margin-left", "0");

    });

    $("#todo3").click(function() {
        if ($(this).is(':checked')) {
            $(".whominput").css("display", "none");
        } else {
            $(".whominput").css("display", "block");

        }
    });

    $(".video").click(function() {
        $(this).toggleClass("stopped playing"); // change both classes
        if ($(this).is('.stopped')) {
            this.pause();
            $(this).siblings('.headicon2').css("display", "block");

        } else {

            // $(this).addClass("stopped");
            // if ($('.video').hasClass("playing")) {

            // this.currentTime = 0;
            $("video").each(function() {
                $(this).get(0).pause();
                $('.video').siblings('.headicon2').css("display", "block");
                $(this).toggleClass("playing stopped"); // change both classes
                $('.video').removeClass("playing");
                $('.video').addClass("stopped");

            });
            // $(this).toggleClass("playing stopped"); // change both classes
            // $('.video').removeClass("playing");
            // $('.video').addClass("stopped");


            // }
            this.play();
            $(this).toggleClass("stopped playing"); // change both classes

            $(this).siblings('.headicon2').hide();


        }

    });
    $("#search-input4").keyup(function () {
        var req_data = {
            text: $(this).val()
        };

        $.ajax({
            url: "/Home/Getcelebritieswithinput",
            type: "get",
            dataType: "json",
            data: req_data,
            success: function (response) {
                $(".gallery").empty();

                $.each(response, function (key, value) {

                    var celebs = ` <div class="col-lg-3 col-md-6 col-sm-12 galrespmar">
                            <a class="celebimg" href="#">
                                <div class="galdetail">
                                    <div class="galimg">
                                        <img src="/Public/assets/images/${value.Photo}" class=" img-fluid personimg">

                                    </div>
                                    <div class="galtext">
                                        <h1>${value.Fullname}</h1>
                                        <p>${value.Name}</p>
                                    </div>
                                    <div class="btnprice">
                                        <span>${value.Price} AZN</span>
                                    </div>
                                </div>
                            </a>
                        </div>`;
                    $(".gallery").append(celebs);
                });


            },
            error: function (err) {
                alert(err.responseJSON.message);
            }

        });
    });
    $(".catsearch").click(function () {
        var req_data = {
            catid: $(this).val()
        };

        $.ajax({
            url: "/Home/Getcelebrities",
            type: "get",
            dataType: "json",
            data: req_data,
            success: function (response) {
                $(".gallery").empty();

                $.each(response, function (key, value) {

                    var celebs = ` <div class="col-lg-3 col-md-6 col-sm-12 galrespmar">
                            <a class="celebimg" href="#">
                                <div class="galdetail">
                                    <div class="galimg">
                                        <img src="/Public/assets/images/${value.Photo}" class=" img-fluid personimg">

                                    </div>
                                    <div class="galtext">
                                        <h1>${value.Fullname}</h1>
                                        <p>${value.Name}</p>
                                    </div>
                                    <div class="btnprice">
                                        <span>${value.Price} AZN</span>
                                    </div>
                                </div>
                            </a>
                        </div>`;
                    $(".gallery").append(celebs);
                });

              
            },
            error: function (err) {
                alert(err.responseJSON.message);
            }

        });
    });
    $(".cancelform").click(function() {

        $(".formappback").css("display", "none");
    });
    $(".cancelform2").click(function() {

        $(".formappback2").css("display", "none");
    });
    $(".btnceleb").click(function() {

        $(".formappback").css("display", "flex");
    });
    $(".btnpay").click(function() {

        $(".formappback2").css("display", "flex");
    });

    $('.drslide1').owlCarousel({
        loop: false,
        margin: 10,
        nav: true,
        lazyLoad: true,
        merge: true,
        video: true,
        dots: false,
        responsive: {
            0: {
                items: 2
            },
            600: {
                items: 3
            },
            1000: {
                items: 4
            }
        }



    });
    $('.drslide2').owlCarousel({
        loop: false,
        margin: 10,
        nav: true,
        lazyLoad: true,
        merge: true,
        video: true,
        dots: false,
        responsive: {
            0: {
                items: 2
            },
            600: {
                items: 3
            },
            1000: {
                items: 4
            }
        }



    });
  
   
    // var inputsearch = document.getElementById("search-input4");
    // inputsearch.addEventListener("keyup", function(event) {
    //     if (event.keyCode === 13) {
    //         event.preventDefault();
    //         document.getElementById("searchbtn").click();
    //     }
    // });
    // $(".navbar-toggler").click(function() {

    //     $('.navbar').css("background-color", "black");

    // });

});