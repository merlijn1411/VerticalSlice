using UnityEngine;
using UnityEngine.Events;

public class PsyshockAttack : MonoBehaviour
{
	[Header("PshyshockParticles")]
	public UnityEvent psyshockActivate,psyshocTake;
	public UnityEvent onMovePlayerChosen;
	
	public void Psyshock()
	{
		psyshockActivate.Invoke();
		onMovePlayerChosen.Invoke();
		psyshocTake.Invoke();
		
	}
}
