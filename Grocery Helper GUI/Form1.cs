using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Grocery_Helper_GUI
{
    public partial class Form1 : Form
    {
        List<Item> ItemList = new List<Item>(Init());

        public Form1()
        {
            InitializeComponent();
        }

        private List<Item> Save(List<Item> Itemlist)
        {
            StreamWriter SaveFile = File.CreateText($"./Grocery Lists/{textBoxCat.Text}.txt");
            foreach (Item aItem in ItemList)
            {
                SaveFile.WriteLine(aItem.ToString("Save"));
                SaveFile.Flush();
            }
            SaveFile.Close();
            //Open notepad after saving. Not needed anymore.
            //Process.Start("notepad.exe", $"./Grocery Lists/{textBoxCat.Text}.txt");
            return ItemList;
        }
        public static List<Item> Init()
        {
            List<Item> ItemList = new List<Item>();

            ItemList.Add(new Item()
            {
                ItemName = "",
                ItemCat = "",
                ItemSize = 0,
                ItemPrice = 0,
                ItemMeals = 0
            });
            return ItemList;
        }
        public List<Item> LoadFile(List<Item> ItemList)
        {

            if (!File.Exists($"./Grocery Lists/{textBoxCat.Text?.ToLower()}.txt")) { MessageBox.Show("File not Found"); return ItemList; }
            if (!String.IsNullOrEmpty(textBoxCat.Text))
            {
                string[] LoadFile = File.ReadAllLines($"./Grocery Lists/{textBoxCat.Text?.ToLower()}.txt");

                foreach (string Line in LoadFile)
                {
                    string[] Field = Line.Split('^');

                    ItemList.Add(new Item()
                    {
                        ItemName = Field[0],
                        ItemCat = Field[1],
                        ItemSize = Convert.ToDouble(Field[2]),
                        ItemPrice = Convert.ToDouble(Field[3]),
                        ItemMeals = Convert.ToDouble(Field[4])
                    });
                }
            }
            return ItemList;
        }

        private void Print(List<Item> Itemlist)
        {
            listView1.Items.Clear();
            for (int Index = 0; Index < Itemlist.Count; Index++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                ItemList[Index].ItemName,
                ItemList[Index].ItemCat,
                ItemList[Index].ItemSize.ToString(),
                Convert.ToDouble(ItemList[Index].ItemPrice).ToString("C"),
                ItemList[Index].ItemMeals.ToString(),
                (Convert.ToDouble(ItemList[Index].ItemPrice) / Convert.ToDouble(ItemList[Index].ItemSize)).ToString("C"),
                (Convert.ToDouble(ItemList[Index].ItemPrice) / Convert.ToDouble(ItemList[Index].ItemMeals)).ToString("C")
                }));
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            LoadFile(ItemList);
            Print(ItemList);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(listView1.ItemName.text.ToString());
            Save(ItemList);
            //MessageBox.Show(Item.ItemName);
        }

        private void buttonRemoveItem_Click(object sender, EventArgs e)
        {
            ItemList.Remove(new Item() { ItemName = textBoxName.Text });
            Print(ItemList);
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxName.Text)
                && !String.IsNullOrEmpty(textBoxCatEdit.Text)
                && !String.IsNullOrEmpty(textBoxSize.Text)
                && !String.IsNullOrEmpty(textBoxPrice.Text)
                && !String.IsNullOrEmpty(textBoxMeals.Text)
                )
            {
                ItemList.Remove(new Item() { ItemName = textBoxName.Text });
                ItemList.Add(new Item()
                {
                    ItemName = textBoxName.Text,
                    ItemCat = textBoxCatEdit.Text,
                    ItemSize = Convert.ToDouble(textBoxSize.Text),
                    ItemPrice = Convert.ToDouble(textBoxPrice.Text),
                    ItemMeals = Convert.ToDouble(textBoxMeals.Text)
                });
                Print(ItemList);
            }
            MessageBox.Show("Please fill in all boxes!");
        }

        private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            int Index = ItemList.FindIndex(
                listIndex =>
                listIndex.ItemName.Equals(
                    listView1.SelectedItems[0].Text,
                    StringComparison.Ordinal
            ));
            textBoxName.Text = ItemList[Index].ItemName;
            textBoxCatEdit.Text = ItemList[Index].ItemCat;
            textBoxSize.Text = ItemList[Index].ItemSize.ToString();
            textBoxPrice.Text = ItemList[Index].ItemPrice.ToString();
            textBoxMeals.Text = ItemList[Index].ItemMeals.ToString();
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            ItemList.Sort(delegate (Item x, Item y)
            {
                switch (e.Column)
                {
                    default: return x.ItemName.CompareTo(y.ItemName);
                    case 1:  return x.ItemCat.CompareTo(y.ItemCat);
                    case 2:  return x.ItemSize.CompareTo(y.ItemSize);
                    case 3:  return x.ItemPrice.CompareTo(y.ItemPrice);
                    case 4:  return x.ItemMeals.CompareTo(y.ItemMeals);
                    case 5:  return (x.ItemPrice / x.ItemSize).CompareTo(y.ItemPrice / y.ItemSize);
                    case 6:  return (x.ItemPrice / x.ItemMeals).CompareTo(y.ItemPrice / y.ItemMeals);
                }
            });
            Print(ItemList);
            //return;
        }
    }
}
