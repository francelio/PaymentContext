using Flunt.Validations;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects {
    public class Name : ValueObject {
        public Name (string fistName, string lastName) {
            FistName = fistName;
            LastName = lastName;    
            AddNotifications (new Contract ()
                .Requires ()
                .HasMinLen (FistName,3,"Name.FistName", "Nome deve conter pelo menos 3 caracteres ")
                .HasMinLen (LastName,3,"Name.LastName", "Sobrenome deve conter pelo menos 3 caracteres ")
                .HasMaxLen (FistName,40,"Name.FistName", "Nome deve conter até 40 caracteres "));
  
        }

        public string FistName { get; private set; }
        public string LastName { get; private set; }
    }
}