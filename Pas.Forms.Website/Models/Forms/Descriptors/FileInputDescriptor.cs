namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class FileInputDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "File";

        /// <summary>
        /// 允许的后缀名
        /// </summary>
        public string Suffix { get; set; } = "*";
        
        /// <summary>
        /// 文件路径或标识
        /// </summary>
        public string Value { get; set; }
        
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