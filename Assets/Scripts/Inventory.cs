using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemDatabase itemDatabase; //Database to look up items
    //Different slots for item types.
    public Item weapon; //0
    public Item gear;   //1
    public Item held;   //2
    public Item bag;    //3

    private void Start()
    {
        GiveItem(0); //Executed at start of game for testing purposes.
       // RemoveItem(0);
    }
    
    //Gives item of specified ID to player.
    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id); //Lookup item in database.
        //characterItems.Add(itemToAdd);
    	switch(itemToAdd.type){ //The type of the item affects which slot to palce it in.
	    case 0:
		if (weapon !=null) RemoveItem(weapon.id); //We remove the item if the slot is occupied.
		weapon = itemToAdd; //Put new item in proper slot.
                break;
	    case 1:
		if (gear !=null) RemoveItem(gear.id);
		gear = itemToAdd;
                break;
	    case 2:
		if (held !=null) RemoveItem(held.id);
		held = itemToAdd;
                break;
	    case 3:
		if (bag !=null) RemoveItem(bag.id);
		bag = itemToAdd;
                break;
        }
	Debug.Log("Gave item: " + itemToAdd.title + " which has a weight of " + itemToAdd.weight + " and a value of " + itemToAdd.value);
    }

    public void drop(int id){ //This is so the removed item drops to the floor, but it wasn't implemented.
	//TODO
    }

    public void RemoveItem(int id)
    {
        Item item = itemDatabase.GetItem(id); //Makes sure the item being removed is valid.
        if (item != null)
        {
            switch (item.type)
            {
                case 0:                   
                    weapon = null; //Clears proper item slot.
                    break;
                case 1:
                    gear = null;
                    break;
                case 2:
                    held = null;
                    break;
                case 3:
                    bag = null;
                    break;
            }
            Debug.Log("Item removed from inventory: " + item.title);
			drop(id);//Drop item.
        }

    }
    public void removeWeapon() //Methods to remove specific slots, used for inventory GUI x button.
    {
        RemoveItem(weapon.id);
    }
    public void removeGear()
    {
        RemoveItem(gear.id);
    }
    public void removeHold()
    {
        RemoveItem(held.id);
    }
    public void removeBackpack()
    {
        RemoveItem(bag.id);
    }



}