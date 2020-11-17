using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Pas.Forms.Website.Common;
using Pas.Forms.Website.Data;

namespace Pas.Forms.Website.Controllers
{
    public class DbsController : Controller
    {
        private readonly FormsDbContext _db;

        public DbsController(FormsDbContext db)
        {
            _db = db;
        }

        #region 列表
        public IActionResult Index()
        {
            return View();
        }

        public Result<List<Db>> Get()
        {
            var data = _db.Dbs.ToList();
            return ResultUtil.Success(data);
        }
        #endregion
        
        #region 按id查找

        
        #endregion
        
        #region 增
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public Result Create(Db entity)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _db.Dbs.Add(entity);
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
            var entity = _db.Find<Db>(id);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        [HttpPost]
        public Result Edit(int id, Db entity)
        {
            if (id != entity.Id)
            {
                return ResultUtil.NotFound();
            }

            try
            {
                var origin = _db.Find<Db>(id);
                
                origin.Title = entity.Title;
                if (origin.ConnectionString != entity.ConnectionString)
                {
                    origin.ConnectionString = entity.ConnectionString;
                    origin.IsValid = false;
                }

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
        
        #region 验证链接字符串

        [HttpPost]
        public Result Check(int id)
        {
            var entity = _db.Dbs.Find(id);
            if (entity == null || string.IsNullOrWhiteSpace(entity.ConnectionString))
            {
                return ResultUtil.NotFound();
            }

            var isValid = Task.Run(() => CheckDbConnectionStringIsValid(entity.ConnectionString)).Result;

            entity.IsValid = isValid;
            _db.SaveChanges();

            return isValid ? ResultUtil.Success() : ResultUtil.Fail("连接字符串无效");
        }
        #endregion
        
        #region 验证连接字符串是否有效
        
        private bool CheckDbConnectionStringIsValid(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        #endregion
    }
}