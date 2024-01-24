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

	//these functions below activate a certain animation trigger (could be improved by making it so you can give the trigger name as argument so we only need 1 function)
	public void TriggerAnimation()
	{
		animator.SetTrigger("StartAttack");
	}
	public void DeadAnimationTrigger()
	{
		animator.SetTrigger("Dead");
	}


}
