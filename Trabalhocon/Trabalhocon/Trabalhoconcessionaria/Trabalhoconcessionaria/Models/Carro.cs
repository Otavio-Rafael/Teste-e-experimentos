namespace Trabalhoconcessionaria.Models
{
    public class Carro : Veiculo //Classe que herda de veiculo
    {
        public int QuantidadePortas { get; set; } //cria a variavel porta só para carro

        public override string Exibirdados() //polimorfismo
        {
            return $"Carro: {Marca} {Modelo} ({Ano}) - {QuantidadePortas} portas";
        }
    }
}
