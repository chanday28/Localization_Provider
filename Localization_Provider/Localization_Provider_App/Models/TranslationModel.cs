using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Localization_Provider_App.Models
{
    public class TranslationModel :TableEntity
    {
        public string OKButtonText { get; set; }
        public string CancelButtonText { get; set; }

        [Required]
        public TranslationType TranslationType { get; set; }
    }

    public enum TranslationType
    {
        FI,
        EN
    }
}