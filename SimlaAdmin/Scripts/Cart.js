var cart = {
    init:function()
    {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/Home/Index";

        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Cart/ThanhToan";

        });
        $('#btnUpdate').off('click').on('click', function () {
            var listMonan = $('.qty');
            var cartList = [];
            $.each(listMonan, function (i, item) {
                cartList.push({
                    SoLuong: $(item).val(),
                    Monan: {
                        ID: $(item).data('id')
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update', data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Cart";
                    }
                }

            })

        });
        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Cart";
                    }
                }
            })
        });
        $('.btn-delete').off('click').on('click', function () {
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart/Cart";
                    }
                }

            })
        });
    }
}
cart.init();