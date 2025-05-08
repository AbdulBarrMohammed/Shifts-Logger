
using System.Net.Http.Json;
using Frontend.obj.Model;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;


class Program
{
    static async Task Main(string[] args)
    {

        var currShift = await GetUser();
        Console.WriteLine(currShift.Name);
        /*
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5247/api/");

        try
        {
            var shifts = await client.GetFromJsonAsync<List<Shift>>("Shift");

            if (shifts != null)
            {
                foreach (var shift in shifts)
                {
                    Console.WriteLine($"{shift.Id}: {shift.Name} ({shift.Duration} mins)");
                }
            }
            else
            {
                Console.WriteLine("No shifts returned.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        } */;
    }

    static async Task<Shift> GetUser()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5247/api/");
        var shift = await client.GetFromJsonAsync<Shift>("Shift/1");
        Console.WriteLine(shift.Name);
        return new Shift(1, 10, DateTime.Now, DateTime.Now, shift.Name);
    }
}
