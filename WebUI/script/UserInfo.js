$(function () {
    
    var uid = getQueryString('uid');
    $("#User_seq").val(uid);
    if (uid > 0) {
        GetUserInfo(uid);
    }   
})

function GetUserInfo(uid) {
    var param = {  
        User_seq: uid,       
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetUserInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                //alert(rtnJson.rs);
                $("#User_seq").val(rtnJson.User_seq);
                $("#user_id").val(rtnJson.User_id);
                $("#user_name").val(rtnJson.User_name);
               
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
    window.location.href = "UserInfoUpdate.html";
}

function Save() {
    var user_id = $("#user_id").val();
    var user_name = $("#user_name").val();
    var User_passwd = $("#user_pwd").val();
    var options = $("#Select1 option:selected");
    var user_canlogin = options.val();
    var User_seq = $("#User_seq").val();

    var options2 = $("#Select2 option:selected");
    var Agroup = options2.val();
    var param = {
        user_id: user_id,
        user_name: user_name,
        User_passwd: User_passwd,
        user_canlogin: user_canlogin,   
        User_seq: User_seq,
        Agroup: Agroup,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetUserInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                alert(rtnJson.rs);
                window.location.href = "UserInfo.html";
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



function GetUserList() {   
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetUserList.aspx",
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
    $("#userList").html("");
    var str = "";
    var isDirectUse = "false";
    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<tr ondblclick=\"GetUserID('" + parsedJson[i].User_seq + "')\"  >";
        str += "<td>" + (i+1) + "</td>";
        str += "<td >" + parsedJson[i].User_id+"</td>";
        str += "<td>" + parsedJson[i].User_name +"</td>";
        if (parsedJson[i].User_canlogin == "1") {
            str += "<td><span class=\"label label-success\">正常</span></td>";
        }
        else {
            str += "<td><span class=\"label label-warning\">停用</span></td>";
        }
        str += "<td>" + parsedJson[i].User_lastlogintime +"</td>";
        str += "<td>" + parsedJson[i].User_lastloginip +"</td>";
        str += " </tr>";
    }
    $("#userList").html(str);   

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


function GetUserID(uid) {
    window.location.href = "UserInfoUpdate.html?uid=" + uid;
    
}

//获取URL中值
function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}


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
                ShowAuthenticationList(parsedJson);
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


function ShowAuthenticationList(parsedJson) {
    $("#Select2").html("");
    var str = "";

    for (var i = 0; i < parsedJson.length; i++) {
        //alert(parsedJson[i].User_id);
        str += "<option value=\"" + parsedJson[i].group_id + "\">" + parsedJson[i].group_name + "</option>";
    
    }
    $("#Select2").html(str);

}