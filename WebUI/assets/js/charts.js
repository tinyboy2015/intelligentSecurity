var chart1; // globally available
var chart1Values; //values for the chart
var chartTheme;


//chartType: line, spline, area, areaspline, column, bar, pie and scatter

//---------------Set Bar or Column Style Chart--------------//
//divID: the Div ID that chart render to
//chartTitle: Title of the Chart
//chartSubTitle: Subtitle of the chart
//yTitle: Axis Y's Title or description
//ifHorizontal: the chart is Bar(Horizontal) or Column(Vertical)
//ifBarStack: stack the bars or seperate the bars
//----------------------------------------------------------//
function setBarChart(divID, chartTitle, chartSubTitle, yTitle, ifHorizontal, ifBarStack) {
    var barType = "column";
    if (ifHorizontal) barType = "bar";
    $('#' + divID).attr('cType', barType).attr('cTitle', chartTitle).attr('csTitle', chartSubTitle).attr('yTitle', yTitle).attr('ifStack', ifBarStack);
    Highcharts.setOptions({
        chart: {
            renderTo: divID,
            className: 'chartBox',
            type: barType,
            style: {
                fontFamily: '微软雅黑,宋体',
                fontSize: '12px'
            }
        },
        title: {
            text: chartTitle,
            style: {
                letterSpacing: '2px'
            }
        },
        subtitle: {
            text: chartSubTitle
        },
        plotOptions: {
            bar: {
                dataLabels: {
                    enabled: true,
                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'
                }
            },
            column: {
                dataLabels: {
                    enabled: true,
                    color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'black'
                }
            }
        },
        yAxis: {
            title: {
                text: yTitle
            },
            stackLabels: {
                enabled: true,
                style: {
                    fontWeight: 'bold'
                }
            }

        }
    });

    if (ifBarStack) {
        Highcharts.setOptions({
            plotOptions: {
                series: {
                    stacking: 'normal'
                }
            }
        });
    }
    else {
        Highcharts.setOptions({
            plotOptions: {
                series: {
                    stacking: null
                }
            }
        });
    }
}

//---------------Set Line Style Chart--------------//
//divID: the Div ID that chart render to
//chartTitle: Title of the Chart
//chartSubTitle: Subtitle of the chart
//yTitle: Axis Y's Title or description
//----------------------------------------------------------//
function setLineChart(divID, chartTitle, chartSubTitle, yTitle) {
    $('#' + divID).attr('cType', 'line').attr('cTitle', chartTitle).attr('csTitle', chartSubTitle).attr('yTitle', yTitle).attr('ifStack', false);
    Highcharts.setOptions({
        chart: {
            renderTo: divID,
            className: 'chartBox',
            type: 'line',
            style: {
                fontFamily: '微软雅黑,宋体',
                fontSize: '12px'
            }
        },
        title: {
            text: chartTitle,
            style: {
                letterSpacing: '2px'
            }
        },
        subtitle: {
            text: chartSubTitle
        },
        plotOptions: {
            line: {
				dataLabels: {
					enabled: true
	            },
				enableMouseTracking: true
			}
        },
        yAxis: {
            title: {
                text: yTitle
            }

        }
    }); 
}

//---------------Set Pie Style Chart--------------//
//divID: the Div ID that chart render to
//chartTitle: Title of the Chart
//chartSubTitle: Subtitle of the chart
//yTitle: Axis Y's Title or description
//----------------------------------------------------------//
function setPieChart(divID, chartTitle, chartSubTitle, yTitle) {
    $('#' + divID).attr('cType', 'pie').attr('cTitle', chartTitle).attr('csTitle', chartSubTitle).attr('yTitle', yTitle).attr('ifStack', false);
    Highcharts.setOptions({
        chart: {
            renderTo: divID,
            className: 'chartBox',
            type: 'pie',
            style: {
                fontFamily: '微软雅黑,宋体',
                fontSize: '12px'
            }
        },
        title: {
            text: chartTitle,
            style: {
                letterSpacing: '2px'
            }
        },
        subtitle: {
            text: chartSubTitle
        },
        plotOptions: {
            pie: {
                allowPointSelect: true,
                cursor: 'pointer',
                dataLabels: {
                    enabled: true,
                    color: '#000000',
                    connectorColor: '#000000',
                    formatter: function () {
                        return '<b>' + this.point.name + '</b>: ' + this.percentage.toFixed(2) + ' %';
                    }
                }
            }

        }
    });
}



//"CAT|天津|北京|上海ẢJohn|2|5.5|7"

function LoadChart(chartVals) {
    chart1Values = chartVals;
    var options = {
        xAxis: {
            categories: []
        },
        series: []
    };
    var items = chartVals.split('Ả');
    $.each(items, function (itemNo, item) {
        if (itemNo == 0) {
            LoadCategories(options, item);
        }
        else {
            LoadSeries(options, item);
        }
    });

    //Disable lengends when there is only one serie!!!!
    if (items.length <= 2) {
        Highcharts.setOptions({
            legend: {
                enabled: false
            }
        });
    }
    else {
        Highcharts.setOptions({
            legend: {
                enabled: true
            }
        });
    }
    chart1 = new Highcharts.Chart(options);

}

//Load Categories(Axis X)
function LoadCategories(options, categories) {
    var items = categories.split('|');
    $.each(items, function (itemNo, item) {
        if (itemNo > 0) options.xAxis.categories.push(item);
    });
}
//Load Series(Axis Y)
function LoadSeries(options, values) {
    var series = {
        data: []
    };
    var items = values.split('|');
    $.each(items, function (itemNo, item) {
        if (itemNo == 0) {
            series.name = item;
        } else {
            series.data.push(parseFloat(item));
        }
    });
    options.series.push(series);
}

