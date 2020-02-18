using TMPro;
using UnityEngine;

public class ItemViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDesc;

    public void SetText(string newName, string newDescription)
    {
        itemName.SetText(newName);
        itemDesc.SetText(newDescription);
    }
}