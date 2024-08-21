//picker

var calendar = $.calendars.instance('ethiopian', 'am');
$('.et-popup-picker').calendarsPicker({ calendar: calendar, yearRange: '+10:-10' });

// delete Link
$('a.delete-link').click(function (event) {
    event.preventDefault();
    var deleteLinkObj = $(this);  //for future use

    $("#delete-dialog").dialog({
        title: "Confirmation",
        buttons: {
            Continue: function () {
                $.post(deleteLinkObj[0].href, function (data) {  //Post to action
                    if (data.Status == 'true') {
                        var tr = deleteLinkObj.parents('tr:first');
                        tr.hide('fast'); //Hide Row
                    }
                    else {
                        //(optional) Display Error
                    }
                });
                $(this).dialog('close');
            },
            Close: function () {
                $(this).dialog('close');
            }
        },
        dialogClass: 'dialog_css',
        width: 400,
        closeOnEscape: false,
        draggable: false,
        resizable: false,
        modal: true
    });
    return false; // prevents the default behaviour

});