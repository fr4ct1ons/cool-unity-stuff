using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogReader : MonoBehaviour
{
    [Tooltip("Name of the file to be read on Start.")]
    [SerializeField] string fileName; // CharacterIndex | ExpressionIndex | Text
    [SerializeField] TextMeshProUGUI testText, characterName;
    [SerializeField] GameObject[] characters = new GameObject[2];
    [SerializeField] DialogCharacter[] charactersInfo = new DialogCharacter[2];

    /// <summary>
    /// StreamReader for the CSV file containing the dialog.
    /// </summary>
    StreamReader file;

    string[] separated;

    void Start()
    {
        try
        {
            file = new StreamReader(fileName);
            separated = file.ReadLine().Split('|');
            //Debug.Log(separated[2]);
            int Id, index;
            if (int.TryParse(separated[1], out Id))
            {
                Debug.Log("Success! Value is " + Id);
                if (int.TryParse(separated[0], out index))
                {
                    Debug.Log("Also got the index! It's character" + index);
                    characters[index - 1].GetComponent<Image>().sprite = charactersInfo[index - 1].GetSprite((uint)Id - 1);
                    characterName.SetText(charactersInfo[index - 1].GetName());
                    testText.color = charactersInfo[index - 1].GetColor();
                }
            }
            else
            {
                Debug.Log("Error, value is " + separated[1]);
            }
            testText.text = separated[2];
        }
        catch(System.Exception e)
        {
            testText.text = "Could not open file :(";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!file.EndOfStream)
            {
                try
                {
                    separated = file.ReadLine().Split('|');
                    int Id, index;
                    if (int.TryParse(separated[1], out Id))
                    {
                        Debug.Log("Success! Value is " + Id);
                        if(int.TryParse(separated[0], out index))
                        {
                            Debug.Log("Also got the index! It's character" + index);
                            characters[index - 1].GetComponent<Image>().sprite = charactersInfo[index - 1].GetSprite((uint)Id - 1);
                            characterName.SetText(charactersInfo[index - 1].GetName());
                            testText.color = charactersInfo[index - 1].GetColor();
                        }
                    }
                    else
                    {
                        Debug.Log("Error, value is " + separated[1]);
                    }
                    testText.text = separated[2];
                }
                catch (System.Exception e)
                {
                    testText.text = "Could not open file :(";
                }
            }
            else
            {
                //testText.text = "Well, that's all.";
                Time.timeScale = 1.0f;
                FindObjectOfType<PlayerController>().ContinueMovement();
                Destroy(transform.parent.gameObject);
            }
        }

    }

    public void SetDialog(string newFile, DialogCharacter charLeft, DialogCharacter charRight)
    {

        fileName = newFile;
        charactersInfo[0] = charLeft;
        charactersInfo[1] = charRight;

        try
        {
            file = new StreamReader(fileName);
            separated = file.ReadLine().Split('|');
            //Debug.Log(separated[2]);
            int Id, index;
            if (int.TryParse(separated[1], out Id))
            {
                Debug.Log("Success! Value is " + Id);
                if (int.TryParse(separated[0], out index))
                {
                    Debug.Log("Also got the index! It's character" + index);
                    characters[index - 1].GetComponent<Image>().sprite = charactersInfo[index - 1].GetSprite((uint)Id - 1);
                    characterName.SetText(charactersInfo[index - 1].GetName());
                    testText.color = charactersInfo[index - 1].GetColor();
                    characters[index].GetComponent<Image>().sprite = charactersInfo[index].GetSprite((uint)0);
                }
            }
            else
            {
                Debug.Log("Error, value is " + separated[1]);
            }
            testText.text = separated[2];
        }
        catch (System.Exception e)
        {
            testText.text = "Could not open file :(";
        }
    }

}
