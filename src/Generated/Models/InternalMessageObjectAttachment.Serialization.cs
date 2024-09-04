// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.Assistants
{
    internal partial class InternalMessageObjectAttachment : IJsonModel<InternalMessageObjectAttachment>
    {
        void IJsonModel<InternalMessageObjectAttachment>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageObjectAttachment>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageObjectAttachment)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("file_id") != true && Optional.IsDefined(FileId))
            {
                writer.WritePropertyName("file_id"u8);
                writer.WriteStringValue(FileId);
            }
            if (SerializedAdditionalRawData?.ContainsKey("tools") != true && Optional.IsCollectionDefined(Tools))
            {
                writer.WritePropertyName("tools"u8);
                writer.WriteStartArray();
                foreach (var item in Tools)
                {
                    if (item == null)
                    {
                        writer.WriteNullValue();
                        continue;
                    }
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item);
#else
                    using (JsonDocument document = JsonDocument.Parse(item))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
                writer.WriteEndArray();
            }
            if (SerializedAdditionalRawData != null)
            {
                foreach (var item in SerializedAdditionalRawData)
                {
                    if (ModelSerializationExtensions.IsSentinelValue(item.Value))
                    {
                        continue;
                    }
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
            writer.WriteEndObject();
        }

        InternalMessageObjectAttachment IJsonModel<InternalMessageObjectAttachment>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageObjectAttachment>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalMessageObjectAttachment)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalMessageObjectAttachment(document.RootElement, options);
        }

        internal static InternalMessageObjectAttachment DeserializeInternalMessageObjectAttachment(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string fileId = default;
            IReadOnlyList<BinaryData> tools = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("file_id"u8))
                {
                    fileId = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tools"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<BinaryData> array = new List<BinaryData>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        if (item.ValueKind == JsonValueKind.Null)
                        {
                            array.Add(null);
                        }
                        else
                        {
                            array.Add(BinaryData.FromString(item.GetRawText()));
                        }
                    }
                    tools = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalMessageObjectAttachment(fileId, tools ?? new ChangeTrackingList<BinaryData>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalMessageObjectAttachment>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageObjectAttachment>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalMessageObjectAttachment)} does not support writing '{options.Format}' format.");
            }
        }

        InternalMessageObjectAttachment IPersistableModel<InternalMessageObjectAttachment>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalMessageObjectAttachment>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalMessageObjectAttachment(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalMessageObjectAttachment)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalMessageObjectAttachment>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalMessageObjectAttachment FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalMessageObjectAttachment(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
