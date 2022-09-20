var SiteHelper = (function () {
    'use strict';

    var AjaxHelper = {};

    AjaxHelper.ajaxObject = function (url, data = null, type = 'GET', dataType = 'json', contentType = 'application/json') {
        this.type = type;
        this.url = url;
        this.dataType = dataType;
        this.contentType = contentType;
        this.data = data;
    };

    AjaxHelper.contentLoader = function (dataContainerId, dataTemplate, onSuccessFinallyFunc = null, ajaxObject, minContainerHeight = null, dataProperty = null) {
        let sectionBuilder = function (dataContainerId, dataTemplate, onSuccessFinallyFunc = null, ajaxObject, minContainerHeight = null, dataProperty = null) {
            this.dataContainerId = dataContainerId;
            this.dataTemplate = dataTemplate;
            this.ajaxObject = ajaxObject;
            this.onSuccessFinallyFunc = onSuccessFinallyFunc;
            this.dataProperty = dataProperty;

            this.start = function () {
                this.load();

                ((t) => {
                    if (t.ajaxObject.data) {
                        $.ajax({
                            type: t.ajaxObject.type,
                            data: JSON.stringify(t.ajaxObject.data),
                            url: t.ajaxObject.url,
                            dataType: t.ajaxObject.dataType,
                            contentType: t.ajaxObject.contentType,
                            success: function (data) { t.build(data); },
                            error: function () { t.error(); }
                        });
                    }
                    else {
                        $.ajax({
                            type: t.ajaxObject.type,
                            url: t.ajaxObject.url,
                            dataType: t.ajaxObject.dataType,
                            contentType: t.ajaxObject.contentType,
                            success: function (data) { t.build(data); },
                            error: function () { t.error(); }
                        });
                    }
                })(this);
            };

            this.build = function (data) {
                //if (data.length > 10) data.length = 10; // Prosoxh gia debug edo perno mono 50 items; kanonika prepei na fugei auth h grammh.
                setTimeout(() => {
                    if (dataProperty) $(`#${dataContainerId}`).html(data[dataProperty].map((o, i) => this.dataTemplate(o, i)));
                    else $(`#${dataContainerId}`).html(data.map((o, i) => this.dataTemplate(o, i)));
                    if (this.onSuccessFinallyFunc) this.onSuccessFinallyFunc(data);
                }, 800);
            };
            this.load = function () {
                const style = minContainerHeight ? ` style="min-height:${minContainerHeight}"` : '';

                $(`#${dataContainerId}`).html(
                    `<div class='spinnerContainer'${style}>
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
        return new sectionBuilder(dataContainerId, dataTemplate, onSuccessFinallyFunc, ajaxObject, minContainerHeight, dataProperty);
    };

    var Converter = {};

    Converter.csDateStrToJsDateStr = function (cSharpDateStr, format = 'dd/mm/yyyy') {
        let f = format.toLowerCase();
        let date = new Date(Date.parse(cSharpDateStr));
        let ar = [{ n: 'y', v: -1 }, { n: 'm', v: -1 }, { n: 'd', v: -1 }].sort((a, b) => f.indexOf(a.n) - f.indexOf(b.n));

        ar.forEach(o => {
            o.v = f.split(o.n).length - 1;
            if (o.v < 1) return;
            switch (o.n) {
                case 'y': f = f.replace(o.n.repeat(o.v), o.v == 2 ? date.getFullYear().toString().slice(2) : date.getFullYear().toString()); break;
                case 'm': f = f.replace(o.n.repeat(o.v), o.v == 1 ? (date.getMonth() + 1).toString() : `0${date.getMonth() + 1}`.slice(-2)); break;
                case 'd': f = f.replace(o.n.repeat(o.v), o.v == 1 ? date.getDate().toString() : `0${date.getDate()}`.slice(-2)); break;
            }
        });

        return f;
    };

    var Window = {};

    Window.getQueryString = function (key) {
        const queryString = window.location.search;
        const parameters = new URLSearchParams(queryString);
        return parameters.get(key);
    };

    var HtmlDom = {};

    HtmlDom.createOption = function (owner = null, value, text) {
        const el = document.createElement('option');
        el.value = value;
        el.text = text;
        if (owner) owner.appendChild(el);
        return el;
    };

    HtmlDom.createElement = function (tagName, owner = null, innerHTML = null, innerTEXT = null, className = null) {
        const el = document.createElement(tagName);
        if (innerTEXT) el.innerTEXT = innerTEXT;
        if (innerHTML) el.innerHTML = innerHTML;
        if (className) el.className = className;
        if (owner) owner.appendChild(el);
        return el;
    };

    var Paging = {};

    Paging.Create = function (infoElement, pagerContainerElement, maxPagerButtons, pageClickFunc, dataModel) {
        const createEl = HtmlDom.createElement;
        this.dataModel = dataModel;

        this.build = function (pagingModel) {
            pagerContainerElement.innerHTML = '';

            let buttonsCounter = maxPagerButtons;
            let li, btn;

            // Arrow Previous
            li = createEl('li', pagerContainerElement);
            btn = createEl('button', li, '<i class="fa fa-arrow-left" aria-hidden="true"></i>');
            btn.onclick = () => {
                this.dataModel = { type: "", PageIndex: pagingModel.PreviousPage, ItemsPerPage: pagingModel.ItemsPerPage };
                if (pagingModel.PageIndex != this.dataModel.PageIndex) pageClickFunc();
            };

            // Left
            for (let i = pagingModel.PageIndex - Math.floor(maxPagerButtons / 2); i < pagingModel.PageIndex; i++) {
                if (i < 0) continue;
                buttonsCounter--;

                li = createEl('li', pagerContainerElement);
                btn = createEl('button', li, (i + 1).toString());

                ((i) => btn.onclick = () => { this.dataModel = { type: "", PageIndex: i, ItemsPerPage: pagingModel.ItemsPerPage }; pageClickFunc(); }) (i);
            }

            // Current
            li = createEl('li', pagerContainerElement, null, null, 'active');
            createEl('button', li, (pagingModel.PageIndex + 1).toString());

            // Right
            for (let i = pagingModel.PageIndex + 1; i < pagingModel.PageIndex + buttonsCounter; i++) {
                if (i > pagingModel.TotalPages - 1) break;

                li = createEl('li', pagerContainerElement);
                btn = createEl('button', li, (i + 1).toString());

                ((i) => btn.onclick = () => { this.dataModel = { type: "", PageIndex: i, ItemsPerPage: pagingModel.ItemsPerPage }; pageClickFunc(); }) (i);
            }

            // Arrow Next
            li = createEl('li', pagerContainerElement);
            btn = createEl('button', li, '<i class="fa fa-arrow-right" aria-hidden="true"></i>');
            btn.onclick = () => {
                this.dataModel = { type: "", PageIndex: pagingModel.NextPage, ItemsPerPage: pagingModel.ItemsPerPage };
                if (pagingModel.PageIndex != this.dataModel.PageIndex) pageClickFunc();
            };
        }
    };


    var Messenger = {};

    Messenger.infoMessenger = function (messageElement) {
        const el = messageElement;

        this.set = {
            primary: (message, ms = null) => writeMessage(message, '#007bff', ms),
            success: (message, ms = null) => writeMessage(message, '#28a745', ms),
            info: (message, ms = null) => writeMessage(message, '#17a2b8', ms),
            warning: (message, ms = null) => writeMessage(message, '#ffc107', ms),
            danger: (message, ms = null) => writeMessage(message, '#dc3545', ms),
            custom: (message, color, ms = null) => writeMessage(message, color, ms)
        };
        this.clear = () => {
            el.innerHTML = '&nbsp;';
            el.style.color = 'inherit';
        };

        const writeMessage = (message, color, ms) => {
            el.innerHTML = message;
            el.style.color = color;

            setTimeout(() => this.clear(), ms ? ms : 1200);
        };
    };

    return { AjaxHelper, Converter, Window, Messenger, HtmlDom, Paging };
})();