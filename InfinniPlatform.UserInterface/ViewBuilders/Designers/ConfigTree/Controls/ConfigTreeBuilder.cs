﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

using InfinniPlatform.Sdk.Hosting;
using InfinniPlatform.UserInterface.ViewBuilders.Designers.ConfigTree.Factories;

namespace InfinniPlatform.UserInterface.ViewBuilders.Designers.ConfigTree.Controls
{
    internal static class ConfigTreeBuilder
    {
        private static readonly ConfigElementNodeBuilder ElementNodeBuilder;

        static ConfigTreeBuilder()
        {
            ElementNodeBuilder = new ConfigElementNodeBuilder(HostingConfig.Default.Name, HostingConfig.Default.Port, null, "1");

            ElementNodeBuilder.Register(ConfigContainerNodeFactory.ElementType, new ConfigContainerNodeFactory());
            ElementNodeBuilder.Register(ConfigElementNodeFactory.ElementType, new ConfigElementNodeFactory());

            ElementNodeBuilder.Register(MenuContainerNodeFactory.ElementType, new MenuContainerNodeFactory());
            ElementNodeBuilder.Register(MenuElementNodeFactory.ElementType, new MenuElementNodeFactory());

            ElementNodeBuilder.Register(DocumentContainerNodeFactory.ElementType, new DocumentContainerNodeFactory());
            ElementNodeBuilder.Register(DocumentElementNodeFactory.ElementType, new DocumentElementNodeFactory());

            ElementNodeBuilder.Register(RegisterContainerNodeFactory.ElementType, new RegisterContainerNodeFactory());
            ElementNodeBuilder.Register(RegisterElementNodeFactory.ElementType, new RegisterElementNodeFactory());

            ElementNodeBuilder.Register(ViewContainerNodeFactory.ElementType, new ViewContainerNodeFactory());
            ElementNodeBuilder.Register(ViewElementNodeFactory.ElementType, new ViewElementNodeFactory());

            ElementNodeBuilder.Register(PrintViewContainerNodeFactory.ElementType, new PrintViewContainerNodeFactory());
            ElementNodeBuilder.Register(PrintViewElementNodeFactory.ElementType, new PrintViewElementNodeFactory());

            ElementNodeBuilder.Register(ScenarioContainerNodeFactory.ElementType, new ScenarioContainerNodeFactory());
            ElementNodeBuilder.Register(ScenarioElementNodeFactory.ElementType, new ScenarioElementNodeFactory());

            ElementNodeBuilder.Register(ProcessContainerNodeFactory.ElementType, new ProcessContainerNodeFactory());
            ElementNodeBuilder.Register(ProcessElementNodeFactory.ElementType, new ProcessElementNodeFactory());

            ElementNodeBuilder.Register(ServiceContainerNodeFactory.ElementType, new ServiceContainerNodeFactory());
            ElementNodeBuilder.Register(ServiceElementNodeFactory.ElementType, new ServiceElementNodeFactory());

        }

        public static IEnumerable<ConfigElementNode> Build(IConfigElementEditPanel editPanel)
        {
            var configTree = new ObservableCollection<ConfigElementNode>();

            ElementNodeBuilder.EditPanel = editPanel;
            ElementNodeBuilder.BuildElement(configTree, null, new object(), ConfigContainerNodeFactory.ElementType);

            return configTree;
        }
    }
}