using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaCPF
{
    public class ValidadorCPF
    {
        // Criando um método estático com retorno
        public static bool Validar(string cpf)
        {
            //int[] valores = { };
            //int soma1 = 0, soma2 = 0, resto1 = 0, resto2 = 0, dv1 = 0, dv2 = 0;
            //int j = 11;

            //for (int i = 0; i < cpf.Length; i++)
            //{   
            //    valores[i] = Convert.ToInt32(cpf.Substring(i, 1));
            //    soma1 += valores[i] * (j-i);
            //}

            string cpf2, digito;
            int soma, resto;
            digito = "10";
            return cpf.EndsWith(digito);
           

        }
    }
}
