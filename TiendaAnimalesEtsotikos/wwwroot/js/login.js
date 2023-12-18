$(document).ready(function () {
    var $loginMsg = $('.loginMsg'),
        $login = $('.login'),
        $signupMsg = $('.signupMsg'),
        $signup = $('.signup'),
        $frontbox = $('.frontbox');

    // Function to handle switching
    function switchViews() {
        $loginMsg.toggleClass("visibility");
        $frontbox.toggleClass("moving");
        $signupMsg.toggleClass("visibility");
        $signup.toggleClass('hide');
        $login.toggleClass('hide');
    }

    // Attach click handlers
    $('#switch1').on('click', function () {
        switchViews();
    });

    $('#switch2').on('click', function () {
        switchViews();
    });

    // Delayed automatic clicks xd
    //setTimeout(function () {
    //    $('#switch1').click();
    //}, 1000);

    //setTimeout(function () {
    //    $('#switch2').click();
    //}, 3000);
});

