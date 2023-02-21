using method2.Data;
using method2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace method2.Pages.Emp1
{
    public class edit18Model : PageModel
    {
        private readonly APIDbContext dbContext;

        //return the data fields to razor page
        [BindProperty]
        public EditEmployeeViewModel EditEmployeeViewModel { get; set; }

        //to search database 
        public edit18Model(APIDbContext dbContext) { 
        
            this.dbContext=dbContext;
        }

        public void OnGet(int id)
        {
            var employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                //convert domian model to view model
                EditEmployeeViewModel = new EditEmployeeViewModel()
                {
                    //mapping fields to view model
                    Id=employee.Id,
                    Name=employee.Name,
                    PhoneNo=employee.PhoneNo,
                    Password=employee.Password
                };
            }
        }

        public void OnPost()
        {
            if (EditEmployeeViewModel != null)
            {
                var existingEmployee = dbContext.Employees.Find(EditEmployeeViewModel.Id);


                if (existingEmployee != null)
                {
                    //convert view model to domain model
                    //updating data
                    existingEmployee.Id = EditEmployeeViewModel.Id;
                    existingEmployee.Name = EditEmployeeViewModel.Name;
                    existingEmployee.PhoneNo = EditEmployeeViewModel.PhoneNo;
              //      existingEmployee.Password = EditEmployeeViewModel.Password;
                    
                    dbContext.SaveChanges();

                    ViewData["Message"] = "Employee profile updated successfully";
                }
            }
           
        }

    }
}
