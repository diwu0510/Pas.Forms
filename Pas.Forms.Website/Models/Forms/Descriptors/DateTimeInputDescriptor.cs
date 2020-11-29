using System;
using System.Linq;

namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class DateTimeInputDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "DateTime";

        /// <summary>
        /// 默认值
        /// 可选默认值：now 当前时间 日期+时分秒 | minute 日期+时分 | hour 日期+小时
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

            var opts = new [] {"now", "minute", "hour"};
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