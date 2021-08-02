var eChartsInterop = eChartsInterop || {};

eChartsInterop.BuildBarChart = function (elementId) {
    // based on prepared DOM, initialize echarts instance
    var myChart = echarts.init(document.getElementById(elementId));

    // specify chart configuration item and data
    var option = {
        title: {
            text: 'ECharts entry example'
        },
        tooltip: {},
        legend: {
            data: ['Sales']
        },
        xAxis: {
            data: ["shirt", "cardign", "chiffon shirt", "pants", "heels", "socks"]
        },
        yAxis: {},
        series: [{
            name: 'Sales',
            type: 'bar',
            data: [5, 20, 36, 10, 10, 20]
        }]
    };

    // use configuration item and data specified to show chart
    myChart.setOption(option);
};