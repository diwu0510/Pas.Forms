using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Common;
using Pas.Forms.Website.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pas.Forms.Website.Controllers
{
    public class FormsController : Controller
    {
        private readonly FormsDbContext _db;

        public FormsController(FormsDbContext db)
        {
            _db = db;
        }

        #region 列表
        public IActionResult Index()
        {
            var data = _db.Forms
                .Include(x => x.DbTable)
                .AsNoTracking()
                .ToList();
            return View(data);
        }

        public PageListResult<Form> Get(int pageIndex = 1, int pageSize = 20)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;

            var query = _db.Forms.AsQueryable();
            var count = query.Count();
            var data = query
                .Include(x => x.DbTable)
                .OrderByDescending(x => x.Id)
                .AsNoTracking()
                .ToList();

            return ResultUtil.PageList(count, data, pageIndex, pageSize);
        }
        #endregion
        
        #region 按id查找

        
        #endregion
        
        #region 增
        
        public IActionResult Create()
        {
            SetPageData();
            return View();
        }

        [HttpPost]
        public Result Create(Form entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Forms.Add(entity);
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
        
        #endregion
        
        #region 改
        public IActionResult Edit(int id)
        {
            var entity = _db.Find<Form>(id);
            if (entity == null)
            {
                return NotFound();
            }

            SetPageData();
            return View(entity);
        }

        [HttpPost]
        public Result Edit(int id, Form entity)
        {
            if (id != entity.Id)
            {
                return ResultUtil.Fail();
            }

            try
            {
                var entry = _db.Update(entity);
                entry.Property(x => x.DbTableId).IsModified = false;
                entry.Property(x => x.Fields).IsModified = false;
                _db.SaveChanges();
                return ResultUtil.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ResultUtil.Fail();
        }
        #endregion

        #region 删
        #endregion

        #region 加载页面数据

        private void SetPageData()
        {
            var dbs = _db.Dbs.Where(x => x.IsValid)
                .Include(x => x.Tables)
                .ToList();

            var data = new List<SelectListItem>();
            foreach (var db in dbs)
            {
                var group = new SelectListGroup { Name = db.Title };
                if (db.Tables != null && db.Tables.Count > 0)
                {
                    foreach (var table in db.Tables)
                    {
                        data.Add(new SelectListItem(table.Title, table.Id.ToString()) {Group = group});
                    }
                }
            }

            ViewBag.Dbs = data;
        }
        #endregion

        #region 设计

        public IActionResult Design(int id)
        {
            var form = _db.Forms
                .Include(x => x.DbTable)
                .ThenInclude(x => x.Fields)
                .Include(x => x.FormTables)
                .ThenInclude(x => x.DbTable)
                .SingleOrDefault(x => x.Id == id);

            return View(form);
        }

        [HttpPost]
        public Result Design(int id, List<FormField> fileds) 
        {
            return default;
        }
        #endregion
    }
}