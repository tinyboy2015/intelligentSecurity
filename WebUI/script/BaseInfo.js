function GetBaseType() {
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetBaseInfoType.aspx",
        type: 'post',
        //data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                ShowBaseTypeList(parsedJson);
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

function ShowBaseTypeList(parsedJson) {
    $("#BaseTypeList").html("");
    var str = "";
    var isDirectUse = "false";
    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr   >";
        str += "<td class=\"checkbox-column\"><input type=\"checkbox\" class=\"uniform\" typeCode=\"" + parsedJson[i].dd_code+"\" id='cb_" + i + "' onclick=\"checkState('#cb_" + i +"')\"></td>";
        str += "<td >" + parsedJson[i].dd_name + "</td>";     
        str += " </tr>";
    }
    $("#BaseTypeList").html(str);
    
}

function checkState(id) {
    $('input:checkbox').each(function () {     
       $('input[type=checkbox]:checked').attr("checked", false);        
    });
    
    $("" + id + "").prop("checked", true);//那么就改为未选中
    var code = $("" + id + "").attr("typeCode");
    //alert(code);
    $("#hidTypeCode").val(code);

    //调用详情
    GetBaseItemList(code);
}

function GetBaseItemList(code) {
    var param = {
        code: code,
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
                ShowBaseItemList(parsedJson);
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

function ShowBaseItemList(parsedJson) {
    $("#BaseMXList").html("");
    var str = "";
   
    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr>";
        str += "<td>";
        str += parsedJson[i].ddi_name;
        str += "</td>";
        str += "<td>";
        str += parsedJson[i].ddi_value;
        str += "</td>";
        str += "<td>";
        str += parsedJson[i].ddi_desc;
        str += "</td>";
        str += "<td class=\"hidden-xs\">";
        str += parsedJson[i].ddi_order;
        str += "</td>";
        str += "<td>";
        str += "<ul class=\"table-controls\">";
        str += "<li>";
        str += "<a href=\"javascript:void(0); \" class=\"btn btn-xs bs-tooltip\" title=\"Edit\" onclick=\"Edit('" + parsedJson[i].ddi_seq +"')\">";
        str += "<i class=\"icon-pencil\">";
        str += "</i>";
        str += "</a>";
        str += "</li>";
        str += "<li>";
        str += "<a href=\"javascript:void(0); \" class=\"btn btn-xs bs-tooltip\" title=\"Delete\" onclick=\"del('" + parsedJson[i].ddi_seq+"')\">";
        str += "<i class=\"icon-trash\">";
        str += "</i>";
        str += "</a>";
        str += "</li>";
        str += "</ul>";
        str += "</td>";
        str += " </tr>";
    }
    $("#BaseMXList").html(str);
}


function insert() {
    $("#myModalLabel").text("新增");
   // $('#myModal').modal();
    $("#myModal").show();
}

function hidmyModal() {
    $("#myModal").hide();
}

function SaveItem() {
    var ddi_name = $("#txt_ddi_name").val();
    var ddi_value = $("#txt_ddi_value").val();
    var ddi_desc = $("#txt_ddi_desc").val();
    var ddi_order = $("#txt_ddi_order").val();    
    var ddi_seq = $("#hid_ddi_seq").val();
    var ddi_ddID = $("#hidTypeCode").val();
    var param = {
        ddi_name: ddi_name,
        ddi_value: ddi_value,
        ddi_desc: ddi_desc,
        ddi_order: ddi_order,
        ddi_seq: ddi_seq,
        ddi_ddID: ddi_ddID,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetBaseItem.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                var code= $("#hidTypeCode").val();

                //调用详情
                GetBaseItemList(code);
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

function del(uid) {
    var ddi_seq = uid;
    var ddi_ddID = $("#hidTypeCode").val();
    var param = {      
        ddi_seq: ddi_seq,
        ddi_ddID: ddi_ddID,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetBaseItemDel.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                var code = $("#hidTypeCode").val();

                //调用详情
                GetBaseItemList(code);
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


function Edit(uid) {
    $("#myModalLabel").text("编辑");    
    $("#myModal").show();

    var param = {
        ddi_seq: uid,
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetBaseItemInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);           

                $("#txt_ddi_name").val(rtnJson.ddi_name);
                $("#txt_ddi_value").val(rtnJson.ddi_value);
                $("#txt_ddi_desc").val(rtnJson.ddi_desc);
                $("#txt_ddi_order").val(rtnJson.ddi_order);
                $("#hid_ddi_seq").val(rtnJson.ddi_seq);
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