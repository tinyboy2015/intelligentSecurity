var themeGray;
var themeGreen;
var themeBlue;
var themeGrid;

//----------------Theme Gray-----------//
//
//-----------------------------------------//
themeGray = {
    colors: ["#DDDF0D", "#7798BF", "#55BF3B", "#DF5353", "#aaeeee", "#ff0066", "#eeaaee",
		"#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
    chart: {
        backgroundColor: {
            linearGradient: [0, 0, 0, 400],
            stops: [
				[0, 'rgb(96, 96, 96)'],
				[1, 'rgb(16, 16, 16)']
			]
        },
        borderWidth: 0,
        borderRadius: 8,
        plotBackgroundColor: null,
        plotShadow: false,
        plotBorderWidth: 0
    },
    title: {
        style: {
            color: '#FFF'

        }
    },
    subtitle: {
        style: {
            color: '#DDD'
        }
    },
    xAxis: {
        gridLineWidth: 1,
        lineColor: '#999',
        tickColor: '#999',
        labels: {
            style: {
                color: '#999',
                fontWeight: 'bold'
            }
        },
        title: {
            style: {
                color: '#AAA'

            }
        }
    },
    yAxis: {
        alternateGridColor: null,
        minorTickInterval: null,
        gridLineColor: 'rgba(255, 255, 255, .1)',
        lineWidth: 0,
        tickWidth: 0,
        labels: {
            style: {
                color: '#999',
                fontWeight: 'bold'
            }
        },
        title: {
            style: {
                color: '#AAA'
            }
        }
    },
    legend: {
        itemStyle: {
            color: '#CCC'
        },
        itemHoverStyle: {
            color: '#FFF'
        },
        itemHiddenStyle: {
            color: '#333'
        }
    },
    labels: {
        style: {
            color: '#CCC'
        }
    },
    tooltip: {
        backgroundColor: {
            linearGradient: [0, 0, 0, 50],
            stops: [
				[0, 'rgba(96, 96, 96, .8)'],
				[1, 'rgba(16, 16, 16, .8)']
			]
        },
        borderWidth: 0,
        style: {
            color: '#FFF'
        }
    },


    plotOptions: {
        line: {
            dataLabels: {
                color: '#CCC'
            },
            marker: {
                lineColor: '#333'
            }
        },
        spline: {
            marker: {
                lineColor: '#333'
            }
        },
        scatter: {
            marker: {
                lineColor: '#333'
            }
        },
        candlestick: {
            lineColor: 'white'
        }
    },

    toolbar: {
        itemStyle: {
            color: '#CCC'
        }
    },

    navigation: {
        buttonOptions: {
            backgroundColor: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#606060'],
					[0.6, '#333333']
				]
            },
            borderColor: '#000000',
            symbolStroke: '#C0C0C0',
            hoverSymbolStroke: '#FFFFFF'
        }
    },

    exporting: {
        buttons: {
            exportButton: {
                symbolFill: '#55BE3B'
            },
            printButton: {
                symbolFill: '#7797BE'
            }
        }
    },

    // scroll charts
    rangeSelector: {
        buttonTheme: {
            fill: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
            },
            stroke: '#000000',
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            },
            states: {
                hover: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.4, '#BBB'],
							[0.6, '#888']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'white'
                    }
                },
                select: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.1, '#000'],
							[0.3, '#333']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'yellow'
                    }
                }
            }
        },
        inputStyle: {
            backgroundColor: '#333',
            color: 'silver'
        },
        labelStyle: {
            color: 'silver'
        }
    },

    navigator: {
        handles: {
            backgroundColor: '#666',
            borderColor: '#AAA'
        },
        outlineColor: '#CCC',
        maskFill: 'rgba(16, 16, 16, 0.5)',
        series: {
            color: '#7798BF',
            lineColor: '#A6C7ED'
        }
    },

    scrollbar: {
        barBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        barBorderColor: '#CCC',
        buttonArrowColor: '#CCC',
        buttonBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        buttonBorderColor: '#CCC',
        rifleColor: '#FFF',
        trackBackgroundColor: {
            linearGradient: [0, 0, 0, 10],
            stops: [
				[0, '#000'],
				[1, '#333']
			]
        },
        trackBorderColor: '#666'
    },

    // special colors for some of the demo examples
    legendBackgroundColor: 'rgba(48, 48, 48, 0.8)',
    legendBackgroundColorSolid: 'rgb(70, 70, 70)',
    dataLabelsColor: '#444',
    textColor: '#E0E0E0',
    maskColor: 'rgba(255,255,255,0.3)'
};

