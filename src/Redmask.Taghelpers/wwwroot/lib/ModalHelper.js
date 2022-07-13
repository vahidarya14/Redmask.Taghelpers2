
const modalHelper = {

    modalCount: 1000,

    loadPartialAsModal(url, title, isLg, onSuccess, onError, onClose) {

        var modalId = modalHelper._makeModalwindow(title, isLg);

        $.ajax({
            type: "get",
            url: url,
            success: function (msg) {
                $("#modelBody-" + modalId).html(msg);

                if (onClose != undefined)
                    $('#modal-' + modalId).on('hidden.bs.modal', function () {
                        onClose();
                    })

                // $('input[data-mddatetimepicker]').map(function () {
                //     //var a = $(this);
                //     $(this).MdPersianDateTimePicker({
                //         Placement: 'bottom',
                //         Trigger: 'click',
                //         EnableTimePicker: false,
                //         TargetSelector: '#' + this.id,
                //         GroupId: '',
                //         ToDate: false,
                //         FromDate: false,
                //         DisableBeforeToday: false,
                //         Disabled: false,
                //         Format: 'yyyy/MM/dd',
                //         IsGregorian: false,
                //         EnglishNumber: false,
                //         InLine: false
                //     });
                // });
                //
                // //$('.bootstrap-select').selectpicker({
                // //    liveSearch: true,
                // //    liveSearchPlaceholder: null,
                // //    liveSearchNormalize: false,
                // //    liveSearchStyle: 'contains'
                // //});
                //
                // $("select[multiple]").select2({ placeholder: 'انتخاب کنید' });
                // $("select.searchable").select2({ placeholder: 'انتخاب کنید' });
                //
                // //$('.venobox').venobox();


                if (onSuccess != undefined)
                    onSuccess(msg);
            },
            error: function (err) {
                $("#modelBody-" + modalId).html("<img src='/_files/redDeath.png' style='width: 50px;' > خطا در بارگذاری فرم");
                if (onError != undefined)
                    onError(err);
            }
        });
    },

    closeActiveModal() {
        modalHelper.modalCount--;
        var modalId = modalHelper.modalCount;
        modalHelper._closeModal(modalId);
    }
    ,
    makeModalForHtml(title, isLg, htmlBody, onClose) {
        var lgClass = (isLg == true) ? "modal-lg" : "";
        var modalId = modalHelper.modalCount++;
        var html =
            ' <div id ="modal-' + modalId + '" class="modal fade" role ="dialog" data-backdrop="static" data-keyboard="false" >' +
            '   <div class="modal-dialog ' + lgClass + '">                                                                        ' +
            '      <div class="modal-content" id="modal-content-' + modalId + '">                                                                                    ' +
            '        <div class="modal-header">                                                                                     ' +
            '           <button type="button" class="close py-2" onclick="modalHelper.closeActiveModal(' + modalId + ');">&times;</button>                                      ' +
            '           <h5 class="modal-title pull-left">' + title + '</h5>                                                                    ' +
            '        </div>                                                                                                         ' +
            '        <div class="modal-body" id="modelBody-' + modalId + '" >' + 'loading...' + '</div>                                         ' +
            '      </div>                                                                                                         ' +
            '   </div>                                                                                                         ' +
            ' </div >                                                                                                        ';
        $('body').append(html);
        $("#modal-" + modalId).modal('show');
        setTimeout(() => { $("#modelBody-" + modalId).html(htmlBody); }, 200);

        if (onClose != undefined)
            $('#modal-' + modalId).on('hidden.bs.modal', function () {
                onClose();
            });

        return modalId;
    }
    ,
    modalError(err, bgColor) {
        var title = "";
        var body = err;
        if (err.responseText) {
            body = err.responseText;
            title = err.statusText;
        }

        var modalId = modalHelper._makeModalwindow(title, false);
        $("#modelBody-" + modalId).html(body);
        if (bgColor != undefined) {
            $("#modal-content-" + modalId).css("background", bgColor);
            $("#modelBody-" + modalId).css("background", bgColor);
        }
    }
    ,
    _makeModalwindow(title, isLg) // this is private
    {
        var lgClass = (isLg == true) ? "  modal-lg " : "";
        var modalClass = isLg == true ? " maximizeModal " : "";
        var modalId = modalHelper.modalCount++;
        var html =
            ' <div id ="modal-' + modalId + '" class="modal fade' + modalClass + '" role ="dialog" data-backdrop="static" data-keyboard="false" >' +
            '   <div class="modal-dialog  ' + lgClass + '">                                                                        ' +
            '      <div class="modal-content" id="modal-content-' + modalId + '">                                                                                    ' +
            '        <div class="modal-header">                                                                                     ' +
            '           <i class="las la-times la-2x text-white" onclick="modalHelper.closeActiveModal(' + modalId + ');"></i>                                      ' +
            '           <h5 class="modal-title">' + title + '</h5>                                                                    ' +
            '        </div>                                                                                                         ' +
            '        <div class="modal-body" id="modelBody-' + modalId + '" >' + '<div class="progress"><div class="progress-bar progress-bar-striped active" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100" style="width:100%"> در حال بارگذاری... </div></div>' + '</div>                                         ' +
            '      </div>                                                                                                         ' +
            '   </div>                                                                                                         ' +
            ' </div >                                                                                                        ';
        $('body').append(html);
        $("#modal-" + modalId).modal('show');

        return modalId;
    }
    ,
    _closeModal(modalId) {
        $('#modal-' + modalId).modal('hide');

        setTimeout(() => { $('#modal-' + modalId).remove(); }, 200);
    }

}

