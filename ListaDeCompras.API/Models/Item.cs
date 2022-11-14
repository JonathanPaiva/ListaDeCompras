namespace ListaDeCompras.API.Models
{
    public class Item : Entidade
    {
        public Guid SetorId { get; private set; }
        public Setor Setor { get; private set; }

        public Item(string nome, string criadoPor, string editadoPor, bool desativado)
        {
            Nome = nome;
            CriadoPor = criadoPor;
            CriadoEm = DateTime.Now;
            EditadoPor = editadoPor;
            EditadoEm = DateTime.Now;
            Desativado = desativado;
        }
    }
}
