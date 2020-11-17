namespace Pas.Forms.Website.Models.Forms
{
    /// <summary>
    /// 静态数据源配置
    /// </summary>
    public class FixedDataSourceSetting
    {
        public string[] Options { get; set; }

        public override string ToString()
        {
            if (Options != null && Options.Length > 0)
            {
                return string.Join('|', Options);
            }

            return string.Empty;
        }
    }
}
