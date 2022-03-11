using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] Item[] items;

    public Item activeItem { get; set; }

    List<Item> inventory = new List<Item>();
    int itemIndex = 0;

    void Start()
    {
        //inventory.AddRange(items);
        inventory.Add(null);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //itemIndex++;
            if (++itemIndex >= inventory.Count) itemIndex = 0;
            ActivateItem(inventory[itemIndex]);
        }
            //if (Input.GetKeyDown(KeyCode.Alpha1)) ActivateItem(null);
            //if (Input.GetKeyDown(KeyCode.Alpha2)) ActivateItem(inventory[0]);
            //if (Input.GetKeyDown(KeyCode.Alpha3)) ActivateItem(inventory[1]);

            activeItem?.UpdateItem();
    }

    void ActivateItem(Item item)
    {
        activeItem?.Deactivate();
        activeItem = item;
        activeItem?.Activate();
    }

    public void StartItem()
    {
        if (activeItem is Weapon weapon)
        {
            weapon.Fire();
        }
    }

    public bool AddItem(Item.Type type)
    {
        if (HasItem(type)) return false;

        var item = items.FirstOrDefault(item => item.type == type);
        inventory.Add(item);

        return true;
    }

    public bool HasItem(Item.Type type)
    {
        return inventory.Any(item => item?.type == type);
    }
}
