namespace UnitTest.Templates.SupportUnitTest
{
    public class Customer
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual StudentAddress AddressNavigation { get; set; }
    }
}