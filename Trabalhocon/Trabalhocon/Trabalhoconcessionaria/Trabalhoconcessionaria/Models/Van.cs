using System.Numerics;
using System.Reflection;
using Trabalhoconcessionaria.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class Van : Veiculo
{
    public int CapacidadePassageiros { get; set; }

    public override string Exibirdados()
    {
        return $"Van: {Marca} {Modelo} ({Ano}) - Placa: {Placa} - {CapacidadePassageiros} assentos";
    }
}
