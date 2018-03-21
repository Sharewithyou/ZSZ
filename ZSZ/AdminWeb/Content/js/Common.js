





var AjaxUtil = {

    // 基础选项
    options: {
        url: "", // 请求的路径 required,
        type: "post",
        data: {},
        dataType: 'json',
        success: function () {

        },
        complete: function () {

        },
        error: function () {

        }
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
            if (this.options.method.toUpperCase() === "GET") {
                paramValue = encodeURIComponent(params[pro]);
            }
            paramsArray.push(pro + "=" + paramValue);
        }
        return paramsArray.join("&");
    },


    // 发送Ajax请求
    request: function (options) {
        var ajaxObj = this;

        // 设置参数
        ajaxObj.setOptions.call(ajaxObj, options);

        // 请求的方式
        var method = ajaxObj.options.method;
        var url = ajaxObj.options.url;

        if ("GET" === method.toUpperCase()) {
            // 格式化参数
            var formateParams = ajaxObj.formateParameters.call(ajaxObj);
            url += "?" + formateParams;
        }

        $.ajax({
            url: ajaxObj.options.url,
            type:
        })

    }
};


AjaxUtil.request({
    url: "servlet/UserJsonServlet",
    params: { id: userid },
    type: 'json',
    callback: process
});