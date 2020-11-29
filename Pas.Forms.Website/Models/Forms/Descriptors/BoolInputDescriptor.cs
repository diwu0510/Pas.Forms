namespace Pas.Forms.Website.Models.Forms.Descriptors
{
    public class BoolInputDescriptor : BaseFormFieldDescriptor
    {
        public override string Type => "Bool";
        
        public bool Value { get; set; }

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