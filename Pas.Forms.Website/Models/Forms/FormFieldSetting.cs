using System;

namespace Pas.Forms.Website.Models.Forms
{
    public class FormFieldSetting
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 表单描述
        /// </summary>
        public BaseFormFieldDescriptor Descriptor { get; set; }
    }

    /// <summary>
    /// 表单Field配置
    /// </summary>
    public abstract class BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表单Label文本
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 提醒
        /// </summary>
        public string Placeholder { get; set; }

        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// 是否只读
        /// </summary>
        public bool Readonly { get; set; }

        /// <summary>
        /// 跨行配置，值支持 1|2|4，宽度分别时1 | 1/2 | 1/4
        /// </summary>
        public int Span { get; set; }

        /// <summary>
        /// 数据库表绑定配置
        /// </summary>
        public DataBindingSetting BindingSetting { get; set; }
    }

    /// <summary>
    /// 单行文本框
    /// </summary>
    public class SingleTextField : FormFieldSetting
    {
        public string Value { get; set; }
    }

    /// <summary>
    /// 多行文本框
    /// </summary>
    public class TextAreaField : FormFieldSetting
    {
        public int Rows { get; set; }

        public string Value { get; set; }
    }

    /// <summary>
    /// 数字框
    /// </summary>
    public class NumberField : FormFieldSetting
    {
        public NumberFieldType NumberType { get; set; }

        public string Value { get; set; }
    }

    public enum NumberFieldType
    {
        Int,
        Float,
        Money
    }

    public enum NumberFieldDefaultValue
    {
        CurrentYear,
        CurrentMonth,
        CurrentDay,
        CurrentDate,
        CurrentHour,
        CurrentMinute,
        CurrentSecond
    }

    /// <summary>
    /// 日期选择框
    /// </summary>
    public class DateField : FormFieldSetting
    {
        public string DefaultValue { get; set; }

        public DateTime Value { get; set; }
    }


    /// <summary>
    /// 日期事件选择框
    /// </summary>
    public class DateTimeField : FormFieldSetting
    {
        public DateTime Value { get; set; }
    }

    /// <summary>
    /// 多选框
    /// </summary>
    public class FixedCheckBoxField : FormFieldSetting
    {
        public FixedDataSourceSetting DataSource { get; set; }
    }

    /// <summary>
    /// 动态多选框
    /// </summary>
    public class DynamicCheckBoxField : FormFieldSetting
    {
        public DynamicDataSourceSetting DataSource { get; set; }
    }

    /// <summary>
    /// 静态下拉框
    /// </summary>
    public class FixedSelect : FormFieldSetting
    {
        public FixedDataSourceSetting DataSource { get; set; }
    }

    /// <summary>
    /// 动态下拉框
    /// </summary>
    public class DynamicSelect : FormFieldSetting
    {
        public DynamicDataSourceSetting DataSource { get; set; }
    }

    /// <summary>
    /// 文件选择框
    /// </summary>
    public class FileInput : FormFieldSetting
    {
        /// <summary>
        /// 允许的后缀名
        /// </summary>
        public string Suffix { get; set; } = "*";
    }

    public enum CurrentData
    {
        Now,
        Today,
        Year,
        Month,
        Day,
        Date,
        Hour,
        Minute,
        Second,
        UserId,
        UserName,
        DepartmentId,
        DepartmentName,
        CompanyId,
        CompanyName,
    }

    /// <summary>
    /// 固定数据输入框
    /// </summary>
    public class CurrentDataInput : FormFieldSetting
    {
        public CurrentData Value { get; set; }
    }

    /// <summary>
    /// 布尔选择框
    /// </summary>
    public class BoolInput : FormFieldSetting
    {
        public string Label { get; set; }
    }
}
