using UnityEngine;

public class TextPanelAnimation : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] Animator Play;

    void Start()
    {
        Play = GetComponent<Animator>();
        Dialogue.OnFinishedDialogue += PanelDissapear;
    }
    public void PanelAnimate()
    {
        Play.SetTrigger("Appear");
    }

    public void PanelDissapear()
    {
        Play.SetTrigger("Disapear");

    }
}
