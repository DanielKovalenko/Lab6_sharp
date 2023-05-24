
namespace lb6_client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnRemoveFromStore = new System.Windows.Forms.Button();
            this.btnAddToStore = new System.Windows.Forms.Button();
            this.btnGetProducts = new System.Windows.Forms.Button();
            this.dgvProducts = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvStoreProducts = new System.Windows.Forms.DataGridView();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PurchasePrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellingPrice1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemoveFromStore
            // 
            this.btnRemoveFromStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnRemoveFromStore.Location = new System.Drawing.Point(513, 433);
            this.btnRemoveFromStore.Name = "btnRemoveFromStore";
            this.btnRemoveFromStore.Size = new System.Drawing.Size(130, 69);
            this.btnRemoveFromStore.TabIndex = 8;
            this.btnRemoveFromStore.Text = "Видалити з магазину";
            this.btnRemoveFromStore.UseVisualStyleBackColor = true;
            this.btnRemoveFromStore.Click += new System.EventHandler(this.btnRemoveFromStore_Click);
            // 
            // btnAddToStore
            // 
            this.btnAddToStore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnAddToStore.Location = new System.Drawing.Point(513, 310);
            this.btnAddToStore.Name = "btnAddToStore";
            this.btnAddToStore.Size = new System.Drawing.Size(130, 72);
            this.btnAddToStore.TabIndex = 7;
            this.btnAddToStore.Text = "Додати до магазину";
            this.btnAddToStore.UseVisualStyleBackColor = true;
            this.btnAddToStore.Click += new System.EventHandler(this.btnAddToStore_Click);
            // 
            // btnGetProducts
            // 
            this.btnGetProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnGetProducts.Location = new System.Drawing.Point(500, 113);
            this.btnGetProducts.Name = "btnGetProducts";
            this.btnGetProducts.Size = new System.Drawing.Size(179, 76);
            this.btnGetProducts.TabIndex = 6;
            this.btnGetProducts.Text = "Отримати список товарів";
            this.btnGetProducts.UseVisualStyleBackColor = true;
            this.btnGetProducts.Click += new System.EventHandler(this.btnGetProducts_Click);
            // 
            // dgvProducts
            // 
            this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Quantity,
            this.PurchasePrice,
            this.SellingPrice});
            this.dgvProducts.Location = new System.Drawing.Point(12, 66);
            this.dgvProducts.Name = "dgvProducts";
            this.dgvProducts.Size = new System.Drawing.Size(444, 185);
            this.dgvProducts.TabIndex = 9;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // PurchasePrice
            // 
            this.PurchasePrice.HeaderText = "PurchasePrice";
            this.PurchasePrice.Name = "PurchasePrice";
            // 
            // SellingPrice
            // 
            this.SellingPrice.HeaderText = "SellingPrice";
            this.SellingPrice.Name = "SellingPrice";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label5.Location = new System.Drawing.Point(363, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 22);
            this.label5.TabIndex = 23;
            this.label5.Text = "SHOP";
            // 
            // dgvStoreProducts
            // 
            this.dgvStoreProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStoreProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductName,
            this.Quantity1,
            this.PurchasePrice1,
            this.SellingPrice1});
            this.dgvStoreProducts.Location = new System.Drawing.Point(12, 330);
            this.dgvStoreProducts.Name = "dgvStoreProducts";
            this.dgvStoreProducts.Size = new System.Drawing.Size(444, 192);
            this.dgvStoreProducts.TabIndex = 24;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "ProductName";
            this.ProductName.Name = "ProductName";
            // 
            // Quantity1
            // 
            this.Quantity1.HeaderText = "Quantity";
            this.Quantity1.Name = "Quantity1";
            // 
            // PurchasePrice1
            // 
            this.PurchasePrice1.HeaderText = "PurchasePrice";
            this.PurchasePrice1.Name = "PurchasePrice1";
            // 
            // SellingPrice1
            // 
            this.SellingPrice1.HeaderText = "SellingPrice";
            this.SellingPrice1.Name = "SellingPrice1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label1.Location = new System.Drawing.Point(202, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 25;
            this.label1.Text = "Stock List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label2.Location = new System.Drawing.Point(175, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 22);
            this.label2.TabIndex = 26;
            this.label2.Text = "Store Items List";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(753, 564);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvStoreProducts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgvProducts);
            this.Controls.Add(this.btnRemoveFromStore);
            this.Controls.Add(this.btnAddToStore);
            this.Controls.Add(this.btnGetProducts);
            //this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStoreProducts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveFromStore;
        private System.Windows.Forms.Button btnAddToStore;
        private System.Windows.Forms.Button btnGetProducts;
        private System.Windows.Forms.DataGridView dgvProducts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvStoreProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PurchasePrice1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellingPrice1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

