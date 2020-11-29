using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Pas.Forms.Website.Models.Forms.Descriptors;
using System.Reflection;

namespace Pas.Forms.Website.Models.Forms
{
    public class FormFieldFactory
    {
        #region 表单Descriptor列表有效性验证

        /// <summary>
        /// 表单配置项验证
        /// </summary>
        /// <param name="fields"></param>
        /// <param name="errors"></param>
        /// <returns></returns>
        public bool Validate(List<FormField> fields, out Dictionary<string, string> errors)
        {
            var result = true;
            errors = new Dictionary<string, string>();

            var idx = 0;
            foreach (var field in fields)
            {
                idx++;
                if (string.IsNullOrWhiteSpace(field.Title) ||
                    string.IsNullOrWhiteSpace(field.Name) ||
                    string.IsNullOrWhiteSpace(field.Type))
                {
                    result = false;
                    errors.Add($"第{idx}个表单", "表单定义无效，必须包含标题|名称|类型|定义的JSON字符串");
                    continue;
                }
                
                if (field.Type == "Input")
                {
                    result = InternalValidate<TextInputField>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Textarea")
                {
                    result = InternalValidate<TextareaDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Number")
                {
                    result = InternalValidate<NumberInputDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Date")
                {
                    result = InternalValidate<DateInputDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "DateTime")
                {
                    result = InternalValidate<DateTimeInputDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Select")
                {
                    result = InternalValidate<SelectDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Checkbox")
                {
                    result = InternalValidate<CheckboxDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "Bool")
                {
                    result = InternalValidate<BoolInputDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "DynamicSelect")
                {
                    result = InternalValidate<DynamicSelectDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "DynamicCheckbox")
                {
                    result = InternalValidate<DynamicCheckBoxDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "File")
                {
                    result = InternalValidate<FileInputDescriptor>(field.Title, field.Descriptor, errors);
                }
                else if (field.Type == "CurrentData")
                {
                    result = InternalValidate<CurrentDataDescriptor>(field.Title, field.Descriptor, errors);
                }
                else
                {
                    errors.Add(field.Title, "不受支持的组件");
                    result = false;
                }
            }

            return result;
        }

        /// <summary>
        /// 表单验证，
        /// 1. 将JSON转为对应的表单Descriptor对象
        /// 2. 调用Descriptor的验证方法，若失败，把错误消息写入字典
        /// </summary>
        /// <param name="title"></param>
        /// <param name="json"></param>
        /// <param name="errors"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private bool InternalValidate<T>(string title, string json, Dictionary<string, string> errors) 
            where T : BaseFormFieldDescriptor
        {
            try
            {
                var obj = JsonConvert.DeserializeObject<T>(json);
                return InternalValidate(title, obj, errors);
            }
            catch (Exception e)
            {
                errors.Add(title, e.Message);
                return false;
            }
        }

        /// <summary>
        /// 表单配置验证，
        /// 1. 调用对应表单Descriptor的验证方法
        /// 2. 若验证失败，将失败信息写入验证失败信息字典
        /// </summary>
        /// <param name="title">表单标题</param>
        /// <param name="descriptor">表单描述对象</param>
        /// <param name="errors">失败消息字典</param>
        /// <returns></returns>
        private bool InternalValidate(string title, BaseFormFieldDescriptor descriptor, Dictionary<string, string> errors)
        {
            if (!descriptor.Validate(out var err))
            {
                errors.Add(title, err);
                return false;
            }

            return true;
        }

        #endregion

        public static string GetJson()
        {
            var assembly = typeof(BaseFormFieldDescriptor).Assembly;
            var types = assembly.GetTypes();
            var subs = types.Where(x => typeof(BaseFormFieldDescriptor).IsAssignableFrom(x.BaseType))
                .ToList();
            var result = new List<object>();
            foreach (var type in subs)
            {
                var obj = Activator.CreateInstance(type);
                result.Add(obj);
            }

            return JsonConvert.SerializeObject(result);
        }
        
        public static List<object> GetFormFieldDescriptors()
        {
            var assembly = typeof(BaseFormFieldDescriptor).Assembly;
            var types = assembly.GetTypes();
            var subs = types.Where(x => typeof(BaseFormFieldDescriptor).IsAssignableFrom(x.BaseType))
                .ToList();
            var result = new List<object>();
            foreach (var type in subs)
            {
                var obj = Activator.CreateInstance(type);
                result.Add(obj);
            }

            return result;
        }
    }
}