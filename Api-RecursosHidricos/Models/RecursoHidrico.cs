using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Api_RecursosHidricos.Models {
   
   [DataContract]
    public class RecursoHidrico 
    {
        public RecursoHidrico()
        {
        }

        public RecursoHidrico(int id, string nombre, string descripcion, string tipo, string ubicacion, string estado, string fechaCreacion, string fechaModificacion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Tipo = tipo;
            Ubicacion = ubicacion;
            Estado = estado;
        }
        //Auto-incremental
        [Key]
        [DataMember (Name = "id", EmitDefaultValue = false, IsRequired = false)]
        [Column("id")]
        public int Id { get; set; }
        [DataMember (Name = "nombre", EmitDefaultValue = false, IsRequired = false)]
        //[Required(ErrorMessage = "El nombre es requerido")]
        [Column("nombre")]
        public string Nombre { get; set; }
        [DataMember (Name = "descripcion", EmitDefaultValue = false, IsRequired = false)]
        [Column("descripcion")]
        public string Descripcion { get; set; }
        [DataMember (Name = "tipo", EmitDefaultValue = false, IsRequired = false)]
        [Column("tipo")]
        public string Tipo { get; set; }
        [DataMember (Name = "ubicacion", EmitDefaultValue = false, IsRequired = false)]
        [Column("ubicacion")]
        public string Ubicacion { get; set; }
        [DataMember (Name = "estado", EmitDefaultValue = false, IsRequired = false)]
        [Column("estado")]
        public string Estado { get; set; }

    }

}
