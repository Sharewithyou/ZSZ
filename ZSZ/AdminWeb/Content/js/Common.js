
var AjaxUtil = {

    // 基础选项
    options: {
        url: "", // 请求的路径 required,
        type: "post",
        data: {},
        dataType: 'json',
        isLoading: true,
        success: function () {

        },
        fail: function () {

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

        var url = ajaxObj.options.url;
        var type = ajaxObj.options.type;

        if (ajaxObj.options.isLoading) {
            //插入loading
            var html = "";
            var imgLoading = "data:image/gif;base64,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";

            html += '<div class="mloading mloading-full mloading-mask active">';
            html += '   <div class="mloading-body">';
            html += '       <div class="mloading-bar">';
            html += '           <img class="mloading-icon" src="' + imgLoading + '" >';
            html += '           <span class="mloading-text">加载中...</span>';
            html += '       </div>';
            html += '   </div>';
            html += '</div>';
            $("body").append(html);
            setTimeout(function () {
                $(".mloading").hide();
            }, 1000 * 10);
        }


        if ("GET" === type.toUpperCase()) {
            // 格式化参数
            var formateParams = ajaxObj.formateParameters.call(ajaxObj);
            url += "?" + formateParams;
        }

        $.ajax({
            url: url,
            type: type,          
            data: ajaxObj.options.data,
            dataType: ajaxObj.options.dataType,
            success: function (rep) {
                if (rep.IsSuccess) {
                    ajaxObj.options.success(rep);
                } else {
                    ajaxObj.options.fail(rep);
                }
            },
            error: function (xhr, status) {
                if (!xhr || xhr.status == 0)
                    return;
                alert(xhr.status);
                //if (xhr.status == 404) { //
                //    //var inReload = xhr.getResponseHeader('in-reload');
                //    //if (inReload == 1) {
                //    //    var check = confirm("此次会话已超时，点击'确定'，重新登录");
                //    //    if (check) {
                //    //        top.location.href = decodeURI(top.location.href.split(';')[0]);
                //    //    }
                //    //    return;
                //    //}
                //}
            },
            //在请求成功或失败之后均调用，即在 success 和 error 函数之后
            complete: function (xhr, status) {
                $(".mloading").hide();
                try {
                    //todo 统一权限校验，统一会话超时校验
                    //var inFefresh = request.getResponseHeader('is-refresh');
                    //var inLogin = request.getResponseHeader('in-login');
                    //var refreshUrl = request.getResponseHeader('refresh-url');
                    //if (inFefresh == '1' || inLogin == '1') {
                    //    if (refreshUrl == null || refreshUrl == '') {
                    //        window.location.reload();
                    //    } else {
                    //        try {
                    //            refreshUrl = decodeURI(refreshUrl);
                    //            top.location.href = refreshUrl;
                    //        } catch (e) {
                    //            window.location.reload();
                    //        }
                    //    }
                    //}
                } catch (e) {
                    //后台没有设置responseHeader则不做处理
                }
            }

        });

    }
};


//AjaxUtil.request({
//    url: "servlet/UserJsonServlet",
//    params: { id: userid },
//    type: 'json',
//    callback: process
//});