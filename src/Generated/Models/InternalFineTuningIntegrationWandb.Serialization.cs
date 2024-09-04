// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;

namespace OpenAI.FineTuning
{
    internal partial class InternalFineTuningIntegrationWandb : IJsonModel<InternalFineTuningIntegrationWandb>
    {
        void IJsonModel<InternalFineTuningIntegrationWandb>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningIntegrationWandb)} does not support writing '{format}' format.");
            }

            writer.WriteStartObject();
            if (SerializedAdditionalRawData?.ContainsKey("project") != true)
            {
                writer.WritePropertyName("project"u8);
                writer.WriteStringValue(Project);
            }
            if (SerializedAdditionalRawData?.ContainsKey("name") != true && Optional.IsDefined(Name))
            {
                if (Name != null)
                {
                    writer.WritePropertyName("name"u8);
                    writer.WriteStringValue(Name);
                }
                else
                {
                    writer.WriteNull("name");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("entity") != true && Optional.IsDefined(Entity))
            {
                if (Entity != null)
                {
                    writer.WritePropertyName("entity"u8);
                    writer.WriteStringValue(Entity);
                }
                else
                {
                    writer.WriteNull("entity");
                }
            }
            if (SerializedAdditionalRawData?.ContainsKey("tags") != true && Optional.IsCollectionDefined(Tags))
            {
                writer.WritePropertyName("tags"u8);
                writer.WriteStartArray();
                foreach (var item in Tags)
                {
                    writer.WriteStringValue(item);
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

        InternalFineTuningIntegrationWandb IJsonModel<InternalFineTuningIntegrationWandb>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(InternalFineTuningIntegrationWandb)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeInternalFineTuningIntegrationWandb(document.RootElement, options);
        }

        internal static InternalFineTuningIntegrationWandb DeserializeInternalFineTuningIntegrationWandb(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            string project = default;
            string name = default;
            string entity = default;
            IReadOnlyList<string> tags = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("project"u8))
                {
                    project = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("name"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        name = null;
                        continue;
                    }
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("entity"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        entity = null;
                        continue;
                    }
                    entity = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tags"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    tags = array;
                    continue;
                }
                if (true)
                {
                    rawDataDictionary ??= new Dictionary<string, BinaryData>();
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new InternalFineTuningIntegrationWandb(project, name, entity, tags ?? new ChangeTrackingList<string>(), serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<InternalFineTuningIntegrationWandb>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningIntegrationWandb)} does not support writing '{options.Format}' format.");
            }
        }

        InternalFineTuningIntegrationWandb IPersistableModel<InternalFineTuningIntegrationWandb>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<InternalFineTuningIntegrationWandb>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeInternalFineTuningIntegrationWandb(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(InternalFineTuningIntegrationWandb)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<InternalFineTuningIntegrationWandb>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal static InternalFineTuningIntegrationWandb FromResponse(PipelineResponse response)
        {
            using var document = JsonDocument.Parse(response.Content);
            return DeserializeInternalFineTuningIntegrationWandb(document.RootElement);
        }

        internal virtual BinaryContent ToBinaryContent()
        {
            return BinaryContent.Create(this, ModelSerializationExtensions.WireOptions);
        }
    }
}
