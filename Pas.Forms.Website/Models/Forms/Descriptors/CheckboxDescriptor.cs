namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class CheckboxDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "Checkbox";
        
        /// <summary>
        /// 选项列表，用 | 分割
        /// </summary>
        public string Options { get; set; }
        
        /// <summary>
        /// 默认值，多个值用 , 分割
        /// </summary>
        public string DefaultValue { get; set; }
        
        /// <summary>
        /// 值，多个值用 , 分割
        /// </summary>
        public string Value { get; set; }
        
        public override bool Validate(out string err)
        {
            if (!base.Validate(out err))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Options))
            {
                err = $"选项{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            return true;
        }
    }
}