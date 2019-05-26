using NicWrites.Controls;
using NicWrites.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ScriptNavigationPage), typeof(ScriptNavigationPageRenderer))]
namespace NicWrites.iOS.Renderers
{
    public class ScriptNavigationPageRenderer : NavigationRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var att = new UITextAttributes();
                att.Font = UIFont.FromName("Courier Prime", 20);
                UINavigationBar.Appearance.SetTitleTextAttributes(att);
            }
        }
    }
}