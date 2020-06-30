using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase itemDatabase;

    private void Start()
    {
        GiveItem(0);
        RemoveItem(0);
    }
    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        Debug.Log("Gave item: " + itemToAdd.title);
    }

    public Item checkForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        Item item = checkForItem(id);
        if (item != null)
        {
            characterItems.Remove(item);
            Debug.Log("Item removed from inventory: " + item.title);
        }
    }
}
