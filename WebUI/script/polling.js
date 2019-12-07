let timerId = 1; // 模拟计时器id，唯一性
let timerObj = {}; // 计时器存储器
function getData() {
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve({


                data: GetDataInfo()


            });
        }, 500);
    });
}


function GetDataInfo() {
    $.ajaxSettings.async = false;
    $.ajax({
        url: "http://localhost:55489/GetUserList.aspx",
        type: 'post',
        //data: param, //参数
        success: function (result) {//成功后执行的方法
            //alert(result); // 后台返回值
            var ja = JSON.parse(result);
            if (ja.message == "2000") {
                var parsedJson = JSON.parse(ja.returnValue);
                var str = "";
                for (var i = 0; i < parsedJson.length; i++) {
                    str +=  " 报警,";
                }
                $("#divID").append(str + "__");
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


// 轮询
function start() {
    const id = timerId++;
    timerObj[id] = true;
    async function timerFn() {
        if (!timerObj[id]) return;
        //const { data } = await getData(); // 模拟请求
        await getData(); // 模拟请求
       
        setTimeout(timerFn, 1000);
    }
    timerFn();
}
// 暂停
function stop() {
    timerObj = {};
}

start();

//const botton = document.querySelector("#button");
//let isPlay = true;
//botton.addEventListener("click", function () {
//    isPlay = !isPlay;
//    botton.innerHTML = isPlay ? '暂停' : '播放';
//    isPlay ? start() : stop();
//}, false);