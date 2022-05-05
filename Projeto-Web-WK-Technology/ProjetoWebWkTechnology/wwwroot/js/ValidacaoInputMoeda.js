$(document).ready(function () {
    $('#currency').maskMoney({
        prefix: "R$: ",
        decimal: ",",
        thousands: "."
    });
});