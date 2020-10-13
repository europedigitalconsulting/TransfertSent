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
        [Parameter]
        public IReadOnlyList<SelectListItem> ListPays { get; set; }
        [Parameter]
        public EventCallback<bool> ClickCancel { get; set; }
        protected int Etape { get; set; } = 1;
        public TransferSentViewModel TransferSentViewModel { get; set; }

        protected int Amount
        {
            get
            {
                return TransferSentViewModel.AmountToSend;
            }
            set
            {
                if (value > AmountInStock)
                    TransferSentViewModel.AmountToSend = AmountInStock;
                else
                    TransferSentViewModel.AmountToSend = value;
            }
        }

        [Inject]
        protected HttpClient HttpClient { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        protected bool Loading { get; set; } = false;
        protected string CodeRef { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TransferSentViewModel = new TransferSentViewModel();
        }

        protected void SelectPays(ChangeEventArgs e)
        {
            TransferSentViewModel.IdPays = int.Parse(e.Value.ToString());
            StateHasChanged();
        }
        protected void StepConfirm()
        {
            Etape = 2;
        }
        protected async Task InviteUser()
        {
            var response = await HttpClient.GetAsync(PathApiSendEmailInviteUser + TransferSentViewModel.Email, HttpCompletionOption.ResponseContentRead);
            if (response.IsSuccessStatusCode)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        protected async Task StepValidation()
        {
            Loading = true;
            Etape = 3;

            var response = await HttpClient.PostAsJsonAsync(PathApiGenerateRefCode, TransferSentViewModel);
            if (response.IsSuccessStatusCode)
            {
                CodeRef = await response.Content.ReadAsStringAsync();
            }

            Loading = false;
        }
    }
}
