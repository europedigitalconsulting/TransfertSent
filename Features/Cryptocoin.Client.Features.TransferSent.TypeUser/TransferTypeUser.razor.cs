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
        public bool Loading { get; set; } = false;
        public bool DisplayQrCode { get; set; } = false;
        private int AmountToSend { get; set; } = 0;
        public int Amount
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
        public string QrCode { get; set; }

        protected override async Task OnInitializedAsync()
        {

        }

        protected MarkupString GetSomeRawHtml(string txt)
        {
            return (MarkupString)txt;
        }
        protected async Task GenerateQrCode()
        {
            await ValidTransfer.InvokeAsync(null);
        }
    }
}
