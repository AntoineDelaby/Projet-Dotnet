﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recap.Datas.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T?> GetById(int id);
    }
}
