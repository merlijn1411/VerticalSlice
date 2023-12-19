using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    static public event Action OnFinishedDialogue;


    public TextMeshProUGUI textComponent;
    public string[] lines;
    private float textspeed;

    private int index;
    public GameObject Playing;


    // Start is called before the first frame update
    void Start()
    {
        Playing.SetActive(true);
        textspeed = 2 * Time.deltaTime;
        textComponent.text = string.Empty;
        StartDialogue();

        EndPanelAnimation.OnPanelAnimationEndEvent += PlayText;
    }

    // Update is called once per frame
    void Update()
    {
        PlayText();
    }

    public void PlayText()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char C in lines[index].ToCharArray())
        {
            textComponent.text += C;
            yield return new WaitForSeconds(textspeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            OnFinishedDialogue?.Invoke();
        }
    }
}
