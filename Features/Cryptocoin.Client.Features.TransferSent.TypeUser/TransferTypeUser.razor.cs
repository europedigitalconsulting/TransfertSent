using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cryptocoin.Client.Features.Transfer.Sent
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
        public ApplicationUser User { get; set; } = new ApplicationUser();
        protected override async Task OnInitializedAsync()
        {
            var response = await HttpClient.GetAsync("api/Profile");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                //  Console.WriteLine($"user :{json}");
                User = JsonConvert.DeserializeObject<ApplicationUser>(json);
            }
        }

        protected MarkupString GetSomeRawHtml(string txt)
        {
            return (MarkupString)txt;
        }
        protected async Task GenerateQrCode()
        {
            Loading = true;

            TransferSentViewModel model = new TransferSentViewModel();
            model.AmountToSend = AmountToSend;
            model.Email = User.Email;
            model.Firstname = User.FirstName;
            model.Lastname = User.LastName;

            string link = CryptHelper.Rijndael.Encrypt(JsonConvert.SerializeObject(model), "E546C8DF278CD5931069B522E695D4F2");

            await Task.Delay(1500);
            var response = await HttpClient.GetAsync(PathApiInitQrCode + link, HttpCompletionOption.ResponseContentRead);

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
