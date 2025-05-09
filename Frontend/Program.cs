
using System.Net.Http.Json;
using Frontend.obj.Model;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;



class Program
{
    static async Task Main(string[] args)
    {

        var currShift = await GetUser();
        Console.WriteLine(currShift.Name);

        var add = await AddUser();

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
        }
    }

    static async Task<Shift> GetUser()
    {
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5247/api/");
        var shift = await client.GetFromJsonAsync<Shift>("Shift/1");
        Console.WriteLine(shift.Name);
        return new Shift(10, DateTime.Now, DateTime.Now, shift.Name);
    }

    static async Task<Shift?> AddUser()
    {


        using (var client = new HttpClient())
        {
            var endpoint = new Uri("http://localhost:5247/api/Shift");
            var newShift = new Shift()
            {
                Duration = 20,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Name = "Snoop"
            };

            var newPostJson = await client.PostAsJsonAsync(endpoint, newShift);
            if (newPostJson.IsSuccessStatusCode)
            {
                Console.WriteLine("You successfully added to shift");
            }
            else {
                Console.WriteLine("error");
            }
        }

        return new Shift();


    }


}
