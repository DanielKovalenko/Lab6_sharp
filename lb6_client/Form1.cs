using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using lb6_server.Model;

namespace lb6_client
{
    public partial class Form1 : Form
    {
        private const string serverUrl = "http://localhost:8888/products/";
        private List<Product> storeProducts;

        public Form1()
        {
            InitializeComponent();
            storeProducts = new List<Product>();
            
        }

        private void btnGetProducts_Click(object sender, EventArgs e)
        {
            // Отримання списку товарів зі складу
            string responseString = SendHttpGetRequest(serverUrl);

            if (!string.IsNullOrEmpty(responseString))
            {
                UpdateProductDataGridView(responseString);
            }
        }

        private void btnAddToStore_Click(object sender, EventArgs e)
        {
            // Перевірка наявності вибраних рядків
            if (dgvProducts.SelectedRows.Count > 0)
            {
                // Отримання вибраного рядка з dgvProducts
                DataGridViewRow selectedRow = dgvProducts.SelectedRows[0];

                // Отримання значень із вибраного рядка
                string name = selectedRow.Cells["Name"].Value.ToString();
                int quantity = int.Parse(selectedRow.Cells["Quantity"].Value.ToString());
                double purchasePrice = double.Parse(selectedRow.Cells["PurchasePrice"].Value.ToString());
                double sellingPrice = double.Parse(selectedRow.Cells["SellingPrice"].Value.ToString());

                // Створення нового екземпляра Product на основі вибраного рядка
                Product product = new Product(name, quantity, purchasePrice, sellingPrice);

                // Додавання товару до списку магазинів
                storeProducts.Add(product);

                // Оновлення таблиці магазину
                UpdateStoreProductDataGridView();
            }
            else
            {
                MessageBox.Show("Оберіть товар для додавання до магазину.");
            }
        }

        private void btnRemoveFromStore_Click(object sender, EventArgs e)
        {
            // Видалення вибраних товарів з магазину
            foreach (DataGridViewRow selectedRow in dgvStoreProducts.SelectedRows)
            {
                string name = selectedRow.Cells["ProductName"].Value.ToString();

                Product productToRemove = storeProducts.Find(p => p.Name == name);
                storeProducts.Remove(productToRemove);
            }

            UpdateStoreProductDataGridView();
        }

        private void UpdateProductDataGridView(string xml)
        {
            dgvProducts.Rows.Clear();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNodeList productNodes = xmlDoc.GetElementsByTagName("Product");

            foreach (XmlNode node in productNodes)
            {
                string name = node["Name"].InnerText;
                int quantity = int.Parse(node["Quantity"].InnerText);
                double purchasePrice = double.Parse(node["PurchasePrice"].InnerText);
                double sellingPrice = double.Parse(node["SellingPrice"].InnerText);

                dgvProducts.Rows.Add(name, quantity, purchasePrice, sellingPrice);
            }
        }

        private void UpdateStoreProductDataGridView()
        {
            dgvStoreProducts.Rows.Clear();

            // Додавання кожного товару з storeProducts до dgvStoreProducts
            foreach (Product product in storeProducts)
            {
                dgvStoreProducts.Rows.Add(product.Name, product.Quantity, product.PurchasePrice, product.SellingPrice);
            }
        }

        private string SendHttpGetRequest(string url)
        {
            string responseString = "";

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(responseStream);
                    responseString = reader.ReadToEnd();

                    reader.Close();
                    responseStream.Close();
                }

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка під час виконання HTTP GET-запиту: " + ex.Message);
            }

            return responseString;
        }
    }
}