using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public string[] dialogueLines;
    public Dialog dialogScript;
    public GameObject player;
    public float detectionRange = 10f;

    private bool isDialogueActive = false;

    private void Start()
    {
        dialogScript.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (player == null || dialogScript == null)
        {
            Debug.LogWarning("Make sure all references are set in the Inspector!");
            return;
        }

        float distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance <= detectionRange && !isDialogueActive)
        {
            dialogScript.SetLinesAndStartDialogue(dialogueLines);
            isDialogueActive = true;
        } 

        else if (distance > detectionRange && isDialogueActive)
        {
            dialogScript.gameObject.SetActive(false);
            isDialogueActive = false;
        }
    }
}
