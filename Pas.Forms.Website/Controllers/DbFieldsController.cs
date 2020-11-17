using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Common;
using Pas.Forms.Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pas.Forms.Website.Controllers
{
    public class DbFieldsController : Controller
    {
        private readonly FormsDbContext _db;

        public DbFieldsController(FormsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var table = _db.DbTables
                .Include(x => x.Db)
                .SingleOrDefault(x => x.Id == id);

            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        public Result<List<DbField>> Get(int id)
        {
            var table = _db.DbTables
                .Include(x => x.Db)
                .SingleOrDefault(x => x.Id == id);

            return table == null ? ResultUtil.NotFound<List<DbField>>() : ResultUtil.Success(table.Fields);
        }

        [HttpPost]
        public Result Create(DbField entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Add(entity);
                    _db.SaveChanges();
                    return ResultUtil.Success();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return ResultUtil.Fail();
        }
        
        [HttpPost]
        public Result Edit(int id, DbField entity)
        {
            if (id != entity.Id)
            {
                return ResultUtil.NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var entry = _db.Update(entity);
                    _db.SaveChanges();
                    return ResultUtil.Success();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            return ResultUtil.Fail();
        }
    }
}