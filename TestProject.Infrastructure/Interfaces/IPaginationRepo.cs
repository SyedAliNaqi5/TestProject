using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.Domain.Entities;

namespace TestProject.Infrastructure.Interfaces
{
    public interface IPaginationRepo
    {
        List<BasicInfo> GetRecords(int currentPage);
    }
}
