﻿using System;
using System.Windows.Controls;

namespace InfinniPlatform.UserInterface.ViewBuilders.Designers.RegisterDesigner
{
    /// <summary>
    ///     Interaction logic for RegisterDesignerControl.xaml
    /// </summary>
    public partial class RegisterDesignerControl : UserControl
    {
        public RegisterDesignerControl()
        {
            InitializeComponent();

            Designer.OnValueChanged += OnValueChangedHandler;
        }

        public Func<string> ConfigId
        {
            get { return Designer.ConfigId; }
            set { Designer.ConfigId = value; }
        }

        public Func<string> DocumentId
        {
            get { return Designer.DocumentId; }
            set { Designer.DocumentId = value; }
        }

        public Func<string> Version
        {
            get { return Designer.Version; }
            set { Designer.Version = value; }
        }

        public object Value
        {
            get { return Designer.Value; }
            set { Designer.Value = value; }
        }

        private void OnValueChangedHandler(object sender, EventArgs e)
        {
            if (OnValueChanged != null)
            {
                OnValueChanged(sender, e);
            }
        }

        public event EventHandler OnValueChanged;
    }
}