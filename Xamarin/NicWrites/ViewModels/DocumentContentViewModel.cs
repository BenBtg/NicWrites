using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace NicWrites.ViewModels
{
    public class DocumentContentViewModel : BaseNicWritesViewModel
    {
        public Document Document { get; set; }
        string _fountainDocText;
        private string _plainDocText;

        public string FountainDocText
        {
            get => _fountainDocText;
            set { RaiseAndUpdate(ref _fountainDocText, value); }
        }

        public string PlainDocText
        {
            get => _plainDocText;
            set { RaiseAndUpdate(ref _plainDocText, value); }
        }

        private INicWritesBlobService _nicWritesService;

        public async override Task InitAsync()
        {
            try
            {
                _nicWritesService = ServiceContainer.Resolve<INicWritesBlobService>();
                IsBusy = true;
                Title = Document.title;

                Analytics.TrackEvent("ViewScript " + Document.title);


                var docText = await _nicWritesService.GetDocContentAsync(Document.url.PathAndQuery);



                MainThread.BeginInvokeOnMainThread(() =>
                {
                    if (Title.EndsWith("fountain", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Code to run on the main thread
                        FountainDocText = docText;
                    }
                    if (Title.EndsWith("md", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //Markdown
                        PlainDocText = docText;
                        //var doc = Markdig.Markdown.Parse(docText);
                        //foreach (var item in doc)
                        //{
                        //    var para = item as Markdig.Syntax.Block;
                        //    if (para != null)
                        //    {

                        //        //foreach (var line in para.Lines)
                        //        {
                        //            Console.WriteLine(para.ToString());
                        //        }
                        //    }
                        //}
                    }
                    else
                    {
                        PlainDocText = docText;
                    }

                });

            }
            catch (Exception ex)
            {
                Logger.Debug(ex.Message, ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