//----------DarkBlue Theme-----------------//
//
//-----------------------------------------//
themeBlue = {
    colors: ["#DDDF0D", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee",
		"#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
    chart: {
        backgroundColor: {
            linearGradient: [0, 0, 250, 500],
            stops: [
				[0, 'rgb(48, 48, 96)'],
				[1, 'rgb(0, 0, 0)']
			]
        },
        borderColor: '#000000',
        borderWidth: 2,
        borderRadius: 8,
        className: 'dark-container',
        plotBackgroundColor: 'rgba(255, 255, 255, .1)',
        plotBorderColor: '#CCCCCC',
        plotBorderWidth: 1
    },
    title: {
        style: {
            color: '#C0C0C0'
        }
    },
    subtitle: {
        style: {
            color: '#666666'
        }
    },
    xAxis: {
        gridLineColor: '#333333',
        gridLineWidth: 1,
        labels: {
            style: {
                color: '#A0A0A0'
            }
        },
        lineColor: '#A0A0A0',
        tickColor: '#A0A0A0',
        title: {
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            }
        }
    },
    yAxis: {
        gridLineColor: '#333333',
        labels: {
            style: {
                color: '#A0A0A0'
            }
        },
        lineColor: '#A0A0A0',
        minorTickInterval: null,
        tickColor: '#A0A0A0',
        tickWidth: 1,
        title: {
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            }
        }
    },
    tooltip: {
        backgroundColor: 'rgba(0, 0, 0, 0.75)',
        style: {
            color: '#F0F0F0'
        }
    },
    toolbar: {
        itemStyle: {
            color: 'silver'
        }
    },
    plotOptions: {
        line: {
            dataLabels: {
                color: '#CCC'
            },
            marker: {
                lineColor: '#333'
            }
        },
        spline: {
            marker: {
                lineColor: '#333'
            }
        },
        scatter: {
            marker: {
                lineColor: '#333'
            }
        },
        candlestick: {
            lineColor: 'white'
        }
    },
    legend: {
        itemStyle: {
            color: '#A0A0A0'
        },
        itemHoverStyle: {
            color: '#FFF'
        },
        itemHiddenStyle: {
            color: '#444'
        }
    },
    credits: {
        style: {
            color: '#666'
        }
    },
    labels: {
        style: {
            color: '#CCC'
        }
    },

    navigation: {
        buttonOptions: {
            backgroundColor: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#606060'],
					[0.6, '#333333']
				]
            },
            borderColor: '#000000',
            symbolStroke: '#C0C0C0',
            hoverSymbolStroke: '#FFFFFF'
        }
    },

    exporting: {
        buttons: {
            exportButton: {
                symbolFill: '#55BE3B'
            },
            printButton: {
                symbolFill: '#7797BE'
            }
        }
    },

    // scroll charts
    rangeSelector: {
        buttonTheme: {
            fill: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
            },
            stroke: '#000000',
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            },
            states: {
                hover: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.4, '#BBB'],
							[0.6, '#888']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'white'
                    }
                },
                select: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.1, '#000'],
							[0.3, '#333']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'yellow'
                    }
                }
            }
        },
        inputStyle: {
            backgroundColor: '#333',
            color: 'silver'
        },
        labelStyle: {
            color: 'silver'
        }
    },

    navigator: {
        handles: {
            backgroundColor: '#666',
            borderColor: '#AAA'
        },
        outlineColor: '#CCC',
        maskFill: 'rgba(16, 16, 16, 0.5)',
        series: {
            color: '#7798BF',
            lineColor: '#A6C7ED'
        }
    },

    scrollbar: {
        barBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        barBorderColor: '#CCC',
        buttonArrowColor: '#CCC',
        buttonBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        buttonBorderColor: '#CCC',
        rifleColor: '#FFF',
        trackBackgroundColor: {
            linearGradient: [0, 0, 0, 10],
            stops: [
				[0, '#000'],
				[1, '#333']
			]
        },
        trackBorderColor: '#666'
    },

    // special colors for some of the
    legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
    legendBackgroundColorSolid: 'rgb(35, 35, 70)',
    dataLabelsColor: '#444',
    textColor: '#C0C0C0',
    maskColor: 'rgba(255,255,255,0.3)'
};

