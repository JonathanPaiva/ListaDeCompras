namespace ListaDeCompras.API.Models
{
    public class Ambiente: Entidade
    {
        public Ambiente(string nome, string criadoPor, string editadoPor, bool desativado)
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
