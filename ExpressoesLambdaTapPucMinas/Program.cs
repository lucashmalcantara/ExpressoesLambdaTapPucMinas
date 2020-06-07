using System;

namespace ExpressoesLambdaTapPucMinas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\t\tExercícios Expressões lambda - TAP PUC Minas");
            Console.WriteLine("---------------------------------------------------------------");

            OperacoesDiversas();
            ExibirProximosNumerosPrimos();

            Console.ReadLine();
        }

        private static void OperacoesDiversas()
        {
            Func<string, float, float, float> indiceMassaCorporal =
                (nome, peso, altura) => peso / (altura * altura);

            Func<double, double, double, double> mediaNumeros =
                (a, b, c) => (a + b + c) / 3;

            Func<double, double, double, double> desvioPadrao =
                (a, b, c) =>
                {
                    double media = mediaNumeros(a, b, c);
                    double soma = Math.Pow(a - media, 2) + Math.Pow(b - media, 2) + Math.Pow(c - media, 2);
                    double resultadoDesvioPadrao = soma / 2;
                    return resultadoDesvioPadrao;
                };

            Action<int, int, int> exibirAreaTrapezio =
                (baseMaior, baseMenor, altura) =>
                {
                    double area = ((baseMaior + baseMenor) * altura) / 2;
                    Console.WriteLine($"A área do trapézio é: {area}");
                };

            Func<float, float> converterParaFahrenheit =
                (grausCentigrados) => (9 * grausCentigrados + 160) / 5;

            Func<float, float> converterParaCentigrados =
                (grausFahrenheit) => (grausFahrenheit - 32) / 5 / 9;

            Func<decimal, decimal, int, decimal> calcularTaxa =
                (valor, taxa, tempo) => valor + (valor * (taxa / 100) * tempo);

            Action saudarUsuario =
                () =>
                {
                    string mensagemSaudacao;

                    if (DateTime.Now.Hour < 12)
                        mensagemSaudacao = "Bom dia, amigo(a)!";
                    else if (DateTime.Now.Hour < 18)
                        mensagemSaudacao = "Boa tarde, amigo(a)!";
                    else
                        mensagemSaudacao = "Boa noite, amigo(a)!";

                    Console.WriteLine(mensagemSaudacao);
                };


            Console.WriteLine("=== Operações Diversas ===");

            Console.WriteLine($"a) Lucas pesa 60 Kg e mede 1.72 m, seu IMC é: {indiceMassaCorporal("Lucas", 60, 1.72f)}");

            Console.WriteLine($"b) O desvio padrão de 10, 15 e 20 é: {desvioPadrao(10, 15, 20)}");

            Console.WriteLine($"c) Um trapézio possui as seguintes medidas: base maior = 20; base menor = 15; altura = 10.");
            exibirAreaTrapezio(20, 15, 10);

            Console.WriteLine($"d) 30 °C equivale a {converterParaFahrenheit(30f)} °F.");

            Console.WriteLine($"e) 30 °F equivale a {converterParaCentigrados(30f)} °C.");

            Console.WriteLine($"f) Uma taxa de 5% aplicada sobre R$ 150,00 por 12 meses resultará em: R${calcularTaxa(150, 5, 12)}");

            Console.WriteLine($"g) Saudações!");
            saudarUsuario();
        }

        private static void ExibirProximosNumerosPrimos()
        {
            Console.WriteLine("=== Exibir Próximos Números Primos ===");
            Action proximoNumeroPrimo = CriarActionProximoNumeroPrimo();

            proximoNumeroPrimo();
            proximoNumeroPrimo();
            proximoNumeroPrimo();
            proximoNumeroPrimo();
            proximoNumeroPrimo();
            proximoNumeroPrimo();

            Console.ReadLine();
        }

        public static Action CriarActionProximoNumeroPrimo()
        {
            int x = 1;

            Action proximoNumeroPrimo = () =>
            {
                Func<int, int, bool> Primos = null;

                Primos = (x, y) => (y == 1) 
                ? true : 
                (x % y != 0 && Primos(x, y - 1));

                Func<int, bool> isPrimo = x => Primos(x, x / 2);

                x++;
                Console.WriteLine(x);
            };

            return proximoNumeroPrimo;
        }
    }
}
