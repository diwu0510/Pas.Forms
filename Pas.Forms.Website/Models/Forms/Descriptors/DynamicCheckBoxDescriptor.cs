namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class DynamicCheckBoxDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "DynamicCheckbox";

        /// <summary>
        /// 数据源类型，1 内部数据源 | 2 外部接口
        /// </summary>
        public short DataSourceType { get; set; }

        /// <summary>
        /// 组件值绑定的数据源字段
        /// </summary>
        public string ValueField { get; set; }

        /// <summary>
        /// 组件显示文本绑定的数据源对象
        /// </summary>
        public string TextField { get; set; }

        /// <summary>
        /// 数据源标识，Type=1时为数据源名称，Type=2时为外部接口的URI地址
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 请求参数，页面表现为KeyValue键值对列表
        /// </summary>
        public object Parameters { get; set; }
        
        /// <summary>
        /// 数据源属性名与其他表单名称的映射
        /// </summary>
        /// <remarks>
        /// 区别于主字段的映射，数据源可能返回多个属性的值，除了Value和Text指定的属性，
        /// 可能还需要使用该数据的其他属性填充到其他表单，这里配置的就是属性和表单名的对应关系
        /// </remarks>
        public object Maps { get; set; }
        
        /// <summary>
        /// 值，用 , 分割
        /// </summary>
        public string Value { get; set; }
        
        /// <summary>
        /// 自动加载数据
        /// </summary>
        public bool Auto { get; set; }
        
        /// <summary>
        /// 关联表单
        /// </summary>
        /// <remarks>
        /// 当关联表单值发生变化时，自动刷新数据源
        /// </remarks>
        public string LinkForm { get; set; }
        
        public override bool Validate(out string err)
        {
            if (!base.Validate(out err))
            {
                return false;
            }

            if(string.IsNullOrWhiteSpace(TextField) || string.IsNullOrWhiteSpace(ValueField))
            {
                err = $"文本属性或值属性{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            if(string.IsNullOrWhiteSpace(Source))
            {
                err = $"数据源{FormFieldConstants.MustBeNotEmpty}";
                return false;
            }

            return true;
        }
    }
}