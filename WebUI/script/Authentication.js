function GetGroupList() {
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetAuthenticationGroupList.aspx",
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
    $("#BaseTypeList").html("");
    var str = "";
  
    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr >";
        str += "<td class=\"checkbox-column\"><input type=\"checkbox\" class=\"uniform\" typeCode=\"" + parsedJson[i].group_id + "\" id='cb_" + i + "' onclick=\"checkState('#cb_" + i + "')\"></td>";
        str += "<td >" + parsedJson[i].group_name + "</td>";     
        str += " </tr>";
    }
    $("#BaseTypeList").html(str);

}


function GetMenuList() {
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetAuthenticationMenuList.aspx",
        type: 'post',
        //data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                ShowMenuList(parsedJson);
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


function ShowMenuList(parsedJson) {
    $("#BaseMXList").html("");
    var str = "";

    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr >";
        str += "<td> " + parsedJson[i].module_name+" </td>";
        str += "<td></td>";
        str += "<td></td>";
        str += "<td></td>";
        str += "<td></td>";
        str += "<td></td>";        
        str += "<td class=\"checkbox-column\"><input type=\"checkbox\" name=\"menuCode\" class=\"uniform\" value=\"" + parsedJson[i].module_id + "\" id='mcb_" + i + "' ></td>";
        //str += "<td >" + parsedJson[i].group_name + "</td>";
        str += " </tr>";
    }
    $("#BaseMXList").html(str);

}

function checkState(id) {
    $('#BaseTypeList input:checkbox').each(function () {
        $('#BaseTypeList input[type=checkbox]:checked').attr("checked", false);
    });

    $("" + id + "").prop("checked", true);//那么就改为未选中
    var code = $("" + id + "").attr("typeCode");
    //alert(code);
    $("#hidGroupID").val(code);
}

function Save() {
    var GroupID = $("#hidGroupID").val();
    var menuID = "";
    $('input[name="menuCode"]:checked').each(function () {
        menuID+=$(this).val()+",";
    });
    //alert(menuID);
    
    var param = {
        GroupID: GroupID,
        menuID: menuID,    
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetAuthentication.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
              
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