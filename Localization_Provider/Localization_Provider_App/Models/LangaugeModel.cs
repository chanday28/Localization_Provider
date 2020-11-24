using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Localization_Provider_App.Models
{
    public class LangaugeModel :TableEntity
    {
        public string OKButtonText { get; set; }
        public string CancelButtonText { get; set; }

        [Required]
        public LanguageType LanguageType { get; set; }
    }

    public enum LanguageType
    {
        FI,
        EN
    }
}