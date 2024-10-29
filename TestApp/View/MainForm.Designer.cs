namespace TestApp.View;
partial class MainForm
{
    private System.Windows.Forms.TextBox txtDistrict;
    private System.Windows.Forms.TextBox txtFirstDeliveryTime;
    private System.Windows.Forms.ListBox listBoxOrders;
    private System.Windows.Forms.Button btnLoadOrders;
    private System.Windows.Forms.Button btnFilterOrders;

    private void InitializeComponent()
    {
        txtDistrict = new TextBox();
        txtFirstDeliveryTime = new TextBox();
        listBoxOrders = new ListBox();
        btnLoadOrders = new Button();
        btnFilterOrders = new Button();
        SuspendLayout();
        // 
        // txtDistrict
        // 
        txtDistrict.Location = new Point(12, 12);
        txtDistrict.Name = "txtDistrict";
        txtDistrict.PlaceholderText = "Введите район";
        txtDistrict.Size = new Size(150, 27);
        txtDistrict.TabIndex = 0;
        // 
        // txtFirstDeliveryTime
        // 
        txtFirstDeliveryTime.Location = new Point(12, 45);
        txtFirstDeliveryTime.Name = "txtFirstDeliveryTime";
        txtFirstDeliveryTime.PlaceholderText = "YYYY-MM-DD HH:mm:ss";
        txtFirstDeliveryTime.Size = new Size(175, 27);
        txtFirstDeliveryTime.TabIndex = 1;
        // 
        // listBoxOrders
        // 
        listBoxOrders.Location = new Point(218, 12);
        listBoxOrders.Name = "listBoxOrders";
        listBoxOrders.Size = new Size(474, 224);
        listBoxOrders.TabIndex = 2;
        // 
        // btnLoadOrders
        // 
        btnLoadOrders.Location = new Point(12, 78);
        btnLoadOrders.Name = "btnLoadOrders";
        btnLoadOrders.Size = new Size(150, 30);
        btnLoadOrders.TabIndex = 3;
        btnLoadOrders.Text = "Загрузить заказы";
        btnLoadOrders.Click += btnLoadOrders_Click;
        // 
        // btnFilterOrders
        // 
        btnFilterOrders.Location = new Point(12, 114);
        btnFilterOrders.Name = "btnFilterOrders";
        btnFilterOrders.Size = new Size(200, 30);
        btnFilterOrders.TabIndex = 4;
        btnFilterOrders.Text = "Отфильтровать заказы";
        btnFilterOrders.Click += btnFilterOrders_Click;
        // 
        // MainForm
        // 
        ClientSize = new Size(704, 269);
        Controls.Add(txtDistrict);
        Controls.Add(txtFirstDeliveryTime);
        Controls.Add(listBoxOrders);
        Controls.Add(btnLoadOrders);
        Controls.Add(btnFilterOrders);
        Name = "MainForm";
        ResumeLayout(false);
        PerformLayout();
    }
}
