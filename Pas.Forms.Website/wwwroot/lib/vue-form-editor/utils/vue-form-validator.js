;(function(w) {
    function vueFormValidator() {
        // 验证文本框
        this.validateText = function (form) {
            var errors = [];
            if (form.IsRequired) {
                var val = form.Val;
                if(val == '' || val == null || val == undefined) {
                    errors.push(form.Label + '不能为空');
                }
            }
            return errors;
        }

        // 验证数字框
        this.validateNumber = function (form) {
            var errors = [];
            if(form.IsRequired) {
                if(!isNumber(form.Val)) {
                    errors.push(form.Label + '必须是不为空的数字');
                } else {
                    if(form.Min != undefined) {
                        if(form.Val < form.Min) {
                            errors.push(form.Label + '必须大于等于' + form.Min);
                        }
                    }

                    if(form.Max != undefined) {
                        if(form.Val > form.Max) {
                            errors.push(form.Label + '必须小于等于' + form.Max);
                        }
                    }
                }
            } else {
                if(!isNumberOrNull(form.Val)) {
                    errors.push(orm.Label + '必须是空或数字');
                }
            }
            return errors;
        }

        // 验证日期框
        this.validateDate = function (form) {
            var errors = [];
            if(form.IsRequired) {
                if(!isDate(form.Val)) {
                    errors.push(form.Label + '必须是不为空的日期');
                }
            } else {
                if(!isDateOrNull(form.Val)) {
                    errors.push(form.Label + '必须是空或日期格式')
                }
            }
            return errors;
        }

        // 验证textarea

        // 验证下拉框

        // 验证checkboxlist
        this.validateCheckBox = function(form) {
            var errors = [];
            if(form.IsRequired) {
                if(form.Val == undefined || form.Val == null || form.length == 0) {
                    errors.push(form.Label + '不能为空');
                }
            }
            return errors;
        };

        function isNumber(val) {
            var reg = /^[-\+]?\d+(\.\d+)?$/;
            return reg.test(val);
        }

        function isNumberOrNull(val) {
            if (val == null || val == undefined || val.length == 0) {
                return true;
            }
            if (val.length != 0) {
                var reg = /^[-\+]?\d+(\.\d+)?$/;
                if (!reg.test(val)) {
                    return false;
                } else {
                    return true;
                }
            }
        }

        function isDate(val) {
            var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
            if (!reg.test(val)) {
                return false;
            }
            else {
                return true;
            }
        }

        function isDateOrNull(val) {
            if (val.length == 0 || val == null || val == undefined) {
                return true;
            }
            if (val.length != 0) {
                var reg = /^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/;
                if (!reg.test(val)) {
                    return false;
                }
                else {
                    return true;
                }
            }
        }
    }

    w.validator = new vueFormValidator();
})(window);