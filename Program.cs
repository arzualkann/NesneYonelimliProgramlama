namespace NesneYonelimliProgramlama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager=new CustomerManager(new Customer(),new TeacherCreditManager());
            customerManager.GiveCredit();
        }
        class CreditManager
        {
            public void Calculate()
            {
                Console.WriteLine("Hesaplandı");
            }
            public void Save()
            {
                Console.WriteLine("Kredi verildi");
            }
        }
        interface ICreditManager
        {
            void Calculate(); //imza; yani metotun sadece ne döndürdüğünü ,ismini ve varsa parametrelerini yazıyoruz.

            void Save();
        }
        class TeacherCreditManager : ICreditManager
        {
            public void Calculate()
            {
                Console.WriteLine("Öğretmen kredisi uygulandı");
            }

            public void Save()
            {
                throw new NotImplementedException();
            }
        }
        class MilitaryCreditManager : ICreditManager
        {
            public void Calculate()
            {
                Console.WriteLine("Asker kredisi hesaplandı");

            }

            public void Save()
            {
                throw new NotImplementedException();
            }
        }
        class Customer
        {
            public Customer() // contructor newlendiğinde çalışır
            {
                Console.WriteLine("Müşteri nesnesi başlatıldı");
            }
            public int  Id { get; set; }        
            public string City { get; set; }
        }
        class Person:Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string NationalIdentity { get; set; }
        }
        class Company: Customer
        {
            public string CompanyName { get; set; }
            public string TaxNumber { get; set; }
        }  
        //Katmanlı Mimamriler yani görevleri birbirinden kesinlikle ayırıyoruz.
        class CustomerManager
        {
            private Customer _customer;
            private ICreditManager _creditManager;//sadece bu classın içinde kullanılabilir demek(private)

            public CustomerManager(Customer customer,ICreditManager creditManager)
            {
                _customer=customer;//customer'a ulaşmak için yazılır.
                _creditManager=creditManager;
            }
            public void Save() 
            {
             Console.WriteLine("Müşteri kaydedildi: ");
            }
            public void Delete() 
            {
              Console.WriteLine("Müşteri silindi: ");
            }
            public void GiveCredit()
            {
                _creditManager.Calculate();
            }
        }

    }
}
