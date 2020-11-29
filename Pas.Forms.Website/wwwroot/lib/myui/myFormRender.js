(function(w, $) {
    var obj = function(containerDomId) {
        // 包裹表单的DOM
        var container = $(containerDomId);
        
        // 渲染单行文本框
        function renderText(option) {
        }
        
        // 渲染多行文本框
        function renderMulti(option) {}
        
        // 渲染数字输入框
        function renderNumber(option) {}
        
        // 渲染日期框
        function renderDate(option) {}

        // 渲染日期和时间框
        function renderDateTime(option) {}
        
        // 渲染静态下拉框
        function renderSelect(option) {}
        
        // 渲染动态下拉框
        function renderDynamicSelect(option) {}
        
        // 渲染多选框列表
        function renderCheckBoxList(option) {}
        
        // 渲染是否选择框
        function renderBool(option) {}

        /*
         * @description 创建表单列表项
         * @param   {String}    label       文本
         * @param   {String}    dom         表单的html，如：input标签，select标签等
         * @param   {Boolean}   required    是否必须
         * @return  {String}    result      结果
         */
        function formItemBuilder(label, dom, required, width) {
            var arr = [];
            var colClass = 'col-6';
            if(width === 1) {
                colClass = 'col-12';
            }
            arr.push('<div class="');
            arr.push(colClass);
            arr.push('"><div class="label>');
            if (required) {
                arr.push('<span class="font-red">* </span>');
            }
            arr.push(label);
            arr.push('</div><div class="control">');
            arr.push(dom);
            arr.push('</div><div class="form-group-item-errors">');
            arr.push('</div></div>');

            return arr.join('');
        }

        // 格式：required;maxlength 10;minlength 2;email;mobile;
        function validationRuleResolver() {

        }

        /*
         * @description 文本输入框
         * @param   {String}    name            表单名称
         * @param   {String}    defaultvalue    文本框初始值
         * @param   {Number}    maxlength       最大长度
         * @param   {String}    placeholder     提醒
         * @return  {String}    result          结果
         */
        function textInputBuilder(name, defaultvalue, maxlength, placeholder) {
            var arr = [];
            arr.push('<input type="text"');
            arr.push(' id="');
            arr.push(name);
            arr.push('"');
            arr.push(' name="');
            arr.push(name);
            arr.push('"');
            if (placeholder) {
                arr.push(' placeholder="');
                arr.push(placeholder);
                arr.push('"');
            }
            if (maxlength) {
                arr.push(' maxlength="');
                arr.push(maxlength);
                arr.push('"')
            }
            if (defaultvalue) {
                arr.push(' value="');
                arr.push(defaultvalue);
                arr.push('"');
            }
            arr.push(' />');

            return arr.join('');
        }

        /*
         * @description 数字输入框
         * @param   {String}    name            表单名称
         * @param   {Number}    defaultvalue    数字框初始值
         * @param   {Number}    min             最大长度
         * @param   {Number}    max             提醒
         * @return  {String}    result          结果
         */
        function numberInputBuilder(name, defaultvalue, min, max) {
            var arr = [];
            arr.push('<input type="number"');
            arr.push(' id="');
            arr.push(name);
            arr.push('"');
            arr.push(' name="');
            arr.push(name);
            arr.push('"');
            if (min) {
                arr.push(' min="');
                arr.push(min);
                arr.push('"')
            }
            if (max) {
                arr.push(' max="');
                arr.push(max);
                arr.push('"');
            }
            if (!isNaN(defaultvalue)) {
                arr.push(' value="');
                arr.push(defaultvalue);
                arr.push('"');
            }
            arr.push(' />');

            return arr.join('');
        }

        /*
         * @description 下拉选择框
         * @param   {String}                  name            表单名称
         * @param   {Number}                  defaultvalue    数字框初始值
         * @param   {Object[] || String[]}    options         ListItem数组或String数组，ListItem { text[String], value[String] }
         * @return  {String}                  result          结果
         */
        function dropdowListBuilder(name, defaultvalue, options) {
            var arr = [];
            arr.push('<select name="');
            arr.push(name);
            arr.push('" id="');
            arr.push(name);
            arr.push('">');
            if (options instanceof Array) {
                for (var i = 0; i < options.length; i++) {
                    var t = options[i].text || options[i].toString();
                    var v = options[i].value || options[i].toString();

                    arr.push('<option value="');
                    arr.push(v);
                    arr.push('"');
                    if (defaultvalue !== null &&
                        defaultvalue !== undefined &&
                        defaultvalue.toString() === v) {
                        arr.push(' selected="selected"');
                    }
                    arr.push('>');
                    arr.push(t);
                    arr.push('</option>');
                }
            } else {
                arr.push('<option value="');
                arr.push(arr.toString());
                arr.push('">');
                arr.push(arr.toString());
                arr.push('</option>');
            }
            arr.push("</select>");

            return arr.join('');
        }

        function checkboxBuilder() {

        }

        function isContains(defaultvalue, val) {
            if (defaultvalue instanceof Array) {
                return defaultvalue.indexOf(val) >= 0;
            } else {
                return defaultvalue === val;
            }
        }

        /*
         * @description 复选框
         * @param   {String}                  name            表单名称
         * @param   {String}                  defaultvalue    初始值
         * @param   {Object[] || String[]}    items           ListItem数组或String数组，ListItem { text[String], value[String] }
         * @return  {String}                  result          结果
         */
        function checkboxGroupBuilder(name, defaultvalue, items) {
            var arr = [];
            arr.push('<div class="checkbox-group">');

            if (items instanceof Array) {
                for (var i = 0; i < items.length; i++) {
                    var t = items[i].text || items[i].toString();
                    var v = items[i].value || items[i].toString();

                    var id = name + i;

                    arr.push('<label class="checkbox-group-item" for="');
                    arr.push(id);
                    arr.push('">');
                    arr.push('<input type="checkbox" id="');
                    arr.push(id);
                    arr.push('" name="');
                    arr.push(name);
                    arr.push('" value="');
                    arr.push(v);
                    arr.push('"');
                    if (isContains(defaultvalue, v)) {
                        arr.push(' checked="checked"');
                    }
                    arr.push(' />')
                    arr.push(t);
                    arr.push('</label>');
                }
            } else {
                var id = name + "0";
                arr.push('<label class="checkbox-group-item" for="');
                arr.push(id);
                arr.push('">');
                arr.push('<input type="checkbox" id="');
                arr.push(id)
                arr.push('" name="');
                arr.push(name);
                arr.push('" value="');
                arr.push(items.toString());
                arr.push('"');
                if (isContains(defaultvalue, v)) {
                    arr.push(' checked="checked"');
                }
                arr.push(' />')
                arr.push(items.toString());
                arr.push('</label>');
            }
            arr.push('</div>');

            return arr.join('');
        }

        /*
         * @description 单选框
         * @param   {String}                  name            表单名称
         * @param   {String}                  defaultvalue    初始值
         * @param   {Object[] || String[]}    items           ListItem数组或String数组，ListItem { text[String], value[String] }
         * @return  {String}                  result          结果
         */
        function radioGroupBuilder(name, defaultvalue, items) {
            var arr = [];
            arr.push('<div class="checkbox-group">');

            if (items instanceof Array) {
                for (var i = 0; i < items.length; i++) {
                    var t = items[i].text || items[i].toString();
                    var v = items[i].value || items[i].toString();

                    var id = name + i;

                    arr.push('<label class="radio-group-item" for="');
                    arr.push(id);
                    arr.push('">');
                    arr.push('<input type="radio" id="');
                    arr.push(id);
                    arr.push('" name="');
                    arr.push(name);
                    arr.push('" value="');
                    arr.push(v);
                    arr.push('"');
                    if (defaultvalue === v) {
                        arr.push(' checked="checked"');
                    }
                    arr.push(' />')
                    arr.push(t);
                    arr.push('</label>');
                }
            } else {
                var id = name + "0";
                arr.push('<label class="radio-group-item" for="');
                arr.push(id);
                arr.push('">');
                arr.push('<input type="radio" id="');
                arr.push(id)
                arr.push('" name="');
                arr.push(name);
                arr.push('" value="');
                arr.push(items.toString());
                arr.push('"');
                if (defaultvalue === v) {
                    arr.push(' checked="checked"');
                }
                arr.push(' />')
                arr.push(items.toString());
                arr.push('</label>');
            }
            arr.push('</div>');

            return arr.join('');
        }

        /*
         * @description 文件域
         * @param   {String}                  name           表单名称
         * @return  {String}                  result          结果
         */
        function fileInputBuilder(name) {

        }

        /*
         * @description 动态下拉框
         * @param   {String}                  name           表单名称
         * @return  {String}                  result          结果
         */
        function dynamicDropdownBuilder(name, api, param, valueField, textField) {
            var arr = [];
            arr.push('<select ');
            arr.push(' id="')
            arr.push(name);
            arr.push('"');
            arr.push(' name="');
            arr.push(name);
            arr.push('">');
            valueField = valueField || "value";
            textField = textField || "text";
            apis.push({ api: api, param: param, domId: name, valueField, textField });
            arr.push('</select>');
            return arr.join('');
        }

        /*
         * @description 弹窗选择器
         * @param   {String}     name        表单名称
         * @return  {String}     result      结果
         */
        function popupBuilder(name, api, param, valueField, textField) {
            var arr = [];
            arr.push('<input type="hidden"');
            arr.push(' id="')
            arr.push(name);
            arr.push('"');
            arr.push(' name="');
            arr.push(name);
            arr.push('" />');
            arr.push('<input id="');
            arr.push(name)
            arr.push('_text" type="text" readonly />');
            valueField = valueField || "value";
            textField = textField || "text";

            $(document).on('click', '#' + name + "_text", function() {
                popup1(name, api, param, valueField, textField);
            })

            return arr.join('');
        }

        /*
         * @description 当前用户
         * @param   {String}                  name           表单名称
         * @return  {String}                  result          结果
         */
        function userNameBuilder(name) {
            var arr = [];
            arr.push('<input type="hidden" name="');
            arr.push(name);
            arr.push('" id="userId" value="');
            arr.push(user.id);
            arr.push('" />');
            arr.push('<input type="text" id="userName" name="userName" value="')
            arr.push(user.name);
            arr.push('" readonly />');
            return arr.join('');
        }

        /*
         * @description 日期输入框
         * @param   {String}                  name           表单名称
         * @return  {String}                  result          结果
         */
        function dateInputBuilder(name, defaultvalue) {
            var arr = [];
            arr.push('<input type="date"');
            arr.push(' id="');
            arr.push(name);
            arr.push('"');
            arr.push(' name="');
            arr.push(name);
            arr.push('"');

            if (defaultvalue) {
                var v;
                if (isDate(defaultvalue)) {
                    var d = new Date(defaultvalue);
                    v = getDateString(d);
                } else if (defaultvalue === "now") {
                    var d = new Date();
                    v = getDateString(d);
                }
                if (v) {
                    arr.push(' value="');
                    arr.push(v);
                    arr.push('"');
                }
            }
            arr.push(' />');

            return arr.join('');
        }
    }
})(window, jQuery);