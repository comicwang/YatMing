using iTelluro.Explorer.YatMing.Domain.Context;
using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Domain.Entities;

namespace iTelluro.Explorer.YatMing.Infrastructure.Context.Repository
{
    public class TPackageRepository : Repository<T_Package>, ITPackageRepository
    {
        public TPackageRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

    }
}
