using UnityEngine;

public class TextPanelAnimation : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;
    [SerializeField] Animator Play;

    void Start()
    {

    }
    public void PanelAnimate()
    {
        Play.SetTrigger("Appear");
        /*
        if (dialogue.active == true)
        {
            Play.SetTrigger("Disapear");
        }
        */
    }
}
