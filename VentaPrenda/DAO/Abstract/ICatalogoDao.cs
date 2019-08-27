using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.DTO;

namespace VentaPrenda.DAO.Abstract
{
    public interface ICatalogoDao
    {
        CatalogoDto GetColor(short ColorID);
        CatalogoDto GetPrenda(short PrendaID);
        CatalogoDto GetTipoPrenda(short TipoPrendaID);

        DataTable GetColores();
        DataTable GetPrendas();
        DataTable GetTiposPrenda();

        CatalogoDto GuardarColor(CatalogoDto dto);
        CatalogoDto GuardarPrenda(CatalogoDto dto);
        CatalogoDto GuardarTipoPrenda(CatalogoDto dto);

        CatalogoDto EliminarColor(CatalogoDto dto);
        CatalogoDto EliminarPrenda(CatalogoDto dto);
        CatalogoDto EliminarTipoPrenda(CatalogoDto dto);
    }
}
