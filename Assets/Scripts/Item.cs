using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    public int type;
    public int weight;
	public bool consumable;
	public int value;
	
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