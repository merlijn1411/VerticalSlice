using UnityEngine;
using UnityEngine.UI;


public class ButtonFinder : MonoBehaviour
{
	public static Button[] FindButtons(string canvasName, string buttonsCanvasName, string attacksCanvasName, string buttonName, int buttonsIndex)
	{
		Button[] attackButtons = new Button[buttonsIndex + 1];

		GameObject mainCanvasObject = GameObject.Find(canvasName);
		if (mainCanvasObject != null)
		{
			Transform buttonsCanvasTransform = mainCanvasObject.transform.Find(buttonsCanvasName);
			if (buttonsCanvasTransform != null)
			{
				Transform attacksCanvasTransform = buttonsCanvasTransform.Find(attacksCanvasName);
				if (attacksCanvasTransform != null)
				{
					Button buttonAttack = attacksCanvasTransform.Find(buttonName).GetComponent<Button>();

					if (buttonAttack != null)
					{
						for (var i = 0; i <= buttonsIndex; i++)
						{
							attackButtons[i] = buttonAttack;
						}
					}
					else
					{
						Debug.LogError(buttonName + " heeft geen Buttonomponent.");
					}
				}
				else
				{
					Debug.LogError(attacksCanvasName + " niet gevonden in de canvas met de buttons.");
				}
			}
			else
			{
				Debug.LogError(buttonsCanvasName + " niet gevonden.");
			}
		}
		else
		{
			Debug.LogError(canvasName + " niet gevonden.");
		}

		return attackButtons;
	}
}
