using System.Text.Json.Serialization;

namespace ListaDeCompras.API.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public string EditadoPor { get; set; }
        public DateTime EditadoEm { get; set; }
        public bool Desativado { get; set; }
        public Guid AmbienteId { get; set; }
        [JsonIgnore]
        public Ambiente Ambiente { get; set; }

        public Item()
        {

        }

        public Item(string nome, string criadoPor, string editadoPor, bool desativado, Guid ambienteId)
        {
            Id = new Guid();
            
            Nome = nome;
            CriadoPor = criadoPor;
            EditadoPor = editadoPor;
            Desativado = desativado;

            AmbienteId = ambienteId;

            CriadoEm = DateTime.Now;
            EditadoEm = DateTime.Now;
        }
    }
}
