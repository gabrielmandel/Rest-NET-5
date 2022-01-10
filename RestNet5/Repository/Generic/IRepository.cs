﻿using RestNet5.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestNet5.Repository.Generic
{
    public interface IPersonRepository<T> where T : BaseEntity
    {
        T Create(T item);
        T Update(T item);
        T FindById(long id);
        List<T> FindAll();
        void Delete(long id);
        bool Exists(long id);

    }
}
