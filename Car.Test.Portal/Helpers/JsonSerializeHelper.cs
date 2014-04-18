using System;
namespace Car.Test.Portal.Helpers
{
    public static class JsonSerializeHelper
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="obj">要序列化的实体</param>
        /// <returns>序列化后的字符串</returns>
        public static string SerializeToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static Object DeserializeFromJson(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject(json);
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T DeserializeFromJson<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
    }
}