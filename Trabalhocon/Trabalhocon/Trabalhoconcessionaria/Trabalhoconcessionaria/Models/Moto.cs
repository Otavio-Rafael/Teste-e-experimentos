namespace Trabalhoconcessionaria.Models
{
    public class Moto : Veiculo //classe que herda de veiculo
    {
        public bool TemCarenagem { get; set; } //cria a variavel carenagem para moto


        public override string Exibirdados() //polimorfismo
        {
            String carenagem = TemCarenagem ? "com carenagem" : "sem carenagem";
            return $"moto: {Marca} {Modelo} ({Ano}) - {carenagem}";
        }
    }
}
