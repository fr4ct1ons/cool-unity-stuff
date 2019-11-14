using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item", order = 0)]
public class Item : ScriptableObject
{
    public string itemName;
    public int id;
    public string description;
}