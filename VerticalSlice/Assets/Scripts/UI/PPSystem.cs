using UnityEngine;
using UnityEngine.UI;

public class PPSystem : MonoBehaviour
{
	public int pp = 5;
	[SerializeField] private Button attackButton;

	public void DecreasePP()
	{
		Debug.Log(pp);
		pp -= 1;
		if (pp <= 0)
		{
			attackButton.interactable = false;
		}
	}

}