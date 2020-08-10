using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id; //Each item has a unique ID
    public string title; //Name of the item
    public string description; //Description of the item
    public Sprite icon; //Icon to display item in inventory GUI
    public Dictionary<string, int> stats = new Dictionary<string, int>(); //To store attribute values as required.
    public int type; //0=weapon, 1=gear, 2=held, 3=bag;
    public int weight;//For inventory limited to weight, not implemented
	public bool consumable; //Item removed upon use
	public int value; //Item worth
	
    //Constructor with all fields filled
    public Item(int id, string title, string description, int type, int weight, bool consumable, int value, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
        this.stats = stats;
        this.type = type;
        this.weight = weight;
		this.consumable = consumable;
		this.value = value;
		
    }

    //Copy constructor
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + item.title);
        this.type = item.type;
        this.weight = item.weight;
        this.stats = item.stats;
		this.consumable = item.consumable;
		this.value = item.value;
    }

}