$(document).ready(function() {
    $.getJSON("Home/Burndown?from=11.06.2014&to=11.10.2014", function(data, textStatus) {
        var myCanvas = document.getElementById("myCanvas");

        var items = [];
        $.each(data.PointsData, function(index, stringPoint) {
            var point = {
                time: StringToDate(stringPoint.Time),
                burned: stringPoint.HoursBurned
            };
            items.push(point);
        });

        var minTime = StringToDate(data.StartTime);
        var maxTime = StringToDate(data.EndTime);
        var minBurned = 0;
        var maxBurned = function() {
            var max = minBurned;
            $.each(items, function(i, e) { if (e.burned > max) max = e.burned; });
            return max;
        }();

        var tickPerPixel = (maxTime - minTime) / myCanvas.clientWidth;
        var burnsPerPixel = (maxBurned - minBurned) / myCanvas.clientHeight;

        var ctx = myCanvas.getContext('2d');
        ctx.beginPath();
        $.each(items, function(i, e) {
            var x = (e.time - minTime) / tickPerPixel;
            var y = (e.burned - minBurned) / burnsPerPixel;
            if (i === 0)
                ctx.moveTo(x, myCanvas.clientHeight - y);
            else
                ctx.lineTo(x, myCanvas.clientHeight - y);
        });
        ctx.stroke();
    });
});

function StringToDate(stringDate) {
    return new Date(parseInt(stringDate.replace("/Date(", "").replace(")/", ""), 10));
}