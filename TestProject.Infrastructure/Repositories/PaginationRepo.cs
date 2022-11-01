using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Domain.Entities;
using TestProject.Domain.ViewModels;

namespace TestProject.Infrastructure.Repositories
{
    public class PaginationRepo: IPaginationRepo
    {
        private readonly TestDbContext _db;

        public PaginationRepo(TestDbContext db)
        {
            _db = db;
        }
        public List<BasicInfo> GetRecords(int currentPage)
        {
            int maxRows = 10;
            return _db.BasicInfo.Skip((currentPage - 1) * maxRows)
                    .Take(maxRows).ToList();
        }
    }
}
