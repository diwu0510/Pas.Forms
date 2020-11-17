using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Common;
using Pas.Forms.Website.Data;
using System;
using System.Linq;

namespace Pas.Forms.Website.Controllers
{
    public class DbTablesController : Controller
    {
        private readonly FormsDbContext _db;

        public DbTablesController(FormsDbContext db)
        {
            _db = db;
        }

        #region 列表
        public IActionResult Index()
        {
            return View();
        }

        public PageListResult<DbTableDto> Get(int pageIndex = 1, int pageSize = 20)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;
            pageSize = pageSize < 1 ? 1 : pageSize;

            var query = _db.DbTables
                .Include(x => x.Db);

            var count = query.Count();
            var data = query
                .OrderByDescending(x => x.Id)
                .Skip((pageIndex - 1) * pageSize) 
                .Take(pageSize)
                .AsNoTracking()
                .Select(x => new DbTableDto
                {
                    Id = x.Id,
                    Db = x.Db.Title,
                    Name = x.Name,
                    Title = x.Title
                })
                .ToList();

            return ResultUtil.PageList(count, data, pageIndex, pageSize);
        }
        #endregion

        #region 字段预览

        public IActionResult Fields(int id)
        {
            var data = _db.DbFields.Where(x => x.DbTableId == id).ToList();
            return View(data);
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
        public Result Create(DbTable entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.DbTables.Add(entity);
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
            var entity = _db.Find<DbTable>(id);
            if (entity == null)
            {
                return NotFound();
            }

            SetPageData();
            return View(entity);
        }

        [HttpPost]
        public Result Edit(int id, DbTable entity)
        {
            if (id != entity.Id)
            {
                return ResultUtil.NotFound();
            }

            try
            {
                _db.Update(entity);
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
                .ToList();
            ViewBag.Dbs = dbs.Select(x => 
                new SelectListItem(x.Title, x.Id.ToString())).ToList();
        }
        #endregion
    }

    public class DbTableDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Name { get; set; }

        public string Db { get; set; }
    }
}