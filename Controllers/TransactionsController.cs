﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Accounting.Api.Models;
using Accounting.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransactionsController : Controller
    {
        private readonly AccountingContext db;

        public TransactionsController(AccountingContext db)
        {
            this.db = db;
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(db.Transactions);
        }

        [HttpGet("{ID}", Name="GetTransaction")]
        public IActionResult GetById(int id)
        {
            var transaction = db.Transactions.Find(id);

            if(transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);

        }

        [HttpPost]
        public IActionResult Post([FromBody]Transaction transaction)
        {
            if(transaction == null)
            {
                return BadRequest();
            }

            this.db.Transactions.Add(transaction);
            this.db.SaveChanges();

            return CreatedAtRoute("GetTransaction", new { id = transaction.Id}, transaction);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Transaction newTransaction)
        {
            if (newTransaction == null)
            {
                return BadRequest();
            }
            var currentTransaction = this.db.Transactions.FirstOrDefault(x => x.Id == newTransaction.Id);

            if (currentTransaction == null)
            {
                return NotFound();
            }

            currentTransaction.Vendor = newTransaction.Vendor;
            currentTransaction.Amount = newTransaction.Amount;
            currentTransaction.Category = newTransaction.Category;
            currentTransaction.TransactionDate = newTransaction.TransactionDate;
            currentTransaction.Account = newTransaction.Account;

            this.db.Transactions.Update(currentTransaction);
            this.db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = this.db.Transactions.FirstOrDefault(x => x.Id == id);

            if (transaction == null)
            {
                return NotFound();
            }

            this.db.Transactions.Remove(transaction);
            this.db.SaveChanges();

            return NoContent();
        }

    }
}
