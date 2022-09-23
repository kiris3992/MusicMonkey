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

    AjaxHelper.ajaxPromise = (url, data = null, type = 'GET', dataType = 'json', contentType = 'application/json') => {
        let options = {
            type: type,
            url: url,
            dataType: dataType,
            contentType: contentType
        };
        if (data) options.data = JSON.stringify(data);

        return $.ajax(options);
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

    Converter.secondsToTimeSpanStr = (seconds) => {
        seconds = parseInt(seconds);
        const [mins, secs] = ['0' + ((seconds - (seconds % 60)) / 60), '0' + (seconds % 60)];
        return `${mins.slice(-2)}:${secs.slice(-2)}`;
    };

    Converter.timeSpanToSeconds = (minutes, seconds) => {
        return (parseInt(minutes) * 60) + parseInt(seconds);
    };

    Converter.formatBytes = (bytes, decimals = 2) => {
        if (!+bytes) return '0 Bytes';

        const k = 1024;
        const dm = decimals < 0 ? 0 : decimals;
        const sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB', 'PB', 'EB', 'ZB', 'YB'];

        const i = Math.floor(Math.log(bytes) / Math.log(k));

        return `${parseFloat((bytes / Math.pow(k, i)).toFixed(dm))} ${sizes[i]}`;
    };

    var Window = {};

    Window.getQueryString = function (key) {
        const queryString = window.location.search;
        const parameters = new URLSearchParams(queryString);
        return parameters.get(key);
    };

    var HtmlDom = {};

    HtmlDom.registerImageFileLoader = (fileInputId, imgPreviewId) => {
        const fileEl = document.getElementById(fileInputId);
        fileEl.addEventListener('change', e => {
            const fr = new FileReader();
            fr.onload = () => document.getElementById(imgPreviewId).src = fr.result;
            fr.readAsDataURL(e.target.files[0]);
        });
    };

    HtmlDom.registerMp3FileLoader = (fileInputId, infoLabelId, inputMinsId, inputSecsId) => {
        const fileEl = document.getElementById(fileInputId);
        fileEl.addEventListener('change', e => {
            const label = HtmlDom.getEl(infoLabelId);
            const file = e.target.files[0];

            const ctx = new AudioContext();
            const fr = new FileReader();

            fr.onload = (ev) => {

                ctx.decodeAudioData(ev.target.result).then((buf) => {
                    const duration = Converter.secondsToTimeSpanStr(buf.duration);
                    label.innerHTML = `File: ${file.name}, Type: ${file.type}, Size: ${Converter.formatBytes(file.size)}, Sampla Rate: ${buf.sampleRate}, Duration: ${duration}`;
                    HtmlDom.getEl(inputMinsId).value = duration.split(':')[0];
                    HtmlDom.getEl(inputSecsId).value = duration.split(':')[1];
                });
            }
            fr.readAsArrayBuffer(e.target.files[0]);
        });
    };

    HtmlDom.createOption = function (owner = null, value, text) {
        const el = document.createElement('option');
        el.value = value;
        el.text = text;
        if (owner) owner.appendChild(el);
        return el;
    };

    HtmlDom.optionForEach = function (data, propValue, propText, owner, ownerClearLength = null) {
        if (ownerClearLength != null) owner.length = ownerClearLength;
        let el;
        data.forEach(o => {
            el = document.createElement('option');
            el.value = o[propValue];
            el.text = o[propText];
            owner.appendChild(el);
        });
        if ((ownerClearLength != null) && owner.length) owner.selectedIndex = 0;
    };

    HtmlDom.clearSelectExcepFirst = function (selectNode) {
        selectNode.length = 1;
        selectNode.selectedIndex = 0;
    };

    HtmlDom.getEl = (id) => document.getElementById(id);
    HtmlDom.getEls = (idsArray) => {
        let ar = [];
        idsArray.forEach(id => ar.push(document.getElementById(id)));
        return ar;
    };

    HtmlDom.Modal = {
        id: 'help_Modal-3992',

        registerRules: function (fontSize = 'inherit', backColor = '#6a1037', width = '400px') {
            if (document.getElementById(this.id)) document.head.removeChild(document.getElementById(this.id));

            const style = document.createElement('style');
            style.id = this.id;
            style.innerHTML = `
                .help_Modal-container {
                    font-size: ${fontSize};
                    display: flex;
                    align-items: center;
                    justify-content: center;
                    width: 100%; height: 100%;
                    background-color: #0000005e;
                    position: fixed;
                    top: 0; left: 0; z-index: 999999;
                    color: #fff;
                }
                .help_Modal-hr{
                    border: 0;
                    border-top: 1px solid #ffffff30;
                }
                .help_Modal-bg {
                    height: auto;
                    width: ${width};
                    background-color: ${backColor};
                    padding: 24px;
                    border-radius: 10px;
                    transition: all 0.25s;
                    opacity: 0;
                    transform: scale(0.25);
                }
                .help_Modal-container > div.help_Modal-fade-in {
                    opacity: 1;
                    transform: scale(1);
                }
                .help_Modal-header {
                    margin-bottom:16px;
                    color: #fff;
                    font-size: larger;
                    text-align: center;
                }
                .help_Modal-footer {
                    margin-top: 16px; display: flex; align-items: center; justify-content: space-around; width: 100%;
                }
                .help_Modal-body {
                    text-align: center;
                    margin: 16px 0;
                }
                .help_Modal-btn {
                    min-width: 100px;
                    border: 1px solid #fff;
                    border-radius: 4px;
                    padding: 4px;
                    background: #ffffff30;
                    color: #fff;
                    cursor: pointer;
                }
                .help_Modal-btn:hover {
                    background: #ffffff87;
                }
            `;
            document.head.appendChild(style);
        },
        showModalAsync: async function (title, query, backColor = null, buttonOkText = 'Ok', buttonCancelText = 'Cancel') {
            if (!document.getElementById(this.id)) {
                console.log('Please register the css rules first.');
                return new Promise.reject();
            }

            //if (backColor) {
            //    const sheet = document.getElementById(this.id).sheet;
            //    const index = Object.values(sheet.cssRules).findIndex(o => o.selectorText == '.help_Modal-bg');
            //    Object.values(sheet.cssRules)[index].style.backgroundColor = backColor;
            //}

            const createEl = HtmlDom.createElement;

            const cont = createEl('div', document.body, null, null, 'help_Modal-container');
            const modalBack = createEl('div', cont, null, null, 'help_Modal-bg');
            if (backColor) modalBack.style.backgroundColor = backColor;

            const header = createEl('div', modalBack, title, null, 'help_Modal-header');
            createEl('hr', modalBack, null, null, 'help_Modal-hr');
            const body = createEl('div', modalBack, query, null, 'help_Modal-body')
            createEl('hr', modalBack, null, null, 'help_Modal-hr');
            const footer = createEl('div', modalBack, null, null, 'help_Modal-footer');

            let btnOk, btnCancel;
            if (buttonOkText) btnOk = createEl('button', footer, buttonOkText, null, 'help_Modal-btn');
            if (buttonCancelText) btnCancel = createEl('button', footer, buttonCancelText, null, 'help_Modal-btn');

            modalBack.addEventListener('click', e => e.stopImmediatePropagation());

            let promise = new Promise((resolve) => {
                cont.addEventListener('click', () => {
                    document.body.removeChild(cont);
                    resolve('cancel');
                }, { once: true });
                if (buttonCancelText) btnCancel.addEventListener('click', () => {
                    document.body.removeChild(cont);
                    resolve('cancel');
                }, { once: true });
                if (buttonOkText) btnOk.addEventListener('click', () => {
                    document.body.removeChild(cont);
                    resolve('ok');
                }, { once: true });
            });

            cont.appendChild(modalBack);
            document.body.appendChild(cont);
            setTimeout(() => { modalBack.className += ' help_Modal-fade-in'; }, 10);

            return await promise;
        }
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

            const updateDataModel = (PageIndex, ItemsPerPage) => {
                this.dataModel.PageIndex = PageIndex;
                this.dataModel.ItemsPerPage = ItemsPerPage;
            };

            // Arrow Previous
            li = createEl('li', pagerContainerElement);
            btn = createEl('button', li, '<i class="fa fa-arrow-left" aria-hidden="true"></i>');
            btn.onclick = () => {
                updateDataModel(pagingModel.PreviousPage, pagingModel.ItemsPerPage);
                if (pagingModel.PageIndex != this.dataModel.PageIndex) pageClickFunc();
            };

            // Left
            for (let i = pagingModel.PageIndex - Math.floor(maxPagerButtons / 2); i < pagingModel.PageIndex; i++) {
                if (i < 0) continue;
                buttonsCounter--;

                li = createEl('li', pagerContainerElement);
                btn = createEl('button', li, (i + 1).toString());

                ((i) => btn.onclick = () => {
                    updateDataModel(i, pagingModel.ItemsPerPage);
                    pageClickFunc();
                })(i);
            }

            // Current
            li = createEl('li', pagerContainerElement, null, null, 'active');
            createEl('button', li, (pagingModel.PageIndex + 1).toString());

            // Right
            for (let i = pagingModel.PageIndex + 1; i < pagingModel.PageIndex + buttonsCounter; i++) {
                if (i > pagingModel.TotalPages - 1) break;

                li = createEl('li', pagerContainerElement);
                btn = createEl('button', li, (i + 1).toString());

                ((i) => btn.onclick = () => { updateDataModel(i, pagingModel.ItemsPerPage); pageClickFunc(); })(i);
            }

            // Arrow Next
            li = createEl('li', pagerContainerElement);
            btn = createEl('button', li, '<i class="fa fa-arrow-right" aria-hidden="true"></i>');
            btn.onclick = () => {
                updateDataModel(pagingModel.NextPage, pagingModel.ItemsPerPage);
                if (pagingModel.PageIndex != this.dataModel.PageIndex) pageClickFunc();
            };

            // Info
            infoElement.innerHTML = `${(pagingModel.PageIndex + 1)} from ${pagingModel.TotalPages}`;
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

            setTimeout(() => this.clear(), ms ? ms : 1600);
        };
    };

    var Sorting = {};

    Sorting.strings = (data, propName) => {
        return data.sort((a, b) => a[propName] < b[propName] ? -1 : a[propName] > b[propName] ? 1 : 0);
    };

    return { AjaxHelper, Converter, Window, Messenger, HtmlDom, Paging, Sorting };
})();