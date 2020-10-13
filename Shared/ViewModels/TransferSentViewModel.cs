
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cryptocoin.Shared
{
    public class TransferSentViewModel
    {
        public int AmountToSend { get; set; } = 0;

        public int IdPays { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public Contact SelectedContact { get; set; }
    }
}
