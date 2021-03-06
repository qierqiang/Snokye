﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Snokye.Utility;

namespace Snokye.VVM
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class ValidateAttribute : Attribute
    {
        public int Length { get; private set; }

        public bool Required { get; private set; }

        public double? Max { get; private set; }

        public double? Min { get; private set; }

        public string RegexPattern { get; private set; }

        public ValidateAttribute(bool required = true, int length = 50, string max = null, string min = null, string regexPattern = null)
        {
            Length = length;
            Required = required;
            if (double.TryParse(max, out double d)) Max = d;
            if (double.TryParse(min, out d)) Min = d;
            RegexPattern = regexPattern;
        }

        public static bool ValidateObject(object obj, out string propertyName, out string discription)
        {
            propertyName = null; discription = null;

            var query = from p in obj.GetType().GetProperties()
                        from a in p.GetCustomAttributes(typeof(ValidateAttribute), true).OfType<ValidateAttribute>()
                        select new
                        {
                            Property = p,
                            Attribute = a,
                            Value = p.GetValue(obj, null)
                        };

            foreach (var item in query)
            {
                //reqired
                if (item.Attribute.Required)
                {
                    if (item.Value.IsNullOrDbNull() || item.Value.ToString().IsNullOrWhiteSpace())
                    {
                        propertyName = item.Property.Name;
                        discription = "不能为空！";
                        return false;
                    }
                    //if (item.Value is IEnumerable e)
                    //{
                    //    IEnumerator etor = e.GetEnumerator();

                    //    if (!etor.MoveNext())
                    //    {
                    //        propertyName = item.Property.Name;
                    //        discription = "不能为空集合！";
                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        do
                    //        {
                    //            if (etor.Current.IsNullOrDbNull())
                    //            {
                    //                propertyName = item.Property.Name;
                    //                discription = "不能为空集合！";
                    //                return false;
                    //            }
                    //        }
                    //        while (etor.MoveNext());
                    //    }
                    //}
                }
                //length
                if (item.Attribute.Length > 0)
                {
                    if (!item.Value.IsNullOrDbNull() && item.Value.ToString().Length > item.Attribute.Length)
                    {
                        propertyName = item.Property.Name;
                        discription = "长度超出上限！";
                        return false;
                    }
                }
                //min
                if (item.Attribute.Min.HasValue)
                {
                    if (Convert.ToDouble(item.Value) < item.Attribute.Min.Value)
                    {
                        propertyName = item.Property.Name;
                        discription = "太小！";
                        return false;
                    }
                }
                //max
                if (item.Attribute.Max.HasValue)
                {
                    if (Convert.ToDouble(item.Value) > item.Attribute.Max.Value)
                    {
                        propertyName = item.Property.Name;
                        discription = "太大！";
                        return false;
                    }
                }
                if (!item.Attribute.RegexPattern.IsNullOrWhiteSpace() && !item.Value.IsNullOrDbNull())
                {
                    if (!Regex.IsMatch(item.Value.ToString(), item.Attribute.RegexPattern))
                    {
                        propertyName = item.Property.Name;
                        discription = "不符合规则！";
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
