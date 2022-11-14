namespace ListaDeCompras.API.Models
{
    public abstract class Entidade
    {
        public Guid Id { get; private set; }
        public string Nome { get; set; }
        public string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public string EditadoPor { get; set; }
        public DateTime EditadoEm { get; set; }
        public bool Desativado { get; set; }

        public Entidade()
        {
            Id = new Guid();
        }
    }
}
