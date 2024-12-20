using CommonLib;
using EMSDataAccess;
using EMSDomain;
using Microsoft.AspNetCore.Mvc;
using Telerik.Reporting.Interfaces;

namespace EmployeeManagementSystem.Pages.EmployeePerformanceReviews
{
    public class PerformanceReviewsModel : TransactionBase
    {
        [BindProperty]
        public PerformanceReview PerformanceReviewData { get; set; }
        public Quarter SelectedQuarter { get; set; }
        public IList<PerformanceReviewListDTO> PerformanceReviewList { get; set; }

        private readonly IEmployee m_Employee;
        public PerformanceReviewsModel(IEmployee empManager)
        {
            m_Employee = empManager;
        }
        public void OnGet(int id, Quarter? selectedQuarter)
        {
            try
            {
                SelectedQuarter = selectedQuarter ?? 0;
                
                if (id > 0)
                {
                    PerformanceReviewData = m_Employee.GetPerformanceReviewById(id);
                }
                else
                {
                    PerformanceReviewData = new PerformanceReview
                    {
                        ReviewDate = TimeZoneUtility.DateTimeNow,
                    };
                }

                PerformanceReviewList = m_Employee.GetAllPerformanceReviews();

                if (SelectedQuarter != 0)
                {
                    PerformanceReviewList = PerformanceReviewList.Where(r => GetQuarterFromDate(r.ReviewDate) == SelectedQuarter).ToList();
                }
                SetCCInfo($"{Navigator.PerformanceReviews}");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private Quarter GetQuarterFromDate(DateTime? date)
        {
            return (Quarter)((date?.Month - 1) / 3 + 1);
        }

        public ActionResult OnPost()
        {
            try
            {
                if (PerformanceReviewData.ReviewDate == null)
                {
                    TempData["Message"] = "Review Date is required";
                    return Page();
                }
                if (PerformanceReviewData.ReviewScore == null)
                {
                    TempData["Message"] = "Review Score is required";
                    return Page();
                }
                if (PerformanceReviewData.Id == 0)
                {
                    m_Employee.CreatePerformanceReview(PerformanceReviewData);
                    TempData["Message"] = "Performance Review has been added successfully";
                }
                else
                {
                    m_Employee.UpdatePerformanceReview(PerformanceReviewData);
                    TempData["Message"] = "Performance Review has been Updated successfully";                   

                }

                return RedirectToPage(Navigator.PerformanceReviews);
            }
            catch
            {
                throw;
            }
        }
    }
}
