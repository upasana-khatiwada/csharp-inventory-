namespace project_main
{
    partial class LowStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SN,
            this.item_name,
            this.rate,
            this.quantity,
            this.total_price});
            this.dataGridView1.Location = new System.Drawing.Point(63, 72);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(555, 254);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // SN
            // 
            this.SN.HeaderText = "SN";
            this.SN.MinimumWidth = 6;
            this.SN.Name = "SN";
            this.SN.Width = 125;
            // 
            // item_name
            // 
            this.item_name.HeaderText = "item_name";
            this.item_name.MinimumWidth = 6;
            this.item_name.Name = "item_name";
            this.item_name.Width = 125;
            // 
            // rate
            // 
            this.rate.HeaderText = "rate";
            this.rate.MinimumWidth = 6;
            this.rate.Name = "rate";
            this.rate.Width = 125;
            // 
            // quantity
            // 
            this.quantity.HeaderText = "quantity";
            this.quantity.MinimumWidth = 6;
            this.quantity.Name = "quantity";
            this.quantity.Width = 125;
            // 
            // total_price
            // 
            this.total_price.HeaderText = "total_price";
            this.total_price.MinimumWidth = 6;
            this.total_price.Name = "total_price";
            this.total_price.Width = 125;
            // 
            // LowStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridView1);
            this.Name = "LowStock";
            this.Text = "LowStock";
            this.Load += new System.EventHandler(this.LowStock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn SN;
        private DataGridViewTextBoxColumn item_name;
        private DataGridViewTextBoxColumn rate;
        private DataGridViewTextBoxColumn quantity;
        private DataGridViewTextBoxColumn total_price;
    }
}