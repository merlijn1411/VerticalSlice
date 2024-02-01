using UnityEngine;

public class ButtonSound : MonoBehaviour
{

	public AudioSource Button;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void ButtonNois()
	{
		Button.Play();
	}

}
