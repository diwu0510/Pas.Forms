namespace Pas.Forms.Website.Data
{
    /// <summary>
    /// 数据源
    /// </summary>
    public class DbSource
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 数据库ID
        /// </summary>
        /// <value></value>
        public int DbId { get; set; }

        /// <summary>
        /// 数据源标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// SQL
        /// </summary>
        public string Sql { get; set; }

        /// <summary>
        /// 返回字段的标题
        /// </summary>
        public string Fields { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        /// <value></value>
        public string Remark { get; set;}

        /// <summary>
        /// 数据库
        /// </summary>
        /// <value></value>
        public Db Db { get; set; }
    }
}