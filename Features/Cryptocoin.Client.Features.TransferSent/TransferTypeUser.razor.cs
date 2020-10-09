using Microsoft.AspNetCore.Components;
using QRCoder;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cryptocoin.Client.Feature.Transfer.Sent
{
    public partial class TransferTypeUser : ComponentBase
    {
        protected bool Loading { get; set; } = false;
        protected bool DisplayQrCode { get; set; } = false;
        [Required]
        private int AmountToSend { get; set; } = 0;
        protected int Amount
        {
            get
            {
                return AmountToSend;
            }
            set
            {
                if (value > AmountInStock)
                    AmountToSend = AmountInStock;
                else
                    AmountToSend = value;
            }
        }
        protected string QrCode { get; set; }
        [Inject]
        protected HttpClient HttpClient { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }
        protected MarkupString GetSomeRawHtml(string txt)
        {
            return (MarkupString)txt;
        }
        protected async Task GenerateQrCode()
        {
            Loading = true;

            await Task.Delay(1500);
            var response = await HttpClient.GetAsync(PathApiInitQrCode + "https://www.bewhoyouart.com", HttpCompletionOption.ResponseContentRead);

            if (response.EnsureSuccessStatusCode().StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = await response.Content.ReadAsByteArrayAsync();
                QrCode = String.Format("data:image/png;base64,{0}", Convert.ToBase64String(data));
                DisplayQrCode = true;
            }

            Loading = false;
        }
    }
}
