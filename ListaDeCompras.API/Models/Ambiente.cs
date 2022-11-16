namespace ListaDeCompras.API.Models
{
    public class Ambiente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public string EditadoPor { get; set; }
        public DateTime EditadoEm { get; set; }
        public bool Desativado { get; set; }

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
    }
}
