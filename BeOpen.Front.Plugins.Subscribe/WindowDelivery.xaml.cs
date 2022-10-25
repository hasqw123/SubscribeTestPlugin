using System.Windows;
using System.Windows.Controls;
using System;


namespace BeOpen.Front.Subscribe
{
    /// <summary>
    /// Созадем окно, при отправки доставки 
    /// </summary>
    public partial class WindowDelivery : Window
    {
        public WindowDelivery()
        {
            InitializeComponent();
        }

        public void ShowStatus(string message)
        {
            
            TextBlock info = new TextBlock();
            info.Text = $"Доставка номер {message} в пути\n {DateTime.Now}";
            info.Width = 300;
            info.Height = 100;
            info.TextAlignment = TextAlignment.Center;

            layoutGrid.Children.Add(info);
            Show();
        }
    }
}
