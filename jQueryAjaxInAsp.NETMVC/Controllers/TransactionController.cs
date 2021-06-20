using jQueryAjaxInAsp.NETMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static jQueryAjaxInAsp.NETMVC.Helper;

namespace jQueryAjaxInAsp.NETMVC.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TarnsactionDbContext _context;

        public TransactionController(TarnsactionDbContext context)
        {
            _context = context;
        }
        // GET: TransactionController
        public ActionResult Index()
        {
            return View(_context.Transactions.ToList()) ;
        }

        //Get: Tranction/AddOrEdit
        //Get: Tranction/AddOrEdit/5
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id= 0) 
        {
            if (id==0)
            {
                return View(new TransactionModel());
            }
            else
            {
                var transactionModel = await _context.Transactions.FindAsync(id);
                if (transactionModel==null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
           
        }

      

        // POST: TransactionController/AddOrEdit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddOrEdit(int id, [Bind("TransactionId,AccountNumber,BeneficiaryName,BankName,SWIFTCode,Amount,Date")]TransactionModel transactionModel)
        {
            if (ModelState.IsValid)
            {
                //Insert
                if (id == 0)
                {
                    transactionModel.Date = DateTime.Now;
                    _context.Add(transactionModel);
                    await _context.SaveChangesAsync();

                }
                //Update
                else
                {
                    try
                    {
                        _context.Update(transactionModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!TransactionModelExists(transactionModel.TransactionId))
                        { return NotFound(); }
                        else
                        { throw; }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
        }

        private bool TransactionModelExists(int id)
        {
            //.Any(e => e.Customer_id == id);
            return _context.Transactions.Any(e => e.TransactionId == id);
        }


        // GET: Transaction/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = await _context.Transactions
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (transactionModel == null)
            {
                return NotFound();
            }

            return View(transactionModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionModel = await _context.Transactions.FindAsync(id);
            _context.Transactions.Remove(transactionModel);
            await _context.SaveChangesAsync();
            return Json(new { html = Helper.RenderRazorViewToString(this, "_ViewAll", _context.Transactions.ToList()) });
        }

    }
}
