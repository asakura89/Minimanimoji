using System;
using System.Windows;
using System.Windows.Controls;

namespace Minimanimoji {
    public partial class MojiButton : UserControl {
        public MojiButton() : this(String.Empty) { }

        public MojiButton(String mojiText) {
            InitializeComponent();

            MojiText = mojiText;
            DataContext = this;
        }

        public static readonly DependencyProperty MojiTextProperty = DependencyProperty.Register("MojiText", typeof(String), typeof(MojiButton), new PropertyMetadata(String.Empty));
        public String MojiText {
            get => GetValue(MojiTextProperty).ToString();
            set => SetValue(MojiTextProperty, value);
        }

        void ButtonBase_OnClick(Object sender, RoutedEventArgs e) {
            Clipboard.Clear();
            Clipboard.SetText(MojiText);
        }
    }
}