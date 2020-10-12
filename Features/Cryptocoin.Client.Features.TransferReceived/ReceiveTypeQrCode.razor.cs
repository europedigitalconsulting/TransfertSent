using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;


namespace Cryptocoin.Client.Feature.Transfer.Received
{
    public partial class ReceiveTypeQrCode : ComponentBase
    {
        [Inject]
        protected HttpClient HttpClient { get; set; }
        [Inject]
        protected NavigationManager NavManager { get; set; }
        public TransferSentViewModel Model { get; set; }
        public string QrCode { get; set; }
        public bool TransactionSuccess { get; set; } = false;
        public bool Loading { get; set; } = true;
     
        protected override async Task OnInitializedAsync()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);

            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("key", out var param))
            {
                QrCode = param.First();
                var response = await HttpClient.GetAsync(PathApiTransferQrCodeReceived + QrCode, HttpCompletionOption.ResponseContentRead);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    Model = JsonConvert.DeserializeObject<TransferSentViewModel>(result);
                    Loading = false;
                }
            }
        }

        public async Task ValidTransact()
        {
            Loading = true;
            var response = await HttpClient.GetAsync(PathApiTransferValidTransfer + QrCode, HttpCompletionOption.ResponseContentRead);
            if (response.IsSuccessStatusCode)
            {
                NavManager.NavigateTo("/");
            }
        }
    }
}
