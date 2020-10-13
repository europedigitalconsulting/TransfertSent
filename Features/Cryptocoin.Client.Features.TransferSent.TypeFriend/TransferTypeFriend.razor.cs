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
        protected Contact SelectedContact;
        protected string MessageValidatedTransfer = null;
        protected bool Loading { get; set; } = false; 
        protected int Page { get; set; } = 1;
        [Inject]
        protected HttpClient HttpClient { get; set; }

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
            Page = 4;
            Loading = true;
            TransferSentViewModel model = new TransferSentViewModel
            {
                AmountToSend = AmountToSend,
                IdPays = 2,
                Email = "okk@free.fr",
                Firstname = "tot",
                Lastname = "tititi",
                SelectedContact = SelectedContact
            };
            var response = await HttpClient.PostAsJsonAsync(PathApiValidTransfer, model);
            if (response.IsSuccessStatusCode)
            {
                MessageValidatedTransfer = await response.Content.ReadAsStringAsync();
                Loading = false;
            }
            StateHasChanged();
        }

    }
}