function LoadPieChart(chartVals) {
    chart1Values = chartVals;
    var chartTotal = 0;
    var items = chartVals.split('Ả');
    var names = items[0].split('|');
    var vals = items[1].split('|');
    var slice = [];
    for (var i = 1; i < names.length; i++) {
        if (i == 1) {
            slice.push({
                name: names[i],
                y: parseFloat(vals[i]),
                sliced: true,
                selected: true
            });
        }
        else {
            slice.push({
                name: names[i],
                y: parseFloat(vals[i])
            });
        }
        chartTotal += parseFloat(vals[i]);
    }
    var options = {
        series: [{
            type: 'pie',
            name: names[0],
            data: slice
        }],
        tooltip: {
            formatter: function () {
                return '<b>' + this.point.name + '</b>: ' + this.point.y + '<br/><b>合计</b>: ' + chartTotal + '<br/><b>百分比</b>: ' + this.percentage.toFixed(2) + ' %';
            }
        }
    };
    chart1 = new Highcharts.Chart(options);


}


function chartRedraw(theme, type, ifStack) {
    dvID = chart1.options.chart.renderTo;
    var dvChart = $('#' + dvID);
    var chartType = type;
    var chartTitle = dvChart.attr('cTitle');
    var chartSubTitle = dvChart.attr('csTitle');
    var chartYTitle = dvChart.attr('yTitle');
    var chartStack = ifStack;
    var cTheme = chartTheme;
    if (type == '') {
        chartType = dvChart.attr('cType');
        chartStack = dvChart.attr('ifStack');
    }

    if (theme != "") cTheme = theme;
    chart1.destroy();
    switch (chartType) {
        case "bar":
            setBarChart(dvID, chartTitle, chartSubTitle, chartYTitle, true, chartStack);
            setChartTheme(cTheme);
            LoadChart(chart1Values);
            break;
        case "column":
            setBarChart(dvID, chartTitle, chartSubTitle, chartYTitle, false, chartStack);
            setChartTheme(cTheme);
            LoadChart(chart1Values);
            break;
        case "line":
            setLineChart(dvID, chartTitle, chartSubTitle, chartYTitle)
            setChartTheme(cTheme);
            LoadChart(chart1Values);
            break;
        case "pie":
            setPieChart(dvID, chartTitle, chartSubTitle, chartYTitle)
            setChartTheme(cTheme);
            LoadPieChart(chart1Values);
            break;
        default:
            break;
    }

}

function ToChartConvert(table, divchart, dimension, firsttitle, secondtitle, yaxis) {
    var chartStr = "CAT";
    if ($('#' + table + ' tr').size() <= 1) {
        $('#' + divchart).html('');
        return;
    }
    $('#' + table + ' tr').each(function (i, e) {
        if (i == 0) {
            $(this).children().each(function (j, e) {
                if (j > 0) chartStr += "|" + $.trim($(this).html());
            })
        }
        else {
            chartStr += "Ả";
            $(this).children().each(function (j, e) {
                if (j == 0) {
                    if (dimension == 3) chartStr += $.trim($(this).html());
                }
                else {
                    chartStr += "|" + $.trim($(this).html() == "&nbsp;" ? "0" : $(this).html());
                }
            })
        }
    })
    setBarChart(divchart, firsttitle, secondtitle, yaxis, false, false);
    setChartTheme("Grid");
    LoadChart(chartStr);
}

function ToChart(table, divchart, dimension, firsttitle, secondtitle, yaxis) {
    var chartStr = "CAT";
    var list = 0;
    if ($("#" + table + " [list='" + list + "']").size() <= 1) {
        $('#' + divchart).html('');
        return;
    }
    while ($("#" + table + " [list='" + list + "']").size() > 0) {
        $("#" + table + " [list='" + list + "']").each(function (i, e) {
            if (i == 0) {
                if (list > 0) chartStr += "Ả";
                if (dimension == 3) chartStr += $.trim($(this).html());
            }
            else {
                chartStr += "|" + $.trim($(this).html() == "&nbsp;" ? "0" : $(this).html());
            }
        });
        list++;
    }
    setPieChart(divchart, firsttitle, secondtitle, yaxis);
    setChartTheme("Grid");
    LoadPieChart(chartStr);
}

function queryCondition(tabID) {
    var qc = "", temp = "";
    var tr_num = $('#' + tabID + ' tr').size();
    var i, j, k;
    for (i = 0; i < tr_num; i++) {
        for (j = 0; j < $('#' + tabID + ' tr:eq(' + i + ')').children('td').size(); j++) {
            var cur_td = $("#" + tabID + " tr:eq(" + i.toString() + ") td:eq(" + j.toString() + ")");
            var next_td = $("#" + tabID + " tr:eq(" + i.toString() + ") td:eq(" + (++j) + ")");
            if (cur_td.attr('class') == "tdName") {
                var obj_num = next_td.children().size();
                temp = "";
                for (k = 0; k < obj_num; k++) {
                    var cur_obj = next_td.children().eq(k);
                    try {
                        if (cur_obj.is('input')) {
                            if (cur_obj.val().length > 0) {
                                temp += cur_obj.val() + "-";
                            }
                        }
                        else if (cur_obj.is('select')) {
                            if (cur_obj.find('option:selected').text().length > 0) {
                                temp += cur_obj.find('option:selected').text() + "-";
                            }
                        }
                    }
                    catch (e) {
                        continue;
                    }
                }
                if (temp != "") {
                    temp = temp.substr(0, temp.length - 1);
                    qc += "," + $.trim(cur_td.html()) + ":" + temp;
                }
            }
        }
    }
    if (qc != "") qc = qc.substr(1);
    return qc;
}