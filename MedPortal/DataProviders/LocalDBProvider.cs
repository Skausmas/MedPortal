namespace MedPortal.DataProviders
{
    public class LocalDBProvider : IHospitalDataProvider 
    {

        ApplicationContext _context;
        public LocalDBProvider(ApplicationContext context)
        {
            _context = context;
        }

        public List<Hospital> GetAllHospitals()
        {
            return this._context.Hospitals.ToList();
        }
        public List<Doctors> GetAllDoctors()
        {
            return this._context.Doctors.ToList();
        }
        public List<Doctors> FindDoctors(int id)
        {
            return this._context.Doctors.ToList();
        }

    }
}
