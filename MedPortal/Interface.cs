using Microsoft.EntityFrameworkCore;

namespace MedPortal
{

    public interface IHospitalDataProvider
    {
        public List<Hospital> GetAllHospitals();
        public List<Doctors> GetAllDoctors();
        public List<Doctors> FindDoctors(int id);
    }

    public interface IFindUsers
    {
        public Task<List<User>> FindUsers(string name);
    }

    public interface IGetAllUsers
    {
        Task<List<User>> GetAllUsers();

    }

   

    public class GetAll : IGetAllUsers
    {
        static HttpClient httpClient = new HttpClient();
        
        async public Task<List<User>> GetAllUsers()
        {
            object? data = await httpClient.GetFromJsonAsync<List<User>>($"http://192.168.90.10:8080/api/users");

            if (data is List<User> user)
            {
                foreach (var item in user)
                {
                    Console.WriteLine($"ID - {item.id}   Name - {item.Name}");
                }
                return user;
            }
            else
            {
                Console.WriteLine("Fail");
                return null;
            }
        }
    }
    public class FindUser : IFindUsers
    {
        static HttpClient httpClient = new HttpClient(); 

        async public Task<List<User>> FindUsers(string name)
        {
            object? data = await httpClient.GetFromJsonAsync<List<User>>($"http://192.168.88.30:8080/api/users?name={name}");

            if (data is List <User> user)
            {
                foreach (var item in user)
                {
                    Console.WriteLine($"ID - {item.id}   Name - {item.Name}");
                }
                return user;
            }
            else
            {
                Console.WriteLine("Fail");
                return null;
            }
        }
    }



}
