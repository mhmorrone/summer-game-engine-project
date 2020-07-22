using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void Awake()
    {
        BuildDatabase();
    }

    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }

    void BuildDatabase()
    {
        // Item has the following members: int id, string title, string description, int type (0 = weapon, 1 = armor, 2 = hold item, 3 = backpack),
        // int weight, bool consumable, int value, int valueDictionary<string, int> stats 
        items = new List<Item>() {
            new Item(0, "Axe", "a fucking axe.",0,10, true, 10,
            new Dictionary<string, int>
            {
                {"Damage", 10 }

            }
            )
          };
    }
}
