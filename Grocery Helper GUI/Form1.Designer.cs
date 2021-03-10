
namespace Grocery_Helper_GUI
{
    partial class Form1
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.button1 = new System.Windows.Forms.Button();
            listView1 = new System.Windows.Forms.ListView();
            this.ColumnItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemMeals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPPM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test Show List";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnItemName,
            this.ColumnItemCat,
            this.ColumnItemSize,
            this.ColumnItemPrice,
            this.ColumnItemMeals,
            this.ColumnItemPPS,
            this.ColumnItemPPM});
            listView1.HideSelection = false;
            listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            listView1.Location = new System.Drawing.Point(342, 12);
            listView1.Name = "listView1";
            listView1.Size = new System.Drawing.Size(657, 426);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = System.Windows.Forms.View.Details;
            // 
            // ColumnItemName
            // 
            this.ColumnItemName.Text = "ItemName";
            this.ColumnItemName.Width = 124;
            // 
            // ColumnItemCat
            // 
            this.ColumnItemCat.Text = "ItemCat";
            this.ColumnItemCat.Width = 62;
            // 
            // ColumnItemSize
            // 
            this.ColumnItemSize.Text = "ItemSize";
            // 
            // ColumnItemPrice
            // 
            this.ColumnItemPrice.Text = "ItemPrice";
            // 
            // ColumnItemMeals
            // 
            this.ColumnItemMeals.Text = "ItemMeals";
            // 
            // ColumnItemPPS
            // 
            this.ColumnItemPPS.Text = "ItemPPS";
            // 
            // ColumnItemPPM
            // 
            this.ColumnItemPPM.Text = "ItemPPM";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 450);
            this.Controls.Add(listView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader ColumnItemName;
        private System.Windows.Forms.ColumnHeader ColumnItemCat;
        private System.Windows.Forms.ColumnHeader ColumnItemSize;
        private System.Windows.Forms.ColumnHeader ColumnItemPrice;
        private System.Windows.Forms.ColumnHeader ColumnItemMeals;
        private System.Windows.Forms.ColumnHeader ColumnItemPPS;
        private System.Windows.Forms.ColumnHeader ColumnItemPPM;
        public static System.Windows.Forms.ListView listView1;
    }
}

