
using Newtonsoft.Json;
using System.Dynamic;
using System.Text.Json.Serialization;

public class Request
{

    CardDbContext cardDbContext = new();
    public async Task Get()
    {
        HttpClient client = new HttpClient();
        var respons = await client.GetAsync("https://randomuser.me/api?results=50");

        if (respons.StatusCode != System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("Run again Server is not working");
            return;
        }

        await CreateCard(JsonConvert.DeserializeObject<dynamic>(respons.Content.ReadAsStringAsync().Result));

    }


    private async Task CreateCard(dynamic data)
    {
        foreach (var item in data.results)
        {
            Card vCard = new Card();
            vCard.FirstName = String.IsNullOrWhiteSpace(item.name.first.ToString()) ? "FirstName is not exsist here " : item.name.first;
            vCard.LastName = String.IsNullOrWhiteSpace(item.name.last.ToString()) ? "LastName is not exsist here " : item.name.last;
            vCard.Email = String.IsNullOrWhiteSpace(item.email.ToString()) ? "Email is not exsist here " : item.email;
            vCard.Phone = String.IsNullOrWhiteSpace(item.phone.ToString()) ? "Phone is not exsist here " : item.phone;
            vCard.Country = String.IsNullOrWhiteSpace(item.location.country.ToString()) ? "Country is not exsist here " : item.location.country;
            vCard.City = String.IsNullOrWhiteSpace(item.location.city.ToString()) ? "City is not exsist here " : item.location.city;
            await cardDbContext.Cards.AddAsync(vCard);
            await cardDbContext.SaveChangesAsync();
            Console.WriteLine($"{Environment.NewLine} BEGIN:VCARD {Environment.NewLine} {vCard}{Environment.NewLine} END:VCARD {Environment.NewLine}");
        }
    }
}

