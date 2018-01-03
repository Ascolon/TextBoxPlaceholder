using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Placeholder
{
    public partial class TextBoxPlaceholder : UserControl
    {
        static private string PlaceholderOldValue = string.Empty;
        public TextBoxPlaceholder()
        {
            InitializeComponent();
            DataContext = this;
        }




        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.Register("Placeholder", typeof(string), typeof(TextBoxPlaceholder), new PropertyMetadata("", PlaceholderChanged));
        private static void PlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PlaceholderOldValue = e.OldValue.ToString() != string.Empty ? e.OldValue.ToString() : ""; 
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); /*NotifyPropertyChanged("Text");*/ }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxPlaceholder), new PropertyMetadata("", TextChanged));
        private static void TextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue.ToString().Length > 0)
                d.ClearValue(PlaceholderProperty);
            if (e.NewValue.ToString().Length == 0)
                d.SetValue(PlaceholderProperty, PlaceholderOldValue);
        }
    }
}
