namespace TestApp.View;
public partial class MainForm : Form
{
    private readonly OrderViewModel _viewModel;

    public MainForm()
    {
        InitializeComponent();
        _viewModel = new OrderViewModel("deliveryLog.txt", "deliveryOrder.json");
    }

    private void btnLoadOrders_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = "Файлы JSON (*.json)|*.json|Все файлы (*.*)|*.*"
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            _viewModel.LoadOrders(openFileDialog.FileName);
        }
    }

    private void btnFilterOrders_Click(object sender, EventArgs e)
    {
        string district = txtDistrict.Text;
        if (!DateTime.TryParse(txtFirstDeliveryTime.Text, out var firstDeliveryTime))
        {
            MessageBox.Show("Неверный формат даты.");
            return;
        }

        var filteredOrders = _viewModel.FilterOrders(district, firstDeliveryTime);
        DisplayOrders(filteredOrders);
    }

    private void DisplayOrders(List<Order> orders)
    {
        listBoxOrders.Items.Clear();
        foreach (var order in orders)
        {
            listBoxOrders.Items.Add($"{order.OrderNumber} - {order.District} - {order.DeliveryTime}");
        }
    }
}
