using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueScript1 : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI nameCharacterText;

    public string[] lines;
    public string[] names;

    public float textSpeed = 0.1f;

    public Animator animator;
    public GameObject transition;

    int index;

    void Start()
    {
        dialogueText.text = string.Empty;
        nameCharacterText.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(dialogueText.text == lines[index]){
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = lines[index];
            }
            if (index == 1)
        {
            animator.Play("deadRoshi");
        }
        }
    }

    public void StartDialogue(){
        index = 0;

        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine(){
        nameCharacterText.text = names[index];
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine(){
        if (index < lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            nameCharacterText.text = string.Empty;
            StartCoroutine(WriteLine());
        }
        else
        {
            gameObject.SetActive(false);
            transition.SetActive(true);
			
			Invoke("ChangeScene", 1);
        }
    }

    void ChangeScene(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}
}
