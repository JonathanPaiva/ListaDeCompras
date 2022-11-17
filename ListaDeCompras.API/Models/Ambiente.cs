using System.Text.Json.Serialization;

namespace ListaDeCompras.API.Models
{
    public class Ambiente
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CriadoPor { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public string EditadoPor { get; private set; }
        public DateTime EditadoEm { get; private set; }
        public bool Desativado { get; private set; }
        [JsonIgnore]
        public ICollection<Item> Itens { get; private set; }

        public Ambiente(string nome, string criadoPor, string editadoPor, bool desativado)
        {
            Id = new Guid();

            Nome = nome;
            CriadoPor = criadoPor;
            EditadoPor = editadoPor;       
            Desativado = desativado;

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
            this.EditadoEm = DateTime.Now; ;
        }
        public void SetDesativado(bool desativado)
        {
            this.Desativado = desativado;
        }
    }
}
