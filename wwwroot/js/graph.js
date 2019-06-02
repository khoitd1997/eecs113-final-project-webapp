function drawGraph(temperatures, humidities, time_stamps) {
    var temperature_ctx = document.getElementById('temperature_chart').getContext('2d');
    var temperature_chart = new Chart(temperature_ctx, {
        type: 'line',

        data: {
            labels: time_stamps,
            datasets: [{
                label: 'Temperatue vs Time',

                backgroundColor: 'transparent',
                // borderColor: "Orange",
                // borderColor: "MediumSeaGreen",
                borderColor: "CadetBlue",

                pointRadius: "5",
                lineTension: "0",

                data: temperatures
            }]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Time',
                        fontSize: "18",
                        fontColor: "rgba(255, 255, 255, 0.6)",
                        display: false,
                    },
                    gridLines: {
                        display: true,
                        color: "rgba(255, 255, 255, 0.198)",
                    },
                    ticks: {
                        fontColor: "rgba(255, 255, 255, 0.6)",
                    },
                }],
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Temperature(C)',
                        fontSize: "18",
                        fontColor: "rgba(255, 255, 255, 0.6)"
                    },
                    gridLines: {
                        display: true,
                        color: "rgba(255, 255, 255, 0.198)",
                    },
                    ticks: {
                        fontColor: "rgba(255, 255, 255, 0.6)",
                    },
                }],
            },
            legend: {
                display: false,
            }
        }
    });

    var humidity_ctx = document.getElementById('humidity_chart').getContext('2d');
    var humidity_chart = new Chart(humidity_ctx, {
        type: 'line',

        data: {
            labels: time_stamps,
            datasets: [{
                label: 'Humidity vs Time',

                backgroundColor: 'transparent',
                // borderColor: "Orange",
                borderColor: "MediumSeaGreen",
                // borderColor: "CadetBlue",

                pointRadius: "5",
                lineTension: "0",

                data: humidities
            }]
        },

        options: {
            responsive: true,
            maintainAspectRatio: false,
            scales: {
                xAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Time',
                        fontSize: "18",
                        fontColor: "rgba(255, 255, 255, 0.6)",
                        display: false,
                    },
                    gridLines: {
                        display: true,
                        color: "rgba(255, 255, 255, 0.198)",
                    },
                    ticks: {
                        fontColor: "rgba(255, 255, 255, 0.6)",
                    },
                }],
                yAxes: [{
                    scaleLabel: {
                        display: true,
                        labelString: 'Humidity(%)',
                        fontSize: "18",
                        fontColor: "rgba(255, 255, 255, 0.6)"
                    },
                    gridLines: {
                        display: true,
                        color: "rgba(255, 255, 255, 0.198)",
                    },
                    ticks: {
                        suggestedMax: 100,
                        suggestedMin: 0,
                        fontColor: "rgba(255, 255, 255, 0.6)",
                    },
                }],
            },
            legend: {
                display: false,
            }
        }
    });
}