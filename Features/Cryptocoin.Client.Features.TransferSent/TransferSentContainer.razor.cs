using Cryptocoin.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Cryptocoin.Client.Feature.Transfer.Sent
{
    public partial class TransferSentContainer : ComponentBase
    {

        protected List<SelectListItem> ListTypeTransfer = new List<SelectListItem>();
        protected int SelectedTypeTransfer { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SelectedTypeTransfer = (int)EnumTransfer.NULL;
            ListTypeTransfer.Add(new SelectListItem { Text = "...", Value = ((int)EnumTransfer.NULL).ToString() });
            ListTypeTransfer.Add(new SelectListItem { Text = LabelSelectTypeFriend, Value = ((int)EnumTransfer.TYPE_FRIEND).ToString() });
            ListTypeTransfer.Add(new SelectListItem { Text = LabelSelectTypeUser, Value = ((int)EnumTransfer.TYPE_USER).ToString() });
            ListTypeTransfer.Add(new SelectListItem { Text = LabelSelectTypePhysical, Value = ((int)EnumTransfer.TYPE_PHYSICAL).ToString() });

            await base.OnInitializedAsync();
        }

        protected void SelectTypeTransfer(ChangeEventArgs e)
        {
            SelectedTypeTransfer = int.Parse(e.Value.ToString());
            StateHasChanged();
        }
        protected void ClickCancelHandler(bool IsCancel)
        {
            if (IsCancel)
            {
                SelectedTypeTransfer = 0;
                StateHasChanged();
            }
        }
    }

}
