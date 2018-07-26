using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Mzl.Common.EnumHelper
{
    /// <summary>
    /// 枚举转换类
    /// </summary>
    public static class EnumConvert
    {
        /// <summary>
        /// 获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        public static string ToDescription(this Enum obj)
        {
            return ToDescription(obj, false);
        }

        /// <summary>
        /// 获取枚举变量值的 Description 属性
        /// </summary>
        /// <param name="obj">枚举变量</param>
        /// <param name="isTop">是否改变为返回该类、枚举类型的头 Description 属性，而不是当前的属性或枚举变量值的 Description 属性</param>
        /// <returns>如果包含 Description 属性，则返回 Description 属性的值，否则返回枚举变量值的名称</returns>
        public static string ToDescription(this Enum obj, bool isTop)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            try
            {
                Type _enumType = obj.GetType();//获取对象的枚举类型
                if (!_enumType.IsEnum)
                {
                    return string.Empty;
                }
                DescriptionAttribute dna = null;
                if (isTop)
                {//获取枚举类型头Description
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(_enumType, typeof(DescriptionAttribute));
                }
                else
                {
                    FieldInfo fi = _enumType.GetField(Enum.GetName(_enumType, obj));//获取枚举字段
                    dna = (DescriptionAttribute)Attribute.GetCustomAttribute(fi, typeof(DescriptionAttribute));//利用反射获取字段的描述属性
                }
                if (dna != null && string.IsNullOrEmpty(dna.Description) == false)
                {
                    return dna.Description;
                }
            }
            catch
            {
            }
            return obj.ToString();
        }
        /// <summary>
        /// 根据enum的name获取description
        /// </summary>
        /// <param name="enumItemName">enum名字</param>
        /// <returns></returns>
        public static string NameToDescription<T>(this string enumItemName)
        {
            Type _enumType = typeof(T);//获取对象的枚举类型
            try
            {
                if (!_enumType.IsEnum)
                {
                    return string.Empty;
                }
                FieldInfo fi = _enumType.GetField(enumItemName.ToString());//获取枚举字段
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);//获取字段的所有描述属性

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            catch
            {
            }
            return enumItemName.ToString();
        }
        /// <summary>
        /// 根据enum的value获取description
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumItemValue">enum值</param>
        /// <returns></returns>
        public static string ValueToDescription<T>(this int enumItemValue)
        {
            Type _enumType = typeof(T);//获取对象的枚举类型
            try
            {
                if (!_enumType.IsEnum)
                {
                    return string.Empty;
                }
                string enumName = Enum.GetName(_enumType, enumItemValue);
                FieldInfo fi = _enumType.GetField(enumName);//获取枚举字段
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);//获取字段的所有描述属性

                if (attributes != null && attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            catch
            {
                return string.Empty;
            }
            return enumItemValue.ToString();
        }
        /// <summary>
        /// 根据enum的value获取枚举对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumItemValue">enum值</param>
        /// <returns></returns>
        public static T ValueToEnum<T>(this int enumItemValue)
        {
            Type _enumType = typeof(T);//获取对象的枚举类型
            try
            {
                if (!_enumType.IsEnum)
                {
                    return default(T);
                }
                return (T)Enum.Parse(_enumType, enumItemValue.ToString(), true);
            }
            catch
            {
            }
            return default(T);
        }
        /// <summary>
        /// 根据Description获取枚举对象
        /// </summary>
        /// <param name="desc">Description</param>
        /// <returns>枚举对象</returns>
        public static T DescriptionToEnum<T>(this string desc)
        {
            if (string.IsNullOrEmpty(desc))
            {
                return default(T);
            }
            Type _enumType = typeof(T);//获取对象的枚举类型
            try
            {
                if (!_enumType.IsEnum)
                {
                    return default(T);
                }
                string[] strs = Enum.GetNames(_enumType);
                foreach (string str in strs)
                {//遍历枚举类型所有值进行匹配
                    FieldInfo fi = _enumType.GetField(str);//获取枚举字段
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);//获取字段的所有描述属性

                    if (attributes != null && attributes.Length > 0 && attributes[0].Description == desc)
                    {
                        return (T)Enum.Parse(_enumType, str, true);
                    }
                }
            }
            catch
            { }
            return default(T);
        }
        /// <summary>
        /// 根据Name获取枚举对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">Name</param>
        /// <returns>枚举对象</returns>
        public static T NameToEnum<T>(this string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return default(T);
            }
            Type _enumType = typeof(T);//获取对象的枚举类型
            try
            {
                if (!_enumType.IsEnum)
                {
                    return default(T);
                }
                return (T)Enum.Parse(_enumType, name, true);
            }
            catch
            { }
            return default(T);
        }
        /// <summary>
        /// 获取枚举的值和描述信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static SortedList<int, string> QueryEnum<T>()
        {
            SortedList<int, string> list = new SortedList<int, string>();
            List<string> nameList = Enum.GetNames(typeof(T)).ToList();
            foreach (string name in nameList)
            {
                if (name.ToUpper() == "NULL")
                {
                    continue;
                }
                list.Add(Convert.ToInt32(name.NameToEnum<T>()), name.NameToDescription<T>());
            }
            return list;
        }

        public static SortedList<string, string> QueryEnumStr<T>()
        {
            SortedList<string, string> list = new SortedList<string, string>();
            List<string> nameList = Enum.GetNames(typeof(T)).ToList();
            foreach (string name in nameList)
            {
                if (name.ToUpper() == "NULL")
                {
                    continue;
                }
                list.Add(name, name.NameToDescription<T>());
            }
            return list;
        }

    }
}
