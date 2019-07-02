using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Text.RegularExpressions;

namespace MetalSaleSystem.Common
{
    public static class JsonHelper
    {
        public static string JsonSerializeFormatDate(this object obj)
        {
            IsoDateTimeConverter timeFormat = new IsoDateTimeConverter();
            timeFormat.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, timeFormat);
        }

        /// <summary>
        /// 把json格式的时间\\/Date\((\d+)\+\d+\)\\/转为一般时间格式
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public static string ConvertJsonDateToDateString(Match m)
        {
            string result = string.Empty;
            DateTime dt = new DateTime(1970, 1, 1);
            dt = dt.AddMilliseconds(long.Parse(m.Groups[1].Value));
            dt = dt.ToLocalTime();
            result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            return result;
        }

        /// <summary>
        /// 把json格式的时间\\/Date\((\d+)\+\d+\)\\/转为一般时间格式
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static string ConvertJsonDateToDateString(this string json)
        {
            ////替换Json的Date字符串 
            string regTemp = @"\\/Date\((\d+)\+\d+\)\\/";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertJsonDateToDateString);
            Regex reg = new Regex(regTemp);
            json = reg.Replace(json, matchEvaluator);
            return json;
        }
    }
}
