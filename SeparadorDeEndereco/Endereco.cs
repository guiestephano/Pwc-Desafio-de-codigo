using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeparadorDeEndereco
{
    internal class Endereco
    {
        private string _rua;
        private string _numero;
        private bool _temArtOuPrepAuxiliar = false;
        private bool _extraordinarioAuxiliar = false;

        public Endereco(string endereco)
        {
            SplitEndereco(endereco);
        }

        /*
         * SplitEndereco() separa o endereço concadenato em um vetor para ser analisado depois
         * analiza para dizer o que é nome de rua e o que é numero para alocar a strig a variavel.
         */
        private void SplitEndereco(string endereco)
        {

            endereco = endereco.Replace(",", "");
            string[] VetEndereco = endereco.Split(' ');

            TemArtigoOuPreposicao(VetEndereco);
            CasoExtraordinario(VetEndereco);

            if (!_extraordinarioAuxiliar)
            {

                for (int i = 0; i < VetEndereco.Length; i++)
                {
                    if (TemNumero(VetEndereco[i]))
                    {
                        _numero += VetEndereco[i];
                    }
                    else if (VetEndereco[i].Length > 1)
                    {
                        _rua += VetEndereco[i];
                        _rua += " ";
                    }
                    else if (!_temArtOuPrepAuxiliar)
                    {
                        _numero += VetEndereco[i];
                    }
                    else if (i > 0 && TemNumero(VetEndereco[i - 1]))
                    {
                        _numero += VetEndereco[i];
                    }
                    else
                    {
                        _rua += VetEndereco[i];
                        _rua += " ";
                    }

                }
            }
            else
            {
                for (int i = 0; i < VetEndereco.Length; i++)
                {
                    if (VetEndereco[i] == "No" && TemNumero(VetEndereco[i + 1]))
                    {
                        _numero += VetEndereco[i];
                        _numero += " ";
                        _numero += VetEndereco[i + 1];
                        i++;
                    }
                    else
                    {
                        _rua += VetEndereco[i];
                        _rua += " ";
                    }
                }

            }
        }

        // TemNumero() verifica se dentro de uma string possui numero.
        private bool TemNumero(string s)
        {
            foreach (char c in s)
            {
                if (c >= '0' && c <= '9')
                {
                    return true;
                }
            }
            return false;
        }

        /*
         *  TemArtigoOuPreposicao() verifica se dentro do vetor de string possui artigo
         *  ou preposiçao para saber se a letra isolada pertence ao nome da rua ou ao numero:
         *  Ex: Rua Pedro e João, 27 ou Rua A america, 45 b
         */
        private void TemArtigoOuPreposicao(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (i == 0)
                {
                    if (s[i].Length == 1 && !TemNumero(s[i]))
                    {
                        _temArtOuPrepAuxiliar = true;
                    }
                }
                else
                {
                    if (s[i].Length == 1 && !TemNumero(s[i]) && !TemNumero(s[i - 1]))
                    {
                        _temArtOuPrepAuxiliar = true;
                    }
                }
            }
        }

        /*
         *  CasoExtrordinario() verifica se o endereço está numa formatação diferente do convencional
         *  Ex: Calle 44 No 1991
         */
        private void CasoExtraordinario(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == "No" && TemNumero(s[i + 1]))
                {
                    _extraordinarioAuxiliar = true;
                }
            }
        }

        // O override do ToString() gera uma formataçao padão ao imprimir o objeto
        public override string ToString()
        {
            return $"Rua: {_rua}, Numero: {_numero}";
        }
    }
}
