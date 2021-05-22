using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Grocery_Helper_GUI
{
    public partial class Form1 : Form
    {
        List<Item> ItemList = new List<Item>(Item.Load());

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ItemList.Sort();
            //Item.Print(ItemList); <---by Price
            ItemList.Sort(delegate (Item x, Item y)
            {
                return (x.ItemPrice / x.ItemSize).CompareTo((y.ItemPrice / y.ItemSize));
            });
            Item.Print(ItemList);
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            Item.Load(ItemList);
            Item.Print(ItemList);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Form1.listView1.ItemName.text.ToString());
            Item.Save(ItemList);
            //MessageBox.Show(Item.ItemName);
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            ItemList.Remove(new Item() { ItemName = Form1.textBoxName.Text });
            Item.Print(ItemList);
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (   !String.IsNullOrEmpty(Form1.textBoxName.Text)
                && !String.IsNullOrEmpty(Form1.textBoxCatEdit.Text)
                && !String.IsNullOrEmpty(Form1.textBoxSize.Text)
                && !String.IsNullOrEmpty(Form1.textBoxPrice.Text)
                && !String.IsNullOrEmpty(Form1.textBoxMeals.Text)
                )
            {
                ItemList.Remove(new Item() { ItemName = Form1.textBoxName.Text });
                ItemList.Add(new Item()
                {
                    ItemName = Form1.textBoxName.Text,
                    ItemCat = Form1.textBoxCatEdit.Text,
                    ItemSize = Convert.ToDouble(Form1.textBoxSize.Text),
                    ItemPrice = Convert.ToDouble(Form1.textBoxPrice.Text),
                    ItemMeals = Convert.ToDouble(Form1.textBoxMeals.Text)
                });
                Item.Print(ItemList);
            }
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            int Index = ItemList.FindIndex(
                listIndex => 
                listIndex.ItemName.Equals(
                    listView1.SelectedItems[0].Text,
                    StringComparison.Ordinal
            )   );
            Form1.textBoxName.Text    = ItemList[Index].ItemName;
            Form1.textBoxCatEdit.Text = ItemList[Index].ItemCat;
            Form1.textBoxSize.Text    = ItemList[Index].ItemSize.ToString();
            Form1.textBoxPrice.Text   = ItemList[Index].ItemPrice.ToString();
            Form1.textBoxMeals.Text   = ItemList[Index].ItemMeals.ToString();
        }
    }
}
