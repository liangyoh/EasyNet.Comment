using System;
using System.Collections.Generic;
using System.Reflection;
using EasyNet.Comment.Serializing;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EasyNet.Comment.JsonNet
{
    /// <summary>
    /// Json.Net implementationof IJsonSerializer.
    /// <para>日期：对于日期格式字符串的序列化，需要在字段增加属性 [JsonConverter(typeof(DateTimeConverter))] </para>
    /// <para>序列化名称：对于需要自定义序列化名称，需要在字段增加属性 [JsonProperty(PropertyName = "CName")] </para>
    /// <para>属性是否序列化：在字段增加属性 [JsonIgnore] </para>
    /// <para>枚举值的自定义格式化问题：对于需要格式化成枚举对应的字符，需要在字段增加属性 [JsonConverter(typeof(StringEnumConverter))] </para>
    /// <para>全局设置是否忽略空值：设置Settings的NullValueHandling</para>
    /// </summary>
    public class NewtonsoftJsonSerializer : IJsonSerializer
    {
        /// <summary>
        /// 可配置通用的序列号和反序列号的规则
        /// <para>DefaultValueHandling：是否忽略默认值属性</para>
        /// <para>NullValueHandling：是否忽略空值</para>
        /// <para>Converters：转换函数</para>
        /// </summary>
        public JsonSerializerSettings Settings { get; set; }

        public NewtonsoftJsonSerializer()
        {
            Settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Include,
                NullValueHandling = NullValueHandling.Include,
                Converters = new List<JsonConverter> { new IsoDateTimeConverter() },
                ContractResolver = new CustomContractResolver(),
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };
        }

        /// <summary>Serialize an object to json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string Serialize(object obj)
        {
            return obj == null ? null : JsonConvert.SerializeObject(obj, Settings);
        }
        /// <summary>Deserialize a json string to an object.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public object Deserialize(string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type, Settings);
        }
        /// <summary>Deserialize a json string to a strong type object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Deserialize<T>(string value) where T : class
        {
            return JsonConvert.DeserializeObject<T>(JObject.Parse(value).ToString(), Settings);
        }

        class CustomContractResolver : DefaultContractResolver
        {
            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var jsonProperty = base.CreateProperty(member, memberSerialization);
                if (jsonProperty.Writable) return jsonProperty;
                var property = member as PropertyInfo;
                if (property == null) return jsonProperty;
                var hasPrivateSetter = property.GetSetMethod(true) != null;
                jsonProperty.Writable = hasPrivateSetter;

                return jsonProperty;
            }
        }
    }

    public class DateTimeConverter : DateTimeConverterBase
    {
        private DateTimeConverter() {}


        private static string _datetimeFormatter = "yyyy-MM-dd hh:mm:ss";
        public static string DateTimeFormatter
        {
            get
            {
                return _datetimeFormatter;
            }
            set
            {
                _datetimeFormatter = value;
            }
        }

        private static IsoDateTimeConverter dtConverter = new IsoDateTimeConverter { DateTimeFormat = DateTimeFormatter };
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return dtConverter.ReadJson(reader, objectType, existingValue, serializer);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            dtConverter.WriteJson(writer, value, serializer);
        }
    }
}

