namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    /// <summary>
    /// 多行文本
    /// </summary>
    public class TextareaDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "Textarea";

        /// <summary>
        /// 行数
        /// </summary>
        public int Rows { get; set; } = 1;

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// 最大长度
        /// </summary>
        public int Maxlength { get; set; }
        
        /// <summary>
        /// 最小长度
        /// </summary>
        public int Minlength { get; set; }
        
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