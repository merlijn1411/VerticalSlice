using System;
using UnityEngine;


public class EndPanelAnimation : MonoBehaviour
{

    static public event Action OnPanelAnimationEndEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnPanelAnimationEnd()
    {
        OnPanelAnimationEndEvent?.Invoke();
    }


}
