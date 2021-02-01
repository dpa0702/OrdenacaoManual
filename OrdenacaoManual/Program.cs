/*

> Ola, candidato!
> No codigo a seguir temos um problema: os numeros nao estao sendo ordenados!
> Altere o que for necessario para que a saida para o usuario fique coerente.

> Valendo 6 pontos: Ordene os numeros sem usar Linq ou Generics.
>> Nao use metodos como Sort(), OrderBy(), OrderByDescending(), pois queremos analisar a sua logica para resolver o problema de ordenacao.
> Valendo 2 pontos: Chame o metodo comparar(int a, int b) no seu codigo.
> Valendo 2 pontos: Caso haja tempo, arrume o algoritmo para apagar os numeros repetidos.
>> Nao use metodos como Distinct(), Contains() ou outros do Linq, pois queremos analisar a sua logica para resolver o problema.
>> Entregue a prova mesmo que nao consiga fazer esse item, ok? Nao esqueca de deixar o codigo funcionando.

> Clique em "fork" (caso esse botao exista) para criar uma versao sua desse codigo, para que seja possivel altera-lo.
> Ao finalizar, copie a URL da pagina e passe para o RH.
> Para executar o codigo, clique em "run" ou aperte "Ctrl + Enter".

>>>>> Boa sorte!

*/

using System; // use somente a namespace System, nao adicione outras

namespace OrdenacaoManual
{
    class Program
    {
        public static void Main(string[] args)
        {
            // nao altere essa linha...
            int?[] numerosDesordenados = new int?[] { 3, 4, 1, 10, null, 5, 2, null, 3, 5, -10, -9, 5 };

            try
            {
                Console.WriteLine("Numeros desordenados:");
                mostrarNumeros(numerosDesordenados);

                Console.WriteLine();

                int?[] numerosOrdenados = removeRepeticao(ordenarNumeros(numerosDesordenados));

                Console.WriteLine("Numeros ordenados:");
                mostrarNumeros(numerosOrdenados);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static int?[] ordenarNumeros(int?[] numeros)
        {
            int aux = 0;

            for (int a = 0; a < numeros.Length; a++)
            {
                for (int b = 0; b < numeros.Length; b++)
                {
                    //if (numeros[a] < numeros[b])
                    //{
                    //    aux = numeros[a].HasValue ? numeros[a].Value : 0;
                    //    numeros[a] = numeros[b];
                    //    numeros[b] = aux;
                    //}
                    if (comparar(numeros[a].HasValue ? numeros[a].Value : 0, numeros[b].HasValue ? numeros[b].Value : 0) == -1)
                    {
                        aux = numeros[a].HasValue ? numeros[a].Value : 0;
                        numeros[a] = numeros[b];
                        numeros[b] = aux;
                    }
                }
            }

            return numeros;
        }

        private static int?[] removeRepeticao(int?[] numeros)
        {
            int?[] numerosUnicos = new int?[15];

            for (int a = 0; a <= numeros.Length - 2; a++)
            {
                int anterior = numeros[a].HasValue ? numeros[a].Value : 0;
                int posterior = numeros[a + 1].HasValue ? numeros[a + 1].Value : 0;
                if (anterior != posterior)
                {
                    numerosUnicos[a] = anterior;
                }
            }

            return numerosUnicos;
        }

        // Retorna -1 se a < b, +1 se a > b e 0 se a = b
        private static int comparar(int a, int b)
        {
            if (a < b)
                return -1;

            if (a > b)
                return 1;

            return 0;
        }

        private static void mostrarNumeros(int?[] numeros)
        {
            if (numeros == null)
                throw new ArgumentNullException("\"numeros\" nao pode ser nulo.");

            int qtdeIgnorados = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].HasValue)
                    qtdeIgnorados++;
            }

            int[] numerosSemNulos = new int[numeros.Length - qtdeIgnorados];
            int idxNumerosOrdenados = 0;

            for (int i = 0; i < numeros.Length; i++)
            {
                if (!numeros[i].HasValue)
                    continue;

                numerosSemNulos[idxNumerosOrdenados] = numeros[i].Value;
                idxNumerosOrdenados++;
            }

            mostrarNumeros(numerosSemNulos);
        }

        private static void mostrarNumeros(int[] numeros)
        {
            if (numeros == null)
                throw new ArgumentNullException("\"numeros\" nao pode ser nulo.");

            Console.WriteLine(string.Join(", ", numeros));
        }
    }
}
