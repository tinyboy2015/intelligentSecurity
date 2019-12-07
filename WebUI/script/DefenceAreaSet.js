function GetDefaultValue() {
    var image = $("#hidImage").val();
    var dname = "防区示意图";
    var param = {
        dname: dname,
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetDefalutValue.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                var imurl = apiurl + rtnJson.sd_value;
                // $("#fqsyt").attr("src", imurl);
                document.getElementById("_canvas").style.background = "url("+imurl+") center top no-repeat";

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
    $("#myModalLabel").text("设置联动设备");
    // $('#myModal').modal();
    GetDeviceList();
    $("#myModal").show();
}

function hidmyModal() {
    $("#myModal").hide();
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
    $("#DeviceList").html("");
    $("#hidDeviceNum").val(parsedJson.length);

    var DAID= $("#hidDeviceID").val();
    var str = "";
    var cd = "";
    var DAID2 = DAID.split('_');
    for (var i = 0; i < parsedJson.length; i++) {

        //判断之前是否被选中
        if (DAID != "") {
            cd = "";
            for (var j = 0; j < DAID2.length; j++) {
                if (DAID2[j] == parsedJson[i].device_ID) {
                    cd = "checked =\"checked\"";
                }
            }
            str += "<tr >";
            str += "<td class=\"checkbox-column\"><input type=\"checkbox\" class=\"uniform\" " + cd + " typeCode=\"" + parsedJson[i].device_ID + "\" id='cb_" + i + "' ></td>";
            str += "<td >" + parsedJson[i].device_Name + "</td>";
            str += " </tr>";

        }
        else {
            str += "<tr >";
            str += "<td class=\"checkbox-column\"><input type=\"checkbox\" class=\"uniform\" typeCode=\"" + parsedJson[i].device_ID + "\" id='cb_" + i + "' ></td>";
            str += "<td >" + parsedJson[i].device_Name + "</td>";
            str += " </tr>";
        }
    }
    $("#DeviceList").html(str);       
}

function SaveItem() {
    var num = $("#hidDeviceNum").val(); 
    var str = "";
    for (var i = 0; i < num; i++) {
       // alert($("#cb_" + i).prop('checked'));
        if ($("#cb_" + i).prop('checked') == true) {
            str += $("#cb_" + i).attr("typeCode")+"_";
        }
    }
    $("#hidDeviceID").val(str);

    //判断是否有seq 如果有直接更新
    var daseq = $("#Hid_DA_seq").val();
    if (daseq != "") {
        SaveArea();
    }
    hidmyModal();

}