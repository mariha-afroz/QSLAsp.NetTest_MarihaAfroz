using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

namespace EmployeeManagementSystem.Pages
{
    public class TransactionBase : PageModel
    {

        [BindProperty]
        public CommitCancelModel CCInfo { get; set; }

        [BindProperty]
        public DeleteCancelModel DCInfo { get; set; }

        public TransactionBase()
        {
            CCInfo = new CommitCancelModel();
            DCInfo = new DeleteCancelModel();
        }

        protected void SetCCInfo(string cancelUrl)
        {
            CCInfo.CancelUrl = cancelUrl;
        }

        protected void SetDCInfo(string cancelUrl)
        {
            DCInfo.CancelUrl = cancelUrl;
        }
    }
}
