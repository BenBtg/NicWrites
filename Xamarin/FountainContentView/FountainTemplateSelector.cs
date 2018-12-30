using System;
using Xamarin.Forms;

namespace FountainView
{
    public class FountainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActionTemplate { get; set; }
        public DataTemplate CharacterTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            DataTemplate template = ActionTemplate;
            if (item is FountainSharp.FountainBlockElement.Action)
            { return ActionTemplate; }
            if (item is FountainSharp.FountainBlockElement.Character)
            { return CharacterTemplate; }

            return DefaultTemplate;
        }
    }
}
