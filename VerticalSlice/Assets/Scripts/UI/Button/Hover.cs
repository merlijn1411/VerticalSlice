using UnityEngine;
using UnityEngine.EventSystems;

public class Hover : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
	[SerializeField] private GameObject hoverIMG;


	public void OnPointerEnter(PointerEventData eventData)
	{
		hoverIMG.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		hoverIMG.SetActive(false);
	}
}
