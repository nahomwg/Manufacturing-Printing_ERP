

var accountCodeTextBox;
var popup;
var aCode;
var previosAccountCode;
function SelectAccCode(e) {

    accountCodeTextBox = $(e).prev('input').attr('id');
    previosAccountCode = $("#" + accountCodeTextBox).val();

    popup = window.open('/Finance/AccountCode/GLAccountSelector?q=' + previosAccountCode, 'WindowPopup', 'top=100, left=400, width=850 , height=400,resizable=no,');
    popup.focus();



    return false;
}

function SelectDynamicAccCode(e) {

    accountCodeTextBox = $(e).prev('input').attr('id');

    popup = window.open('/Finance/AccountCodeSelector/GLAccountSelector', 'WindowPopup', 'top=100, left=400, width=850 , height=400,resizable=no,');
    popup.focus();
     return false;
}

//old with id of popup wrapper
function SelectAccCodeold(e) {
    var pid = $(e).parent()[0].id;
    accountCodeTextBox = $("#" + pid + " :input")[0].id;

    //alert(accountCodeTextBox);
    popup = window.open('/Finance/AccountCode/GLAccountSelector', 'WindowPopup', 'top=100, left=400, width=850 , height=400,resizable=no,');
    popup.focus();
    return false;
}

function setLang(accCode) {
    aCode = accCode;
    $("#" + accountCodeTextBox).val(aCode).trigger("change");
}

