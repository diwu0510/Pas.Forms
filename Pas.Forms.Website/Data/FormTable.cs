namespace Pas.Forms.Website.Data
{
    /// <summary>
    /// 表单关联的表
    /// </summary>
    public class FormTable
    {
        public int Id { get; set; }
        
        /// <summary>
        /// 表单ID
        /// </summary>
        public int FormId { get; set; }
        
        /// <summary>
        /// 关联的表
        /// </summary>
        public int DbTableId { get; set; }
        
        /// <summary>
        /// 主表的关联字段
        /// </summary>
        public string MasterField { get; set; }
        
        /// <summary>
        /// 字表的关联字段
        /// </summary>
        public string SubField { get; set; }

        /// <summary>
        /// 关联的表单
        /// </summary>
        public Form Form { get; set; }

        /// <summary>
        /// 关联的子表
        /// </summary>
        public DbTable DbTable { get; set; }
    }
}