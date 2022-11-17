using System.Text.Json.Serialization;

namespace ListaDeCompras.API.Models
{
    public class Item
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CriadoPor { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string EditadoPor { get; private set; }
        public DateTime EditadoEm { get; private set; }
        public bool Desativado { get; private set; }
        [JsonIgnore]
        public Guid AmbienteId { get; private set; }
        public Ambiente Ambiente { get; set; }

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

        public void SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void SetEditado(string editadoPor)
        {
            this.EditadoPor = editadoPor;
            this.EditadoEm = DateTime.Now;
        }
        public void SetDesativado(bool desativado)
        {
            this.Desativado = desativado;
        }

        public void SetAmbiente(Guid ambienteId)
        {
            this.AmbienteId = ambienteId;
        }
    }
}
