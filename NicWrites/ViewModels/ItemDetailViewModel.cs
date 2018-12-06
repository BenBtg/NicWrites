using System;

using NicWrites.Models;

namespace NicWrites.ViewModels
{
    public class ItemDetailViewModel : BaseNicWritesViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
