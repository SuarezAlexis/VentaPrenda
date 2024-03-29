﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaPrenda.Model;
using VentaPrenda.Service;

namespace VentaPrenda.DTO
{
    public class UsuarioDto
    {
        public long ID { get; set; }
        public string Nombre { get; set; }
        public string Username { get; set; }
        public string Contraseña { get; set; }
        public string Confirmacion { get; set; }
        public bool Bloqueado { get; set; }
        public int IntentosFallidos { get; set; }
        public Permisos Permisos { get; set; }
        public bool Logged { get; set; }
        public DateTime UltimoIngreso { get; set; }
        public ColoresGUIDto Colores { get; set; }

        public Dictionary<PerfilDto,bool> Perfiles { get; set; }

        public UsuarioDto()
        {
            ID = -1;
            Username = "";
            Nombre = "";
            Permisos = new Permisos();
            Perfiles = new Dictionary<PerfilDto, bool>();
            UltimoIngreso = new DateTime();
            Colores = new ColoresGUIDto();
        }

        public UsuarioDto(Usuario u)
        {
            ID = u.ID;
            Nombre = u.Nombre;
            Username = u.Username;
            Contraseña = u.Contraseña;
            Bloqueado = u.Bloqueado;
            IntentosFallidos = u.IntentosFallidos;
            Permisos = u.Permisos;
            Logged = u.Logged;
            UltimoIngreso = u.UltimoIngreso;
        }

        public override string ToString()
        { return Username; }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType())) return false;
            else
            {
                if (this == obj) return true;
                UsuarioDto d = (UsuarioDto)obj;
                return ID == d.ID;
            }
        }
    }
}
