using Indrani_Jewellers.Data;
using Indrani_Jewellers.Models;
using Indrani_Jewellers.Services;
using Microsoft.AspNetCore.Mvc;

namespace Indrani_Jewellers.Controllers
{
    public class LoanController : BaseController
    {
        public readonly LoanService _loanServices;
        public readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly CustomerService _CustomerService;

        public LoanController(LoanService loanServices, ApplicationDbContext db, IHttpContextAccessor httpContextAccessor, CustomerService customerService)
        {
            _loanServices = loanServices;
            _db = db;
            _httpContextAccessor = httpContextAccessor;
            _CustomerService = customerService;
        }

        public IActionResult Index()
        {
            var loanList = _loanServices.GetLoanList();
            return View(loanList); ;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Loan loan)
        {
            int Lid = _loanServices.InsertLoan(loan);

            foreach (var data in loan.loanProductDetails)
            {
                _loanServices.InsertLoanProducts(data, Lid);
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult GetCustomerId(string cid)
        {
            var data = _db.customer_master.FirstOrDefault(m => m.CustomerID == cid);

            if (data == null)
            {
                return Json(null);
            }
            else
            {
                return Json(data);
            }
        }



        public IActionResult Details(int id)
        {
            // Fetch loan details
            var loan = _db.Loans.FirstOrDefault(m => m.LID == id);

            // Fetch loan product details
            var loanProducts = _loanServices.GetLoanProductList(id);

            if (loan == null)
            {
                return NotFound(); // Handle case where loan with the given ID is not found
            }

            // Assuming you have a view model to combine loan and loan product details
            var viewModel = new LoanDetailsViewModel
            {
                loan = loan,
                loanProductDetail = loanProducts
            };

            return View(viewModel); // Pass the view model to the view
        }


    }
}
