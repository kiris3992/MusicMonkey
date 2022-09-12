var SiteHelper = (function () {
    'use strict';

    var AjaxHelper = {};

    AjaxHelper.ajaxObject = function (url, type = 'GET', dataType = 'json', contentType = 'application/json') {
        this.type = type;
        this.url = url;
        this.dataType = dataType;
        this.contentType = contentType;
    };

    AjaxHelper.contentLoader = function (dataContainerId, dataTemplate, onSuccessFinallyFunc = null, ajaxObject) {
        let sectionBuilder = function (dataContainerId, dataTemplate, onSuccessFinallyFunc = null, ajaxObject) {
            this.dataContainerId = dataContainerId;
            this.dataTemplate = dataTemplate;
            this.ajaxObject = ajaxObject;
            this.onSuccessFinallyFunc = onSuccessFinallyFunc;

            this.start = function () {
                this.load();

                ((t) => {
                    $.ajax({
                        type: t.ajaxObject.type, url: t.ajaxObject.url, dataType: t.ajaxObject.dataType, contentType: t.ajaxObject.contentType,
                        success: function (data) { t.build(data); },
                        error: function () { t.error(); }
                    });
                })(this);
            };

            this.build = function (data) {
                if (data.length > 30) data.length = 30; // Prosoxh gia debug edo perno mono 30 items; kanonika prepei na fugei auth h grammh.
                setTimeout(() => {
                    $(`#${dataContainerId}`).html(data.map((o, i) => this.dataTemplate(o, i)));
                    if (this.onSuccessFinallyFunc) this.onSuccessFinallyFunc();
                }, 1600);
            };
            this.load = function () {
                $(`#${dataContainerId}`).html(
                    `<div class='spinnerContainer'>
                    <div class="spinner-grow" style="width: 5rem; height: 5rem;" role="status">
                        <span class="sr-only">Loading...</span>
                    </div>
                <div>`
                );
            };
            this.error = function () {
                $(`#${dataContainerId}`).html(
                    `<div class="errorContainer">
                    <div class="single_player_container">
                        <h4>No data found</h4>
                        <h6>Please refresh the page</h6>
                    </div>
                </div>`
                );
            };
        };
        return new sectionBuilder(dataContainerId, dataTemplate, onSuccessFinallyFunc, ajaxObject);
    };

    return { AjaxHelper };
})();










