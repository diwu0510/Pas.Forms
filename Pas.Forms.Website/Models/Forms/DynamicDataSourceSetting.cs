namespace Pas.Forms.Website.Models.Forms
{
    /// <summary>
    /// 动态数据源配置
    /// </summary>
    public class DynamicDataSourceSetting
    {
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
        public object Parameter { get; set; }
    }
}
