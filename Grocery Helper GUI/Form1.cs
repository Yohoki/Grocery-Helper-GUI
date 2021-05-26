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
        List<Item> ItemList = new List<Item>(Init());

        public Form1()
        {
            InitializeComponent();
        }

        private List<Item> Save(List<Item> Itemlist)
        {
            StreamWriter SaveFile = File.CreateText($"D:/Test/{textBoxCat.Text.ToString()}.txt");
            foreach (Item aItem in ItemList)
            {
                SaveFile.WriteLine(aItem.ToString("Save"));
                SaveFile.Flush();
            }
            SaveFile.Close();
            Process.Start("notepad.exe", $"D:/Test/{textBoxCat.Text.ToString()}.txt");
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

            if (!File.Exists($"D:/Test/{textBoxCat.Text?.ToLower()}.txt")) { Console.WriteLine("File not Found"); return ItemList; }
            if (!String.IsNullOrEmpty(textBoxCat.Text))
            {
                string[] LoadFile = File.ReadAllLines($"D:/Test/{textBoxCat.Text?.ToLower()}.txt");

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
            int ID = 0;
            listView1.Items.Clear();

            foreach (Item aItem in ItemList)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    ItemList[ID].ItemName,
                    ItemList[ID].ItemCat,
                    ItemList[ID].ItemSize.ToString(),
                    Convert.ToDouble(ItemList[ID].ItemPrice).ToString("C"),
                    ItemList[ID].ItemMeals.ToString(),
                    (Convert.ToDouble(ItemList[ID].ItemPrice) / Convert.ToDouble(ItemList[ID].ItemSize)).ToString("C"),
                    (Convert.ToDouble(ItemList[ID].ItemPrice) / Convert.ToDouble(ItemList[ID].ItemMeals)).ToString("C")
                }));
                ID++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ItemList.Sort();
            //Print(ItemList); <---by Price
            ItemList.Sort(delegate (Item x, Item y)
            {
                return (x.ItemPrice / x.ItemSize).CompareTo((y.ItemPrice / y.ItemSize));
            });
            Print(ItemList);
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
            if (   !String.IsNullOrEmpty(textBoxName.Text)
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
            textBoxName.Text    = ItemList[Index].ItemName;
            textBoxCatEdit.Text = ItemList[Index].ItemCat;
            textBoxSize.Text    = ItemList[Index].ItemSize.ToString();
            textBoxPrice.Text   = ItemList[Index].ItemPrice.ToString();
            textBoxMeals.Text   = ItemList[Index].ItemMeals.ToString();
        }
    }
}
