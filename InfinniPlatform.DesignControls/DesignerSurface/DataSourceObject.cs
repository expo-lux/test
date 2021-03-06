﻿using InfinniPlatform.DesignControls.Layout;
using InfinniPlatform.Sdk.Dynamic;

namespace InfinniPlatform.DesignControls.DesignerSurface
{
    public sealed class DataSourceObject : ILayoutProvider
    {
        public string DataSourceName
        {
            get { return DataSource != null ? ObjectHelper.GetProperty(DataSource, "Name") : string.Empty; }
        }

        public dynamic DataSource { get; set; }

        public string DataSourceString
        {
            get { return DataSource != null ? DataSource.ToString() : string.Empty; }
        }

        public dynamic GetLayout()
        {
            var layoutProvider = DataSource as ILayoutProvider;
            if (layoutProvider != null)
            {
                return layoutProvider.GetLayout();
            }
            return new DynamicWrapper();
        }

        public void SetLayout(dynamic value)
        {
            //no layout
        }

        public string GetPropertyName()
        {
            var layoutProvider = DataSource as ILayoutProvider;
            if (layoutProvider != null)
            {
                return layoutProvider.GetPropertyName();
            }
            return string.Empty;
        }
    }
}