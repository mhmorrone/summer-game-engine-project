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

    void BuildDatabase()
    {
        // Item has the following members: int id, string title, string description, int type (1 = weapon, 2 = armor, 3 = hold item), int weight,
        // Dictionary<string, int> stats 
        items = new List<Item>() {
            new Item(0, "Iron Sword", "A sword made of iron.",1,10,
            new Dictionary<string, int>
            {
                {"Damage", 10 }

            }
            )
          };
    }
}
