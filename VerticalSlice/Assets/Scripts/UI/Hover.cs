using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
	public GameObject HoverIMG;
	public void OnPointerEnter(PointerEventData eventData)
	{
		HoverIMG.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		HoverIMG.SetActive(false);
	}
}
