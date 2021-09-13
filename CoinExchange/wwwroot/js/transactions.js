window.onload = function () {
    var _currencyIdBuy = '#trade-coin-price-buy';
    var _currencyIdSell = '#trade-coin-price-sell';

    var dropdown = $('.transaction-dropdownlist').append('<option selected="true" disabled>Choose Coin name</option>');
    dropdown.prop('selectedIndex', 0);

    $.getJSON("/api/Prices/", function (data) {
        $.each(data, function (key, entry) {
            dropdown.append($('<option></option>').attr('value', entry.id).text(entry.name));
        })
    });

    function dropdownBuy() {
        var _displayCoinNames = $('#transaction-dropdownlist-buy').val();
        if (_displayCoinNames == null) {
            return;
        }
        $.getJSON("/api/Prices/" + _displayCoinNames, dataFunc(_currencyIdBuy));
    };

    function dropdownSell() {
        var _displayCoinNames = $('#transaction-dropdownlist-sell').val();
        if (_displayCoinNames == null) {
            return;
        }
        $.getJSON("/api/Prices/" + _displayCoinNames, dataFunc(_currencyIdSell));
    };

    $('#transaction-dropdownlist-buy').change(dropdownBuy);

    $('#transaction-dropdownlist-sell').change(dropdownSell);

    function dataFunc(path) {
        return function (data) {
            var dataGr = JSON.parse(data);
            var datas = dataGr.market_data.current_price.eur;
            console.log(new Date());
            $.getScript('/js/site.js', function () {
                formatCurrency2(datas, path);
            });
        }            
    }

    setInterval(dropdownBuy, 60000);
    setInterval(dropdownSell, 60000);
}