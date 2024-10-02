using PruebaDetalleMaestro.Models;

namespace PruebaDetalleMaestro.Services;

public class OrderService
{

    private HttpClient _client = new() { BaseAddress = new Uri("http://localhost:5202/") };
    
    public async Task<List<Order>?> GetOrders() {
        return await _client.GetFromJsonAsync<List<Order>>("orders");
    }

    public async Task<Order?> ObtenerOrdenPorId(int id)
    {
        await _client.GetFromJsonAsync<Order>($"orders/{id}");
        return await _client.GetFromJsonAsync<Order>($"orders/{id}");
    }

    public async Task<bool> GuardarOrden(Order order)
    {
        var response = await _client.PostAsJsonAsync("orders", order);
        if(response.StatusCode == System.Net.HttpStatusCode.Created) return true;
        return false;
    }

    public async Task<bool> ModificarOrden(Order order)
    {
        var response = await _client.PutAsJsonAsync("orders", order);
        if(response.StatusCode == System.Net.HttpStatusCode.OK) return true;
        return false;
    }

    public async Task<bool> EliminarOrden(int id)
    {
        var response = await _client.DeleteAsync($"orders/{id}");
        if(response.StatusCode == System.Net.HttpStatusCode.OK) return true;
        return false;
    }
}
