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
}