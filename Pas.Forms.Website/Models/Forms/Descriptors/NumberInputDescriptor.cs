namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    /// <summary>
    /// 数字输入框
    /// </summary>
    public class NumberInputDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "Number";

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// 最小值
        /// </summary>
        public float Min { get; set; }
        
        /// <summary>
        /// 最大值
        /// </summary>
        public float Max { get; set; }
        
        /// <summary>
        /// 规则，正则表达式
        /// </summary>
        public string Rule { get; set; }
        
        public override bool Validate(out string err)
        {
            if (!base.Validate(out err))
            {
                return false;
            }

            return true;
        }
    }
}