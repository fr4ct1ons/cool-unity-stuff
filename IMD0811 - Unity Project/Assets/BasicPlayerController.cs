using System;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    private void Start()
    {
        PickableItem.OnItemPickup.AddListener(Test);
    }

    public void Test(Item item)
    {
        Debug.Log(item.itemName);
    }
}