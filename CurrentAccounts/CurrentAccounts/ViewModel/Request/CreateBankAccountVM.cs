using System.ComponentModel.DataAnnotations;

namespace CurrentAccounts.ViewModel.Request
{
    public class CreateBankAccountVM
    {
        [Range(1, int.MaxValue, ErrorMessage = "Invalid customer id.")]
        public int CustomerID { get; set; }
        public decimal InitialCredit { get; set; }
    }
}
