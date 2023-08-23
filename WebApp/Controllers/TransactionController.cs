using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using System.Web.Mvc;
using System.Dynamic;
using WebGrease.Css.Extensions;

namespace WebApp.Controllers
{
    public class TransactionController : Controller
    {
        [ActionName("Index")]
        public async Task<ActionResult> IndexAsync()
        {
            string[] c = { "orange", "gray" };
            var items = await Repository<Transaction>.GetItemsAsync();
            DbContext firstDbContext = new FirstDbContext();
            //show on other div
            RepositoryData firstRepo = new RepositoryData(firstDbContext);
            List<Transaction> box = new List<Transaction>();
            try
            {
                var tuples = firstRepo.GetActive(); 
                foreach (var n in tuples)
                {
                    Entity.Transaction t = new Entity.Transaction();
                    t.Code = n.Code.ToString();
                    t.Amount = n.Amount.ToString(); 
                    t.Bank = n.Bank;
                    t.Flag = c[Convert.ToInt16(n.Flag)];
                    box.Add(t);
                }
            }
            catch { }
            items.ForEach(x => x.Flag="black");
            items.ForEach(i => box.Add(i));
            // loc4l st0rage
            return View(box);
        }


        [ActionName("Create")]
        public async Task<ActionResult> CreateAsync()
        {
            return View();
        }

        [ActionName("Edit")]
        public async Task<ActionResult> EditAsync(string id, string Code, string Amount, string Bank)
        {
            Entity.Transaction filter = new Entity.Transaction();
            filter.Code = Code;
            filter.Amount = Amount;
            filter.Bank = Bank;

            //var filter = Data.GetByIdData(Convert.ToInt32(id));
            return View(filter);
        }


        [HttpPost]
        [ActionName("Edit")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> EditAsync([Bind(Include = "Id,Code,Amount,Bank,Date,Flag")] Transaction item)
        {
            if (ModelState.IsValid)
            {
                DbContext firstDbContext = new FirstDbContext();
                RepositoryData firstRepo = new RepositoryData(firstDbContext);
                DbContext secondDbContext = new FirstDbContext();
                RepositoryData secondRepo = new RepositoryData(secondDbContext);
                Transactions obj = new Transactions();
                var today = DateTime.Now;
                item.Date = today.ToString();
                //obj.Id = Convert.ToInt32(item.Id);
                obj.Code = 1;
                obj.Amount = decimal.Parse(item.Amount);
                obj.Bank = item.Bank;
                obj.Date = today;
                //await Repository<Transaction>.CreateItemAsync(item);
                try
                {
                    firstRepo.InsertData(obj);
                    secondRepo.InsertData(obj);
                }
                catch{ }
                return RedirectToAction("SQL");
            }

            return View(item);
        }
        
        [HttpPost]
        [ActionName("Create")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync([Bind(Include = "Id,Code,Amount,Bank,Date,Flag")] Transaction item)
        {
            if (ModelState.IsValid)
            {
                item.Flag = "0";
                await Repository<Transaction>.CreateItemAsync(item);
                return RedirectToAction("Index");
            }

            return View(item);
        }

    }
}