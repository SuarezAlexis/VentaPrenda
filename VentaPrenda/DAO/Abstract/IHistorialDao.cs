﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface IHistorialDao
    {
        HistorialDto Guardar(HistorialDto dto);
        HistorialDto GetHistorial(long id);
        DataTable GetHistorial();
    }
}
