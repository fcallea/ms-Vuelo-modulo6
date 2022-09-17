using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Modelo
{
    public class Vuelo
    {
        public int VueloId { get; set; }
        public Guid IdVuelo { get; set; }
        public Guid IdAeropuertoOrigen { get; set; }
        public Guid IdAeropuertoDestino { get; set; }

        public int NroVuelo { get; set; }

        [StringLength(20)]
        public string? EstadoVuelo { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal MillasVuelo { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime FechaHoraAlta { get; set; }
        public ICollection<ItinerarioVuelo>? ListaItinerario { get; set; }
    }
}
