using method2.Data;
using method2.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.Entity;

namespace method2.Pages.Emp1
{
    public class ListModel : PageModel
    {

        private readonly APIDbContext dbContext;

        public List<Models.Domain.Employee> Employees1 { get; set; }
        public ListModel(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void OnGet()
        {
            //to get employee details from database
            Employees1 = dbContext.Employees.ToList();
        }
    }
}