//----------------Theme Dark Green-----------//
//
//-----------------------------------------//
themeGreen = {
    colors: ["#DDDF0D", "#55BF3B", "#DF5353", "#7798BF", "#aaeeee", "#ff0066", "#eeaaee",
		"#55BF3B", "#DF5353", "#7798BF", "#aaeeee"],
    chart: {
        backgroundColor: {
            linearGradient: [0, 0, 250, 500],
            stops: [
				[0, 'rgb(48, 96, 48)'],
				[1, 'rgb(0, 0, 0)']
			]
        },
        borderColor: '#000000',
        borderWidth: 2,
        borderRadius: 8,
        className: 'dark-container',
        plotBackgroundColor: 'rgba(255, 255, 255, .1)',
        plotBorderColor: '#CCCCCC',
        plotBorderWidth: 1
    },
    title: {
        style: {
            color: '#C0C0C0'
        }
    },
    subtitle: {
        style: {
            color: '#666666'
        }
    },
    xAxis: {
        gridLineColor: '#333333',
        gridLineWidth: 1,
        labels: {
            style: {
                color: '#A0A0A0'
            }
        },
        lineColor: '#A0A0A0',
        tickColor: '#A0A0A0',
        title: {
            style: {
                color: '#CCC',
                fontWeight: 'bold'

            }
        }
    },
    yAxis: {
        gridLineColor: '#333333',
        labels: {
            style: {
                color: '#A0A0A0'
            }
        },
        lineColor: '#A0A0A0',
        minorTickInterval: null,
        tickColor: '#A0A0A0',
        tickWidth: 1,
        title: {
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            }
        }
    },
    tooltip: {
        backgroundColor: 'rgba(0, 0, 0, 0.75)',
        style: {
            color: '#F0F0F0'
        }
    },
    toolbar: {
        itemStyle: {
            color: 'silver'
        }
    },
    plotOptions: {
        line: {
            dataLabels: {
                color: '#CCC'
            },
            marker: {
                lineColor: '#333'
            }
        },
        spline: {
            marker: {
                lineColor: '#333'
            }
        },
        scatter: {
            marker: {
                lineColor: '#333'
            }
        },
        candlestick: {
            lineColor: 'white'
        }
    },
    legend: {
        itemStyle: {
            font: '9pt Trebuchet MS, Verdana, sans-serif',
            color: '#A0A0A0'
        },
        itemHoverStyle: {
            color: '#FFF'
        },
        itemHiddenStyle: {
            color: '#444'
        }
    },
    credits: {
        style: {
            color: '#666'
        }
    },
    labels: {
        style: {
            color: '#CCC'
        }
    },

    navigation: {
        buttonOptions: {
            backgroundColor: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#606060'],
					[0.6, '#333333']
				]
            },
            borderColor: '#000000',
            symbolStroke: '#C0C0C0',
            hoverSymbolStroke: '#FFFFFF'
        }
    },

    exporting: {
        buttons: {
            exportButton: {
                symbolFill: '#55BE3B'
            },
            printButton: {
                symbolFill: '#7797BE'
            }
        }
    },

    // scroll charts
    rangeSelector: {
        buttonTheme: {
            fill: {
                linearGradient: [0, 0, 0, 20],
                stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
            },
            stroke: '#000000',
            style: {
                color: '#CCC',
                fontWeight: 'bold'
            },
            states: {
                hover: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.4, '#BBB'],
							[0.6, '#888']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'white'
                    }
                },
                select: {
                    fill: {
                        linearGradient: [0, 0, 0, 20],
                        stops: [
							[0.1, '#000'],
							[0.3, '#333']
						]
                    },
                    stroke: '#000000',
                    style: {
                        color: 'yellow'
                    }
                }
            }
        },
        inputStyle: {
            backgroundColor: '#333',
            color: 'silver'
        },
        labelStyle: {
            color: 'silver'
        }
    },

    navigator: {
        handles: {
            backgroundColor: '#666',
            borderColor: '#AAA'
        },
        outlineColor: '#CCC',
        maskFill: 'rgba(16, 16, 16, 0.5)',
        series: {
            color: '#7798BF',
            lineColor: '#A6C7ED'
        }
    },

    scrollbar: {
        barBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        barBorderColor: '#CCC',
        buttonArrowColor: '#CCC',
        buttonBackgroundColor: {
            linearGradient: [0, 0, 0, 20],
            stops: [
					[0.4, '#888'],
					[0.6, '#555']
				]
        },
        buttonBorderColor: '#CCC',
        rifleColor: '#FFF',
        trackBackgroundColor: {
            linearGradient: [0, 0, 0, 10],
            stops: [
				[0, '#000'],
				[1, '#333']
			]
        },
        trackBorderColor: '#666'
    },

    // special colors for some of the
    legendBackgroundColor: 'rgba(0, 0, 0, 0.5)',
    legendBackgroundColorSolid: 'rgb(35, 35, 70)',
    dataLabelsColor: '#444',
    textColor: '#C0C0C0',
    maskColor: 'rgba(255,255,255,0.3)'
};

