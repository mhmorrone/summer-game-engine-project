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
        items = new List<Item> { 
            new Item(0, "Steel Sword", "A sword made of steel.", IronSword,
            new Dictionary<string, int>
            {
                {"Damage", 10 }

            })
          };
    }
}
