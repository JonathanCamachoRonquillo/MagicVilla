﻿using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Modelos
{
    public class Villa
    {
        //Crear entidades de BD desde Codigo
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        [Required]
        public double Tarifa {get; set; }

        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }

        public string ImagenURL {get; set; }
        public string Amenidad{ get; set; }
        public DateTime FechaActualizacion { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}