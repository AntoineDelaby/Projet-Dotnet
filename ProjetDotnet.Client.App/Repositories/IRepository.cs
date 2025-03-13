using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotnet.Client.App.Repositories
{
    interface IRepository<T>
    {
        Task<List<T>> GetAll();

        Task<T?> GetById(int id);


    }
}
