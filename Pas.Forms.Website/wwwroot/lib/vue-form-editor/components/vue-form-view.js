Vue.component('vue-form-view', {
    render: function(h) {
        var self = this;
        var comLabel;
        if (self.form.IsRequired) {
            comLabel = h('label', {}, [
                h('span', {class: 'text-danger'}, '* '),
                this.form.Label
            ]);
        } else {
            comLabel = h('label', {}, self.form.Label);
        }
        var comError = h('span', {
                style: {
                    display: self.errors.length == 0 ? 'none' : 'block'
                },
            }, self.errors.join(';'));

        switch (self.form.Type) {
            case "text" :
                var comText = h(
                    'input',
                    {
                        class: 'form-control',
                        domProps: {
                            value: self.form.Val
                        },
                        on: {
                            'input': function (e) {
                                self.form.Val = e.target.value;
                                self.errors = validator.validateText(self.form);
                                self.$emit('input', self.form.Val);
                            },
                            'blur': function(e) {
                                self.errors = validator.validateText(self.form);
                            }
                        }
                    }
                );
                return h(
                    'div',
                    {
                        class: 'form-group'
                    },
                    [comLabel, comText, comError]
                );
                break;
            case "number":
                var comNum = h(
                    'input',
                    {
                        class: 'form-control',
                        domProps: {
                            type: 'number',
                            value: self.form.Val
                        },
                        on: {
                            'input': function (e) {
                                self.form.Val = e.target.value;
                                self.$emit('input', self.form.Val);
                            },
                            'blur': function() {
                                self.errors = validator.validateNumber(self.form);
                            }
                        }
                    }
                );
                return h(
                    'div',
                    {
                        class: 'form-group'
                    },
                    [comLabel, comNum, comError]
                );
                break;
            case "date":
                var comDate = h('input', {
                        class: 'form-control',
                        domProps: {
                            type: 'date',
                            value: self.form.Val
                        },
                        on: {
                            'input': function (e) {
                                self.form.Val = e.target.value;
                                self.$emit('input', self.form.Val);
                            },
                            'blur': function(e) {
                                self.errors = validator.validateDate(self.form);
                            }
                        }
                    }
                );
                return h('div', {
                        class: 'form-group'
                    }, [comLabel, comDate, comError]
                );
                break;
            case "textarea":
                var comTextArea = h('textarea', {
                        class: 'form-control',
                        domProps: {
                            value: self.form.Val
                        },
                        on: {
                            'input': function (e) {
                                self.form.Val = e.target.value;
                                self.$emit('input', self.form.Val);
                            },
                            'blur': function(e) {
                                self.errors = validator.validateText(self.form);
                            }
                        }
                    }
                );
                return h('div', {
                        class: 'form-group'
                    }, [comLabel, comTextArea, comError]
                );
                break;
            case "select":
                var opts = [];
                for (var i = 0; i < self.form.Items.length; i++) {
                    var v = self.form.Items[i];
                    opts.push(h('option', {domProps: {value: v}}, v));
                }
                var comSelect = h(
                    'select',
                    {
                        class: 'form-control',
                        domProps: {
                            value: self.form.Val
                        },
                        on: {
                            'input': function (e){
                                self.form.Val = e.target.value;
                                self.$emit('input', self.form.Val);
                            },
                            'blur': function() {
                                self.errors = validator.validateText(self.form);
                            }
                        }
                    },
                    opts
                );

                return h('div', {
                    class: 'form-group'
                }, [comLabel, comSelect, comError]);
                break;
            case "checkboxlist":
                var cbs = [];
                for (var i = 0; i < self.form.Items.length; i++) {
                    var v = self.form.Items[i];
                    var id = 'cb' + self.form.Id + '-' + (i + 1);
                    cbs.push(
                        h(
                            'input',
                            {
                                attrs: {
                                    id: id
                                },
                                domProps: {
                                    value: v,
                                    checked: self.form.Val.indexOf(v) >= 0,
                                    type: 'checkbox'
                                },
                                on: {
                                    'click': function (e) {
                                        if(e.target.checked) {
                                            self.form.Val.push(e.target.value);
                                        } else {
                                            self.form.Val.splice(self.form.Val.indexOf(e.target.value), 1);
                                        }
                                        self.errors = validator.validateText(self.form);
                                        self.$emit('input', self.form.Val);
                                    }
                                }
                            }
                        ));
                    cbs.push(h('label', {
                        attrs: {
                            for: id
                        }
                    }, v));
                }

                return h('div', {
                    class: 'form-group'
                }, [comLabel, cbs, comError]);
                break;
            default:
                break;
        }
    },
    props: {
        form1: Object,
        viewOnly: {
            type: Boolean,
            default: false
        }
    },
    data: function() {
        return {
            form: this.form1,
            errors: []
        }
    },
    methods: {
        onChange: function(e) {
            this.form.Value = e.target.value;
        }
    }
});