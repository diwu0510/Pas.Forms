namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    /// <summary>
    /// 表单Field配置
    /// </summary>
    public abstract class BaseFormFieldDescriptor
    {
        /// <summary>
        /// 类型
        /// </summary>
        public abstract string Type { get; }
        
        /// <summary>
        /// 关联的数据表
        /// </summary>
        public int TableId { get; set; }

        /// <summary>
        /// 关联的字段
        /// </summary>
        public int FieldId { get; set; }

        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 表单Label文本
        /// </summary>
        public string Title { get; set; }

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

        public virtual bool Validate(out string error)
        {
            error = string.Empty;
            if (TableId == 0 || FieldId == 0)
            {
                error = $"关联表{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Name))
            {
                error = $"表单名称{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            if (string.IsNullOrWhiteSpace(Title))
            {
                error = $"表单标题{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            if (Span != 1 || Span != 2 || Span != 4)
            {
                error = $"跨列值{FormFieldConstants.Invalid}，只支持 1|2|4";
                return false;
            }

            return true;
        }
    }
}