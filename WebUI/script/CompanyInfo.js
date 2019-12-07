$(function () {
    GetCompanyInfo();
})


var userkey = "admin";
var userPwd = "admin";
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
        // console.log(this.result);//文件路径
        // console.log(e.target.result);//文件路径
		var data = e.target.result.split(',');		
		var imgUrl = data[1];//图片的url，去掉(data:image/png;base64,)
		//需要上传到服务器的在这里可以进行ajax请求
		// console.log(imgUrl);
		// 创建一个 Image 对象 
		//var image = new Image();
		// 创建一个 Image 对象 
		// image.src = imgUrl;
      
        $("#CompanyLogo").attr("src", data);
        $("#hidImage").val(data);
        $("#hidImageState").val("1");
		//image.onload = function(){
		//	document.body.appendChild(image);
		//}

   //     var image = new Image();
   //     // 设置src属性 
   //     image.src = e.target.result;
   //     var max = 200;
   //     // 绑定load事件处理器，加载完成后执行，避免同步问题
   //     image.onload = function () {
   //         // 获取 canvas DOM 对象 
   //         var canvas = document.getElementById("cvs");
   //         // 如果高度超标 宽度等比例缩放 *= 
			///*if(image.height > max) {
			//	image.width *= max / image.height; 
			//	image.height = max;
			//} */
   //         // 获取 canvas的 2d 环境对象, 
   //         var ctx = canvas.getContext("2d");
   //         // canvas清屏 
   //         ctx.clearRect(0, 0, canvas.width, canvas.height);
   //         // 重置canvas宽高
			///*canvas.width = image.width;
			//canvas.height = image.height;
			//if (canvas.width>max) {canvas.width = max;}*/
   //         // 将图像绘制到canvas上
   //         // ctx.drawImage(image, 0, 0, image.width, image.height);
   //         ctx.drawImage(image, 0, 0, 200, 200);
   //         // 注意，此时image没有加入到dom之中
   //     };
    }
};


function SetConmpanyInfo() {
    var Company_name = $("#txtName").val();
    var Company_sname = $("#txtSName").val();
    var Company_address = $("#txtAddress").val();
    var Company_tel = $("#txtTel").val();
    var Company_contact = $("#txtContact").val();
    var Company_logo = $("#hidImage").val();
    var ImageState = $("#hidImageState").val();
    var logoUrl = $("#hidlogoUrl").val();

    var param = {
        Company_name: Company_name,
        Company_sname: Company_sname,
        Company_address: Company_address,
        Company_tel: Company_tel,
        Company_contact: Company_contact,
        Company_logo: Company_logo,
        ImageState: ImageState,
        logoUrl: logoUrl,
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "SetCompanyInfo.aspx",
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

function Save() {
    SetConmpanyInfo();
}

function GetCompanyInfo() {
    var param = {       
        userkey: "admin",
        userPwd: "admin",
    };
    $.ajaxSettings.async = false;
    $.ajax({
        url: apiurl + "GetCompanyInfo.aspx",
        type: 'post',
        data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var rtnJson = JSON.parse(ja.returnValue);
               // alert(rtnJson.rs);
                 $("#txtName").val(rtnJson.Company_name);
                 $("#txtSName").val(rtnJson.Company_sname);
                 $("#txtAddress").val(rtnJson.Company_address);
                 $("#txtTel").val(rtnJson.Company_tel);
                 $("#txtContact").val(rtnJson.Company_contact);
                 $("#hidImage").val("");
                 $("#hidImageState").val("0");
                $("#hidlogoUrl").val(rtnJson.logoUrl);
                var imurl = apiurl + rtnJson.logoUrl;
                $("#CompanyLogo").attr("src", imurl);
            }
            else {
                //alert(result);
            }

        },
        error: function (result) {//失败执行的方法
            alert("error: 数据访问超时，请稍后再试！" + result.responseText);
        }
    });
}