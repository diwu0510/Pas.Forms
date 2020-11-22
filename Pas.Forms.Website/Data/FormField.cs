namespace Pas.Forms.Website.Data
{
    /// <summary>
    /// 表单列配置
    /// </summary>
    public class FormField
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 表单ID
        /// </summary>
        public int FormId { get; set; }
        
        /// <summary>
        /// 关联表ID
        /// </summary>
        public string TableId { get; set; }

        /// <summary>
        /// 数据表名称
        /// </summary>
        /// <value></value>
        public string TableName { get; set; }
        
        /// <summary>
        /// 关联列ID
        /// </summary>
        public string FiledId { get; set; }

        /// <summary>
        /// 数据列名称
        /// </summary>
        /// <value></value>
        public string FieldName { get; set; }
        
        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 表单标题
        /// </summary>
        public string Label { get; set; }
        
        /// <summary>
        /// PlaceHolder
        /// </summary>
        public string Placeholder { get; set; }
        
        /// <summary>
        /// 是否必填
        /// </summary>
        public bool Required { get; set; }
        
        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool Readonly { get; set; }
        
        /// <summary>
        /// 自动加载
        /// </summary>
        public bool Auto { get; set; }
        
        /// <summary>
        /// 选项文本，以|分割
        /// </summary>
        public string Options { get; set; }
        
        /// <summary>
        /// 数据源类型
        /// </summary>
        public int DataSourceType { get; set; }
        
        /// <summary>
        /// 数据源名称，如果是字典，则是字典的Key，如果是数据源，是数据源的Key
        /// </summary>
        public string DataSource { get; set; }
        
        /// <summary>
        /// 表单值对应的数据源属性
        /// </summary>
        public string ValueField { get; set; }
        
        /// <summary>
        /// 表单文本对应的数据源属性
        /// </summary>
        public string TextField { get; set; }

        /// <summary>
        /// 数据源请求参数的JSON字符串
        /// </summary>
        public string Params { get; set; }
    }

    public class FormField2
    {
        public string Table { get; set; }

        public string Field { get; set; }

        public string Type { get; set; }

        public FormFieldSpan Span { get; set; }

        public string Name { get; set; }

        public string Label { get; set; }

        public string PlaceHolder { get; set; }

        public bool Required { get; set; }

        public bool ReadOnly { get; set; }

        public string DefaultValue { get; set; }

        public string Options { get; set; }

        public DataSourceType DataSourceType { get; set; }

        public string DataSource { get; set; }

        public string ValueProperty { get; set; }

        public string TextProperty { get; set; }

        public string ParamListJson { get; set; }

        /// <summary>
        /// 数据源字段与表单项名称（输入框之类的名称）的映射列表
        /// </summary>
        public string MapListJson { get; set; }
    }

    public enum FormFieldSpan
    {
        Full = 1,
        Half = 2
    }

    public enum DataSourceType
    {
        DataSource = 1,
        Dictionary = 2
    }
}