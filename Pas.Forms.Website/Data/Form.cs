using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pas.Forms.Website.Data
{
    /// <summary>
    /// 表单
    /// </summary>
    public class Form
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 数据表ID
        /// </summary>
        public int DbTableId { get; set; }
        
        /// <summary>
        /// 表单名称
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        
        /// <summary>
        /// 表单配置JSON字符串
        /// </summary>
        public string Fields { get; set; }
        
        /// <summary>
        /// 主表
        /// </summary>
        [ForeignKey("DbTableId")]
        public DbTable DbTable { get; set; }

        /// <summary>
        /// 关联的子表
        /// </summary>
        public List<FormTable> FormTables { get; set; } = new List<FormTable>();
    }
}