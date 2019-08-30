using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Reparation.Models
{
    public class WorkOrders
    {
        [Key]
        public int Id { get; set; }

        public string WorkOrderId { get; set; }


        public string GoldSmithName { get; set; }

        [Required(ErrorMessage = "Kund namn")]
        [Display(Name = "Customer Name :")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "Kund telefonenummer")]
        [Display(Name = "Contact Number :")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string CustomerMobileNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        public string JewelleryDescription1 { get; set; }

        public string JewelleryDescription2 { get; set; }

        public string JewelleryDescription3 { get; set; }

        public string WorkToBeDone { get; set; }

        public string WorkToBeDone2 { get; set; }

        public string WorkToBeDone3 { get; set; }

        public string AgentName { get; set; }

        //[DataType(DataType.Date)]
        [Required(ErrorMessage = "Föremål Datum")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime ProductGivenOn { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateAcceptedOrRejected { get; set; }

        public AcceptedRejectedStatus sAcceptedRejectedStatus { get; set; }



        public int? AmountToBeCollected { get; set; }



        [Range(0, 2)]
        public status sStatus { get; set; }

        public string Comments { get; set; }
    }

    public enum AcceptedRejectedStatus
    {
        Accepterat = 1,
        [Display(Name = "Ej Accepterat")]
        Ejaccepterat = 2,
        Vänteläge = 3
    }
    public enum status
    {
        Mottaget = 0,
        [Display(Name = "Hos Guldsmed")]
        HosGuldsmed = 1,
        [Display(Name = "Åter i butik")]
        Åteributik = 2

    }
}
