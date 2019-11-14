using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ItemEvent : UnityEvent<Item>{}

public class PickableItem : MonoBehaviour
{
    [SerializeField] GameObject itemInfo, mainCanvas;
    [SerializeField] Item item;
    public static ItemEvent OnItemPickup;
    
    GameObject bufferInfoBox, player;
    bool canChange = false, playerTriggerStay = false;

    private void Awake()
    {
        OnItemPickup = new ItemEvent();
    }

    private void Update()
    {
        if(playerTriggerStay)
        {
            bufferInfoBox.transform.position = Camera.main.WorldToScreenPoint(transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                OnItemPickup.Invoke(item);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            playerTriggerStay = true;
            bufferInfoBox = Instantiate(itemInfo, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity);
            bufferInfoBox.transform.SetParent(mainCanvas.transform);
            bufferInfoBox.GetComponent<ItemViewer>().SetText(item.itemName, item.description);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerTriggerStay = false;
            Destroy(bufferInfoBox);
            canChange = false;
        }
    }
}
