//Nomeação do projeto de Registro de Notas:
namespace Notas
{
    //Criação da classe da aplicação:
    class App
    {
        //Criação do método principal da classe:
        public static void Main(string[] args)
        {
            //Executa o método de pedir notas:
            Dictionary<string, float> dados = PedirNotas();

            //Retorna os dados:
            Console.WriteLine($"{ new String('=', 30) }DADOS DAS MÉDIAS{ new String('=', 20) }" +
                $"\n\nQuantidade de alunos: { dados["quantAlunos"] }" +
                $"\nMédia de todos alunos: { dados["mediaGeral"] }" +
                $"\nMaior média: { dados["maiorMedia"] }" +
                $"\nMenor média: { dados["menorMedia"] }\n\n");
        }

        //Método que pede os valores das médias e retorna uma série de dados:
        public static Dictionary<string, float> PedirNotas() {

            //Variáveis das notas globais:
            float maior_media = float.NaN, menor_media = float.NaN, quant_alunos = 0, soma_das_medias = 0, media_geral;
            //Variáveis das notas individuais:
            float nota1, nota2, nota3, nota4, media;
            //Variável para prosseguir a execução:
            char continuar;

            //Criação da estrutura de repetição que fará enquanto a condição do while for verdadeira:
            do
            {
                //Cabeçalho da aplicação:
                Console.WriteLine($"{ new String('=', 30) }NOTA INDIVIDUAL{ new String('=', 30) }");

                //Pedido das notas:
                Console.Write("Primeira nota: ");
                nota1 = float.Parse(Console.ReadLine());

                Console.Write("Segunda nota: ");
                nota2 = float.Parse(Console.ReadLine());

                Console.Write("Terceira nota: ");
                nota3 = float.Parse(Console.ReadLine());

                Console.Write("Quarta nota: ");
                nota4 = float.Parse(Console.ReadLine());

                //Faz o calculo da média:
                media = mediaDeQuatro(nota1, nota2, nota3, nota4);

                //Retorna a maior média até então:
                maior_media = maiorMedia(media, maior_media);

                //Retorna a menor média até então:
                menor_media = menorMedia(media, menor_media);

                //Soma 1 na quantidade de alunos:
                quant_alunos++;

                //Faz a soma dessa média na variavel de soma de todas médias:
                soma_das_medias += media;

                //Perguntar se deseja continuar:
                Console.Write("\nDeseja continuar ('s' para sim)? ");
                continuar = char.Parse(Console.ReadLine());

                //Executa uma limpeza na tela:
                Console.Clear();

            } while (char.ToLower(continuar) == 's');

            //Calcula o valor da média geral:
            media_geral = soma_das_medias / quant_alunos;

            //Criação e povoação do dicionário com todos os dados:
            var dados = new Dictionary<string, float>()
            {
                { "quantAlunos", quant_alunos },
                { "mediaGeral", media_geral },
                { "maiorMedia", maior_media },
                { "menorMedia", menor_media }
            };

            //Retorno de todos os dados obtidos pelo método:
            return dados;
        }

        //Método público que retorna a média de 4 números:
        public static float mediaDeQuatro(float nota1, float nota2, float nota3, float nota4)
        {
            //Executa o calculo de média dos quatros valores:
            float media = (nota1 + nota2 + nota3 + nota4) / 4;

            //Retorna o valor da média:
            return media;
        }

        //Método público que retorna a maior média:
        public static float maiorMedia(float media, float maior_media)
        {
            //Verifica se a maior média é desconhecida ou se a média é maior do que ela:
            maior_media = (float.IsNaN(maior_media) || media > maior_media)? media : maior_media;

            //Retorna o valor da maior média:
            return maior_media;
        }

        //Método público que retorna a menor média:
        public static float menorMedia(float media, float menor_media)
        {
            //Faz os devidos testes e dá o valor da menor média de acordo com as condições:
            menor_media = (float.IsNaN(menor_media) || media < menor_media) ? media : menor_media;

            //Retorna o valor da menor média:
            return menor_media;
        }
    }
}