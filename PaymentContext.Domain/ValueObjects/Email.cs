using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects {
    public class Email : ValueObject {
        public Email (string adrress) {
            Adrress = adrress;
            AddNotifications (new Contract ()
                .Requires ()
                .IsEmail (adrress, "Email.Address", "E-mail inválido"));
        }

        public string Adrress { get; private set; }
    }
}