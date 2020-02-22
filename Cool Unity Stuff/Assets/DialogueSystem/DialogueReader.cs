using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    [Tooltip("Name of the file to be read on Start.")]
    [SerializeField] protected string fileName; // CharacterIndex | ExpressionIndex | Text
    [SerializeField] protected TextMeshProUGUI dialogueText, characterName;
    [SerializeField] protected GameObject[] characters = new GameObject[2];
    [SerializeField] protected DialogueCharacter[] charactersInfo = new DialogueCharacter[2];

    /// <summary>
    /// StreamReader for the CSV file containing the dialog.
    /// </summary>
    protected StreamReader file;

    public delegate void DialogueDelegate(string[] separatedLine);

    protected Dictionary<string, DialogueDelegate> dialogueMethods;

    protected string[] separated;

    protected virtual void Start()
    {
        dialogueMethods = new Dictionary<string, DialogueDelegate>();
        //try
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
                    dialogueText.color = charactersInfo[index - 1].GetColor();
                }
            }
            else
            {
                Debug.Log("Error, value is " + separated[1]);
            }
            SetupReader();
            dialogueText.text = separated[2];
        }
        //catch(System.Exception e)
        {
            //dialogueText.text = e.Message;
        }
    }

    /// <summary>
    /// Called AFTER opening the file successfully. Override this method to include methods in the dialogueMethods dictionary.
    /// </summary>
    protected virtual void SetupReader()
    {
        
    }

    // Update is called once per frame
    /*protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AdvanceLine();
        }

    }*/

    public virtual void AdvanceLine()
    {
        if (!file.EndOfStream)
        {
            try
            {
                separated = file.ReadLine().Split('|');
                if (!(separated[0][0] == '#')) // If the first character is NOT a hashtag.
                {
                    int Id, index;
                    if (int.TryParse(separated[1], out Id))
                    {
                        if (int.TryParse(separated[0], out index))
                        {
                            characters[index - 1].GetComponent<Image>().sprite =
                                charactersInfo[index - 1].GetSprite((uint) Id - 1);

                            characterName.SetText(charactersInfo[index - 1].GetName());
                            dialogueText.color = charactersInfo[index - 1].GetColor();
                        }
                    }
                    else
                    {
                        Debug.LogError("Error reading value from line, value is " + separated[1]);
                    }

                    dialogueText.text = separated[2];
                }
                else // If the first character IS a hashtag
                {
                    dialogueMethods[separated[0]]?.Invoke(separated);
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Something is wrong with the file. Exception: " + e.Message);
            }
        }
        else
        {
            //testText.text = "Well, that's all.";
            Time.timeScale = 1.0f;
            Destroy(gameObject);
        }
    }

    protected virtual void SetNewDialogueFile(string newFile, DialogueCharacter charLeft, DialogueCharacter charRight)
    {

        fileName = newFile;
        charactersInfo[0] = charLeft;
        charactersInfo[1] = charRight;

        //try
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
                    dialogueText.color = charactersInfo[index - 1].GetColor();
                }
            }
            else
            {
                Debug.Log("Error, value is " + separated[1]);
            }
            Debug.Log(separated);
            dialogueText.text = separated[2];
        }
        //catch (System.Exception e)
        {
            //dialogueText.text = "Could not open file :(";
        }
    }
    
    public virtual void SetNewDialogueFile(string newFile)
    {

        file.Close();
        
        fileName = newFile;

        //try
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
                    dialogueText.color = charactersInfo[index - 1].GetColor();
                }
            }
            else
            {
                Debug.Log("Error, value is " + separated[1]);
            }
            dialogueText.text = separated[2];
        }
        //catch (System.Exception e)
        {
            //dialogueText.text = "Could not open file :(";
        }
    }

    private void OnDestroy()
    {
        file.Close();
    }
}
