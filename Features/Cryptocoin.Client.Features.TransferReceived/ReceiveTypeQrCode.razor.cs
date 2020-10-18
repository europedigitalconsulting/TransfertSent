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
        public bool TransactionSuccess { get; set; } = false;
        public bool Loading { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }
        private async Task ValidTransactionClick()
        {
            Loading = true;
            await ValidTransaction.InvokeAsync(null);
        }


    }
}
