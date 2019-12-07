$(function () {
   // GetDeviceList();
    var uid = getQueryString('uid');
    $("#device_ID").val(uid);
    if (uid > 0) {
        GetDeviceInfo(uid);
    }
})

function GetDeviceInfo(uid) {
    var param = {
        device_ID: uid,
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetDeviceInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                //alert(rtnJson.rs);
                $("#device_ID").val(rtnJson.device_ID);
                $("#device_Name").val(rtnJson.device_Name);
                $("#device_Type").val(rtnJson.device_Type);
                $("#device_Remark").val(rtnJson.device_Remark);
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

function insert() {
    window.location.href = "DeviceInfoUpdate.html";
}

function Save() {
    var device_ID = $("#device_ID").val();
    var device_Name = $("#device_Name").val();   
    var options = $("#device_Type option:selected");
    var device_Type = options.val();
    var device_Remark = $("#device_Remark").val();   
    //var options2 = $("#device_State option:selected");
    //var device_State = options2.val();
    var param = {
        device_ID: device_ID,
        device_Name: device_Name,
        device_Type: device_Type,
        device_Remark: device_Remark,
        //device_State: device_State,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetDeviceInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                window.location.href = "DeviceInfo.html";
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



function GetDeviceList() {
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetDeviceList.aspx",
        type: 'post',
        //data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                ShowList(parsedJson);
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

function ShowList(parsedJson) {
    $("#modelList").html("");
    var str = "";
    var isDirectUse = "false";
    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr ondblclick=\"GetModelID('" + parsedJson[i].device_ID + "')\"  >";
        str += "<td>" + (i + 1) + "</td>";
        str += "<td >" + parsedJson[i].device_Name + "</td>";
        str += "<td>" + parsedJson[i].ddi_name + "</td>";        
        str += "<td>" + parsedJson[i].device_Remark + "</td>";
        str += "<td>";
        str += "<ul class=\"table-controls\">";
        str += "<li>";
        str += "<a href=\"../Device/" + parsedJson[i].ddi_desc+"?id=" + parsedJson[i].device_ID+"\" class=\"btn btn-xs bs-tooltip\" title=\"配置\" >";
        str += "<i class=\"icon-pencil\">";
        str += "</i>";
        str += "</a>";
        str += "</li>";
        str += "<li>";
        str += "<a href=\"javascript:void(0);\" class=\"btn btn-xs bs-tooltip\" title=\"删除\" onclick=\"del('" + parsedJson[i].device_ID + "')\">";
        str += "<i class=\"icon-trash\">";
        str += "</i>";
        str += "</a>";
        str += "</li>";
        str += "</ul>";
        str += "</td > ";
        str += " </tr>";
    }
    $("#modelList").html(str);

    $("#mytable").dataTable().fnDestroy();
    $('#mytable').DataTable({
        autoWidth: true,////不开启自动宽度，用bootstrap的自适应去调整
        "lengthMenu": [10, 20, 50, 100],//表格行数选择框内数目 显示2条,4条,20条,50条
        "displayLength": 10,//默认的显示行数 (也就是每页显示几条数据)
        "order": [],
        "language": {//自定义语言提示
            "processing": "处理中...",
            "lengthMenu": "显示 _MENU_ 项结果",
            "zeroRecords": "没有找到相应的结果",
            "info": "第 _START_ 至 _END_ 行，共 _TOTAL_ 行",
            "infoEmpty": "第 0 至 0 项结果，共 0 项",
            "infoFiltered": "(由 _MAX_ 项结果过滤)",
            "infoPostFix": "",
            "url": "",
            "thousands": "'",
            "emptyTable": "表中数据为空",
            "loadingRecords": "载入中...",
            "infoThousands": ",",
            "paginate": {
                "first": "首页",
                "previous": "上页",
                "next": "下页",
                "last": "末页"
            }
        }
    });
}


function GetModelID(uid) {
    window.location.href = "DeviceInfoUpdate.html?uid=" + uid;

}

//获取URL中值
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


function GetDeviceType() {
    var param = {
        Code: "DeviceType",
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
    $("#device_Type").html("");
    var str = "";

    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<option value=\"" + parsedJson[i].ddi_value + "\">" + parsedJson[i].ddi_name + "</option>";

    }
    $("#device_Type").html(str);

}

