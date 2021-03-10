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

namespace Grocery_Helper_GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Item> ItemList = Item.Load();
            //listView1.Items.Add(new ListViewItem(ItemList.ToString()));
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
        public static List<Item> Print(List<Item> ItemsList)
        {
            int ID = 1;
            String Message = "";
            Message = ("   ItemName\t\tType\tSize\tPrice\tMeals\t$/Oz\t$/Meal");
            foreach (Item aItem in ItemsList)
            {
                Message = Message + (ID.ToString().PadRight(3, ' ') + aItem + "\n");
                ID++;
            }
            MessageBox.Show(Message);
            return ItemsList;
        }

        //Use **Item.Save(ItemList);** to Save ItemsList to a file with '^' delimiters.
        //CURRENTLY: uses ItemsList[0].ItemCat to determine filename.
        public static void Save(List<Item> ItemsList)
        {
            //string SaveLine ="";
            //StreamWriter SaveFile = File.AppendText($"./{ItemsList[0].ItemCat}.txt");
            StreamWriter SaveFile = File.AppendText($"D:/Test/{ItemsList[0].ItemCat}.txt");
            foreach (Item aItem in ItemsList)
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
        }

        //Use **Item.Load()** to load this module.
        //Use **List<Item> ItemList = Item.Load();** to load this module and return the ItemList.
        //Currently only loads hardcoded file.
        public static List<Item> Load()
        {
            List<Item> ItemList = new List<Item>();
            Form1.listView1.Items.Clear();
            string Catagory = "snacks";

            //if (!File.Exists($"./{Catagory}.txt")) { Console.WriteLine("File not Found"); Main(); }
            if (!File.Exists($"D:/Test/{Catagory}.txt")) { Console.WriteLine("File not Found"); }//TEMP Program.Main(); }
            //string[] LoadFile = File.ReadAllLines($"./{Catagory}.txt");
            string[] LoadFile = File.ReadAllLines($"D:/Test/{Catagory}.txt");
            foreach (string Line in LoadFile)
            {
                //for (int Col = 0; Col < 5; Col++)
                //{
                //Console.WriteLine(Line);
                string[] Field = Line.Split('^');
                //ItemsArray[ItemsCount, Col] = Field[Col];
                //Form1.listView1.Items.Add(new ListViewItem(new string[] { Field[0].ToString(), Field[3].ToString() }));

                Form1.listView1.Items.Add(new ListViewItem(new string[] { Field[0], Field[1], Field[2], Convert.ToDouble(Field[3]).ToString("C"), Field[4], (Convert.ToDouble(Field[3]) / Convert.ToDouble(Field[2])).ToString("C"), (Convert.ToDouble(Field[3]) / Convert.ToDouble(Field[4])).ToString("C") }));
                ItemList.Add(new Item() {
                    ItemName = Field[0],
                    ItemCat = Field[1],
                    ItemSize = Convert.ToDouble(Field[2]),
                    ItemPrice = Convert.ToDouble(Field[3]),
                    ItemMeals = Convert.ToDouble(Field[4]) });
                //}

            }
            Console.WriteLine(ItemList[0].ItemName);
            Item.Print(ItemList);
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
