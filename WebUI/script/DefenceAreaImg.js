function readFile() {
    var file = this.files[0];//获取上传文件列表中第一个文件
    if (!/image\/\w+/.test(file.type)) {
        //图片文件的type值为image/png或image/jpg
        alert("文件必须为图片！");
        return false;
    }
    // console.log(file);
    var reader = new FileReader();//实例一个文件对象
    reader.readAsDataURL(file);//把上传的文件转换成url
    //当文件读取成功便可以调取上传的接口
    reader.onload = function (e) {
       
        var data = e.target.result.split(',');
        var imgUrl = data[1];//图片的url，去掉(data:image/png;base64,)    
        $("#fqsyt").attr("src", data);
        $("#hidImage").val(data);  
        SetDefaultValue();
    }
};


function SetDefaultValue() {
  
    var image = $("#hidImage").val();
    var dname = "防区示意图";
    var param = {     
        dvalue: image,
        dname: dname,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetDafaultValue.aspx",
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
                $("#fqsyt").attr("src", imurl);

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