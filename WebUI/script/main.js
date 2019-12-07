$(document).ready(function () {
   LoadMenu();
});
//function LoadMenu() {

//    $.ajax({
//        type: "POST",
//        url: apiurl+"GetTreeMenu.aspx",
//        contentType: "application/json; charset=utf-8", 
//        //data: { username: $("#username").val(), password: $("#password").val() },
//        dataType: "json",
//        success: function (data) {
//           //alert(data.menu);
//            $('#nav').html(htmldecode(data.menu));

//            $(".has-sub>a").click(function () {
//                $(this).parent().siblings().find(".sub-menu").slideUp();
//                $(this).parent().find(".sub-menu").slideToggle();
//            });
//        },
//        error: function (e) {
//            alert("服务器错误");
//        }
//    });
//}

function htmldecode(str) {
    str = str.replace(/&amp;/gi, '&');
    str = str.replace(/&nbsp;/gi, ' ');
    str = str.replace(/&quot;/gi, '"');
    str = str.replace(/&#39;/g, "'");
    str = str.replace(/&lt;/gi, '<');
    str = str.replace(/&gt;/gi, '>');
    str = str.replace(/<br[^>]*>(?:(rn)|r|n)?/gi, 'n');
    return str;
}


function LoadMenu() {
    // pageNum = 1;
    //var typeID = 0;
    var param = {
        userkey: userkey,
        userPwd: userPwd,
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetTreeMenu.aspx",
        type: 'post',
        data: { param: JSON.stringify(param) }, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
                BindInfo(rtnJson);
            }
        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}

function BindInfo(rtnJson) {
    //$('#nav').html(htmldecode(rtnJson.menu));
    $('#nav').html(rtnJson.menu);
    $(".has-sub>a").click(function () {
        $(this).parent().siblings().find(".sub-menu").slideUp();
        $(this).parent().find(".sub-menu").slideToggle();
    });
}



