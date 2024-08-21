
$(document).ready(function () {    

    //activating the moduleLink in cookie
    var active = Cookies.get('currentNavLi');
    $('#' + active).addClass('active');
    $('#' + active).parents('li').addClass('open active');
    //getting the clicked menu
    $('li.actionlinlk').click(function (e) {
        //remove previous
        var active = Cookies.get('currentNavLi');
        $('#' + active).removeClass('active');
        $('#' + active).parents('li').removeClass('open active');
        Cookies.remove('currentNavLi');
        //set new
        $(this).parents('li').addClass('open active');
        $(this).addClass('active');
        var id = $(this).attr('id');
        Cookies.set('currentNavLi', id);
    });


    //alert('hi from hr');
    //$(document).on("contextmenu", function (e) {
    //    if (e.target.nodeName != "INPUT" && e.target.nodeName != "TEXTAREA")
    //        e.preventDefault();
    //});
});

$(document).ready(function () {
    //alert('hi');
    //localization
    $("input.language:radio").click(function () {
        $(this).parents("form").submit(); // post form
    });

    //use default datepicker in chrome and jquery for others
    if (navigator.userAgent.indexOf('Chrome') == -1) {
        //datepicker
        $('.date-picker').datepicker();
        $(".date-picker").datepicker("setDate", new Date());
    }
    
    $('#EmpID').change(function () {
        var item = $('#EmpID').val();
        $.ajax({
            url: '/HR/JSON/GetEmlpoyee',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#EmpFullName').val('');
                        $('#EmpFullName').val(result[i].Name + " " + result[i].FName + " " + result[i].GFName);
                    }
                }
                else {
                    $('#EmpFullName').val('');
                    $('#EmpID').val('');
                    alert("Employee not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng

    $('#EmpIDContract').change(function () {
        var item = $('#EmpIDContract').val();
        $.ajax({
            url: '/HR/JSON/GetContractEmlpoyee',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#EmpFullNameContract').val('');
                        $('#EmpFullNameContract').val(result[i].Name + " " + result[i].FName + " " + result[i].GFName);
                    }
                }
                else {
                    $('#EmpFullNameContract').val('');
                    $('#EmpIDContract').val('');
                    alert("Employee not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
    }); //end chng

    $('#DivisionName').change(function () {
        var item = $('#DivisionName').val();
        //get departments
        $.ajax({
            url: '/HR/JSON/GetDepartments',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#DepartmentName')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#DepartmentName').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#DepartmentName')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error departments");
            }
        }); //end post get departments

    }); //end chng division
    $('#DepartmentName').change(function () {
        var item = $('#DepartmentName').val();
        $.ajax({
            url: '/HR/JSON/GetSections',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#SectionName')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#SectionName').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#SectionName')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post

    }); //end chng department
    //section selected
    $('#Organization').change(function () {
        var item = $('#Organization').val();
        //reser
        $('#Division').val('');
        $('#Department').val();
        $('#Section').val();
        $('#Team').val();
        $('#JobTitle').val();
       // alert(item);
        //get section job titles
        $.ajax({
            url: '/HR/JSON/GetOrgJobtitles',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#JobTitle').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Organization Job Title Item not found");
                }

            }, //end succ
            error: function (result) {
                alert('');
            }
        }); //end post get section jobs
    }); //end chng section

    //Division selected
    $('#Division').change(function () {
        var item = $('#Division').val();
        //reset children
        $('#Department').val('');
        $('#Section').val('');
        $('#JobTitle').val('');
        //get departments
        $.ajax({
            url: '/HR/JSON/GetDepartments',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#Department')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#Department').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#Department')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert("error departments");
            }
        }); //end post get departments
        //get division job titles
        $.ajax({
            url: '/HR/JSON/GetDivisionJobtitles',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#JobTitle').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Division Job Title Item not found");
                }

            }, //end succ
            error: function (result) {
                alert('');
            }
        }); //end post get div jobs
    }); //end chng division

    //Department selected
    $('#Department').change(function () {
        var item = $('#Department').val();
        $.ajax({
            url: '/HR/JSON/GetSections',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#Section')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#Section').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#Section')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Item not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post
        //get departments job titles
        $.ajax({
            url: '/HR/JSON/GetDepartmentJobtitles',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#JobTitle').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    // alert("Department Job Title Item not found");
                }

            }, //end succ
            error: function (result) {
                alert('');
            }
        }); //end post get department jobs
    }); //end chng department

    //section selected on emp assignment
    $('#Section').change(function () {
        var item = $('#Section').val();
        //get section job titles
        $.ajax({
            url: '/HR/JSON/GetSectionJobtitles',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#JobTitle').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#JobTitle')
                    .empty()
                    .append('<option selected="NA" value="NA">NA</option>');
                    //alert("Section Job Title Item not found");
                }

            }, //end succ
            error: function (result) {
                alert('');
            }
        }); //end post get section jobs
    }); //end chng section
    //rank section selected
    $('#Rank').change(function () {
        var rank = $('#Rank').val();
        var step = $('#Step').val();
        var rankstep = rank + "-" + step;
        //get section job titles
        $.ajax({
            url: '/HR/JSON/GetSalarystructure',
            type: 'POST',
            data: { id: rankstep },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#Salary').val('');
                        $('#Salary').val(result[i].Name);
                    }
                }
                else {
                    $('#Salary').val('');
                    //alert("salary not found");
                }

            }, //end succ
            error: function (result) {
                alert(result);
            }
        }); //end post get salary
    }); //end chng rank
    //Step section selected
    $('#Step').change(function () {
        var rank = $('#Rank').val();
        var step = $('#Step').val();
        var rankstep = rank + "-" + step;
        //get section job titles
        $.ajax({
            url: '/HR/JSON/GetSalarystructure',
            type: 'POST',
            data: { id: rankstep },
            success: function (result) {
                if (result.length > 0) {
                    for (var i = 0; i < result.length; i++) {
                        $('#Salary').val('');
                        $('#Salary').val(result[i].Name);
                    }
                }
                else {
                    $('#Salary').val('');
                    //alert("salary not found");
                }

            }, //end succ
            error: function (result) {
                alert("error" + result);
            }
        }); //end post get salary
    }); //end chng rank    

    $('#MeasureRank').change(function () {
        
        var item = $('#MeasureRank').val();
        //get departments
        $.ajax({
            url: '/HR/JSON/GetMeasureTypes',
            type: 'POST',
            data: { id: item },
            success: function (result) {
                if (result.length > 0) {
                    //reset
                    $('#MeasureTaken')
                    .empty()
                    .append('<option selected="" value=""></option>');
                    //new data
                    for (var i = 0; i < result.length; i++) {
                        $('#MeasureTaken').append(
                            $("<option></option>").val(result[i].Name).html(result[i].Name)
                                       );
                    }
                }
                else {
                    //reset
                    $('#MeasureTaken')
                    .empty()
                    .append('<option selected="" value=""></option>');
                   // alert("Measure Not found");
                }

            }, //end succ
            error: function (result) {
                //alert("error meassure type");
            }
        }); //end post get departments

    }); //end chng measure rank

});//end document