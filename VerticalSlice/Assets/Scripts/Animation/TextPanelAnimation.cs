using UnityEngine;

public class TextPanelAnimation : MonoBehaviour
{
    Dialogue dialogue;
    private Animator Play;
    private bool AttackMove;
    private void Awake()
    {
        dialogue = GetComponent<Dialogue>();
    }

    void Start()
    {

        Play = GetComponent<Animator>();
    }

    public void PanelAnimate()
    {
        if (Play != null)
        {
            Play.SetTrigger("Appear");
        }
    }
}

    // Start is called before the first frame update

}
