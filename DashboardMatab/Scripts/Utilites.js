function MyAjax(Url, Data, CallbackFunction) {
    var backResult = "";
    $.ajax({
        //type: "POST",
        url: Url,
        data: { DataJson: Data },
        dataType: "text",
        success: function (data) {

            backResult = data;
        

        },
        error: function () {
            swal("خطا", "ثبت با خطا روبرو شد!", "error");
        },
        complete: function (data) {
            if (CallbackFunction !== null) {
                CallbackFunction(backResult);
            }

        }
    });
}
function MyAjaxMultiParameter(Url, Data1,Data2,Data3, CallbackFunction) {
    var backResult = "";
    $.ajax({
        //type: "POST",
        url: Url,
        data: {
            _Data1: Data1,
            _Data2: Data2,
            _Data3: Data3
        },
        dataType: "text",
        success: function (data) {


            backResult = data;
            

        },
        error: function () {
            swal("خطا", "ثبت با خطا روبرو شد!", "error");
        },
        complete: function () {
            CallbackFunction(backResult);
        }
    });
}
function ConvertToTable(TableSelector, data) {


    $(TableSelector+" tr").remove();
    DataJson = JSON.parse(data);
    $.each(DataJson, function (index, value) {
        var TableRow = "<tr>";
        $.each(value, function (key, val) {
            
                TableRow += "<td>" + val + "</td>";

        });

        TableRow += "</tr>";
        $(TableSelector).append(TableRow);
    });
   

}
function ConvertToTableParentList(TableSelector, data) {


    $(TableSelector + " tr").remove();
    DataJson = JSON.parse(data);
    $.each(DataJson, function (index, value) {
        var keys = "";
        var TableRow = "<tr>";

        $.each(value, function (key, val) {

            TableRow += "<td>" + val + "</td>";
            
            if (key === "Id") {
               
                keys = val;
            }
                
        });
        TableRow += "<td>" + "<button class='btn btn-primary' onclick='selectParent(" + keys + "," + data + ",false)'>انتخاب</button>" + "</td>";

        TableRow += "</tr>";
        $(TableSelector).append(TableRow);
    });


}
function ConvertToTableRecents(TableSelector, data) {


    $(TableSelector + " tr").remove();
    DataJson = JSON.parse(data);
    $.each(DataJson, function (index, value) {
        var TableRow = "<tr>";
        $.each(value, function (key, val) {
            if (key === "FristName" ||
                key === "LastName" ||
                key === "PhoneNumber" ||
                key === "CityCode" ||
                key === "RecentDate" ||
                key === "RecentTime" ||
                key === "RecentType" ||
                key === "Line" ||
                key === "Mode" ||
                key === "CallState" ||
                key === "Address" ||
                key === "DurrTime"

            )
            {
                TableRow += "<td>" + val + "</td>";
            }



        });

        TableRow += "</tr>";
        $(TableSelector).append(TableRow);
    });


}
function ConvertToTableTasks(TableSelector, data) {
    var _Status = "";
    var _TaskId = "";

    $(TableSelector + " tr").remove();
    DataJson = JSON.parse(data);
    $.each(DataJson, function (index, value) {
        var TableRow = "<tr>";
        $.each(value, function (key, val) {
            if (key ==="Title"||
                key === "FullName" ||
                key === "StartDate" ||
                key === "EndDate" ||
                key === "Status" 
                //key === "RecentTime" ||
                //key === "RecentType" ||
                //key === "Line" ||
                //key === "Mode" ||
                //key === "CallState" ||
                //key === "Address" ||
                //key === "DurrTime"

            ) {
                TableRow += "<td>" + val + "</td>";
            }
            if (key === "TaskStatusTypeID") {
                _Status = val;
            }
            if (key === "Id") {
                _TaskId = val;
            }


        });


        if (_Status===7) {
           

            TableRow += "<td><button class='btn btn-primary' onclick=UpdateStatus(" + _Status + "," + '8' + "," + _TaskId + ")>پذیرش کار</button> </td>";

        }

        if (_Status === 8) {
           

            TableRow += "<td><button class='btn btn-success' onclick=UpdateStatus(" + _Status + "," + '9' + "," + _TaskId + ")>اتمام کار</button> </td>";

        }
        if (_Status === 9) {
          

            TableRow += "<td><button class='btn btn-defult' disabled>تمام شده</button> </td>";

        }
        TableRow += "</tr>";
        $(TableSelector).append(TableRow);
    });


}

function AlertCallerId(_Date) {
    DataJson = JSON.parse(_Date);
    console.log(DataJson);
    $.each(DataJson, function (index, value) {


        if (value.FlagRead === false) {

            alertify.success(value.PhoneNumber);
            MyAjax("/Home/UpdateFlaghRecend", value.id, null);
        }

    });

}
function show(data) {
    alert("اتمام کار");
}
function createlistbox() {

}
function _SelectByIdByField(DataJson, id, FiledName) {
   
    alert(DataJson);
    DataJson = JSON.parse(DataJson);
    alert(DataJson);

}

function ConvertToSelectOption(_dataStatus,Selector) {


    let dropdown = $(Selector);

    dropdown.empty();

    dropdown.append('<option selected="true" disabled>انتخاب کنید</option>');
    dropdown.prop('selectedIndex', 0);

    $.each(JSON.parse(_dataStatus), function (index, value) {

        dropdown.append($('<option></option>').attr('value', value.Id).text(value.Title));
    });



    //$.each(_DateJson, function(key, entry){
    //    alert("sss");
    //    dropdown.append($('<option></option>').attr('value', entry.Id).text(entry.Title));
    //});
    

}