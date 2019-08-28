using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentaPrenda.Model
{
    public class Perfil
    {
        public short ID { get; set; }
        public string Nombre { get; set; }
        public Permisos Permisos { get; set; }
    }

    public class Permisos
    {
        private const int NotaMask = 1;
        private const int ClientesMask = 2;
        private const int CatalogosMask = 4;
        private const int UsuariosMask = 8;
        private const int PerfilesMask = 16;
        private const int BalanceMask = 32;
        private const int ReportesMask = 64;
        private const int DescuentosMask = 128;
        private const int HistorialMask = 256;
        private const int AdmonUsuariosMask = 512;
        private const int AdmonPerfilesMask = 1024;
        private const int GeneraNotaMask = 2048;
        private const int EditaNotaMask = 4096;
        private const int EliminaNotaMask = 8192;
        private const int AdmonClientesMask = 16384;
        private const int AdmonCatalogosMask = 32768;
        private const int GeneraMovimientosMask = 65536;
        private const int AdmonMovimientosMask = 131072;

        private int _numeric;

        public Permisos()
        {
        }

        public Permisos(int num)
        {
            Numeric = num;
        }
        public int Numeric {
            get { return _numeric; }
            set { _numeric = value; } }

        public Boolean Notas
        {
            get { return ( Numeric & NotaMask) == NotaMask; }
            set {
                if(Notas != value)
                    Numeric = (value ? Numeric | NotaMask : Numeric ^ NotaMask);
            }
        }

        public Boolean Clientes
        {
            get { return (Numeric & ClientesMask) == ClientesMask; }
            set
            {
                if (Clientes != value)
                    Numeric = (value ? Numeric | ClientesMask : Numeric ^ ClientesMask);
            }
        }

        public Boolean Catalogos
        {
            get { return (Numeric & CatalogosMask) == CatalogosMask; }
            set
            {
                if (Catalogos != value)
                    Numeric = (value ? Numeric | CatalogosMask : Numeric ^ CatalogosMask);
            }
        }

        public Boolean Usuarios
        {
            get { return (Numeric & UsuariosMask) == UsuariosMask; }
            set
            {
                if (Usuarios != value)
                    Numeric = (value ? Numeric | UsuariosMask : Numeric ^ UsuariosMask);
            }
        }

        public Boolean Perfiles
        {
            get { return (Numeric & PerfilesMask) == PerfilesMask; }
            set
            {
                if (Perfiles != value)
                    Numeric = (value ? Numeric | PerfilesMask : Numeric ^ PerfilesMask);
            }
        }

        public Boolean Balance
        {
            get { return (Numeric & BalanceMask) == BalanceMask; }
            set
            {
                if (Balance != value)
                    Numeric = (value ? Numeric | BalanceMask : Numeric ^ BalanceMask);
            }
        }

        public Boolean Reportes
        {
            get { return (Numeric & ReportesMask) == ReportesMask; }
            set
            {
                if (Reportes != value)
                    Numeric = (value ? Numeric | ReportesMask : Numeric ^ ReportesMask);
            }
        }

        public Boolean Descuentos
        {
            get { return (Numeric & DescuentosMask) == DescuentosMask; }
            set
            {
                if (Descuentos != value)
                    Numeric = (value ? Numeric | DescuentosMask : Numeric ^ DescuentosMask);
            }
        }

        public Boolean Historial
        {
            get { return (Numeric & HistorialMask) == HistorialMask; }
            set
            {
                if (Historial != value)
                    Numeric = (value ? Numeric | HistorialMask : Numeric ^ HistorialMask);
            }
        }

        public Boolean AdmonUsuarios
        {
            get { return (Numeric & AdmonUsuariosMask) == AdmonUsuariosMask; }
            set
            {
                if (AdmonUsuarios != value)
                    Numeric = (value ? Numeric | AdmonUsuariosMask : Numeric ^ AdmonUsuariosMask);
            }
        }

        public Boolean AdmonPerfiles
        {
            get { return (Numeric & AdmonPerfilesMask) == AdmonPerfilesMask; }
            set
            {
                if (AdmonPerfiles != value)
                    Numeric = (value ? Numeric | AdmonPerfilesMask : Numeric ^ AdmonPerfilesMask);
            }
        }

        public Boolean GenerarNota
        {
            get { return (Numeric & GeneraNotaMask) == GeneraNotaMask; }
            set
            {
                if (GenerarNota != value)
                    Numeric = (value ? Numeric | GeneraNotaMask : Numeric ^ GeneraNotaMask);
            }
        }

        public Boolean EditarNota
        {
            get { return (Numeric & EditaNotaMask) == EditaNotaMask; }
            set
            {
                if (EditarNota != value)
                    Numeric = (value ? Numeric | EditaNotaMask : Numeric ^ EditaNotaMask);
            }
        }

        public Boolean EliminarNota
        {
            get { return (Numeric & EliminaNotaMask) == EliminaNotaMask; }
            set
            {
                if (EliminarNota != value)
                    Numeric = (value ? Numeric | EliminaNotaMask : Numeric ^ EliminaNotaMask);
            }
        }

        public Boolean AdmonClientes
        {
            get { return (Numeric & AdmonClientesMask) == AdmonClientesMask; }
            set
            {
                if (AdmonClientes != value)
                    Numeric = (value ? Numeric | AdmonClientesMask : Numeric ^ AdmonClientesMask);
            }
        }
        public Boolean AdmonCatalogos
        {
            get { return (Numeric & AdmonCatalogosMask) == AdmonCatalogosMask; }
            set
            {
                if (AdmonCatalogos != value)
                    Numeric = (value ? Numeric | AdmonCatalogosMask : Numeric ^ AdmonCatalogosMask);
            }
        }
        public Boolean GeneraMovimientos
        {
            get { return (Numeric & GeneraMovimientosMask) == GeneraMovimientosMask; }
            set
            {
                if (GeneraMovimientos != value)
                    Numeric = (value ? Numeric | GeneraMovimientosMask : Numeric ^ GeneraMovimientosMask);
            }
        }

        public Boolean AdmonMovimientos
        {
            get { return (Numeric & AdmonMovimientosMask) == AdmonMovimientosMask; }
            set
            {
                if (AdmonMovimientos != value)
                    Numeric = (value ? Numeric | AdmonMovimientosMask : Numeric ^ AdmonMovimientosMask);
            }
        }
    }    

}
