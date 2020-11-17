using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pas.Forms.Website.Data;
using System.Collections.Generic;
using System.Linq;

namespace Pas.Forms.Website.Controllers
{
    public class DbCenterController : Controller
    {
        private readonly FormsDbContext _db;

        public DbCenterController(FormsDbContext db)
        {
            _db = db;
        }

        #region 数据库

        public IActionResult Dbs()
        {
            var data = _db.Dbs.Where(x => x.IsValid).AsNoTracking().ToList();
            return Json(data);
        }
        #endregion
        
        #region 数据表

        public IActionResult DbTables(int? db, bool? fields)
        {
            var query = _db.DbTables.AsQueryable();

            if (fields.HasValue && fields.Value)
            {
                query = query.Include(x => x.Fields);
            }
            
            if (db.HasValue && db.Value > 0)
            {
                query = query.Where(x => x.DbId == db.Value);
            }

            var data = query.AsNoTracking().ToList();
            return Json(data);
        }
        #endregion
        
        #region 数据列

        public IActionResult DbFields(int table)
        {
            if (table <= 0)
            {
                return Json(new List<DbField>());
            }

            var data = _db.DbFields
                .Where(x => x.DbTableId == table)
                .AsNoTracking()
                .ToList();
            return Json(data);
        }
        #endregion
    }
}