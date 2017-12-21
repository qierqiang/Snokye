using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Security.Cryptography;
using System.Text;

namespace Snokye.Utility
{
    public static class CodeHelper
    {
        //application
        public static string GetApplicationTitle()
        {
            object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }

        //string
        public static string FormatWith(this string source, params object[] args) => string.Format(source, args);

        public static string LowerFirstLetter(this string source) => source.Substring(0, 1).ToLower() + source.Substring(1);

        public static bool IsNullOrEmpty(this string source) => string.IsNullOrEmpty(source);

        public static bool IsNullOrBlank(this string source) => source.IsNullOrWhiteSpace();

        public static bool IsNullOrWhiteSpace(this string source) => string.IsNullOrEmpty(source) || source.Trim().Length == 0;

        public static string GetMD5(this string source)
        {
            source = source == null ? string.Empty : source;
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(source));// Encoding.UTF8.GetBytes(source));
            return BitConverter.ToString(result).Replace("-", "").ToUpper();//Encoding.UTF8.GetString(result).ToUpper();
        }

        public static string Encrypt(this string source, string encryptKey)
        {
            DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   

            byte[] key = new byte[8], iv = new byte[8]; //参数长度8
            //用0填充
            for (int i = 0; i < 8; i++)
            {
                key[i] = 0;
                iv[i] = 0;
            }
            //take 8 
            for (int i = 0; i < 8 && i < encryptKey.Length; i++)
            {
                key[i] = Convert.ToByte(encryptKey[i]);
            }
            //reserve take 8
            char[] tmp = encryptKey.ToCharArray().Reverse().ToArray();
            for (int i = 0; i < 8 && i < tmp.Length; i++)
            {
                iv[i] = Convert.ToByte(tmp[i]);
            }

            byte[] data = Encoding.Unicode.GetBytes(source);//定义字节数组，用来存储要加密的字符串  
            using (MemoryStream mStream = new MemoryStream()) //实例化内存流对象 
            using (CryptoStream cStream = new CryptoStream(mStream, descsp.CreateEncryptor(key, iv), CryptoStreamMode.Write)) ////使用内存流实例化加密流对象 
            {
                cStream.Write(data, 0, data.Length);  //向加密流中写入数据    
                cStream.FlushFinalBlock();              //释放加密流      
                return Convert.ToBase64String(mStream.ToArray());//返回加密后的字符串  
            }
        }

        public static string Decrypt(this string source, string encryptKey)
        {
            using (DESCryptoServiceProvider descsp = new DESCryptoServiceProvider())   //实例化加/解密类对象    
            {
                byte[] key = new byte[8], iv = new byte[8]; //参数1，长度24，参数2长度8
                                                            //用0填充
                for (int i = 0; i < 8; i++)
                {
                    key[i] = 0;
                    iv[i] = 0;
                }
                //take24
                for (int i = 0; i < 8 && i < encryptKey.Length; i++)
                {
                    key[i] = Convert.ToByte(encryptKey[i]);
                }
                //reserve take 8
                char[] tmp = encryptKey.ToCharArray().Reverse().ToArray();
                for (int i = 0; i < 8 && i < tmp.Length; i++)
                {
                    iv[i] = Convert.ToByte(tmp[i]);
                }

                byte[] data = Convert.FromBase64String(source);//定义字节数组，用来存储要解密的字符串  

                using (MemoryStream MStream = new MemoryStream()) //实例化内存流对象      
                using (CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, iv), CryptoStreamMode.Write))//使用内存流实例化解密流对象 
                {
                    CStream.Write(data, 0, data.Length);      //向解密流中写入数据  
                    CStream.FlushFinalBlock();               //释放解密流  
                    return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
                }
            }
        }

        public static string JsonSerialize(this object source) => JsonConvert.SerializeObject(source);

        public static string ToJson(this object source) => JsonConvert.SerializeObject(source);

        public static string TryToString(this object source, string valueWhenNull) => source.IsNullOrDbNull() ? valueWhenNull : source.ToString();

        //<T>
        public static bool In<T>(this T source, params T[] collection) => collection.Contains(source);

        public static T JsonDeserialize<T>(this string source) => JsonConvert.DeserializeObject<T>(source);

        public static IEnumerable<T> GetAttributes<T>(this MemberInfo member, bool inherit = true) => member.GetCustomAttributes(typeof(T), inherit).OfType<T>();

        public static IEnumerable<T> GetAttributes<T>(this Assembly assembly, bool inherit = true) => assembly.GetCustomAttributes(typeof(T), inherit).OfType<T>();

        //object
        public static bool IsNullOrDbNull(this object source) => source == null || source == DBNull.Value;

        public static object JsonDeserialize(this string source) => JsonConvert.DeserializeObject(source);

        public static bool In(this object source, params object[] collection) => collection.Contains(source);

        public static Type GetRealType(this object source) => source is RealProxy rp ? rp.GetProxiedType() : source.GetType();

        public static object GetPropertyValue(this object source, string propertyName) => source.GetRealType().GetProperty(propertyName).GetValue(source, null);

        //type
        public static bool IsNumericType(this Type source)
        {
            switch (Type.GetTypeCode(source))
            {
                case TypeCode.SByte:
                case TypeCode.Byte:
                case TypeCode.Int16:
                case TypeCode.UInt16:
                case TypeCode.Int32:
                case TypeCode.UInt32:
                case TypeCode.Int64:
                case TypeCode.UInt64:
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
                default:
                    return false;
            }
        }

        public static bool Is(this Type source, Type parentType) => source == parentType || source.IsSubclassOf(parentType) || (parentType.IsInterface && parentType.IsAssignableFrom(source));

        public static T GetAttribute<T>(this Type source) => source.GetCustomAttributes(typeof(T), true).OfType<T>().FirstOrDefault();

        //propertyInfo
        public static T GetAttribute<T>(this PropertyInfo property) => property.GetCustomAttributes(typeof(T), true).OfType<T>().FirstOrDefault();
    }
}
