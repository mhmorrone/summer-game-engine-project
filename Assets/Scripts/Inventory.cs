using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public ItemDatabase itemDatabase;
    public Item weapon; //0
    public Item gear;   //1
    public Item held;   //2
    public Item bag;    //3

    private void Start()
    {
        GiveItem(0);
       // RemoveItem(0);
    }

    public void GiveItem(int id)
    {
        Item itemToAdd = itemDatabase.GetItem(id);
        //characterItems.Add(itemToAdd);
    	switch(itemToAdd.type){
	    case 0:
		if (weapon !=null) RemoveItem(weapon.id);
		weapon = itemToAdd;
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

    public void drop(int id){
	//TODO
    }

    public void RemoveItem(int id)
    {
        Item item = itemDatabase.GetItem(id);
        if (item != null)
        {
            switch (item.type)
            {
                case 0:                   
                    weapon = null;
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
			drop(id);
        }

    }
    public void removeWeapon()
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