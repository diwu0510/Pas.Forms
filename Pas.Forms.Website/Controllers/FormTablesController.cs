using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Data;
using System.Linq;
using Pas.Forms.Website.Common;

namespace Pas.Forms.Website.Controllers
{
    public class FormTablesController : Controller
    {
        private readonly FormsDbContext _db;

        public FormTablesController(FormsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index(int id)
        {
            var form = _db.Forms
                .Include(x => x.DbTable)
                .SingleOrDefault(x => x.Id == id);

            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        public Result<List<FormTable>> Get(int id)
        {
            var data = _db.FormTables
                .Include(x => x.DbTable)
                .Where(x => x.FormId == id).ToList();
            return ResultUtil.Success(data);
        }

        public IActionResult Create(int formId)
        {
            var form = _db.Forms
                .Include(x => x.DbTable)
                .ThenInclude(x => x.Fields)
                .SingleOrDefault(x => x.Id == formId);

            if (form == null)
            {
                return NotFound();
            }

            var tables = _db.DbTables
                .Where(x => x.DbId == form.DbTable.DbId)
                .ToList();

            var data = tables.Select(table => new SelectListItem($"[{table.Name}] {table.Title}", table.Id.ToString())).ToList();

            ViewBag.Tables = data;
            ViewBag.Fields = form.DbTable.Fields.Select(x => new SelectListItem($"[{x.Field}] {x.Title}", x.Field)).ToList();

            var entity = new FormTable { FormId = formId };
            ViewBag.Form = form.Title;

            return View(entity);
        }

        [HttpPost]
        public Result Create(FormTable entity)
        {
            if (ModelState.IsValid)
            {
                _db.FormTables.Add(entity);
                _db.SaveChanges();

                return ResultUtil.Success();
            }

            return ResultUtil.Fail();
        }
    }
}
