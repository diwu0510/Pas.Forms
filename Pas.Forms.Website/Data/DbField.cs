using System.ComponentModel.DataAnnotations.Schema;

namespace Pas.Forms.Website.Data
{
    public class DbField
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
        /// 字段标题
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// 字段名
        /// </summary>
        public string Field { get; set; }
        
        /// <summary>
        /// 数据类型
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// 创建时忽略
        /// </summary>
        public bool InsertIgnore { get; set; }
        
        /// <summary>
        /// 更新时忽略
        /// </summary>
        public bool UpdateIgnore { get; set; }
        
        /// <summary>
        /// 是不是外键
        /// </summary>
        public bool IsForeignKey { get; set; }
        
        /// <summary>
        /// 外键表
        /// </summary>
        public string ForeignTable { get; set; }
        
        /// <summary>
        /// 链接外键表时匹配的字段名
        /// </summary>
        public string ForeignField { get; set; }
    }
}