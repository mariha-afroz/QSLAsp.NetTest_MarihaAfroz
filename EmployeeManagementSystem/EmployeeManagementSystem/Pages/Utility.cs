using DocumentFormat.OpenXml.EMMA;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace EmployeeManagementSystem.Pages
{

    public class CommitCancelModel
    {
        public string CancelUrl { get; set; }

    }
    public class DeleteCancelModel
    {
        public string CancelUrl { get; set; }
        public int ListId { get; set; }
    }


    public class MessageModel
    {
        public object Message { get; set; }
    }



}
