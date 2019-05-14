using System;
using Castle.Core.Logging;

namespace UnitTest.Templates.SupportUnitTest
{
    public class TestController
    {
        private readonly IRepo _repo;
        private readonly ILogger _logger;

        public TestController(IRepo repo, ILogger logger = null)
        {
            _repo = repo;
            _logger = logger;
            _repo.FailedDatabaseRequest += _repo_FailedDatabaseRequest;
        }

        private void _repo_FailedDatabaseRequest(object sender, EventArgs e)
        {
            _logger.Error("An error occurred");
        }

        public int TenantId() => _repo.TenantId;
        public void SetTenantId(int id) => _repo.TenantId = id;

        public Customer GetCustomer(int id)
        {
            try
            {
                _repo.AddRecord(new Customer());
                //call Find(id) more than 1 time
                //Expected invocation on the mock once, but was 4 times: x => x.Find
                //_repo.Find(id); _repo.Find(id); _repo.Find(id);
                return _repo.Find(id);

            }
            catch (Exception ex)
            {
                throw;
                //return null;
            }
        }

        public void SaveCustomer(Customer customer)
        {
            if(customer != null)
                _repo.AddRecord(customer);
            else
            {
                _logger.Error("customer could not null");
            }
        }
    }
}