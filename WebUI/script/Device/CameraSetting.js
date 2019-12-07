$(function () {
    var DI_DeviceID = getQueryString('id');
    $("#DI_DeviceID").val(DI_DeviceID);
    GetDeviceList();
    GetDeviceType();
})

function GetDeviceType() {
    var param = {
        Code: "CameraBrand",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetBaseItemList.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                ShowDDList(parsedJson);
            }
            else {
                alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}


function ShowDDList(parsedJson) {
    $("#DIC_Type").html("");
    var str = "";

    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<option value=\"" + parsedJson[i].ddi_value + "\">" + parsedJson[i].ddi_name + "</option>";

    }
    $("#DIC_Type").html(str);

}


function insert() {
    $("#myModalLabel").text("新增摄像头");
    // $('#myModal').modal();
   
    $("#myModal").show();
}

function hidmyModal() {
    $("#myModal").hide();
}

function UpateSet(id, name) {
    $("#HIDDI_ID").val(id);
    $("#DIC_NameID").val(name);
    //获取数据
  
    GetSet();
    $("#myModalLabel").text("更新摄像头");
    $("#myModal").show();
}

function GetSet() {
    var DI_DeviceID = $("#DI_DeviceID").val();
    var HIDDI_ID = $("#HIDDI_ID").val();
    var param = {
        DI_DeviceID: DI_DeviceID,
        HIDDI_ID: HIDDI_ID,
        userkey: "admin",
        userPwd: "admin",
    };

    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "Device/GetCameraSettingInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                //alert(rtnJson.rs);
                ShowDeviceSet(parsedJson);

            }
            else {
                alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}

function ShowDeviceSet(parsedJson) {
    $("#HIDDI_ID").val(parsedJson[0].DIC_ID);
    $("#DIC_Type").val(parsedJson[0].DIC_Type);
    $("#DIC_IP").val(parsedJson[0].DIC_IP);
    $("#DIC_Admin").val(parsedJson[0].DIC_Admin);
    $("#DIC_Pwd").val(parsedJson[0].DIC_Pwd);
    //for (var i = 0; i < parsedJson.length; i++) {
    //    $("#zy_" + (i + 1)).val(parsedJson[i].DIP_ZY);
    //    $("#sx_" + (i + 1)).val(parsedJson[i].DIP_SX);
    //    $("#sx_" + (i + 1)).val(parsedJson[i].DIP_XX);
    //    $("#gykz_" + (i + 1)).val(parsedJson[i].DIP_GYYZ);
    //    $("#glkz_" + (i + 1)).val(parsedJson[i].DIP_GLYZ);
    //    $("#lxzs_" + (i + 1)).val(parsedJson[i].DIP_LXZS);
    //}
}


function SaveItem() {
    var DIC_NameID = $("#DIC_NameID").val();
    var DI_DeviceID = $("#DI_DeviceID").val();
    var hidDeviceID = $("#HIDDI_ID").val();

    var options = $("#DIC_Type option:selected");
    var DIC_Type = options.val();
    
    var DIC_IP = $("#DIC_IP").val();
    var DIC_Admin = $("#DIC_Admin").val();

    var DIC_Pwd = $("#DIC_Pwd").val();
   
    var param = {
        DIC_NameID: DIC_NameID,
        DI_DeviceID: DI_DeviceID,
        hidDeviceID, hidDeviceID,
        DIC_Type: DIC_Type,
        DIC_IP: DIC_IP,
        DIC_Admin: DIC_Admin,
        DIC_Pwd: DIC_Pwd,        
        userkey: "admin",
        userPwd: "admin",
    };

    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "Device/SetCameraSetting.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                GetDeviceList();
                hidmyModal();
            }
            else {
                alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}

//获取URL中值
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


function GetDeviceList() {
    var DI_DeviceID = $("#DI_DeviceID").val();

    var param = {
        DI_DeviceID: DI_DeviceID,
        userkey: "admin",
        userPwd: "admin",
    };

    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetDefenceAreaSettingList.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                //alert(rtnJson.rs);
                ShowDeviceList(parsedJson);

            }
            else {
                alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });

}

function ShowDeviceList(parsedJson) {
    $("#sblist").html("");
    var str = "";
    var isDirectUse = "false";
    for (var i = 0; i < parsedJson.length; i++) {
        str += "<div class=\"ComStyle\" onclick=\"UpateSet('" + parsedJson[i].DI_ID + "','" + parsedJson[i].DI_Name + "');\">";
        str += "<i class=\"icon-remove close\" onclick=\"DelSet('" + parsedJson[i].DI_ID + "')\"></i>";
        str += parsedJson[i].DI_Name;
        str += "</div>";
    }
    $("#sblist").html(str);

}

function DelSet(id) {

    var HIDDI_ID = id;
    var param = {
        HIDDI_ID: HIDDI_ID,
        userkey: "admin",
        userPwd: "admin",
    };

    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetDefenceAreaSettingDel.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                GetDeviceList();
                hidmyModal();

            }
            else {
                alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}