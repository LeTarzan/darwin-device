using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DispositivoDarwin
{
    public class Calculos
    {
        Random rnd = new Random();

        public string gerarLetra()
        {
            int n = rnd.Next(65, 91);
            string s = ((char)n).ToString();
            return s;
        }

        public string gerarPalavra(int n)
        {
            string palavra = "";
            for (int i = 0; i < n; i++)
            {
                palavra += gerarLetra();
            }
            return palavra;
        }

        public int calcDistChar(char n1, char n2)
        {
            int d = Math.Abs(n1 - n2);
            return d;
        }

        public int calcDistString(string s1, string s2)
        {
            int tam = s1.Length - 1;
            int dist = 0;
            for (; tam >= 0; tam--)
            {
                dist += calcDistChar(s1[tam], s2[tam]);
            }
            return dist;
        }
        public string gerarFilhos(string pai, int nl)
        {
            int nLetras = pai.Length;
            int letraEscolhida = rnd.Next(0, nLetras);
            char letra = pai[letraEscolhida];
            int s = (char)letra;
            nl = rnd.Next(-nl, nl + 1);
            s += nl;
            letra = (char)s;
            string novaPalavra = "";
            for (int i = 0; i < pai.Length; i++)
            {
                if (i == letraEscolhida)
                {
                    novaPalavra += letra;
                }
                else
                {
                    novaPalavra += pai[i];
                }
            }
            // pai[letraEscolhida] = letra;

            return novaPalavra;
        }
    }
}
