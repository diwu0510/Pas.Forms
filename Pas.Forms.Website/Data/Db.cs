using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pas.Forms.Website.Data
{
    public class Db
    {
        /// <summary>
        /// ID
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 数据库名称
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 链接字符串
        /// </summary>
        public string ConnectionString { get; set; }
        
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool IsValid { get; set; }
        
        /// <summary>
        /// 数据表
        /// </summary>
        public List<DbTable> Tables { get; set; }
    }
}