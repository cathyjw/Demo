using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UnitTest.Templates.SupportUnitTest
{
    public interface IRepo
    {
        event EventHandler FailedDatabaseRequest;
        int TenantId { get; set; }
        Customer Find(int id);
        IList<Customer> GetSome(Expression<Func<Customer, bool>> where);
        void AddRecord(Customer customer);
    }
}