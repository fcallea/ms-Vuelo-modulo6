using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AeronlineaServicios.Api.Vuelos.Modelo
{
    public class ItinerarioVuelo
    {
        public int ItinerarioVueloId { get; set; }
        public int VueloId { get; set; }
        public Guid IdItinerarioVuelo { get; set; }
        public Guid IdVuelo { get; set; }
        public Guid IdTripulacion { get; set; }
        public Guid IdAeronave { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime FechaHoraCreacion { get; set; }

        //[Column(TypeName = "VARCHAR")]
        [StringLength(20)]
        public string ZonaAbordaje { get; set; }

        [StringLength(20)]
        public string NroPuertaAbordaje { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime FechaHoraAbordaje { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime FechaHoraPartida { get; set; }

        [DataType(DataType.DateTime)]
        [Column(TypeName = "DateTime")]
        public DateTime FechaHoraLLegada { get; set; }
        public int NroAsientosHabilitados { get; set; }
        public int NroAsientosDisponibles { get; set; }

        [StringLength(20)]
        public string TipoVuelo { get; set; }

        [StringLength(20)]
        public string EstadoItinerarioVuelo { get; set; }
        public Vuelo Vuelo { get; set; }
    }
}
