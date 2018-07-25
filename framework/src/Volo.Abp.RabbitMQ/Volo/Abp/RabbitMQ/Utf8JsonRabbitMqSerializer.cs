﻿using System;
using System.Text;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Json;

namespace Volo.Abp.RabbitMQ
{
    public class Utf8JsonRabbitMqSerializer : IRabbitMqSerializer, ITransientDependency
    {
        private readonly IJsonSerializer _jsonSerializer;

        public Utf8JsonRabbitMqSerializer(IJsonSerializer jsonSerializer)
        {
            _jsonSerializer = jsonSerializer;
        }

        public byte[] Serialize(object obj)
        {
            return Encoding.UTF8.GetBytes(_jsonSerializer.Serialize(obj));
        }

        public object Deserialize(byte[] value, Type type)
        {
            return _jsonSerializer.Deserialize(type, Encoding.UTF8.GetString(value));
        }

        public T Deserialize<T>(string value)
        {
            return _jsonSerializer.Deserialize<T>(value);
        }
    }
}