using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] Transform CamTR;

	// Start is called before the first frame update
	void Start()
	{
		animator = GetComponent<Animator>();
	}

	public void TriggerAnimation()
	{
		animator.SetTrigger("StartAttack");
	}
	public void DeadAnimationTrigger()
	{
		animator.SetTrigger("Dead");
	}


}
