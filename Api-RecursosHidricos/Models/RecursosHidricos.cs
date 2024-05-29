using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api_RecursosHidricos.Models {
   
   [DataContract]
    public class RecursosHidricos
    {
        public RecursosHidricos()
        {
        }

        public RecursosHidricos(int id, string nombre, string descripcion, string tipo, string ubicacion, string estado, string fechaCreacion, string fechaModificacion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Tipo = tipo;
            Ubicacion = ubicacion;
            Estado = estado;
            FechaCreacion = fechaCreacion;
            FechaModificacion = fechaModificacion;
        }
        //Auto-incremental
        [Key]
        [DataMember (Name = "id", EmitDefaultValue = false, IsRequired = false)]
        public int Id { get; set; }
        [DataMember (Name = "nombre", EmitDefaultValue = false, IsRequired = false)]
        //[Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        [DataMember (Name = "descripcion", EmitDefaultValue = false, IsRequired = false)]
        public string Descripcion { get; set; }
        [DataMember (Name = "tipo", EmitDefaultValue = false, IsRequired = false)]
        public string Tipo { get; set; }
        [DataMember (Name = "ubicacion", EmitDefaultValue = false, IsRequired = false)]
        public string Ubicacion { get; set; }
        [DataMember (Name = "estado", EmitDefaultValue = false, IsRequired = false)]
        public string Estado { get; set; }
        [DataMember (Name = "fecha_creacion", EmitDefaultValue = false, IsRequired = false)]
        public string FechaCreacion { get; set; }
        [DataMember (Name = "fecha_modificacion", EmitDefaultValue = false, IsRequired = false)]
        public string FechaModificacion { get; set; }
    }

}
