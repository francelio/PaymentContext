using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string adrress)
        {
            Adrress = adrress;
        }

        public string Adrress { get; private set; }
    }
}