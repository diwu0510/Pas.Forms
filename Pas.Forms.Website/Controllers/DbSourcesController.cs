using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Pas.Forms.Website.Common;
using Pas.Forms.Website.Data;
using Microsoft.EntityFrameworkCore;

namespace Pas.Forms.Website.Controllers
{
    public class DbSourcesController : Controller
    {
        private readonly FormsDbContext _db;

        public DbSourcesController(FormsDbContext db)
        {
            _db = db;
        }

        #region 列表
        public IActionResult Index()
        {
            return View();
        }

        public Result<List<DbSource>> Get()
        {
            var data = _db.DbSources
            .Include(x => x.Db)
            .AsNoTracking()
            .ToList();
            return ResultUtil.Success(data);
        }
        #endregion
        
        #region 按id查找

        
        #endregion
        
        #region 增
        
        public IActionResult Create()
        {
            var dbs = _db.Dbs.Where(x => x.IsValid).AsNoTracking().ToList();
            ViewBag.Dbs = dbs.Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();
            return View();
        }

        [HttpPost]
        public Result Create(DbSource entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.DbSources.Add(entity);
                    _db.SaveChanges();
                    return ResultUtil.Success();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return ResultUtil.Fail(e.Message);
                }
            }

            return ResultUtil.Fail(ModelState);
        }
        
        #endregion
        
        #region 改
        public IActionResult Edit(int id)
        {
            var dbs = _db.Dbs.Where(x => x.IsValid).AsNoTracking().ToList();
            ViewBag.Dbs = dbs.Select(x => new SelectListItem(x.Title, x.Id.ToString())).ToList();

            var entity = _db.Find<DbSource>(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        public Result Edit(int id, DbSource entity)
        {
            if (id != entity.Id)
            {
                return ResultUtil.NotFound();
            }

            try
            {
                _db.DbSources.Update(entity);
                _db.SaveChanges();
                return ResultUtil.Success();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return ResultUtil.Fail(e.Message);
            }
        }
        #endregion

        #region 删
        #endregion

        #region 获取数据

        public Result<DataSourceResult> GetDataById(int id)
        {
            var source = _db.DbSources
                .Include(x => x.Db)
                .SingleOrDefault(x => x.Id == id);

            if (source == null) return ResultUtil.Fail<DataSourceResult>(null, "");

            using var conn = new SqlConnection(source.Db.ConnectionString);
            var data = conn.Query(source.Sql);

            var dsr = new DataSourceResult {Data = data, Titles = source.Fields.Split('|')};

            return ResultUtil.Success(dsr);
        }

        [HttpPost]
        public Result<DataSourceResult> GetSourceData([FromBody]DataSourceRequest request)
        {
            var source = _db.DbSources
                .Include(x => x.Db)
                .SingleOrDefault(x => x.Id == request.Id);

            if (source == null) return ResultUtil.Fail<DataSourceResult>(null, "没找到");

            var param = new DynamicParameters();
            if (request.Data != null)
            {
                param.AddDynamicParams(request.Data);
            }

            using var conn = new SqlConnection(source.Db.ConnectionString);
            var data = conn.Query(source.Sql, param);

            var dsr = new DataSourceResult { Data = data, Titles = source.Fields.Split('|') };

            return ResultUtil.Success(dsr);
        }
        #endregion
    }

    public class DataSourceResult
    {
        public object Data { get; set; }

        public string[] Titles { get; set; }
    }

    public class DataSourceRequest
    {
        public int Id { get; set; }

        public object Data { get; set; }
    }
}