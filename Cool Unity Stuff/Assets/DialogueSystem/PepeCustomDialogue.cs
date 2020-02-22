using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PepeCustomDialogue : DialogueReader
{

    [SerializeField] private Button nextMessage;
    [SerializeField] private GameObject responseButtons;

    /// <summary>
    /// Called AFTER opening the file successfully. Override this method to include methods in the dialogueMethods dictionary.
    /// </summary>
    protected override void SetupReader()
    {
        dialogueMethods.Add("#PROMPTREACTION", ActivateButton);
    }

    // Update is called once per frame
    /*protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            AdvanceLine();
        }

    }*/

    private void ActivateButton(string[] notUsed)
    {
        responseButtons.SetActive(true);
    }
}
