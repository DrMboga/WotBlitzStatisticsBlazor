var eChartsInterop = eChartsInterop || {};

eChartsInterop.BuildBarChartByTankType = function (elementId, chartTitle, chartData) {
    var tankTypes = {
        'HeavyTank': '/tank-type/vehicle.class.heavy.small.scale-200.png',
        'AtSpg': '/tank-type/vehicle.class.atspg.small.scale-200.png',
        'MediumTank': '/tank-type/vehicle.class.medium.small.scale-200.png',
        'LightTank': '/tank-type/vehicle.class.light.small.scale-200.png'
    };

    var seriesLabel = {
        show: true
    }

    // based on prepared DOM, initialize echarts instance
    var myChart = echarts.init(document.getElementById(elementId), 'dark');

    var lightData = chartData.find(d => d.tankType === 'lightTank');
    var mediumData = chartData.find(d => d.tankType === 'mediumTank');
    var heavyData = chartData.find(d => d.tankType === 'heavyTank');
    var atData = chartData.find(d => d.tankType === 'AT-SPG');

    // specify chart configuration item and data
    var option = {
        title: {
            text: chartTitle
        },
        toolbox: {
            show: true,
            feature: {
                saveAsImage: {}
            }
        },
        xAxis: {
            type: 'value',
            name: '',
            axisLabel: {
                formatter: '{value}'
            }
        },
        yAxis: {
            type: 'category',
            data: ['HeavyTank', 'AtSpg', 'MediumTank', 'LightTank'],
            axisTick: {
                alignWithLabel: true
            },
            axisLabel: {
                formatter: function (value) {
                    return '{' + value + '| }';
                },
                rich: {
                    value: {
                        lineHeight: 10,
                        align: 'center'
                    },
                    HeavyTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.HeavyTank
                        }
                    },
                    AtSpg: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.AtSpg
                        }
                    },
                    MediumTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.MediumTank
                        }
                    },
                    LightTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.LightTank
                        }
                    }
                }
            }
        },
        series: [
            {
                type: 'bar',
                label: seriesLabel,
                barWidth: '30px',
                data: [
                    {
                        value: heavyData.value,
                        itemStyle: {
                            color: heavyData.color
                        }
                    },
                    {
                        value: atData.value,
                        itemStyle: {
                            color: atData.color
                        }
                    },
                    {
                        value: mediumData.value,
                        itemStyle: {
                            color: mediumData.color
                        }
                    },
                    {
                        value: lightData.value,
                        itemStyle: {
                            color: lightData.color
                        }
                    }]
            }]
    };

    // use configuration item and data specified to show chart
    myChart.setOption(option);
    window.addEventListener('resize',
        function() {
            myChart.resize();
        });
};

eChartsInterop.BuildStackedBarChart = function (elementId) {
    var tankTypes = {
        'HeavyTank': '/tank-type/vehicle.class.heavy.small.scale-200.png',
        'AtSpg': '/tank-type/vehicle.class.atspg.small.scale-200.png',
        'MediumTank': '/tank-type/vehicle.class.medium.small.scale-200.png',
        'LightTank': '/tank-type/vehicle.class.light.small.scale-200.png'
    };

    var seriesLabel = {
        show: true
    }

    // based on prepared DOM, initialize echarts instance
    var myChart = echarts.init(document.getElementById(elementId), 'dark');

    // specify chart configuration item and data
    var option = {

        title: {
            text: 'Statistics by tank types'
        },
        tooltip: {
            trigger: 'axis',
            axisPointer: {            // Use axis to trigger tooltip
                type: 'shadow'        // 'shadow' as default; can also be 'line' or 'shadow'
            }
        },
        legend: {
            data: ['Battles', '% Побед', 'Avg Dmg']
        },
        grid: {
            left: '3%',
            right: '4%',
            bottom: '3%',
            containLabel: true
        },
        xAxis: {
            type: 'value'
        },
        toolbox: {
            show: true,
            feature: {
                saveAsImage: {}
            }
        },
        yAxis: {
            type: 'category',
            data: ['HeavyTank', 'AtSpg', 'MediumTank', 'LightTank'],
            axisTick: {
                alignWithLabel: true
            },
            axisLabel: {
                formatter: function (value) {
                    return '{' + value + '| }';
                },
                rich: {
                    value: {
                        lineHeight: 10,
                        align: 'center'
                    },
                    HeavyTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.HeavyTank
                        }
                    },
                    AtSpg: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.AtSpg
                        }
                    },
                    MediumTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.MediumTank
                        }
                    },
                    LightTank: {
                        height: 20,
                        width: 20,
                        align: 'center',
                        backgroundColor: {
                            image: tankTypes.LightTank
                        }
                    }
                }
            }
        },
        series: [
            {
                name: 'Battles',
                type: 'bar',
                stack: 'total',
                label: {
                    show: true
                },
                emphasis: {
                    focus: 'series'
                },
                data: [830, 1300, 50, 5000]
            },
            {
                name: '% Побед',
                type: 'bar',
                stack: 'total',
                label: {
                    show: true
                },
                emphasis: {
                    focus: 'series'
                },
                data: [35, 56, 48, 60]
            },
            {
                name: 'Avg Dmg',
                type: 'bar',
                stack: 'total',
                label: {
                    show: true
                },
                emphasis: {
                    focus: 'series'
                },
                data: [600, 2500, 1700, 1300]
            }
        ]
    };

    // use configuration item and data specified to show chart
    myChart.setOption(option);
    window.onresize = function () {
        myChart.resize();
    };
};