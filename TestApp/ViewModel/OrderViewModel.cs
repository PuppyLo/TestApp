using System.Text.Json;

public class OrderViewModel
{
    private List<Order> _orders;
    private readonly string _logFilePath;
    private readonly string _resultFilePath;

    public OrderViewModel(string logFilePath, string resultFilePath)
    {
        _orders = new List<Order>();
        _logFilePath = logFilePath;
        _resultFilePath = resultFilePath;
    }

    public void LoadOrders(string filePath)
    {
        try
        {
            string jsonData = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                Converters = { new DateTimeConverter() }
            };

            _orders = JsonSerializer.Deserialize<List<Order>>(jsonData, options);
            Log("Заказы успешно загружены.");
        }
        catch (Exception ex)
        {
            Log($"Ошибка при загрузке заказов: {ex.Message}");
        }
    }

    public List<Order> FilterOrders(string district, DateTime firstDeliveryTime)
    {
        // Фильтруем заказы на основании района и временного интервала
        var result = _orders
            .Where(o => o.District == district && o.DeliveryTime <= firstDeliveryTime.AddMinutes(30))
            .ToList();

        // Логируем и сохраняем результат, если найдены заказы
        if (result.Count > 0)
        {
            SaveFilteredOrders(result);
            Log($"Отфильтрованные {result.Count} заказы для района '{district}' в течение 30 минут после {firstDeliveryTime}.");
        }
        else
        {
            Log("Не найдено ни одного заказа по заданным критериям.");
        }

        return result;
    }

    private void SaveFilteredOrders(List<Order> orders)
    {
        try
        {
            string jsonResult = JsonSerializer.Serialize(orders, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_resultFilePath, jsonResult);
            Log("Отфильтрованные заказы успешно сохранены.");
        }
        catch (Exception ex)
        {
            Log($"Ошибка при сохранении отфильтрованных заказов: {ex.Message}");
        }
    }

    private void Log(string message)
    {
        File.AppendAllText(_logFilePath, $"{DateTime.Now}: {message}\n");
    }
}
