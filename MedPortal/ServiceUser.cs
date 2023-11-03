namespace MedPortal
{
    public class ServiceUser
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ServiceUser(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;

        }

        static public List<ServiceUser> users = new List<ServiceUser>
        {
            new ServiceUser(1, "example@mail.com"),
            new ServiceUser(2, "example1@mail.com"),
            new ServiceUser(3, "1"),
            new ServiceUser(4, "admin")

        };
    }
}
