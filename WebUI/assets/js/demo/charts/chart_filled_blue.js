"use strict"; $(document).ready(function () {
    var b = [[1262304000000, 0], [1264982400000, 500], [1267401600000, 700], [1270080000000, 1300], [1272672000000, 2600], [1275350400000, 1300], [1277942400000, 1700], [1280620800000, 1300], [1283299200000, 1500], [1285891200000, 2000], [1288569600000, 1500], [1291161600000, 1200]];
    var a = [{ label: "Total clicks", data: b, color: App.getLayoutColorCode("blue") }];
    $.plot(
        "#chart_filled_blue", a,
        $.extend(true, {}, Plugins.getFlotDefaults(),
            {
                xaxis:
                {
                    min: (new Date(2009, 12, 1)).getTime(),
                    max: (new Date(2010, 11, 2)).getTime(), mode: "time", tickSize: [1, "month"], monthNames: ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"], tickLength: 0
                },
                series:
                {
                    lines:
                        { fill: true, lineWidth: 1.5 },
                    points:
                        { show: true, radius: 2.5, lineWidth: 1.1 },
                    grow:
                        { active: true, growings: [{ stepMode: "maximum" }] }
                },
                grid:
                {
                    hoverable: true, clickable: true
                },
                tooltip: true,
                tooltipOpts:
                    { content: "%s: %y" }
            }))
});