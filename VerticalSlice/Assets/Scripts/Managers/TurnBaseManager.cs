using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnBaseManager : MonoBehaviour
{
	[Header("Attack Buttons")]
	private Button[] AttackButtons;

	public bool isplayerTurn = true;
	
	public UnityEvent onEnemyMove;
	
	[Header("PlayerEvents")] 
	public UnityEvent onPlayerMove;
	public UnityEvent onPlayerTurn;

	[Header("AttackEvents")] 
	public UnityEvent onDefaultChosen;
	public UnityEvent onPsyshockChosen;
	public UnityEvent onRecoverChosen;
	public UnityEvent onPainSplitChosen;
	
	public void DefaultMove()
	{
		onPlayerMove.Invoke();
		onDefaultChosen.Invoke();
		ChangeTurn();
	}

	public void PsyshockMove()
	{
		onPlayerMove.Invoke();
		onPsyshockChosen.Invoke();
		ChangeTurn();
	}
	
	public void RecoverMove()
	{
		onRecoverChosen.Invoke();
		ChangeTurn();
	}
	
	public void PainSplitMove()
	{
		onPlayerMove.Invoke();
		onPainSplitChosen.Invoke();
		ChangeTurn();
	}
	

	private void ChangeTurn()
	{
		isplayerTurn = !isplayerTurn;

		if (!isplayerTurn)
			StartCoroutine(EnemyTurn());
		else
			onPlayerTurn.Invoke();
		
	}
	

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(10);
		
		onEnemyMove.Invoke();
		
		yield return new WaitForSeconds(7.5f);

		ChangeTurn();

	}

	public void StopBattle()
	{
		StopAllCoroutines();
	}
	
}