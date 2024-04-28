using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CameraAnimationController : MonoBehaviour
{
	[SerializeField] Animator animator;
	[SerializeField] Transform CamTR;
	
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	
	public void TriggerAnimation()
	{
		animator.SetTrigger("StartAttack");
	}
	
	public void StartDeadCam()
	{
		StartCoroutine(DoDeadCam());
	}

	private IEnumerator DoDeadCam()
	{
		yield return new WaitForSeconds(3.5f);
		animator.SetTrigger("Dead");
	}


}
