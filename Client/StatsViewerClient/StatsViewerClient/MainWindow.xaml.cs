using Client_Lab1_PRN222.Models;
using Client_Lab1_PRN222.Services;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace Client_Lab1_PRN222
{
    public partial class MainWindow : Window
    {
        private readonly StatisticClient _client = new StatisticClient();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (cbCategory.SelectedItem is not ComboBoxItem categoryItem ||
                cbType.SelectedItem is not ComboBoxItem typeItem)
            {
                MessageBox.Show("Please select Category and Type");
                return;
            }

            string category = categoryItem.Content?.ToString() ?? string.Empty;
            string action = typeItem.Content?.ToString() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(category) || string.IsNullOrWhiteSpace(action))
            {
                MessageBox.Show("Invalid Category or Type");
                return;
            }

            ResponseDTO response = _client.GetStatistics(category, action);

            if (response.Success)
            {
                // If payload is JsonElement (System.Text.Json), deserialize to concrete list
                if (response.Payload is JsonElement je && je.ValueKind == JsonValueKind.Array)
                {
                    var records = JsonSerializer.Deserialize<List<StatisticRecord>>(je.GetRawText()) ?? new List<StatisticRecord>();
                    dgData.ItemsSource = records;
                }
                else if (response.Payload is IEnumerable<object> data)
                {
                    dgData.ItemsSource = data;
                }
                else
                {
                    MessageBox.Show("Unexpected payload format from server");
                    dgData.ItemsSource = null;
                }
            }
            else
            {
                MessageBox.Show(
                    response.Error
                    ?? response.Message
                    ?? "No data returned from server"
                );

                dgData.ItemsSource = null;
            }
        }
    }
}