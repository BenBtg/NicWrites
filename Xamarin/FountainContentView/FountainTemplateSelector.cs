using System;
using FountainSharp;
using Xamarin.Forms;

namespace FountainView
{
    public class FountainTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ActionTemplate { get; set; }
        public DataTemplate CharacterTemplate { get; set; }
        public DataTemplate DefaultTemplate { get; set; }
        public DataTemplate SceneHeadingTemplate { get; set; }
        public DataTemplate DialogueTemplate { get; set; }
        public DataTemplate ParentheticalTemplate { get; set; }
        public DataTemplate EmptyTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            // Some items come back empty and break the templates hard coded array references
            if (item.ToString().Contains("[]")) 
                return EmptyTemplate;

           // Console.WriteLine(item);
           // Console.WriteLine(item.GetType().Name);   
            if (item is FountainBlockElement.Action) return ActionTemplate;
            if (item is FountainBlockElement.Character) return CharacterTemplate;
            if (item is FountainBlockElement.Dialogue) return this.DialogueTemplate;
            if (item is FountainBlockElement.SceneHeading) return SceneHeadingTemplate;
            if (item is FountainBlockElement.Parenthetical) return ParentheticalTemplate;

           // Console.WriteLine(item.GetType().Name);
            return DefaultTemplate;
        }
    }
}
