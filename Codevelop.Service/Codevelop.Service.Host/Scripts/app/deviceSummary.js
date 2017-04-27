


(function () {
    //UI configuration
    var margin = { top: 50, right: 0, bottom: 100, left: 30 },
        width = 960 - margin.left - margin.right,
        height = 1500 - margin.top - margin.bottom,
        gridSize = Math.floor(width / 24),
        legendElementWidth = gridSize * 2,
        buckets = 9,
        colors = ["#ffffd9", "#edf8b1", "#c7e9b4", "#7fcdbb", "#41b6c4", "#1d91c0", "#225ea8", "#253494", "#081d58"], // alternatively colorbrewer.YlGnBu[9]
        //days = ["Mo", "Tu", "We", "Th", "Fr", "Sa", "Su"],
        times = ["1a", "2a", "3a", "4a", "5a", "6a", "7a", "8a", "9a", "10a", "11a", "12a", "1p", "2p", "3p", "4p", "5p", "6p", "7p", "8p", "9p", "10p", "11p", "12p"];



    var svg = d3.select("#chart").append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
        .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    //var dayLabels = svg.selectAll(".dayLabel")
    //    .data(days)
    //    .enter().append("text")
    //    .text(function (d) { return d; })
    //    .attr("x", 0)
    //    .attr("y", function (d, i) { return i * gridSize; })
    //    .style("text-anchor", "end")
    //    .attr("transform", "translate(-6," + gridSize / 1.5 + ")")
    //    .attr("class", function (d, i) {
    //        return ((i >= 0 && i <= 4) ? "dayLabel mono axis axis-workweek" : "dayLabel mono axis");
    //    });

    var timeLabels = svg.selectAll(".timeLabel")
        .data(times)
        .enter().append("text")
        .text(function (d) { return d; })
        .attr("x", function (d, i) { return i * gridSize; })
        .attr("y", 0)
        .style("text-anchor", "middle")
        .attr("transform", "translate(" + gridSize / 2 + ", -6)")
        .attr("class", function (d, i) {
            return ((i >= 7 && i <= 16) ? "timeLabel mono axis axis-worktime" : "timeLabel mono axis");
        });



    d3.json('../api/DeviceSummary/Summary?deviceId={0D55E0B7-FF32-41AD-8C02-FAB47C50E62E}&year=2017&month=1', function (data) {
        // data.MonthSummary
        var monthNameFormat = d3.timeFormat("%a %d");
        var parseDate = d3.utcParse("%Y-%m-%dT%H:%M:%S");


        data.forEach(function (d) {
            d.Date = parseDate(d.Date);

        });

        var nestedByDay = d3.nest()
            .key(function (d) {
                // Build a new date from just the year, month, date - chopping off the time
                // (d3 will convert it to a string, being the key - but we'll convert it back to a Date later)
                 return new Date(d.Date.getFullYear(), d.Date.getMonth(), d.Date.getDate());
            })
            .entries(data);

        var dayLabels = svg.selectAll(".dayLabel")
            .data(nestedByDay)
            .enter().append("text")
            .text(function (d) {
                // (need to turn it back into a Date because d3 makes all nest keys strings)
                return monthNameFormat(new Date(d.key)); 
            })
            .attr("x", 0)
            .attr("y", function (d, i) { return i * gridSize; })
            .style("text-anchor", "end")
            .attr("transform", "translate(16," + gridSize / 1.5 + ")")
            .attr("class", function (d, i) {
                return ((i >= 0 && i <= 4) ? "dayLabel mono axis axis-workweek" : "dayLabel mono axis");
            });

        var colorScale = d3.scaleQuantile()
            .domain([0, buckets - 1, 60]) // range in each hour max's to 60 mins
            .range(colors);

        var cards = svg.selectAll(".hour")
            .data(data, function (d, i) {

                return d.Day + ':' + d.Bucket;
            });

        cards.append("title");

        // Keep a ref to the "new" (entered) cards, so we can set their initial attributes & then transition them
        var entered = cards.enter().append("rect");

        // Set the initial attributes for entered cards
        entered
            .attr("x",
                function(d) {
                    return (d.Bucket) * gridSize;
                })
            .attr("y",
                function(d) {
                    return (d.Day - 1) * gridSize;
                })
            .attr("rx", 4)
            .attr("ry", 4)
            .attr("class", "hour bordered")
            .attr("width", gridSize)
            .attr("height", gridSize)
            .style("fill", colors[0]); // start at a light colour, we'll transition them in below

        // Transition them to their actual colours
        entered.transition().duration(1000)
            .style("fill", function (d) {
                return colorScale(d.HeaterOnMins);
            });

        cards.select("title").text(function (d) {
            return d.value;
        });

        cards.exit().remove();

        var legend = svg.selectAll(".legend")
            .data([0].concat(colorScale.quantiles()), function (d) { return d; });

        legend.enter().append("g")
            .attr("class", "legend");

        legend.append("rect")
            .attr("x", function (d, i) { return legendElementWidth * i; })
            .attr("y", height)
            .attr("width", legendElementWidth)
            .attr("height", gridSize / 2)
            .style("fill", function (d, i) { return colors[i]; });

        legend.append("text")
            .attr("class", "mono")
            .text(function (d) { return "≥ " + Math.round(d); })
            .attr("x", function (d, i) { return legendElementWidth * i; })
            .attr("y", height + gridSize);

        legend.exit().remove();

    });

})();
