using System.Windows.Input;
using Xamarin.Forms;

namespace NicWrites.Controls
{
    public class ListView : Xamarin.Forms.ListView
    {
        public static BindableProperty ItemTappedCommandProperty = BindableProperty.Create<ListView, ICommand>(x => x.ItemTappedCommand, null);

        public ListView()
        {
            ItemTapped += OnItemTapped;
        }
        public ListView(ListViewCachingStrategy strategy) : base(Device.OS == TargetPlatform.iOS ? ListViewCachingStrategy.RetainElement : strategy)
        {
            ItemTapped += OnItemTapped;
        }

        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }

        void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null && ItemTappedCommand != null && ItemTappedCommand.CanExecute(e))
            {
                ItemTappedCommand.Execute(e.Item);
                SelectedItem = null;
            }
        }
    }
}