//----------Grid Theme-----------------//
//
//-----------------------------------------//
themeGrid = {
    colors: ['#058DC7', '#50B432', '#ED561B', '#DDDF00', '#24CBE5', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
    chart: {
        backgroundColor: {
            linearGradient: [0, 0, 500, 500],
            stops: [
				[0, 'rgb(255, 255, 255)'],
				[1, 'rgb(240, 240, 255)']
			]
        },
        borderWidth: 2,
        borderRadius: 8,
        plotBackgroundColor: 'rgba(255, 255, 255, .9)',
        plotShadow: true,
        plotBorderWidth: 1
    },
    title: {
        style: {
            color: '#000'
        }
    },
    subtitle: {
        style: {
            color: '#666666'
        }
    },
    xAxis: {
        gridLineWidth: 1,
        lineColor: '#000',
        tickColor: '#000',
        labels: {
            style: {
                color: '#000'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold'

            }
        }
    },
    yAxis: {
        minorTickInterval: 'auto',
        lineColor: '#000',
        lineWidth: 1,
        tickWidth: 1,
        tickColor: '#000',
        labels: {
            style: {
                color: '#000'
            }
        },
        title: {
            style: {
                color: '#333',
                fontWeight: 'bold'
            }
        },
        stackLabels: {
            enabled: true,
            style: {
                color: '#0634B8'
            }
        }
    },
    legend: {
        itemStyle: {
            color: 'black'

        },
        itemHoverStyle: {
            color: '#039'
        },
        itemHiddenStyle: {
            color: 'gray'
        }
    },
    labels: {
        style: {
            color: '#99b'
        }
    }
};


function setChartTheme(theme) {
    switch (theme) {
        case "Gray":
            Highcharts.theme = themeGray;
            break;
        case "Green":
            Highcharts.theme = themeGreen;
            break;
        case "Blue":
            Highcharts.theme = themeBlue;
            break;
        case "Grid":
            Highcharts.theme = themeGrid;
            break;
        default:
            Highcharts.theme = null;
            break;
    }
    chartTheme = theme;
    Highcharts.setOptions(Highcharts.theme);
}