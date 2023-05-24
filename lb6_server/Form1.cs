using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using lb6_server.Model;

namespace lb6_server
{
    public partial class Form1 : Form
    {
        private List<Product> products;

        public Form1()
        {
            InitializeComponent();
            products = new List<Product>();
        }

        private void ServerForm_Load(object sender, EventArgs e)
        {
            // Завантаження даних про товари зі складу із файлу
            LoadProductsFromFile("warehouse.xml");
            UpdateProductDataGridView();
        }

        private void LoadProductsFromFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                products.Clear();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(filePath);

                XmlNodeList productNodes = xmlDoc.GetElementsByTagName("Product");

                foreach (XmlNode node in productNodes)
                {
                    string name = node["Name"].InnerText;
                    int quantity = int.Parse(node["Quantity"].InnerText);
                    double purchasePrice = double.Parse(node["PurchasePrice"].InnerText);
                    double sellingPrice = double.Parse(node["SellingPrice"].InnerText);

                    Product product = new Product(name, quantity, purchasePrice, sellingPrice);
                    products.Add(product);
                }
            }
        }

        private void UpdateProductDataGridView()
        {
            dgvProducts.Rows.Clear();

            foreach (Product product in products)
            {
                dgvProducts.Rows.Add(product.Name, product.Quantity, product.PurchasePrice, product.SellingPrice);
            }
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Додавання нового товару
            string name = txtName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            double purchasePrice = double.Parse(txtPurchasePrice.Text);
            double sellingPrice = double.Parse(txtSellingPrice.Text);

            Product product = new Product(name, quantity, purchasePrice, sellingPrice);

            products.Add(product);
           

            UpdateProductDataGridView();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Збереження товарів на складі до папки
            SaveProductsToFile("Store_storage\\warehouse.xml");
        }

        private void SaveProductsToFile(string filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Products");
            xmlDoc.AppendChild(rootElement);

            foreach (Product product in products)
            {
                XmlElement productElement = xmlDoc.CreateElement("Product");

                XmlElement nameElement = xmlDoc.CreateElement("Name");
                nameElement.InnerText = product.Name;
                productElement.AppendChild(nameElement);

                XmlElement quantityElement = xmlDoc.CreateElement("Quantity");
                quantityElement.InnerText = product.Quantity.ToString();
                productElement.AppendChild(quantityElement);

                XmlElement purchasePriceElement = xmlDoc.CreateElement("PurchasePrice");
                purchasePriceElement.InnerText = product.PurchasePrice.ToString();
                productElement.AppendChild(purchasePriceElement);

                XmlElement sellingPriceElement = xmlDoc.CreateElement("SellingPrice");
                sellingPriceElement.InnerText = product.SellingPrice.ToString();
                productElement.AppendChild(sellingPriceElement);

                rootElement.AppendChild(productElement);
            }

            xmlDoc.Save(filePath);
            MessageBox.Show("Файл успішно збережено.");
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            // Запуск сервера для обробки запитів від клієнта
            string url = "http://localhost:8888/products/";
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add(url);
            listener.Start();

            Task.Run(() =>
            {
                while (true)
                {
                    HttpListenerContext context = listener.GetContext();
                    ProcessClientRequest(context);
                }
            });

            MessageBox.Show("Сервер запущено.");
        }

        private void ProcessClientRequest(HttpListenerContext context)
        {
            HttpListenerRequest request = context.Request;
            HttpListenerResponse response = context.Response;

            string responseString = "";

            if (request.HttpMethod == "GET")
            {
                // Обробка GET-запиту від клієнта
                responseString = GetProductsAsXml();
            }
            else if (request.HttpMethod == "POST")
            {
                // Обробка POST-запиту від клієнта
                string requestBody = new StreamReader(request.InputStream).ReadToEnd();
                AddProductFromXml(requestBody);

                responseString = "Товар доданий до складу.";
            }

            byte[] buffer = Encoding.UTF8.GetBytes(responseString);

            response.ContentLength64 = buffer.Length;
            Stream outputStream = response.OutputStream;
            outputStream.Write(buffer, 0, buffer.Length);
            outputStream.Close();
        }

        private string GetProductsAsXml()
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Products");
            xmlDoc.AppendChild(rootElement);

            foreach (Product product in products)
            {
                XmlElement productElement = xmlDoc.CreateElement("Product");

                XmlElement nameElement = xmlDoc.CreateElement("Name");
                nameElement.InnerText = product.Name;
                productElement.AppendChild(nameElement);

                XmlElement quantityElement = xmlDoc.CreateElement("Quantity");
                quantityElement.InnerText = product.Quantity.ToString();
                productElement.AppendChild(quantityElement);

                XmlElement purchasePriceElement = xmlDoc.CreateElement("PurchasePrice");
                purchasePriceElement.InnerText = product.PurchasePrice.ToString();
                productElement.AppendChild(purchasePriceElement);

                XmlElement sellingPriceElement = xmlDoc.CreateElement("SellingPrice");
                sellingPriceElement.InnerText = product.SellingPrice.ToString();
                productElement.AppendChild(sellingPriceElement);

                rootElement.AppendChild(productElement);
            }

            return xmlDoc.OuterXml;
        }

        private void AddProductFromXml(string xml)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNode productNode = xmlDoc.SelectSingleNode("/Product");

            string name = productNode["Name"].InnerText;
            int quantity = int.Parse(productNode["Quantity"].InnerText);
            double purchasePrice = double.Parse(productNode["PurchasePrice"].InnerText);
            double sellingPrice = double.Parse(productNode["SellingPrice"].InnerText);

            Product product = new Product(name, quantity, purchasePrice, sellingPrice);
            products.Add(product);

            UpdateProductDataGridView();
        }
    }
}
