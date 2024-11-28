using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicPayChallenge.Infra.Validations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class Cnpj: ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value == null) return false;
            if(value is not string) return false;
            string cnpj = new string((value as string).Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14) return false;
            if (cnpj.All(c => c == cnpj[0])) return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            tempCnpj += primeiroDigito;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            return cnpj.EndsWith($"{primeiroDigito}{segundoDigito}");
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
        }
    }
}
