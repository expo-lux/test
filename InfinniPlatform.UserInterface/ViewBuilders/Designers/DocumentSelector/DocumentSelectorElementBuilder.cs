﻿using System.Collections;
using InfinniPlatform.UserInterface.Services.Metadata;
using InfinniPlatform.UserInterface.ViewBuilders.Data;
using InfinniPlatform.UserInterface.ViewBuilders.Elements;
using InfinniPlatform.UserInterface.ViewBuilders.Views;

namespace InfinniPlatform.UserInterface.ViewBuilders.Designers.DocumentSelector
{
    internal sealed class DocumentSelectorElementBuilder : IObjectBuilder
    {
        public object Build(ObjectBuilderContext context, View parent, dynamic metadata)
        {
            var element = new DocumentSelectorElement(parent);
            element.ApplyElementMeatadata((object) metadata);
            element.SetDocumentsFunc(GetDocuments);

            // Привязка к источнику данных

            IElementDataBinding configIdBinding = context.Build(parent, metadata.ConfigId);

            if (configIdBinding != null)
            {
                configIdBinding.OnPropertyValueChanged += (c, a) => element.SetConfigId(a.Value);
            }

            IElementDataBinding valueBinding = context.Build(parent, metadata.Value);

            if (valueBinding != null)
            {
                valueBinding.OnPropertyValueChanged += (c, a) => element.SetValue(a.Value);
                element.OnValueChanged += (c, a) => valueBinding.SetPropertyValue(a.Value);
            }

            return element;
        }

        private static IEnumerable GetDocuments(string version, string configId)
        {
            if (!string.IsNullOrWhiteSpace(configId))
            {
                var documentService = new DocumentMetadataService(configId);
                return documentService.GetItems();
            }

            return null;
        }
    }
}