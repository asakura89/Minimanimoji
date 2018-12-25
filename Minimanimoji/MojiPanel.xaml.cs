using System;
using System.Windows;
using System.Windows.Controls;

namespace Minimanimoji {
    public partial class MojiPanel : UserControl {
        public MojiPanel() : this(String.Empty) { }

        public MojiPanel(String title) {
            InitializeComponent();

            MojiTitle = title;
            DataContext = this;
        }

        public static readonly DependencyProperty MojiTitleProperty = DependencyProperty.Register("MojiTitle", typeof(String), typeof(MojiPanel), new PropertyMetadata(String.Empty));
        public String MojiTitle {
            get => GetValue(MojiTitleProperty).ToString();
            set => SetValue(MojiTitleProperty, value);
        }
    }
}