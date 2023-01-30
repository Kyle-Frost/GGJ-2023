using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combine : MonoBehaviour
{
    public GameObject slotOne;
    public GameObject slotTwo;

    private Item itemOne;
    private Item itemTwo;

    public List<Recipe> Recipes = new List<Recipe>();

    public int counter = 0;

    public GameObject inventory;
    public GameObject itemPrefab;

    public void CreateObject(Item element)
    {
        GameObject ele = Instantiate(itemPrefab, inventory.transform);
        ele.GetComponentInChildren<DraggableItem>().item = element;
        ele.GetComponentInChildren<DraggableItem>().UpdateImage();
        
    }

    private void Update()
    {
        if (slotOne.transform.childCount == 1 && slotTwo.transform.childCount == 1)
        {
            itemOne = slotOne.GetComponentInChildren<DraggableItem>().item;
            itemTwo = slotTwo.GetComponentInChildren<DraggableItem>().item;


            foreach (Recipe rec in Recipes)
            {
                if ((itemOne == rec.itemOne && itemTwo == rec.itemTwo) ||
                    itemOne == rec.itemTwo && itemTwo == rec.itemOne)
                {
                    //Give new item
                    Debug.Log("Created " + rec.createdItem.itemName);
                    CreateObject(rec.createdItem);
                    Recipes.Remove(rec);
                    break;
                }
            }

            slotOne.transform.GetChild(0).SetParent(slotOne.GetComponentInChildren<DraggableItem>().originalParent);
            slotTwo.transform.GetChild(0).SetParent(slotTwo.GetComponentInChildren<DraggableItem>().originalParent);

            counter = 0;
        }
    }
}
