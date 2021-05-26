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
        //public override string ToString(string? Print)
        public string ToString(string Option)
        {
            if (Option == "Save")
            {
                return (
                      ItemName + "^"
                    + ItemCat + "^"
                    + ItemSize + "^"
                    + ItemPrice + "^"
                    + ItemMeals
                );
            }
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
        //public override int GetHashCode()
        //{
        //    return 0;
        //}

        //Use** ItemList.Remove(new Item() { ItemName = "Chex Mix" });** to delete the whole row.
        public bool Equals(Item other)
        {
            if (other == null) return false;
            return (this.ItemName.ToLower().Equals(other.ItemName.ToLower()));
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
