﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Comun
{
   public interface IRepositorio<T> where T :Agregado
    {
        void Guardar(T agregado);
    }
}
