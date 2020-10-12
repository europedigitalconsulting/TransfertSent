using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cryptocoin.Client.Feature.Transfer.Received
{
    public partial class TransferReceivedContainer : ComponentBase
    {
        public int Page { get; set; } = 2;

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine(TypeReceived);
            if (TypeReceived == "QrCodeReceived")
            {
                Page = 1;
            }
        }
    }

}
