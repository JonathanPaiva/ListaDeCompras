namespace ListaDeCompras.API.DTO
{
    public class ItemDTO
    {
        public string Nome { get; set; }
        public string CriadoPor { get; set; }
        public string EditadoPor { get; set; }
        public bool Desativado { get; set; }
        public Guid AmbienteId { get; set; }
    }
}
