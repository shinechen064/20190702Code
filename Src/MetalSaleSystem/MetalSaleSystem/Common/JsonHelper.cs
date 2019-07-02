using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MetalSaleSystem.Common
{
    /// <summary>
    /// Json帮助类
    /// </summary>
    public class JsonHelper
    {
        static JsonHelper()
        {
            s_jsonSettings.Formatting = Formatting.Indented;
            s_jsonSettings.TypeNameHandling = TypeNameHandling.None;
        }
        /// <summary>
        /// 将对象序列化为JSON格式
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>json字符串</returns>
        public static string SerializeObject(object argObject)
        {
            Debug.Assert(null != argObject);
            return JsonConvert.SerializeObject(argObject, s_jsonSettings);
        }

        /// <summary>
        /// 解析JSON字符串生成对象实体
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json字符串(eg.{"ID":"112","Name":"石子儿"})</param>
        /// <returns>对象实体</returns>
        public static T DeserializeJsonToObject<T>(string argJson) where T : class
        {
            //JsonSerializer serializer = new JsonSerializer();
            //StringReader sr = new StringReader(json);
            //object o = serializer.Deserialize(new JsonTextReader(sr), typeof(T));
            //T t = o as T;
            //return t;
            Debug.Assert(!string.IsNullOrWhiteSpace(argJson));
            return JsonConvert.DeserializeObject<T>(argJson);
        }

        /// <summary>
        /// 解析JSON数组生成对象实体集合
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json数组字符串(eg.[{"ID":"112","Name":"石子儿"}])</param>
        /// <returns>对象实体集合</returns>
        public static List<T> DeserializeJsonToList<T>(string argJson) where T : class
        {
            //JsonSerializer serializer = new JsonSerializer();
            //StringReader sr = new StringReader(json);
            //object o = serializer.Deserialize(new JsonTextReader(sr), typeof(List<T>));
            //List<T> list = o as List<T>;
            //return list;
            Debug.Assert(!string.IsNullOrWhiteSpace(argJson));
            object o = JsonConvert.DeserializeObject<T>(argJson);
            return (o as List<T>);
        }

        /// <summary>
        /// 反序列化JSON到给定的匿名对象.
        /// </summary>
        /// <typeparam name="T">匿名对象类型</typeparam>
        /// <param name="json">json字符串</param>
        /// <param name="anonymousTypeObject">匿名对象</param>
        /// <returns>匿名对象</returns>
        public static T DeserializeAnonymousType<T>(string argJson, T anonymousTypeObject)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(argJson) && null != anonymousTypeObject);
            return JsonConvert.DeserializeAnonymousType<T>(argJson, anonymousTypeObject);
        }

        public static JsonSerializerSettings s_jsonSettings = new JsonSerializerSettings();
    }
}
