
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
            //System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemName = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemCat = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemSize = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemPrice = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemMeals = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemPPS = new System.Windows.Forms.ListViewItem("");
            System.Windows.Forms.ListViewItem ItemPPM = new System.Windows.Forms.ListViewItem("");
            this.button1 = new System.Windows.Forms.Button();
            listView1 = new System.Windows.Forms.ListView();
            this.ColumnItemName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemCat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemMeals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPPS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColumnItemPPM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            textBoxCat = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 415);
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
            ItemName,
            ItemCat,
            ItemSize,
            ItemPrice,
            ItemMeals,
            ItemPPS,
            ItemPPM});
            //listViewItem2});
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
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(162, 21);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(243, 21);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(18, 80);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 84);
            this.listBox1.TabIndex = 4;
            // 
            // textBoxCat
            // 
            textBoxCat.Location = new System.Drawing.Point(6, 21);
            textBoxCat.Name = "textBoxCat";
            textBoxCat.Size = new System.Drawing.Size(150, 22);
            textBoxCat.TabIndex = 5;
            textBoxCat.Text = "Snacks";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(textBoxCat);
            this.groupBox1.Controls.Add(this.buttonLoad);
            this.groupBox1.Controls.Add(this.buttonSave);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 62);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Saving and Loading";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(listView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ListBox listBox1;
        public static System.Windows.Forms.TextBox textBoxCat;
        private System.Windows.Forms.GroupBox groupBox1;
        public static System.Windows.Forms.ListView listView1;
    }
}

