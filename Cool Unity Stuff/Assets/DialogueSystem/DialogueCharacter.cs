using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Dialogue Character", menuName = "Dialogue Character")]
public class DialogueCharacter : ScriptableObject
{
    [Tooltip("Name of the character.")]
    [SerializeField] string characterName;
    [Tooltip("List of expressions the character has. 0 is the default.")]
    [SerializeField] Sprite[] expressions;
    [Tooltip("Text color of the character.")]
    [SerializeField] Color32 textColor = Color.white;

    public Sprite GetSprite(uint index) { return expressions[index]; }
    public string GetName() { return characterName; }
    public Color32 GetColor() { return textColor; }
}
