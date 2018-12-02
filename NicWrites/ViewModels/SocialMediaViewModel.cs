using System;
using System.Collections.ObjectModel;
using Microsoft.MobCAT;
using NicWrites.Models;
using NicWrites.Services;

namespace NicWrites.ViewModels
{
    public class SocialMediaViewModel: BaseViewModel
    { 
        public object ViewModel
        {
            get;
            set;
        }

        private int _currentPosition;
        public int CurrentPosition
        {
            get { return _currentPosition; }
            set { SetProperty(ref _currentPosition, value); }
        }

        public ObservableCollection<SocialPost> SocialPosts { get; set; }

        private INicWritesService _nicWritesService;

        public SocialMediaViewModel()
        {
            SocialPosts = new ObservableCollection<SocialPost>();

            _nicWritesService = ServiceContainer.Resolve<INicWritesService>();

            GetPhotos();

            SocialPosts.Add(new SocialPost("https://lh3.googleusercontent.com/008XQc9APt-FXhcQeBp7fdQt3G1CPWhzsj3BVhd-pvfQgGv5iol4uLpu8BK3Y4cTIzX44EnuPhIGKPHjlEMKVVm3tzscLtyOOltz-OF4WCpzcEj77T_53LazX_eVQVT3teaDdaaKn2lG6WswtDzhNEqohRIA3jgceukgaSjp-hXx8H5NluWXIsO523rkSEcH_jMe6lYQMDirESA-VwwjA2A1JlKYHdasQvZyQ_hUSYXZdaYPCJCUxlRN2yNzuaGflOLMaUGBhGmCPIN68A5wPFijgku8Uiqad-LM6gtzjU7VvCKG9pxqoVMP0nKMB4wfPTp_-wJC1SORpOlMF9w3ojaf40VFTmrkWPInxc71QReMPBdm-Q9kVbNW1BWyGYcOeM8DGJmOrfifS-Y5aWtgrSsgiY4fvtKRS6sYnX_mocoQhs6ccUmv6mSqhB-AnzNEfZ8_NZRJ6qRJFE-RvwnjjRXud3HAU1WfJNcByt7tgvH5F64gfe0ntVc-QSgJmrKI3t1dEo4WMLxe8G9_l6BD4Ipo5dytXgIRjMN7DVV-9ZMk3wCCK44ZOQylPVtdKKRJ9U_h60AU1WeGzIE1v4VTZNPaxLHYXuWt6Aiyfv_mlz6XJBGYBUF7DBufrhRuTd_w-4et07AM0zQpDY-dsryfPnu8Qat_ghlTGNqFXbMBxBsCYku8jWTZjliNbVRiOTn6yBsbXZmBBH8ymygOqQ=w1440-h1614-no"));
            SocialPosts.Add(new SocialPost("https://lh3.googleusercontent.com/hAIkBw57k-L-k9gN9bQi2GVuO9rtJaAPV8N_613KGjgKQXMDkYqz-R7bRoUazVBwzUXv9wfCE_uBgv0mavlfJPzV0NOZu8ElARQMC4cP1e0A01XIy02q88JU8hfEALwyivrjwmudpMfDceHmeKeVB-cRh6hOUU2yOXukShn7ecigfCIqGhu4vZ8gfwAWrzKg_kYUeuOlDtt-CMsDh-EnbomGxmdh2pBUMSFcC8tW6H9a81MWoBTq1E3As_7zMwiwkhq1IIMkFfU4hmuS0KZPD3vsGFeXUchtt01Gc5RthZbypPDqViEfpEc4t-9FdQVYsReTWwBx_1wFuJDNIS48oUyV4j2G1wHcftc93DXtkPPCsA4yBZYA0YSTXOgvLN6JoDJvWpNY9W8pqfENuWBd438NI7dw2xwCP076uOPTSwjrM1gMYod5pORQfyrsi-ec4wF2JrmzeUbsYDNXLuv0DaxJkVrEzI39yWSAhWi7NjNz39hN87OZkt1Rdki8YNWDGAziXS8c4-uM1VzT4kEaiLB0RptEJQa1Vug0AUj8LaNTgQuya4-EtuiV8vF5C-SAXJypODLKB42oxDpTGHWns9MMYqvk_E06RM9ADf1Vjsq4OEkYsvo_qPWKpfkPq7NJTQRZRirns5F00y73oeCQm2sqHEszunxCKCxI-ueWaKA-QnwUHZ29vSNjwP3BncEkNDfEM1oGV7PZW7kyCw=w1398-h1968-no"));
            SocialPosts.Add(new SocialPost("https://lh3.googleusercontent.com/kQ6QBORKcpJl4GFxYEcJda_UaK2U767E29nIMhsSFty5Werx4bjOG9U80VoIBjQ6VNbWXrH3ZcvepnOkOR8wS55NoIg0HPnoV64tqm4Zb_cpcBh55FM-dDd5zhVODoymju_mHDRNyDjPYEIEcjnJSzn0vm7B641MQGrEzW6AK44nOXQkZH-WK4lV-r8ThVQAZcQVolmO9l3xA_1HPwr9R1TXFHZdlaBOGL7rVgfe4d7vsv0PzqszJnHNsjkJKosA3VS3GKQ5w8Ynd70O6Yfz6z2tUCvBoBC1NmNMCcWGlQd9DS-RH-aFh7slWi3_K2dit_ikooJVrYFBlubwPSI-ortFN0UdcC4bW5Dqi-gaOdTqchCJnMT1gZFET54PaTMFmzZ4HCLPSroNYoBqnhAxxfDB-iF-itt-n5JehuRqp6cUCg_NbiwlpVQ-Ywh-mNxB0ShKbDeIKWFPEVYYSpN1BqOzoEjxpnFPQ8vaRyuTFIOKtAS5-V2gWJkiXK26aV57gxqfN8XBHe2csYOfRvTSZVEWOEdF2KlyovOKxSrj3Ya0HGf1UJDXNahuXyq6QTJ5hvzlz-df3jctM2wXZeyxv25nQnJS_no2-ASphYrPzPKX-ZIMEFQCtfWjU59LvQQus-e_WXEXe1RJ0TBGhRiz59yzWPBvZP1s6by7slMV_WbiD-AbG10tdvIyzxoJjGk7goCn15NGyz1HrhCI2w=w1440-h1679-no"));
        }

        private async void GetPhotos()
        {
            var result = await _nicWritesService.GetSocialPhotosAsync();
        }

    }
}
