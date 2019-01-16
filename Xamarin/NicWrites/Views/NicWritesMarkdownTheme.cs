using System;
using Xam.Forms.Markdown;
using Xamarin.Forms;

namespace NicWrites.Views
{
    public class NicWritesMarkdownTheme: MarkdownTheme
    {
        public NicWritesMarkdownTheme()
        {
            this.BackgroundColor = DefaultBackgroundColor;
            this.Paragraph.ForegroundColor = DefaultTextColor;
            this.Heading1.ForegroundColor = DefaultTextColor;
            this.Heading1.BorderColor = DefaultSeparatorColor;
            this.Heading2.ForegroundColor = DefaultTextColor;
            this.Heading2.BorderColor = DefaultSeparatorColor;
            this.Heading3.ForegroundColor = DefaultTextColor;
            this.Heading4.ForegroundColor = DefaultTextColor;
            this.Heading5.ForegroundColor = DefaultTextColor;
            this.Heading6.ForegroundColor = DefaultTextColor;
            this.Link.ForegroundColor = DefaultAccentColor;
            this.Code.ForegroundColor = DefaultTextColor;
            this.Code.BackgroundColor = DefaultCodeBackground;
            this.Quote.ForegroundColor = DefaultQuoteTextColor;
            this.Quote.BorderColor = DefaultQuoteBorderColor;
            this.Separator.BorderColor = DefaultSeparatorColor;



            if (Device.RuntimePlatform == Device.iOS)
            {
                this.Paragraph.FontFamily = "Courier Prime";
                this.Heading1.FontFamily = "Courier Prime";
                this.Heading2.FontFamily = "Courier Prime";
                this.Heading3.FontFamily = "Courier Prime";
                this.Heading4.FontFamily = "Courier Prime";
                this.Code.FontFamily = "Courier Prime";

            }
            else
            {
                this.Paragraph.FontFamily = "Courier Prime.ttf#Courier Prime";
                this.Heading1.FontFamily = "Courier Prime.ttf#Courier Prime";
                this.Heading2.FontFamily = "Courier Prime.ttf#Courier Prime";
                this.Heading3.FontFamily = "Courier Prime";
                this.Heading4.FontFamily = "Courier Prime";
                this.Code.FontFamily = "Courier Prime.ttf#Courier Prime";
            }
        }

        public static readonly Color DefaultBackgroundColor = Color.FromHex("#ffffff");

        public static readonly Color DefaultAccentColor = Color.FromHex("#0366d6");

        public static readonly Color DefaultTextColor = Color.FromHex("#24292e");

        public static readonly Color DefaultCodeBackground = Color.FromHex("#f6f8fa");

        public static readonly Color DefaultSeparatorColor = Color.FromHex("#eaecef");

        public static readonly Color DefaultQuoteTextColor = Color.FromHex("#6a737d");

        public static readonly Color DefaultQuoteBorderColor = Color.FromHex("#dfe2e5");

    }
}
