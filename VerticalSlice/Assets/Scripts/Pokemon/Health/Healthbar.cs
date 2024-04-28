using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
	public Slider slider;
	public Gradient gradient;
	public Image Fill;

	private float lerpSpeed = 0.5f;
	public float time;

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;

		Fill.color = gradient.Evaluate(1f);
	}
	
	public void CurrentHealth(float targetHealth, float startHealth)
	{
		time += Time.deltaTime * lerpSpeed;

		Fill.color = gradient.Evaluate(slider.normalizedValue);

		slider.value = Mathf.Lerp(startHealth, targetHealth, time);

	}
	
}
