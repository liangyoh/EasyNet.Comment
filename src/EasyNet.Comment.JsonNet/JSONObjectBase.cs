using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyNet.Comment.JsonNet
{
    public class JSONObjectBase
    {
        /// <summary>
        /// JSON的
        /// </summary>
        private NewtonsoftJsonSerializer jsonConvert = new NewtonsoftJsonSerializer();
        /// <summary>
        /// 暴露JSON序列化的配置
        /// </summary>
        public JsonSerializerSettings settings { get; set; }
        /// <summary>
        /// 序列化为JSON字符串
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            if (settings != null)
            {
                jsonConvert.Settings = settings;
            }
            return jsonConvert.Serialize(this);
        }
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="modelJson"></param>
        /// <returns></returns>
        public T Deserialize<T>(string modelJson) where T:JSONObjectBase
        {
            return jsonConvert.Deserialize<T>(modelJson);
        }
    }
}
