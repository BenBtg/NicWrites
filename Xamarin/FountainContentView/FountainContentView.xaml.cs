using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FountainSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FountainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FountainContentView : ContentView
    {
        //public string FountainText { get; set; }
        private FountainSharp.FountainDocument fountainDocument;


        List<FountainBlockElement> BlockElements { get; set; }
        public FountainContentView()
        {
            InitializeComponent();
        }

        public async Task SetContent(string FountainText)
        {
            fountainDocument = await FountainSharp.FountainDocument.ParseAsync(FountainText);

            FountainList.ItemsSource = fountainDocument.Blocks.ToList();

            //var test = fountainDocument.Blocks.ToList()[2];
           // Console.WriteLine(test);
        }
    }
}
