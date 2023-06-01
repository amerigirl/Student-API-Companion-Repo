namespace StudentAdminPortal.API.DataModels
{
    public class Address
    {
        public Guid Id { get; set; }
        public string PhysicalAddess { get; set; }
        public string PostalAddress { get; set; }

        //Navigation Property

        public Guid StudentId { get; set; }

    }
}
