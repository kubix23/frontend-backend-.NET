using client.Data.Model;

namespace client.Data.Service;

public class ServiceContact
{
    public Task<String> getContact(int id) {
        using var http = new HttpClient();
        var response = http.GetStringAsync($"/api/Contacts/{id}");
        return response;
    }
}