using Microsoft.AspNetCore.Mvc;
using Trabalhoconcessionaria.Models;

namespace Trabalhoconcessionaria.Controllers
{
    public class VeiculoController : Controller
    {
        // Encapsulamento - lista privada
        private static List<Veiculo> veiculos = new List<Veiculo>();

        public IActionResult Cadastro()
        {
            return View(); // saída de dados
        }



        [HttpPost] //Método para criar dois veiculos de classes diferentes.
        public IActionResult Cadastro(string tipo, string marca, string modelo, string placa, int ano, int? quantidadePortas, bool? temCarenagem, int? capacidadePassageiros)
        {
            if (tipo == "Carro")
            {
                Carro carro = new Carro
                {
                    Marca = marca,
                    Modelo = modelo,
                    Ano = ano,
                    Placa = placa,
                    QuantidadePortas = quantidadePortas ?? 4
                };
                veiculos.Add(carro);
            }
            else if (tipo == "Moto")
            {
                Moto moto = new Moto
                {
                    Marca = marca,
                    Modelo = modelo,
                    Ano = ano,
                    Placa = placa,
                    TemCarenagem = temCarenagem ?? false
                };
                veiculos.Add(moto);
            }
            else if (tipo == "Van")
            {
                Van van = new Van
                {
                    Marca = marca,
                    Modelo = modelo,
                    Ano = ano,
                    Placa = placa,
                    CapacidadePassageiros = capacidadePassageiros ?? 0
                };
                veiculos.Add(van);
            }

            return RedirectToAction("Lista");
        }
        public IActionResult Lista()

        {
            return View(veiculos);
        }
        public IActionResult Delete(int id)//Método para criar a função do botão delete sem usar banco de dados.
        {
            var veiculo = veiculos.FirstOrDefault(v => v.Id == id);//Aqui ele simula uma id e executa manualmente o processo para não usar banco de dados
            if (veiculo != null)
            {
                veiculos.Remove(veiculo);
            }

            return RedirectToAction("Lista");
        }

        public IActionResult Edit(int id)//Método para criar a função do botão edit
        {
            var veiculo = veiculos.FirstOrDefault(v => v.Id == id);//novamente cria uma id para simular o banco de dados manualmente
            if (veiculo == null) return NotFound();
            return View(veiculo);
        }

        [HttpPost]
        public IActionResult Edit(int id, string marca, string modelo, int ano, int? quantidadePortas, bool? temCarenagem)//Método para editar as informações que estão na lista
        {
            var veiculo = veiculos.FirstOrDefault(v => v.Id == id);
            if (veiculo == null) return NotFound();

            veiculo.Marca = marca;
            veiculo.Modelo = modelo;
            veiculo.Ano = ano;

            if (veiculo is Carro carro)//para carro puxa o variavel porta
            {
                carro.QuantidadePortas = quantidadePortas ?? 4;
            }
            else if (veiculo is Moto moto)//para moto puxa a função carenagem
            {
                moto.TemCarenagem = temCarenagem ?? false;
            }

            return RedirectToAction("Lista");
        }
    }
}
