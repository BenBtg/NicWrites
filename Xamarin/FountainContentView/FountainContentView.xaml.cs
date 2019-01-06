using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FountainSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FountainView;
using System.Collections.ObjectModel;

namespace FountainView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FountainContentView : ContentView
    {
        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }

        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(FountainContentView), default(string), propertyChanged: OnTextChanged);
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }

            set
            {
                SetValue(TextProperty, value);
            }
        }
        static async void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FountainContentView)bindable;

            var existing = (string)oldValue;
            var incoming = (string)newValue;

            var doc = await FountainDocument.ParseAsync(incoming);

            Xamarin.Essentials.MainThread.BeginInvokeOnMainThread(() =>
            {
                control.FountainList.ItemsSource = doc.Blocks.ToList();
            });
        }

        private FountainDocument fountainDocument;
        private ObservableCollection<FountainBlockElement> _blockElements = new ObservableCollection<FountainBlockElement>();
        public ObservableCollection<FountainBlockElement> BlockElements { get => _blockElements; set => _blockElements = value; }

        List<FountainBlockElement> Elements { get; set; }
        public FountainContentView()
        {
            InitializeComponent();
        }
    }
}
