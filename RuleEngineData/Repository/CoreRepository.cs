using RuleEngineContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace RuleEngineData
{
    public abstract class EfCoreRepository<T> : IGenericRepository<T> 
        where T : class, new()
        {
        public EfCoreRepository()
        {
        }


    }
}
