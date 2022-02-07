var activeAjax;
const Helper = {

    ajaxPostFormDataCancleable(form, onSuccess = null, onError = null, loadingMsg = "", cancleableLoading = false) {

        $(".btn").attr('disabled', 'disabled');
        if (activeAjax) { activeAjax.abort(); activeAjax = null; }


        if (cancleableLoading)
            Helper.showLoadingCancable(loadingMsg, "");
        else
            Helper.showLoading(loadingMsg);


        var url = $(form).attr('action');
        var data = new FormData(form);
        data.append("__RequestVerificationToken", $("[name='__RequestVerificationToken']").val());


        activeAjax = $.ajax({
            type: "post",
            url: url,
            data: data,
            cache: false,
            contentType: false,
            processData: false,
            success: function (data) {
                Helper.hideLoading();
                $(".btn").removeAttr('disabled');
                if (onSuccess)
                    onSuccess(data);

                //var end = window.performance.now();
                //var time = Helper.millisecondsToTime(end - start);
                //toastr.warning('زمان انجام : ' + time, '', { positionClass: "toast-bottom-left", timeOut: 4000 });
                ////alert('زمان انجام : ' + time);
            },
            error: function (xhr, err, status) {
                Helper.hideLoading();
                $(".submit-btn").removeAttr('disabled');

                if (status == "abort")
                    toastr.error('لغو عملیات توسط کاربر', '', { positionClass: "toast-top-center", timeOut: 4000 });
                else
                    toastr.error(xhr.status + ":" + xhr.statusText, 'خطا', { positionClass: "toast-top-center", timeOut: 20000 });

                if (onError)
                    onError(xhr, err, status);
            }
        });

    }
    ,
    ajaxPost2(url, data = {}, onSuccess = null, onError = null) {

        try {
            data["__RequestVerificationToken"] = $("[name='__RequestVerificationToken']").val();
        } catch (e) { }


        //activeAjax =
        $.ajax({
            type: "post",
            url: url,
            data: data,
            //processData: false,
            //dataType: 'json',
            success: function (data) {

                if (onSuccess)
                    onSuccess(data);
            },
            error: function (xhr, err, status) {

                toastr.error(xhr.status + ":" + xhr.statusText, 'خطا', { positionClass: "toast-top-center", timeOut: 20000 });

                if (onError)
                    onError(xhr, err, status);
            }
        });

    }
    ,
    ajaxPostCancleable(url, data = {}, onSuccess = null, onError = null, loadingMsg = "", cancleableLoading = false) {

        let start = window.performance.now();

        if (activeAjax) { activeAjax.abort(); activeAjax = null; }


        if (cancleableLoading)
            Helper.showLoadingCancable(loadingMsg, "");
        else
            Helper.showLoading(loadingMsg);
        try {
            data["__RequestVerificationToken"] = $("[name='__RequestVerificationToken']").val();
        } catch (e) { }


        activeAjax = $.ajax({
            type: "post",
            url: url,
            data: data,
            //processData: false,
            //dataType: 'json',
            success: function (data) {
                Helper.hideLoading();
                $(".submit-btn").removeAttr('disabled');
                if (onSuccess)
                    onSuccess(data);

                var end = window.performance.now();
                var time = Helper.millisecondsToTime(end - start);
                toastr.warning('زمان انجام : ' + time, '', { positionClass: "toast-bottom-left", timeOut: 4000 });
                //alert('زمان انجام : ' + time);
            },
            error: function (xhr, err, status) {
                Helper.hideLoading();
                $(".submit-btn").removeAttr('disabled');

                if (status == "abort")
                    toastr.error('لغو عملیات توسط کاربر', '', { positionClass: "toast-top-center", timeOut: 4000 });
                else
                    toastr.error(xhr.status + ":" + xhr.statusText, 'خطا', { positionClass: "toast-top-center", timeOut: 20000 });

                if (onError)
                    onError(xhr, err, status);
            }
        });

    }
    ,
    millisecondsToTime(s) {
        let ms = s % 1000;
        s = (s - ms) / 1000;
        let secs = s % 60;
        s = (s - secs) / 60;
        let mins = s % 60;
        let hrs = (s - mins) / 60;

        return hrs + ':' + mins + ':' + secs;// + '.' + ms;
    }
    ,
    moneyFormat(d) {
        return (new Intl.NumberFormat('de-DE', { maximumSignificantDigits: 3 }).format(d));
    }
    ,
    moneyFormat2(digit) {
        var sum = parseFloat(digit, 10).toFixed(1).replace(/(\d)(?=(\d{3})+\.)/g, "$1,").toString();
        return sum.split('.')[0];
    }
    ,
    cancleActiveAjax() {
        if (activeAjax != undefined) {
            activeAjax.abort();
            $(".btn").removeAttr("disabled");
            this.hideLoading();
        }
    }
    ,
    showLoading(msg) {
        if (msg == undefined || msg == null) msg = "  ";

        $(".btn:not(.workOnLoading)").attr("disabled", "disabled");


        $(".loading").html(`<span style="padding:24px 20px;background:#ffffffe3;border-radius: 20px;">
                                <img src="/_files/loading.gif" style="height: 35px;" />
                            </span><br><br />
                            <span style="font-size: 14px; color: #8e0606;background:#ffffffe3;border-radius: 8px;padding: 5px;white-space: nowrap;">${msg} <span class="serverMsg"></span></span>
                            <br />`);
        $(".loading").css("display", '');
        $(".loading").fadeIn("fast");

        //$(".top-main-div").css("filter", "blur(16px)");
        //$(".filter-box").css("filter", "blur(16px)");
        //$(".page-top-main-div").css("filter", "blur(16px)");
        //$(".container.body-content").css("filter", "blur(16px)");
        //$("footer").css("filter", "blur(16px)");
    }
    ,
    showLoadingCancable(msg, moreInfo = "") {
        if (msg == undefined || msg == null) msg = "  ";

        $(".btn:not(.workOnLoading)").attr("disabled", "disabled");

        $(".loading").html(`<span style="padding:24px 20px;background:#ffffffe3;border-radius: 20px;">
                                <img src="/_files/loading.gif" style="height: 35px;" />
                            </span><br><br />
                            <button onclick="Helper.cancleActiveAjax()" class="btn btn-sm btn-danger" >لغو  <i class="la la-ban la-2x"></i></button>
                            <span style="font-size: 14px; color: #8e0606;background:#ffffffe3;border-radius: 8px;padding: 5px;white-space: nowrap;">${msg} <span class="serverMsg"></span></span>
                            <br />`+
            (moreInfo == "" ? "" : `<span style="font-size: 12px; color: red;border-radius: 20px;padding:2px;">${moreInfo}</span>`));
        $(".loading").css("display", '');
        $(".loading").fadeIn("fast");

        //$(".top-main-div").css("filter", "blur(16px)");
        //$(".filter-box").css("filter", "blur(16px)");
        //$(".page-top-main-div").css("filter", "blur(16px)");
        //$(".container.body-content").css("filter", "blur(16px)");
        //$("footer").css("filter", "blur(16px)");
    }
    ,
    hideLoading() {
        $(".loading").stop();
        $(".loading").fadeOut("slow");

        $(".btn").removeAttr("disabled");

        $(".top-main-div").css("filter", "");
        $(".filter-box").css("filter", "");
        $(".page-top-main-div").css("filter", "");
        $(".container.body-content").css("filter", "");
        $("footer").css("filter", "");
    }
    ,
    replaceAll(wordOrsentence, search, replacement) {
        return wordOrsentence.replace(new RegExp(search, 'g'), replacement);
    }
    ,
    setCookie(cname, cvalue, exdays) {
        var d = new Date();
        d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
        var expires = "expires=" + d.toUTCString();
        document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
    }
    ,
    getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }
    ,
    palyDing() {
        var audio = new Audio('/_files/ding.mp3');
        audio.play();
    }
    ,
    notifyMe(msg, title, icon, senderId) {
        // Let's check if the browser supports notifications
        if (!("Notification" in window)) {
            //alert("This browser does not support system notifications");
            return;
        }

        // Let's check whether notification permissions have already been granted
        else if (Notification.permission === "granted") {
            // If it's okay let's create a notification

            //var notification = new Notification(msg);

            var notification = new Notification(title, {
                icon: (icon != "" && icon != undefined && !icon.endsWith("null")) ? icon : 'http://site.ir/_files/_img/logo.png',
                body: msg,
            });
            notification.onclick = function (event) {
                event.preventDefault(); // prevent the browser from focusing the Notification's tab               
                Helper.handleNotficationclick(title, senderId);
            }

        }

        // Otherwise, we need to ask the user for permission
        else if (Notification.permission !== 'denied') {
            Notification.requestPermission(function (permission) {
                // If the user accepts, let's create a notification
                if (permission === "granted") {
                    var notification = new Notification(title, {
                        icon: (icon != "" && icon != undefined && !icon.endsWith("null")) ? icon : 'http://site.ir/_files/_img/logo.png',
                        body: msg,
                    });
                    notification.onclick = function (event) {
                        event.preventDefault(); // prevent the browser from focusing the Notification's tab
                        Helper.handleNotficationclick(title, senderId);
                    }
                }
            });
        }

        // Finally, if the user has denied notifications and you 
        // want to be respectful there is no need to bother them any more.
    }
    ,
    handleNotficationclick(senderUserName, senderId) {


    }
    ,
    shakeElm(selector) {
        $(selector).effect("shake");
    }
    ,

}


