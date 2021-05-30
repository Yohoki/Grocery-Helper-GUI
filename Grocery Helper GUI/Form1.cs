using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Grocery_Helper_GUI
{
    public partial class Form1 : Form
    {
        List<Item> ItemList = new List<Item>();
        private const string dir = "./Grocery Lists";

        public Form1()
        {
            InitializeComponent();
            InitFilesList();
            comboBoxFilename.SelectedIndex = 0;
        }

        public void InitFilesList()
        {
            comboBoxFilename.Items.Clear();
            if (!Directory.Exists(dir)) { Directory.CreateDirectory(dir); }
            string[] files = Directory.GetFiles(dir);
            foreach (string filePath in files) { comboBoxFilename.Items.Add(Path.GetFileName(filePath)); }
            comboBoxFilename.Items.Add("New...");
        }

        private List<Item> Save(List<Item> Itemlist)
        {
            if (string.IsNullOrEmpty(comboBoxFilename.Text)) { MessageBox.Show("Please name your file!", "Error: Filename Required"); return ItemList; }
            Regex FilenameTest = new Regex("^[^<>:;,?\" *|/]+$");
            if (!Regex.Match(comboBoxFilename.Text, FilenameTest.ToString()).Success)
            {
                MessageBox.Show("Only Valid file names are allowed. Please use valid characters only", "Error: Filename Invalid"); return ItemList;
            }
            StreamWriter SaveFile = File.CreateText($"{dir}/{comboBoxFilename.Text}");
            foreach (Item item in ItemList)
            {
                SaveFile.WriteLine(item.ToString("Save"));
                SaveFile.Flush();
            }
            SaveFile.Close();
            InitFilesList();
            return ItemList;
        }

        public List<Item> LoadFile(List<Item> ItemList)
        {
            if (!File.Exists($"{dir}/{comboBoxFilename.Text.ToLower()}")) { MessageBox.Show("The filename you have entered cannot be found.", "Error: File Not Found"); return ItemList; }
            if (!string.IsNullOrEmpty(comboBoxFilename.Text))
            {
                string[] LoadFile = File.ReadAllLines($"{dir}/{comboBoxFilename.Text.ToLower()}");

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

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            ItemList.Clear();
            LoadFile(ItemList);
            Print(ItemList);
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            Save(ItemList);
        }

        private void ButtonRemoveItem_Click(object sender, EventArgs e)
        {
            ItemList.Remove(new Item() { ItemName = textBoxName.Text });
            Print(ItemList);
        }

        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            if (   string.IsNullOrEmpty(textBoxName.Text)
                || string.IsNullOrEmpty(textBoxCat.Text)
                || string.IsNullOrEmpty(textBoxSize.Text)
                || string.IsNullOrEmpty(textBoxPrice.Text)
                || string.IsNullOrEmpty(textBoxMeals.Text)
                ) { MessageBox.Show("Please fill in all boxes!", "Error: Empty Box Detected"); return; }

            Regex NumbersTest = new Regex("^\\d*(\\.\\d+)?$");
            if (   !Regex.Match(textBoxPrice.Text, NumbersTest.ToString()).Success
                || !Regex.Match(textBoxSize.Text, NumbersTest.ToString()).Success
                || !Regex.Match(textBoxMeals.Text, NumbersTest.ToString()).Success
                ) { MessageBox.Show("Make sure only Numbers and a decimal are in Price, Size and Meals boxes.", "Error: Non-Number Detected"); return; }

            ItemList.Remove(new Item() { ItemName = textBoxName.Text });
            ItemList.Add(new Item()
            {
                ItemName = textBoxName.Text,
                ItemCat = textBoxCat.Text,
                ItemSize = Convert.ToDouble(textBoxSize.Text),
                ItemPrice = Convert.ToDouble(textBoxPrice.Text),
                ItemMeals = Convert.ToDouble(textBoxMeals.Text)
            });
            Print(ItemList);
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) { return; }
            int Index = ItemList.FindIndex(
                listIndex =>
                listIndex.ItemName.Equals(
                    listView1.SelectedItems[0].Text,
                    StringComparison.Ordinal
            ));
            textBoxName.Text = ItemList[Index].ItemName;
            textBoxCat.Text = ItemList[Index].ItemCat;
            textBoxSize.Text = ItemList[Index].ItemSize.ToString();
            textBoxPrice.Text = ItemList[Index].ItemPrice.ToString();
            textBoxMeals.Text = ItemList[Index].ItemMeals.ToString();
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
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
        }
    }
}
