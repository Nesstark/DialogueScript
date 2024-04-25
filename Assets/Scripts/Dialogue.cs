using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; //This is our textcomponent
    public string[] lines;  //String for our different text dialogues
    public float textSpeed; //This is our textspeed float
    public Animator animator;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        animator.SetBool("isTalking", true);
        StartCoroutine(TypeLine());
        // Play the appropriate sound based on the dialogue index
        PlayDialogueSound(index);
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
            // Play the appropriate sound based on the dialogue index
            PlayDialogueSound(index);
        }
        else
        {
            animator.SetBool("isTalking", false);
            gameObject.SetActive(false);
        }
    }
    // Play the appropriate sound based on the dialogue index
    void PlayDialogueSound(int index)
    {
   
        switch (index)
        {
            case 0:
                AudioManager.instance.PlaySound(14);
                break;
            case 1:
                AudioManager.instance.PlaySound(15); 
                break;
            case 2:
                AudioManager.instance.PlaySound(16); 
                break;
           
            default:
                break;
        }
    }
}