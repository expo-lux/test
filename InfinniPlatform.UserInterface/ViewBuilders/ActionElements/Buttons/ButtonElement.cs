﻿using System.Windows;
using InfinniPlatform.UserInterface.ViewBuilders.Actions;
using InfinniPlatform.UserInterface.ViewBuilders.Elements;
using InfinniPlatform.UserInterface.ViewBuilders.Images;
using InfinniPlatform.UserInterface.ViewBuilders.Scripts;
using InfinniPlatform.UserInterface.ViewBuilders.Views;

namespace InfinniPlatform.UserInterface.ViewBuilders.ActionElements.Buttons
{
    /// <summary>
    ///     Элемент представления для кнопки.
    /// </summary>
    public sealed class ButtonElement : BaseElement<ButtonControl>
    {
        // Action

        private BaseAction _action;
        // Image

        private string _image;

        public ButtonElement(View view)
            : base(view)
        {
            Control.Click += OnClickButton;
        }

        // OnClick

        /// <summary>
        ///     Возвращает или устанавливает обработчик события нажатия на кнопку.
        /// </summary>
        public ScriptDelegate OnClick { get; set; }

        private void OnClickButton(object sender, RoutedEventArgs e)
        {
            this.InvokeScript(OnClick);

            var action = GetAction();

            if (action != null)
            {
                action.Execute();
            }
        }

        // Text

        public override void SetText(string value)
        {
            base.SetText(value);

            Control.Text = value;
        }

        /// <summary>
        ///     Возвращает изображение кнопки.
        /// </summary>
        public string GetImage()
        {
            return _image;
        }

        /// <summary>
        ///     Устанавливает изображение кнопки.
        /// </summary>
        public void SetImage(string value)
        {
            _image = value;

            Control.Image = ImageRepository.GetImage(value);
        }

        /// <summary>
        ///     Возвращает действие при нажатии на кнопку.
        /// </summary>
        public BaseAction GetAction()
        {
            return _action;
        }

        /// <summary>
        ///     Устанавливает действие при нажатии на кнопку.
        /// </summary>
        public void SetAction(BaseAction value)
        {
            _action = value;
        }

        // Click

        /// <summary>
        ///     Осуществляет программное нажатие на кнопку.
        /// </summary>
        public void Click()
        {
            Control.PerformClick();
        }
    }
}