var AjaxUtil = {

    // 基础选项
    options: {
        method: "post", // 默认提交的方法,post
        url: "", // 请求的路径 required
        params: {}, // 请求的参数
        type: 'json', // 默认返回的内容的类型json
        callback: function () {

        }// 回调函数 required
    },
  
    // 设置基础选项
    setOptions: function (newOptions) {
        for (var pro in newOptions) {
            this.options[pro] = newOptions[pro];
        }
    },
    // 格式化请求参数
    formateParameters: function () {
        var paramsArray = [];
        var params = this.options.params;
        for (var pro in params) {
            var paramValue = params[pro];
            /*if(this.options.method.toUpperCase() === "GET")
            {
                paramValue = encodeURIComponent(params[pro]);
            }*/
            paramsArray.push(pro + "=" + paramValue);
        }
        return paramsArray.join("&");
    },
 

    // 发送Ajax请求
    request: function (options) {
        var ajaxObj = this;

        // 设置参数
        ajaxObj.setOptions.call(ajaxObj, options);

        // 创建XMLHttpRequest对象
        var xmlhttp = ajaxObj.createRequest.call(ajaxObj);

        // 设置回调函数
        xmlhttp.onreadystatechange = function () {
            ajaxObj.readystatechange.call(ajaxObj, xmlhttp);
        };

        // 格式化参数
        var formateParams = ajaxObj.formateParameters.call(ajaxObj);

        // 请求的方式
        var method = ajaxObj.options.method;
        var url = ajaxObj.options.url;

        if ("GET" === method.toUpperCase()) {
            url += "?" + formateParams;
        }

        // 建立连接
        xmlhttp.open(method, url, true);

        if ("GET" === method.toUpperCase()) {
            xmlhttp.send(null);
        } else if ("POST" === method.toUpperCase()) {
            // 如果是POST提交，设置请求头信息
            xmlhttp.setRequestHeader("Content-Type",
                "application/x-www-form-urlencoded");
            xmlhttp.send(formateParams);
        }
    }
};


AjaxUtil.request({
    url: "servlet/UserJsonServlet",
    params: { id: userid },
    type: 'json',
    callback: process
});