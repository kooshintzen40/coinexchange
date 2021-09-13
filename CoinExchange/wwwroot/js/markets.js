window.onload = function () {
    var chartCreated = false;
    var _displayCoinName = "{coin}";
    var _currencyId = '#coin_currency';

    $.getScript('/js/site.js', function () {
        formatCurrency(_currencyId);
    });

    $("#Coins").change(function () {
        var _displayCoinName = $("#Coins").val();
        $.getJSON("/api/Json/" + _displayCoinName.trim(), printData);
    });

    if (_displayCoinName == "{coin}") {
        $.getJSON("/api/Json/{coin}", printData);
    }

    function printData(data) {
        var dataGr = JSON.parse(data);
        var months = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
        var time = dataGr.prices.map(function (elem) {
            var date = new Date(elem[0]);
            var yr = date.getFullYear();
            var mnth = months[date.getMonth()];
            var day = date.getDate();
            var stringDate = day + "-" + mnth + "-" + yr;
            return stringDate;
        })

        var price = dataGr.prices.map(function (elem) {
            return elem[1];
        })

        decimateArray(time, price);

        if (chartCreated == false) {
            createChart(time, price);
            chartCreated = true;
        } else {
            resetCanvas();
            createChart(time, price);
        }
    }

    function createChart(time, price) {
        var ctx = document.getElementById('coinChart').getContext('2d');
        
        var chart = new Chart(ctx, {
            type: 'line',
            data: {
                labels: time,
                datasets: [{
                    label: 'price in (EUR)',
                    data: price,
                    borderColor: 'blue',
                    borderWidth: 4
                }]
            },
            options: {
                scales: {
                    y: {
                        beginAtZero: true
                    }
                }
            }
        });
    }

    function resetCanvas() {
        $('#coinChart').remove();
        $('#graphContainer').append('<canvas id="coinChart"></canvas>');
    }

    function decimateArray(time, price) {
        for (var i = 0; i < time.length; i += 0.2) {
            time.splice(i, 1);
            price.splice(i, 1);
        }
    }
}
    


