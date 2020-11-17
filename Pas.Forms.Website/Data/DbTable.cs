using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pas.Forms.Website.Data
{
    public class DbTable
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 数据表名称
        /// </summary>
        [Required]
        public string Title { get; set; }
        
        /// <summary>
        /// 表名，数据库中的名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        
        /// <summary>
        /// 数据库ID
        /// </summary>
        [Required]
        public int DbId { get; set; }
        
        /// <summary>
        /// 数据库
        /// </summary>
        public Db Db { get; set; }
        
        /// <summary>
        /// 数据表字段
        /// </summary>
        public List<DbField> Fields { get; set; } = new List<DbField>();
    }
}