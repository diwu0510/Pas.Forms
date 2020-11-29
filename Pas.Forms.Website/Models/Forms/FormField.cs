namespace Pas.Forms.Website.Models.Forms
{
    public class FormField
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public string Type { get; set; }
        
        /// <summary>
        /// 表单名称
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 表单标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 表单描述
        /// </summary>
        public string Descriptor { get; set; }
    }

    public enum NumberFieldType
    {
        Int,
        Float,
        Money
    }

    public enum NumberFieldDefaultValue
    {
        CurrentYear,
        CurrentMonth,
        CurrentDay,
        CurrentDate,
        CurrentHour,
        CurrentMinute,
        CurrentSecond
    }

    public enum CurrentData
    {
        Now,
        Today,
        Year,
        Month,
        Day,
        Date,
        Hour,
        Minute,
        Second,
        UserId,
        UserName,
        DepartmentId,
        DepartmentName,
        CompanyId,
        CompanyName,
    }
}
