// formating prices in EUR currency format
function formatCurrency(id) {
    let cells = Array.prototype.slice.call(document.querySelectorAll(id));
    cells.forEach(function (cell) {
        if (cell.textContent.includes('e')) {
            cell.textContent = (cell.textContent);
        } else { cell.textContent = (+cell.textContent).toLocaleString('en-US', { style: 'currency', currency: 'EUR' }); }
    });
}

function formatCurrency2(data, path) {
    var newData = new Intl.NumberFormat('en-US', {
        style: 'currency', 
        currency: 'EUR',
        maximumFractionDigits: 10,
        }).format(data);
    $(path).val(newData);
}