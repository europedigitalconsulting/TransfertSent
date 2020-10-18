using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocoin.Client.Features.Transfer.Sent
{
    public partial class TransferTypePhysical : ComponentBase
    {
        public int Etape { get; set; } = 1;
        public int IdPays { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        private int AmountToSend { get; set; }
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
        [Inject] protected HttpClient HttpClient { get; set; }
        [Inject] NavigationManager NavigationManager { get; set; }
        public bool Loading { get; set; } = false;
        public string CodeRef { get; set; }

        protected override async Task OnInitializedAsync()
        {
        }

        protected void SelectPays(ChangeEventArgs e)
        {
            IdPays = int.Parse(e.Value.ToString());
            StateHasChanged();
        }
        protected void StepConfirm()
        {
            Etape = 2;
        }
        protected async Task StepValidation()
        {
            await ValidTransfer.InvokeAsync(null);
        }
        protected async Task InviteUserAsync()
        {
            await InviteUser.InvokeAsync(null);
        }
    }
}
