namespace Pas.Forms.Website.Models.Forms.Descriptors
{
  public class TextInputField : BaseFormFieldDescriptor
  {
    /// <summary>
    /// 表单类型
    /// </summary>
    public override string Type => "Input";
    
    /// <summary>
    /// 值
    /// /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// 占位符
    /// </summary>
    public string Placeholder { get; set; }

    /// <summary>
    /// 默认值
    /// </summary>
    public string DefaultValue { get; set; }

    /// <summary>
    /// 最大长度
    /// </summary>
    public int Maxlength { get; set; }

    /// <summary>
    /// 最小长度
    /// </summary>
    public int Minlength { get; set; }

    /// <summary>
    /// 验证规则，正则表达式
    /// </summary>
    public string Rule { get; set; }

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