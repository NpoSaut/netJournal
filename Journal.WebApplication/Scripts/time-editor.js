var currentTime;


$(document).ready(function() {
    var manualTime = moment();
    var realTime = moment();;

    function requestTime() {
        return $.getJSON("Api/CurrentTime", function(data) {
            realTime = moment(data);
            setTimeout(requestTime, (65 - realTime.seconds()) * 1000);
        });
    };

    $(".main-line").slideDown(1000);

    requestTime().done(function() {
        $(".time-editor").fadeIn(3000);
    });

    $(".time-editor").data("update-date", true);
    $(".time-editor").focus(function() { $(this).data("update-date", false); });
    $(".time-editor").blur(function() { $(this).data("update-date", true); });

    currentTime = realTime;
    $(".time-editor").inputmask("hh:mm", {
        "placeholder": " ",
        "onincomplete": function() {
            currentTime = realTime;
        },
        "oncomplete": function() {
            manualTime.set("HH:mm", this.value);
            currentTime = manualTime;
            console.log(currentTime);
            console.log(manualTime);
        }
    });
});