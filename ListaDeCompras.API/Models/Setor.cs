namespace ListaDeCompras.API.Models
{
    public class Setor: Entidade
    {
        public Setor(string nome, string criadoPor, string editadoPor, bool desativado)
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
