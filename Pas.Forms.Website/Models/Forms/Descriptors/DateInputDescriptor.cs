using System;
using System.Linq;

namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    /// <summary>
    /// 日期选择框，
    /// 可选默认值：具体日期(yyyy/MM/dd) | today | yesterday | tomorrow
    /// </summary>
    public class DateInputDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "Date";

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public DateTime? Value { get; set; }

        public override bool Validate(out string err)
        {
            if (!base.Validate(out err))
            {
                return false;
            }

            var opts = new[] {"today", "yesterday", "tomorrow"};
            if (!opts.Contains(DefaultValue) &&
                DateTime.TryParse(DefaultValue, out _))
            {
                err = $"日期默认值配置{FormFieldConstants.Invalid}";
                return false;
            }

            return true;
        }
    }
}