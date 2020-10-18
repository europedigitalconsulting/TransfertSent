using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace Cryptocoin.Client.Features.Transfer.Sent
{
    public partial class TransferTypeFriend : ComponentBase
    {
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
        public Contact SelectedContact;
        public string MessageValidatedTransfer = null;
        public  bool Loading { get; set; } = false; 
        public int Page { get; set; } = 1;

        protected void GoSearchContact()
        {
            SelectedContact = null;
            Page = 2;
            StateHasChanged();
        }

        protected void GetContactSelected(Contact item)
        {
            SelectedContact = item;
            Page = 3;
            StateHasChanged();
        }
        protected async Task ConfirmTransfer()
        {
            await ValidTransfer.InvokeAsync(null);
        }

    }
}
