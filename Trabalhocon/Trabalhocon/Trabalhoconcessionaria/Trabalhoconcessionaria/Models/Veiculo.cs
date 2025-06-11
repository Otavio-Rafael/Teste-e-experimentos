namespace Trabalhoconcessionaria.Models
{
    public abstract class Veiculo//classe abstrata
    {
        public int Id { get; set; } // ID simulado (manual)
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public string Placa { get; set; }
        public abstract string Exibirdados();
    }
}