using ListSorter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ListSorter.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var tempTxt = Request.Query["tmpTxt"].ToString();
            var tempStorage = tempTxt.Split(';');
            ViewData["tmpText"] = tempStorage.Aggregate(
                "", (current, element) => current + $"<li>{element}</li>");
            if (tempStorage.Length == 0 || string.IsNullOrEmpty(tempTxt)) return;
            {
                var sortedList = new MyList(tempTxt);
                var selectedOption =  Request.Query["sortSelector"].ToString();
                sortedList.Sort(selectedOption);
                ViewData["sortedData"] = sortedList.Data.Aggregate(
                    "", (current, element) => current + $"<li>{element}</li>");
            }
        }
    }
}