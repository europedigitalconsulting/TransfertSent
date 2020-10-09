
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Cryptocoin.Shared
{
    public class TransferSentViewModel
    {
        [Required]
        public int AmountToSend { get; set; } = 0;
        [Required]
        public int IdPays { get; set; }
        [Required]
        public string SenderName { get; set; }
        [Required]
        public string SenderEmail { get; set; }
    }
}
