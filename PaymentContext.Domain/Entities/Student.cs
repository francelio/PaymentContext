using System.Collections.Generic;
using System.Linq;

namespace PaymentContext.Domain.Entities {
    public class Student {
        private IList<Subscription> _subscriptions;
        public Student (string fistName, string lastName, string document, string email) {
            FistName = fistName;
            LastName = lastName;
            Document = document;
            Email = email;
            _subscriptions = new List<Subscription> ();
        }

        public string FistName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray (); } }

        public void AddSubscription (Subscription subscription) {
            //se já tiver uma assinatura ativa, cancela
            //Cancela todas as outras assinaturas, e coloca esta como 
            // principal

            foreach (var sub in Subscriptions) {
                sub.Activate ();
            }

            _subscriptions.Add (subscription);
        }

    }
}