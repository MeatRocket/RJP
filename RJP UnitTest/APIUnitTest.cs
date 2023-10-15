using RJP.DataAccess;
using RJP.Mock_Database;
using RJP.Model;

namespace RJP_UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ReturnNullCustomerTest()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(0);

            Assert.IsNull(customer);
        }

        [Test]
        public void ReturnCustomerTest()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(1);

            Assert.IsNotNull(customer);
        }

        [Test]
        public void GetAndCompareCustomerFromCustomerMockDbTest()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(1);

            Customer? TestCusomter = MockCustomers.Customers.FirstOrDefault(x => x.Id == 1);

            Assert.AreEqual(TestCusomter, customer);
        }

        [Test]
        public void GetAndCompareCustomerWithStaticCustomerClassTest()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(1);

            Customer? TestCusomter = new Customer() { Id = 1, FirstName = "Mohammad", LastName = "Mohammad", DateCreated = DateTime.Parse("14 10 2023") };

            Assert.AreNotEqual(TestCusomter, customer);
        }

        [Test]
        public void GetandCheckIfCustomerAccountsAreNoEmpty()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(1);

            Assert.IsNotNull(customer.Accounts);
        }

        [Test]
        public void GetandCheckIfCustomerTransactionsAreNotEmpty()
        {
            Customer? customer = new Customer();

            CustomersDataAccess customersDataAccess = new CustomersDataAccess();

            customer = customersDataAccess.GetCustomerById(1);

            Assert.IsNotNull(customer.Accounts.FirstOrDefault().Transactions);
        }

        [Test]
        public void CreateNullCustomerAccountTest()
        {
            Customer? customer = new Customer();

            AccountsDataAccess accountsDataAccess = new AccountsDataAccess();

            CustomersDataAccess customerDataAccess = new CustomersDataAccess();

            List<Account> Accounts = new();

            Accounts = accountsDataAccess.GetAllAccounts().OrderByDescending(x => x.Id).ToList();

            int? LatestAccountId = Accounts != null && Accounts.Count > 0 ? Accounts.FirstOrDefault().Id : 0;

            bool IsCreated = accountsDataAccess.CreateAccount(0, 1400);

            Assert.IsTrue(!IsCreated);
        }

        [Test]
        public void CreateCustomerAccountTest()
        {
            Customer? customer = new Customer();

            AccountsDataAccess accountsDataAccess = new AccountsDataAccess();

            CustomersDataAccess customerDataAccess = new CustomersDataAccess();

            List<Account> Accounts = new();

            Accounts = accountsDataAccess.GetAllAccounts().OrderByDescending(x => x.Id).ToList();

            int? LatestAccountId = Accounts != null && Accounts.Count > 0 ? Accounts.FirstOrDefault().Id : 0;

            bool IsCreated = accountsDataAccess.CreateAccount(1, 1400);

            Assert.IsTrue(IsCreated);
        }

        [Test]
        public void CheckIfCreatedAccountIdAutoIncrementsTest()
        {
            Customer? customer = new Customer();

            AccountsDataAccess accountsDataAccess = new AccountsDataAccess();

            CustomersDataAccess customerDataAccess = new CustomersDataAccess();

            List<Account> Accounts = new();

            customer = customerDataAccess.GetCustomerById(1);

            Accounts = accountsDataAccess.GetAllAccounts().OrderByDescending(x => x.Id).ToList();

            int? LatestAccountId = Accounts != null && Accounts.Count > 0 ? Accounts.FirstOrDefault().Id : 0;

            accountsDataAccess.CreateAccount(customer.Id, 1400);

            Assert.IsTrue(LatestAccountId + 1 == accountsDataAccess.GetLastAccount().Id);
        }


    }
}