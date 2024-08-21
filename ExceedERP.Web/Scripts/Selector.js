



$(document).ready(function () {




    $(window).resize(function () {
        //window.resizeTo(600, 380);
    });
    //$(document).on("contextmenu", function (e) {
    //    if (e.target.nodeName != "INPUT" && e.target.nodeName != "TEXTAREA")
    //        e.preventDefault();
    //});    

    

    $("#Account").keyup(function () {
        var item = $('#Account').val();
        $.ajax({
            url: '/Finance/JSON/GetAccountDesc',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#AccountDesc').val('');
                        $('#AccountDesc').val(result[i].Description);
                    }
                }
                else {
                    $('#AccountDesc').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post

    });

    $("#Branch").keyup(function () {
        var item = $('#Branch').val();
        $.ajax({
            url: '/Finance/JSON/GetBranchDesc',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#BranchDesc').val('');
                        $('#BranchDesc').val(result[i].Description);
                    }
                }
                else {
                    $('#BranchDesc').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post

    });

    $("#CostCenter").keyup(function () {
        var item = $('#CostCenter').val();
        $.ajax({
            url: '/Finance/JSON/GetCostCenterDesc',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#CostCenterDesc').val('');
                        $('#CostCenterDesc').val(result[i].Description);
                    }
                }
                else {
                    $('#CostCenterDesc').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post

    });

    $("#SubAccount").keyup(function () {
        var item = $('#SubAccount').val();
        $.ajax({
            url: '/Finance/JSON/GetSubAccountDesc',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#SubAccountDesc').val('');
                        $('#SubAccountDesc').val(result[i].Description);
                    }
                }
                else {
                    $('#SubAccountDesc').val('');
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post

    });

    $('#Accounts').change(function () {
        var item = $('#Accounts').val();
        $('#Account').val('');
        $('#AccountDesc').val('');
        $('#Account').val(item.split('_')[0]);
        $('#AccountDesc').val(item.split('_')[1]);
    }); //end chng

    $('#Location').change(function () {
        var item = $('#Location').val();
        $('#Branch').val('');
        $('#BranchDesc').val('');
        $('#Branch').val(item.split('_')[0]);
        $('#BranchDesc').val(item.split('_')[1]);
    }); //end chng

    $('#CostCenters').change(function () {
        var item = $('#CostCenters').val();
        $('#CostCenter').val('');
        $('#CostCenterDesc').val('');
        $('#CostCenter').val(item.split('_')[0]);
        $('#CostCenterDesc').val(item.split('_')[1]);
    }); //end chng

    $('#SubAccounts').change(function () {
        var item = $('#SubAccounts').val();
        $('#SubAccount').val('');
        $('#SubAccountDesc').val('');
        $('#SubAccount').val(item.split('_')[0]);
        $('#SubAccountDesc').val(item.split('_')[1]);
    }); //end chng
});