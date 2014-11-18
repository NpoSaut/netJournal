$(document).ready(function() {
    $.getJSON("Home/Burndown?from=10.28.2014&to=11.10.2014&userlogin=SAUT\\plyusnin", function(data, textStatus) {
        var myCanvas = document.getElementById("myCanvas");

        var items = [];
        $.each(data.PointsData, function(index, stringPoint) {
            var point = {
                time: StringToDate(stringPoint.Time),
                unburned: stringPoint.UnburnedHours
            };
            items.push(point);
        });

        var minTime = StringToDate(data.StartTime);
        var maxTime = StringToDate(data.EndTime);
        var minUnburned = function () {
            var min = 0;
            $.each(items, function (i, e) { if (e.unburned < min) min = e.unburned; });
            return min;
        }();
        var maxUnburned = function() {
            var max = minUnburned;
            $.each(items, function(i, e) { if (e.unburned > max) max = e.unburned; });
            return max;
        }();

        var tickPerPixel = (maxTime - minTime) / myCanvas.clientWidth;
        var burnsPerPixel = (maxUnburned - minUnburned) / myCanvas.clientHeight;

        var ctx = myCanvas.getContext('2d');
        ctx.fillStyle = '#74A3C2';
        ctx.strokeStyle = '#00405C';
        ctx.beginPath();
        ctx.moveTo(0, myCanvas.clientHeight);
        $.each(items, function(i, e) {
            var x = (e.time - minTime) / tickPerPixel;
            var y = (e.unburned - minUnburned) / burnsPerPixel;
            ctx.lineTo(x, myCanvas.clientHeight - y);
        });
        ctx.fill();
        ctx.stroke();
    });
});

function StringToDate(stringDate) {
    return new Date(parseInt(stringDate.replace("/Date(", "").replace(")/", ""), 10));
}