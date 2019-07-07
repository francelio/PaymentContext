using Flunt.Validations;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects {
    public class Document : ValueObject {
        public Document (string number, EDocumentType type) {
            Number = number;
            Type = type;
            AddNotifications (new Contract ()
                .Requires ()
                .IsTrue (Validate (), "Document.Number", "Documento inválido"));
        }
        public string Number { get; private set; }
        public EDocumentType Type { get; private set; }
        private bool Validate () {

            if (Type == EDocumentType.CNPJ) {

                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                Number = Number.Trim ();
                Number = Number.Replace (".", "").Replace ("-", "").Replace ("/", "");
                if (Number.Length != 14)
                    return false;
                tempCnpj = Number.Substring (0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse (tempCnpj[i].ToString ()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString ();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse (tempCnpj[i].ToString ()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString ();
                return Number.EndsWith (digito);

            }
            if (Type == EDocumentType.CPF) {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                Number = Number.Trim ();
                Number = Number.Replace (".", "").Replace ("-", "");
                if (Number.Length != 11)
                    return false;
                tempCpf = Number.Substring (0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse (tempCpf[i].ToString ()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString ();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse (tempCpf[i].ToString ()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString ();
                return Number.EndsWith (digito);
            }
            return false;

        }

    }
}