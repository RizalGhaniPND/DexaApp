$(document).ready(function () {
    var flag = 0;

    $("#btn-add").on("click", function () {
        alert_notification();

        if ($("#tbody-create tr").length > 0) {
            $("#btn-submit").attr('hidden', false)
        } else {
            $("#btn-submit").attr('hidden', true)
        };
    });

    $('.onlynumber').keyup(function (e) {
        if (/\D/g.test(this.value)) {
            this.value = this.value.replace(/\D/g, '');
        }
    });

    function reset() {
        $("#Customer_CustomerID").val("");
        $("#Customer_CustomerName").val("");
        $("#Customer_Address").val("");
        $("#Customer_Code").val("");
        $("#Customer_StartDate").val("");
        $("#Customer_EndDate").val("");
        $("#Customer_OutletId").val("");

        $(".customerid-validation").addClass("d-none");
    }

    function add_value() {
        var _customerid = $("#Customer_CustomerID").val();
        var _customername = $("#Customer_CustomerName").val();
        var _address = $("#Customer_Address").val();
        var _code = $("#Customer_Code").val();
        var _startdate = $("#Customer_StartDate").val();
        var _endate = $("#Customer_EndDate").val();
        var _outletid = $("#Customer_OutletId").val();

        var _input_customid = '<input type="text" name="item[' + flag + '].CustomerID" class="form-control border-0 py-0" value="' + _customerid + '" readonly />';
        var _input_customername = '<input type="text" name="item[' + flag + '].CustomerName" class="form-control border-0 py-0" value="' + _customername + '" readonly />';
        var _input_address = '<input type="text" name="item[' + flag + '].Address" class="form-control border-0 py-0" value="' + _address + '" readonly />';
        var _input_code = '<input type="text" name="item[' + flag + '].Code" class="form-control border-0 py-0" value="' + _code + '" readonly />';
        var _input_startdate = '<input type="text" name="item[' + flag + '].StartDate" class="form-control border-0 py-0" value="' + _startdate + '" readonly />';
        var _input_enddate = '<input type="text" name="item[' + flag + '].EndDate" class="form-control border-0 py-0" value="' + _endate + '" readonly />';
        var _input_outletid = '<input type="text" name="item[' + flag + '].OutletID" class="form-control border-0 py-0" value="' + _outletid + '" readonly />';

        var _tr = '<tr class="text-center" id=' + flag + '><td>' + _input_customid + '</td>' +
            '</td><td>' + _input_customername + '</input>' +
            '</td><td>' + _input_code + '</input>' +
            '</td><td>' + _input_startdate + '</input>' +
            '</td><td>' + _input_enddate + '</input>' +
            '</td><td>' + _input_address + '</input>' +
            '</td><td>' + _input_outletid + '</input>' +
            '</td></tr>'

        if (_customerid != "" && _customername != "" && _outletid != "") {
            $("#tbody-create").append(_tr);
            $("#btn-save").removeClass("d-none");
            reset();
            flag++;
        }
    }

    function alert_notification() {
        var cus_id = $("#Customer_CustomerID").val();
        var cus_name = $("#Customer_CustomerName").val();
        var cus_outlet = $("#Customer_OutletId").val();

        var alert_component = '<div class="alert alert-danger alert-dismissible fade show" role="alert">' +
            '<strong>Error !</strong> Customer ID, Customer Name and Outlet Can Not be Null.' +
            '<button type="button" class="close" data-dismiss="alert" aria-label="Close">' +
            '<span aria-hidden="true">&times;</span></button></div>'

        if (cus_id == "" || cus_name == "" || cus_outlet == "") {
            $("#alert-message").append(alert_component);
            $(".alert").delay(3000).fadeOut(
                "normal",
                function () {
                    $(this).remove();
                });
        } else {
            $("#alert-message").empty();
            add_value();
        }
    }
});