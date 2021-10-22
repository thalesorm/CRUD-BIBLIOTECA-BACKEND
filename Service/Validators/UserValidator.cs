using Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(prop => prop.Name)
            .NotEmpty().WithMessage("Insira o nome do usuário")
            .NotNull().WithMessage("Campo name vazio não permitido");

            RuleFor(c => c.CPF)
            .NotEmpty().WithMessage("Insira o CPF")
            .NotNull().WithMessage("Insira um CPF válido")
            .Must(ValidatorCPF).WithMessage("CPF Invalido");

            RuleFor(prop => prop.Email)
            .NotEmpty().WithMessage("Campo email Vazio")
            .NotNull().WithMessage("Campo email vazio não permitido");

            RuleFor(prop => prop.Telephone)
            .NotEmpty().WithMessage("Telefone Vazio")
            .NotNull().WithMessage("Campo telefone vazio não permitido");

            RuleFor(prop => prop.NickName)
            .NotEmpty().WithMessage("Apelido Vazio")
            .NotNull().WithMessage("Campo Apelido vazio não permitido");

            RuleFor(prop => prop.Telephone)
            .NotEmpty().WithMessage("Telephone Vazio")
            .NotNull().WithMessage("Campo telephone vazio não permitido");

            RuleFor(prop => prop.Password)
            .NotEmpty().WithMessage("Campo senha Vazio")
            .NotNull().WithMessage("Campo senha vazio não permitido")
                    .Must(ValidateRepeatedCharacters).WithMessage("Existem caracteres em sequencia repetidos")
                    .Matches(@"[A-Z]+").WithMessage("Sua senha deve conter pelo menos uma letra maiúscula.")
                    .Matches(@"[a-z]+").WithMessage("Sua senha deve conter pelo menos uma letra miniscula.")
                    .Matches(@"[0-9]+").WithMessage("Sua senha deve conter pelo menos um numero.")
                    .Matches(@"[\!\?\*\.\@\#\-\!]+").WithMessage("Sua senha deve conter pelo menos um (!? *.).");
        }

        private bool ValidateRepeatedCharacters(string password)
        {
            if (password.Length == 0)
            {
                return true;
            }
            char current = password[0];
            for (int i = 0; i < password.Length; i++)
            {
                char next = password[i];
                if (i != 0)
                {
                    if (next == current)
                    {
                        return false;
                    }
                    current = next;
                }

            }

            return true;
        }

        private bool ValidatorCPF(string cpf)
        {
            cpf = RemoveNaoNumericos(cpf);

            if (cpf.Length > 11)
                return false;

            while (cpf.Length != 11)
                cpf = '0' + cpf;

            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (cpf[i] != cpf[0])
                    igual = false;

            if (igual || cpf == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(cpf[i].ToString());

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
        public static string RemoveNaoNumericos(string text)
        {
            System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(@"[^0-9]");
            string ret = reg.Replace(text, string.Empty);
            return ret;
        }
    }
}
