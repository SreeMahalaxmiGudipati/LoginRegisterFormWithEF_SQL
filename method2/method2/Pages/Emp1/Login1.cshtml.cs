using method2.Data;
using method2.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace method2.Pages.Emp1
{
    public class Login1Model : PageModel
    {
        private APIDbContext db;

        public string Msg;
        public Login1Model(APIDbContext _db)
        {
            db = _db;
        }
        [BindProperty]
        public Employee emp { get; set; }

        public void OnGet()
        {
            emp = new Employee();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return RedirectToPage("/Emp1/Login1");
        }
        public IActionResult OnPost()
        {
            var stud = login2(emp.Name, emp.Password);
            if (stud == null)
            {
                Msg = "invalid";
                return RedirectToPage("/Error");
            }
            else
            {
                HttpContext.Session.SetString("username", stud.Name);
                return RedirectToPage("/Emp1/welcome11");

            }
        }

        private Employee login2(string username, string password)
        {
            var stu = db.Employees.SingleOrDefault(a => a.Name.Equals(username));
            if (stu != null)
            {
                if (BCrypt.Net.BCrypt.Verify(password, stu.Password))
                {
                    //       Console.WriteLine("Not null");
                    return stu;
                }
            }
               return null;
        }
    }
}
