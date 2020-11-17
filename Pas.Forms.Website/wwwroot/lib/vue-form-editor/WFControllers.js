var WFController = {
    SingleTextBox: {
        Id: '',
        Title: '单行文本',
        PlaceHolder: '',
        Text: '',
        Required: true,
        Printable: true,
        Type: 'SingleTextBox'
    },
    MultiTextBox: {
        Id: '',
        Title: '多行文本',
        PlaceHolder: '',
        Text: '',
        Required: true,
        Printable: true,
        Type: 'MultiTextBox'
    },
    NumberTextBox: {
        Id: '', 
        Title: '数字',
        PlaceHolder: '',
        Text: '',
        Val: undefined,
        Unit: '',
        Required: true,
        Printable: true,
        Type: 'NumberTextBox'
    },
    DateTimeTextBox: {
        Id: '',
        Title: '日期',
        PlaceHolder: '',
        Text: '',
        Val: undefined,
        Format: 'date',
        Required: true,
        Printable: true,
        Type: 'DateTimeTextBox'
    },
    RadioButton: {
        Id: '',
        Title: '单选',
        PlaceHolder: '',
        Options: ['选项一'],
        Val: '',
        Required: true,
        Printable: true,
        Type: 'RadioButton'
    },
    CheckBoxButton: {
        Id: '',
        Title: '复选框',
        PlaceHolder: '',
        Options: ['选项一'],
        Val: [],
        Required: true,
        Printable: true,
        Type: 'CheckBoxButton'
    },
    ImageUploader: {
        Id: '',
        Title: '图片上传',
        Val: '',
        Required: true,
        Type: 'ImageUploader'
    },
    FileUploader: {
        Id: '',
        Title: '文件上传',
        Val: '',
        Required: true,
        Type: 'FileUploader'
    },
    ItemBox: {
        Id: '',
        Title: '明细列表',
        ActionName: '',
        Items: [],
        Type: 'ItemBox'
    }
};