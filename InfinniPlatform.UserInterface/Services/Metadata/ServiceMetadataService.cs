﻿using System;
using System.Collections.Generic;
using System.IO;

using InfinniPlatform.Core.Metadata;
using InfinniPlatform.Sdk.Dynamic;
using InfinniPlatform.Sdk.Serialization;

namespace InfinniPlatform.UserInterface.Services.Metadata
{
    /// <summary>
    /// Сервис для работы с метаданными бизнес-сервисов.
    /// </summary>
    internal sealed class ServiceMetadataService : BaseMetadataService
    {
        public ServiceMetadataService(string configId, string documentId)
        {
            ConfigId = configId;
            _documentId = documentId;
        }

        private readonly string _documentId;

        public string ConfigId { get; }

        public override object CreateItem()
        {
            dynamic service = new DynamicWrapper();

            service.Id = Guid.NewGuid().ToString();
            service.Name = string.Empty;
            service.Caption = string.Empty;
            service.Description = string.Empty;

            return service;
        }

        public override void ReplaceItem(dynamic item)
        {
            var serializedItem = JsonObjectSerializer.Formated.Serialize(item);

            File.WriteAllBytes(PackageMetadataLoader.GetServicePath(ConfigId, _documentId, item.Name), serializedItem);

            PackageMetadataLoader.UpdateCache();
        }

        public override void DeleteItem(string itemId)
        {
            dynamic service = PackageMetadataLoader.GetService(ConfigId, _documentId, itemId);

            File.Delete(service.FilePath);

            PackageMetadataLoader.UpdateCache();
        }

        public override object GetItem(string itemId)
        {
            return PackageMetadataLoader.GetService(ConfigId, _documentId, itemId);
        }

        public override IEnumerable<object> GetItems()
        {
            return PackageMetadataLoader.GetServices(ConfigId, _documentId);
        }
    }
}