$(function () {
    var DI_DeviceID = getQueryString('id');
    $("#DI_DeviceID").val(DI_DeviceID);
    GetDeviceList();
})

function insert() {
    $("#myModalLabel").text("新增COM串口");
    // $('#myModal').modal();
    $("#myModal").show();
}

function hidmyModal() {
    $("#myModal").hide();
}

function UpateSet(id,name) {
    $("#HIDDI_ID").val(id);
    $("#txtCom").val(name);
    //获取数据
    GetSet();
    $("#myModalLabel").text("更新COM串口"); 
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
        url: apiurl + "GetDefenceAreaSettingSet.aspx",
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
    for (var i = 0; i < parsedJson.length; i++) {
        $("#zy_" + (i + 1)).val(parsedJson[i].DIP_ZY);
        $("#sx_" + (i + 1)).val(parsedJson[i].DIP_SX);
        $("#sx_" + (i + 1)).val(parsedJson[i].DIP_XX);
        $("#gykz_" + (i + 1)).val(parsedJson[i].DIP_GYYZ);
        $("#glkz_" + (i + 1)).val(parsedJson[i].DIP_GLYZ);
        $("#lxzs_" + (i + 1)).val(parsedJson[i].DIP_LXZS);
    }  
}


function SaveItem() {
    var comName = $("#txtCom").val();
    var DI_DeviceID = $("#DI_DeviceID").val();
    var hidDeviceID = $("#HIDDI_ID").val();
    var td1 = $("#zy_1").val() + "," + $("#sx_1").val() + "," + $("#xx_1").val() + "," + $("#gykz_1").val() + "," + $("#glkz_1").val() + "," + $("#lxzs_1").val();
    var td2 = $("#zy_2").val() + "," + $("#sx_2").val() + "," + $("#xx_2").val() + "," + $("#gykz_2").val() + "," + $("#glkz_2").val() + "," + $("#lxzs_2").val();
    var td3 = $("#zy_3").val() + "," + $("#sx_3").val() + "," + $("#xx_3").val() + "," + $("#gykz_3").val() + "," + $("#glkz_3").val() + "," + $("#lxzs_3").val();
    var td4 = $("#zy_4").val() + "," + $("#sx_4").val() + "," + $("#xx_4").val() + "," + $("#gykz_4").val() + "," + $("#glkz_4").val() + "," + $("#lxzs_4").val();
    var td5 = $("#zy_5").val() + "," + $("#sx_5").val() + "," + $("#xx_5").val() + "," + $("#gykz_5").val() + "," + $("#glkz_5").val() + "," + $("#lxzs_5").val();
    var td6 = $("#zy_6").val() + "," + $("#sx_6").val() + "," + $("#xx_6").val() + "," + $("#gykz_6").val() + "," + $("#glkz_6").val() + "," + $("#lxzs_6").val();
    var td7 = $("#zy_7").val() + "," + $("#sx_7").val() + "," + $("#xx_7").val() + "," + $("#gykz_7").val() + "," + $("#glkz_7").val() + "," + $("#lxzs_7").val();
    var td8 = $("#zy_8").val() + "," + $("#sx_8").val() + "," + $("#xx_8").val() + "," + $("#gykz_8").val() + "," + $("#glkz_8").val() + "," + $("#lxzs_8").val();

    var param = {
        comName: comName,
        DI_DeviceID: DI_DeviceID,
        hidDeviceID, hidDeviceID,
        td1: td1,
        td2: td2,
        td3: td3,
        td4: td4,
        td5: td5,
        td6: td6,
        td7: td7,
        td8: td8,
        userkey: "admin",
        userPwd: "admin",
    };
    
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetDefenceAreaSetting.aspx",
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
        str += "<div class=\"ComStyle\" onclick=\"UpateSet('" + parsedJson[i].DI_ID + "','" + parsedJson[i].DI_Name+"');\">";
        str += "<i class=\"icon-remove close\" onclick=\"DelSet('"+ parsedJson[i].DI_ID +"')\"></i>";
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