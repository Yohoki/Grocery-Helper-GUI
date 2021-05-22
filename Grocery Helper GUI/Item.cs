using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grocery_Helper_GUI
{
    public class Item : IEquatable<Item>, IComparable<Item>//, IEnumerable<Item>
    {
        //Use **ItemList.Add(new Item() { ItemName = "Test", ItemCat="snackos", ItemSize = 6, ItemPrice = 5.00, ItemMeals = 2 });** to set values
        public string ItemName { get; set; }
        public string ItemCat { get; set; }
        public double ItemMeals { get; set; }
        public double ItemSize { get; set; }
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
        public override int GetHashCode()
        {
            return 0;
        }

        //Use** ItemList.Remove(new Item() { ItemName = "Chex Mix" });** to delete the whole row.
        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this.ItemName.ToLower().Equals(other.ItemName.ToLower()));
        }

        //Use **Item.Print(ItemList);** to print entire list.
        public static List<Item> Print(List<Item> ItemList)
        {
            int ID = 0;
            Form1.listView1.Items.Clear();

            foreach (Item aItem in ItemList)
            {
                Form1.listView1.Items.Add(new ListViewItem(new string[] {
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
            StreamWriter SaveFile = File.AppendText($"D:/Test/{Form1.textBoxCat.Text.ToString()}2.txt");
            foreach (Item aItem in ItemList)
            {
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
        public static List<Item> Load(List<Item> ItemList)
        {

            if (!File.Exists($"D:/Test/{Form1.textBoxCat.Text?.ToLower()}.txt")) { Console.WriteLine("File not Found"); return ItemList; }
            if (!String.IsNullOrEmpty(Form1.textBoxCat.Text))
            {
                string[] LoadFile = File.ReadAllLines($"D:/Test/{Form1.textBoxCat.Text?.ToLower()}.txt");

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


        // Default comparer for Item type.
        public int CompareTo(Item compareItem)
        {
            // A null value means that this object is greater.
            if (compareItem == null) { return 1; }
            else { return this.ItemPrice.CompareTo(compareItem.ItemPrice); }
        }
    }
}
