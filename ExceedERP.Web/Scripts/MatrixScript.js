function fnAllowNumeric_deleted() {
    if ((event.keyCode < 48 || event.keyCode > 57) && event.keyCode != 8) {
        event.keyCode = 0;
        alert("Accept only Integer..!");
        return false;
    }
}

$(document).ready(function () {
   
  

    $('#CustomerName').change(function () {
        var item = $('#CustomerName').val();
        $.ajax({
            url: '/Finance/JSON/GetCustomerID',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#CustomerID').val('');
                        $('#CustomerID').val(result[i].ID);
                    }
                }
                else {
                    $('#CustomerID').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng
    $('#InvoiceNumber').change(function () {
        var item = $('#InvoiceNumber').val();
        $.ajax({
            url: '/Finance/JSON/GetARInvoiceDueAmount',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#BalanceDue').val('');
                        $('#BalanceDue').val(result[i].AmountDue);
                    }
                }
                else {
                    $('#BalanceDue').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng


    //grn extra initialize
    if ($('#IsExtra').prop('checked') == true) {
        $('label[for=ExtraQuantity], input#ExtraQuantity').show();
        $("#ExtraQuantity").show();
    }

    else {
        $("#ExtraQuantity").hide();
        $("#ExtraQuantity").val('');
        $("#ExtraQuantity").val('0.0');
        $('label[for=ExtraQuantity], input#ExtraQuantity').hide();
    }

    $('#IsExtra').click(function () {
        if ($('#IsExtra').prop('checked') == true) {
            $('label[for=ExtraQuantity], input#ExtraQuantity').show();
            $("#ExtraQuantity").show();
        }
        else {
            $("#ExtraQuantity").hide();
            $("#ExtraQuantity").val('');
            $("#ExtraQuantity").val('0.0');
            $('label[for=ExtraQuantity], input#ExtraQuantity').hide();
        }
    });


    $("#divToggle").hide();
    $("#divToggleBuilding").hide();
    if ($('#IsBuilding').prop('checked', true))
    {
        $("#divToggleBuilding").show();
    }
    else
    {

    }
    $('#IsMachinery').click(function () {       
        if (this.checked) {
            $("#divToggle").show();
            $('#IsBuilding').prop('checked', false);
            $("#divToggleBuilding").hide();
        }
        else {
            $("#divToggle").hide();
        }
    });
    $('#IsBuilding').click(function () {
        if (this.checked) {
            $("#divToggleBuilding").show();
            $('#IsMachinery').prop('checked', false);
            $("#divToggle").hide();
        }
        else {
            $("#divToggleBuilding").hide();
        }
    });


    $('#ByBank').click(function () {
        if (this.checked) {
            $('label[for=BankName], input#BankName').show();
            $("#BankName").show();

            $('label[for=Account], input#Account').show();
            $("#Account").show();
        }
        else {
            $("#BankName").hide();
            $("#BankName").val('');
            $("#BankName").val('0.0');
            $('label[for=BankName], input#BankName').hide();

            $("#Account").hide();
            $("#Account").val('');
            $("#Account").val('0.0');
            $('label[for=Account], input#Account').hide();
        }
    });
    //alert("hi");
    //use default datepicker in chrome and jquery for others
    if (navigator.userAgent.indexOf('Chrome') == -1) {
        //datepicker
        var currentDate = new Date();
        $('.date-picker').datepicker({ dateFormat: 'dd/mm/yy' });
        //$(".date-picker").datepicker("setDate", new Date());
    }
    //alert("ready!3");
    $('#Items').change(function () {
        var item = $('#Items').val();
        $.ajax({
            url: '/ARInvoiceLines/GetProduct',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#Description').val('');
                        $('#Description').val(result[i].Description);
                        $('#AccountCode').val('');
                        $('#AccountCode').val(result[i].Account);
                    }
                }
                else {
                    $('#Items').val('');
                    $('#Description').val('');
                    $('#AccountCode').val('');
                    ////alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng

    $('#BudgetYear').change(function () {
        var item = $('#BudgetYear').val();
        //get departments
        $.ajax({
            url: '/Finance/JSON/GetMonths',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#BudgetMonth')
                    .empty()
                    //.append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#BudgetMonth').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#BudgetMonth')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error ");
            }
        }); //end post get departments

    }); //end chng division

    $('#FiscalYear').change(function () {
        var item = $('#FiscalYear').val();
        //get periods
        $.ajax({
            url: '/Finance/JSON/GetMonths',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    
                    //reset
                    $('#PeriodName').empty();
                    //.append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#PeriodName').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }                    
                }
                else {
                    //reset
                    $('#PeriodName')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error ");
            }
        }); //end post get departments

    }); //end chng division

    $('#CategoryName').change(function () {
        var item = $('#CategoryName').val();
        if (item == "Payment - Cheque")
            $('#JournalNumber').val("PV NO.");
        else if (item == "Payment - Petty Cash")
            $('#JournalNumber').val("PCV NO.");
        else if (item == "Collection - Cheque/Cash/Bank")
            $('#JournalNumber').val("CRV");
        else if (item == "Depoist - Main Cashier/Bank")
            $('#JournalNumber').val("BD");
        else if (item == "Sales - Cash/Cheque/others")
            $('#JournalNumber').val("AARESZ");
        else if (item == "Journal Voucher - JV Form")
            $('#JournalNumber').val("JV");
        else if (item == "Issue- Issue Voucher")
            $('#JournalNumber').val("SIVNO.");
        else if (item == "GRN- Good Receiving Notes")
            $('#JournalNumber').val("GRNNO.");
        else if (item == "Payroll- Program Form")
            $('#JournalNumber').val("");
        else if (item == "Reconcilation A/R- Program Form")
            $('#JournalNumber').val("");
        else if (item == "Reconcilation Bank- Program Form")
            $('#JournalNumber').val("");
    }); //end chng cat
    $('#ItemCategory').change(function () {
        var item = $('#ItemCategory').val();
        //get departments
        $.ajax({
            url: '/Finance/JSON/GetInventoryItems',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#InventoryItem')
                    .empty()
                    .append('<option selected="Please choose" value="">Please choose</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#InventoryItem').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#InventoryItem')
                    .empty()
                    .append('<option selected="" value=""></option>');
                    ////alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error ");
            }
        }); //end post get departments

    }); //end chng division
    $('#InventoryItem').change(function () {
        var item = $('#InventoryItem').val();
        //get departments
        $.ajax({
            url: '/Finance/JSON/GetReceivedFixedAssetItems',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#FixedAssetSelector')
                    .empty()
                    .append('<option selected="Please choose" value="">Please choose</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#FixedAssetSelector').append(
                           $("<option></option>").val("Price Birr:" + result[i].UnitPrice + " on:" + result[i].ReceiveDate + "_" + result[i].GoodReceiveItemID + "_" + result[i].UnitPrice).html("Price Birr:" + result[i].UnitPrice + " on:" + result[i].ReceiveDate + "_" + result[i].GoodReceiveItemID + "_" + result[i].UnitPrice)
                                       );
                    }
                }
                else {
                    //reset
                    $('#FixedAssetSelector')
                    .empty()
                    .append('<option selected="" value=""></option>');
                    ////alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error " + result);
            }
        }); //end post get departments

    }); //end chng division

    $('#PurchaseOrderID').change(function () {
        var item = $('#PurchaseOrderID').val();
        $.ajax({
            url: '/Finance/JSON/GetSupplierName',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#SupplierName').val('');
                        $('#SupplierName').val(result[i].Supplier);
                    }
                }
                else {
                    $('#SupplierName').val('');
                    $('#PurchaseOrderID').val('');
                    alert("Supplier not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng
});


$(document).ready(function () {

    //alert("hi");

    $("#divProcessingUnreconciled").hide();

    $("#unreconciledbankform").on("submit", function (event) {
        event.preventDefault();

        // Show the "busy" Gif:
        $("#divProcessingUnreconciled").show();
        var url = $(this).attr("action");
        var formData = $(this).serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (resp) {
                //reset form values
                $("#Debit").val(0);
                $("#Credit").val(0);
                // Hide the "busy" gif:
                $("#divProcessingUnreconciled").hide();

                //var txt = "";
                //txt += "<tr><td>" + resp.AccountCode + "</td><td>" + resp.Debit + "</td><td>" + resp.Credit + "</td><td>" + resp.Description + "</td></tr>";
                //$("#divResult").append(txt).removeClass("hidden");

            }
            , //end succ
            error: function (result) {
                alert(result);
            }
        })
    });

    // Hide the "busy" Gif at load:
    $("#divProcessing").hide();

    $("#glRecordJournalLinesform").on("submit", function (event) {
        event.preventDefault();

        // Show the "busy" Gif:
        $("#divProcessing").show();
        var url = $(this).attr("action");
        var formData = $(this).serialize();
        $.ajax({
            url: url,
            type: "POST",
            data: formData,
            dataType: "json",
            success: function (resp) {
                //reset form values
                $("#Debit").val(0);
                $("#Credit").val(0);
                $("#AdditionalDescription").val("");
                $("#AccountCode").val("");
                // Hide the "busy" gif:
                $("#divProcessing").hide();

                var txt = "";
                txt += "<tr><td>" + resp.AccountCode + "</td><td>" + resp.Debit + "</td><td>" + resp.Credit + "</td><td>" + resp.Description + "</td></tr>";
                $("#divResult").append(txt).removeClass("hidden");
                //iterate
                //for (var i = 0; i < resp.length; i++) {
                //    //$("<h3>" + resp[i].Debit + " " + resp[i].Credit + "</h3>").appendTo("#divResult");

                //    txt += "<tr><td>" + resp[i].AccountCode + "</td><td>" + resp[i].Debit + "</td><td>" + resp[i].Credit + "</td><td>" + resp[i].Description + "</td></tr>";
                //}
                //if (txt != "") {
                //    $("#divResult").append(txt).removeClass("hidden");
                //}
            }
            , //end succ
            error: function (result) {
                alert("error");
            }
        })
    });


    $("a.nolink").click(function (event) {
        event.preventDefault();
        //$("<div>")
        // .append("default " + event.type + " prevented")
        // .append($(this).text())
        //.appendTo("#Description");
        var item = $(this).text();
        $.ajax({
            url: '/Finance/JSON/Description',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $("#DescriptionArea").text('');
                        $("<a>")
                        .append(result[i].Description)
                      .appendTo("#DescriptionArea");
                    }
                }
                else {
                    alert("Description not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    });//end of click

    //alert("ready!3");
    $('#AccountCode').click(function () {
        var item = $('#AccountCode').val();
        $.ajax({
            url: '/Finance/JSON/Description',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        //alert(result[i].Name + "..." + result[i].FName);
                        $('#Description').val('');
                        $('#Description').val(result[i].Description + " " + result[i].Description);
                    }
                }
                else {
                    $('#Description').val('');
                    $('#Description').val('');
                    alert("Description not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng

    

});




