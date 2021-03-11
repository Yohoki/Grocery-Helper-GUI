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
            ItemList = Item.Load(ItemList);
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
    }

    public class Item : IEquatable<Item>, IComparable<Item>//, IEnumerable<Item>
    {
            //Use **ItemList.Add(new Item() { ItemName = "Test", ItemCat="snackos", ItemSize = 6, ItemPrice = 5.00, ItemMeals = 2 });** to set values
            //Set ItemName in ItemsList
        public string ItemName { get; set; }

        //Set ItemCat in ItemsList
        public string ItemCat { get; set; }

        //Set ItemMeals in ItemsList
        public double ItemMeals { get; set; }

        //Set ItemSize in ItemsList
        public double ItemSize { get; set; }

        //Set ItemPrice in ItemsList
        public double ItemPrice { get; set; }



        //Use WriteLine(ItemList) to display this string.
        public override string ToString()
        {
            return (
                      ItemName.PadRight(21, ' ')
                    + ItemCat.PadRight(8, ' ')
                    + ItemSize.ToString().PadRight(8, ' ')
                    + ItemPrice.ToString("C").PadRight(8, ' ')
                    + ItemMeals.ToString().PadRight(8, ' ')
                    + (ItemPrice / ItemSize).ToString("C").PadRight(8, ' ')
                    + (ItemPrice / ItemMeals).ToString("C").PadRight(8, ' ')
                    );
        }

        //Use **ItemList.Remove(new Item() { ItemName = "Chex Mix" });** to check if item can be deleted.
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Item objAsItem = obj as Item;
            if (objAsItem == null) return false;
            else return Equals(objAsItem);
        }

        // Not sure if needed. Can get hash from ItemNames, but not really useful for this project.
        // Maybe in other projects, I could use an ID and return that insead of a hash.
        // Use **ItemList.GetHashCode();** or **ItemList[1].GetHashCode()** to hash entire list or single item.
        public override int GetHashCode()
        {
            return 0;
            //return HashCode.Combine(ItemName);
        }

        //Use** ItemList.Remove(new Item() { ItemName = "Chex Mix" });** to delete the whole row.
        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this.ItemName.Equals(other.ItemName));
        }

        //Use **Item.Print(ItemList);** to print entire list.
        public static List<Item> Print(List<Item> ItemList)
        {
            int ID = 0;
            Form1.listView1.Items.Clear();

            foreach (Item aItem in ItemList)
            {
                Form1.listView1.Items.Add(new ListViewItem (new string[] {
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
            //temp MessageBox.Show(Form1.listView1.Items[1].ToString());
            return ItemList;
        }

        //Use **Item.Save(ItemList);** to Save ItemsList to a file with '^' delimiters.
        //CURRENTLY: uses ItemsList[0].ItemCat to determine filename.
        public static List<Item> Save(List<Item> ItemList)
        {
            //string SaveLine ="";
            //StreamWriter SaveFile = File.AppendText($"./{ItemsList[0].ItemCat}.txt");
            StreamWriter SaveFile = File.AppendText($"D:/Test/{Form1.textBoxCat.Text.ToString()}2.txt");
            foreach (Item aItem in ItemList)
            {
                //SaveLine = SaveLine + aItem + "^";
                SaveFile.WriteLine(
                      aItem.ItemName + "^"
                    + aItem.ItemCat + "^"
                    + aItem.ItemSize + "^"
                    + aItem.ItemPrice + "^"
                    + aItem.ItemMeals
                );
                SaveFile.Flush();
            }
            SaveFile.Close();
            Process.Start("notepad.exe", $"D:/Test/{Form1.textBoxCat.Text.ToString()}2.txt");
            return ItemList;
        }

        //Use **Item.Load()** to load this module.
        //Use **List<Item> ItemList = Item.Load();** to load this module and return the ItemList.
        //Currently only loads hardcoded file.
        public static List<Item> Load(List<Item> ItemList)
        {
            //List<Item> ItemList = new List<Item>();
            string Catagory = "snacks";
            //int ID = 0;

            //if (!File.Exists($"./{Catagory}.txt")) { Console.WriteLine("File not Found"); Main(); }
            if (!File.Exists($"D:/Test/{Form1.textBoxCat.Text?.ToLower()}.txt")) { Console.WriteLine("File not Found"); return ItemList; }
            //string[] LoadFile = File.ReadAllLines($"./{Catagory}.txt");
            if (!String.IsNullOrEmpty(Form1.textBoxCat.Text))
            {
                string[] LoadFile = File.ReadAllLines($"D:/Test/{Form1.textBoxCat.Text?.ToLower()}.txt");
                //string[] LoadFile = File.ReadAllLines($"D:/Test/{Catagory.ToLower()}.txt");

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
            else { return ItemList; }
            return ItemList;
        }
        public static List<Item> Load()
        {
            List<Item> ItemList = new List<Item>();
            //int ID = 0;

            //if (!File.Exists($"./{Catagory}.txt")) { Console.WriteLine("File not Found"); Main(); }
            //if (!File.Exists($"D:/Test/{Catagory}.txt")) { Console.WriteLine("File not Found"); }
            //string[] LoadFile = File.ReadAllLines($"./{Catagory}.txt");
            //string[] LoadFile = File.ReadAllLines($"D:/Test/{Catagory}.txt");
                //string[] LoadFile = File.ReadAllLines($"D:/Test/{Catagory.ToLower()}.txt");

            //foreach (string Line in LoadFile)
            //{
            //    string[] Field = Line.Split('^');
                
                ItemList.Add(new Item()
                {
                    ItemName = "",
                    ItemCat = "",
                    ItemSize = 0,
                    ItemPrice = 0,
                    ItemMeals = 0
                });
            //}
            return ItemList;
        }


        // Default comparer for Item type.
        public int CompareTo(Item compareItem)
        {
            // A null value means that this object is greater.
            if (compareItem == null) { return 1; }

            //else { return this.ItemPrice.CompareTo(compareItem.ItemPrice); }
            else { return this.ItemPrice.CompareTo(compareItem.ItemPrice); }
        }
    }

}
