namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class CurrentDataDescriptor : BaseFormFieldDescriptor
    {
        /// <summary>
        /// 表单类型
        /// </summary>
        public override string Type => "CurrentData";
        
        public CurrentData Value { get; set; }
        
        public override bool Validate(out string err)
        {
            if (!base.Validate(out err))
            {
                return false;
            }

            return true;
        }
    }
}