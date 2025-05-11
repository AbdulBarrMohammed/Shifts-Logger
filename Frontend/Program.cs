
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
using Spectre.Console;
using Frontend;
using Newtonsoft.Json;





class Program
{
    static async Task Main(string[] args)
    {
        bool isOn = true;
        while (isOn)
        {
            Console.Clear();
            var actionChoice = AnsiConsole.Prompt(
            new SelectionPrompt<MenuAction>().Title("Select an action:")
            .PageSize(10)
            .UseConverter(action =>
                System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(
                    action.ToString().Replace("_", " ").ToLower()))
            .AddChoices(Enum.GetValues<MenuAction>()));

            switch(actionChoice)
            {
                case MenuAction.View_All_Shifts:
                    await GetAllShifts();
                    break;
                case MenuAction.Get_Shift:
                    await GetUser(4);
                    break;
            }

            if (isOn)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
            else {
                break;
            }
        }

        /*
        //await DeleteShift(4);
        //await UpdateShift(2);

        //var add = await AddUser();
        */
    }


    static async Task GetUser(int id)
    {

        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"http://localhost:5247/api/Shift/{id}");

            var response = await client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("You successfully added to shift");
                var jsonResponse = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"{jsonResponse}\n");
                Shift shift = JsonConvert.DeserializeObject<Shift>(jsonResponse);
                Console.WriteLine(shift.Duration);

            }
            else {
                Console.WriteLine($"No user with id: {id}");
            }
        }





    }

    static async Task GetAllShifts()
    {
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

    static async Task AddShift()
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


    }

    static async Task UpdateShift(int id)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"http://localhost:5247/api/Shift/{id}");
            var newShift = new Shift()
            {
                Id = id,
                Duration = 400,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Name = "Snoop Dog is Doggg"
            };

            var newPostJson = await client.PutAsJsonAsync(endpoint, newShift);
            if (newPostJson.IsSuccessStatusCode)
            {
                Console.WriteLine("You successfully updated to shift");
            }
            else {
                Console.WriteLine(newPostJson.StatusCode);
            }
        }
    }

    static async Task DeleteShift(int id)
    {
        using (var client = new HttpClient())
        {
            var endpoint = new Uri($"http://localhost:5247/api/Shift/{id}");


            var newPostJson = await client.DeleteAsync(endpoint);
            if (newPostJson.IsSuccessStatusCode)
            {
                Console.WriteLine("You successfully deleted shift");
            }
            else {
                Console.WriteLine(newPostJson.StatusCode);
            }
        }
    }


}
