using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;

namespace Minimanimoji {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // NOTE: https://blog.scottlogic.com/2012/02/06/a-simple-pattern-for-creating-re-useable-usercontrols-in-wpf-silverlight.html
            var kaomojis = JsonConvert.DeserializeObject<IList<KaomojiModel>>(EmbeddedJson.Get("kaomoji.ejx"));
            IList<String> type1s = kaomojis
                .Select(moji => moji.Type1)
                .Distinct()
                .OrderBy(type => type)
                .ToList();

            foreach (String type1 in type1s) {
                var type1panel = new MojiPanel(type1);
                IList<String> type2s = kaomojis
                    .Where(moji => moji.Type1 == type1)
                    .Select(moji => moji.Type2)
                    .Distinct()
                    .OrderBy(type => type)
                    .ToList();

                foreach (String type2 in type2s) {
                    var type2panel = new MojiPanel(type2);
                    IList<String> mojis = kaomojis
                        .Where(moji =>
                            moji.Type1 == type1 &&
                            moji.Type2 == type2)
                        .SelectMany(moji => moji.Moji)
                        .ToList();

                    foreach (String moji in mojis)
                        type2panel.MojiStackPanel.Children.Add(new MojiButton(moji));

                    type1panel.MojiStackPanel.Children.Add(type2panel);
                }

                RootPanel.Children.Add(type1panel);
            }
        }
    }
}