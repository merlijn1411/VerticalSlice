using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseManager : MonoBehaviour
{
	public enum ElementType { Physic, Ghost, Grass }

	PlayerStats Player;
	EnemyStats Enemy;

	[SerializeField] private Button AttackBtn1, AttackBtn2, AttackBtn3, AttackBtn4 = null;

	//[SerializeField] private GameObject UICanvas = null;
	//[SerializeField] private GameObject CanvasStart = null;
	//[SerializeField] private GameObject CanvasAttack = null;

	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;

	[SerializeField] private Healthbar Playerhealthbar;
	[SerializeField] private Healthbar Enemyhealthbar;

	private bool isplayerTurn = true;

	Animator Phan_anim;
	Animator Reu_anim;

	void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();

		Phan_anim = GameObject.Find("Phantump").GetComponent<Animator>();
		Reu_anim = GameObject.Find("Reuniclus").GetComponent<Animator>();
	}
	private void Update()
	{
		if (Player.CurrentHealth <= 0 || Enemy.CurrentHealth <= 0)
		{
			StopAllCoroutines();
		}
	}
	private void Attack1(Component target)
	{
		if (target == Enemy)
		{
			Phan_anim.SetBool("Hurt", true);
			Enemy.CurrentHealth -= CalculateDamage(Player.AttackDamage, Player.typeElement);
			Enemyhealthbar.time = 0f;
			Invoke("PlayerIdleAnim", 0.1f);
			Invoke("EnemyIdleAnim", 0.8f);
		}
		else if (target == Player)
		{
			Reu_anim.SetBool("Hurt", true);
			Player.CurrentHealth -= CalculateDamage(Enemy.AttackDamage, Enemy.typeElement);
			Playerhealthbar.time = 0f;
			Invoke("EnemyIdleAnim", 0.1f);
			Invoke("PlayerIdleAnim", 0.8f);
		}
		ChangeTurn();
	}

	public void BtnAttack1()
	{
		Reu_anim.SetBool("Attack", true);
		Attack1(Enemy);
	}

	void PlayerIdleAnim()
	{
		Reu_anim.SetBool("Attack", false);
		Reu_anim.SetBool("Hurt", false);
	}
	void EnemyIdleAnim()
	{
		Phan_anim.SetBool("Attack", false);
		Phan_anim.SetBool("Hurt", false);
	}

	private void ChangeTurn()
	{
		isplayerTurn = !isplayerTurn;

		if (!isplayerTurn)
		{
			//UICanvas.SetActive(false);
			AttackBtn1.interactable = false;
			AttackBtn2.interactable = false;
			AttackBtn3.interactable = false;
			AttackBtn4.interactable = false;

			StartCoroutine(EnemyTurn());
		}
		else
		{
			//Invoke("ResetCanvas", 1);
			AttackBtn1.interactable = true;
			AttackBtn2.interactable = true;
			AttackBtn3.interactable = true;
			AttackBtn4.interactable = true;
		}
	}
	/*/public void ResetCanvas()
	{
		CanvasStart.SetActive(true);
		CanvasAttack.SetActive(false);
		UICanvas.SetActive(true);
	}/*/

	public int CalculateDamage(int AttackDamage, ElementType elementType)
	{
		float PokemonDamage = AttackDamage;
		switch (elementType)
		{
			case ElementType.Physic:
				PokemonDamage = AttackDamage * PhysicPower;
				break;
			case ElementType.Ghost:
				PokemonDamage = AttackDamage * GhostPower;
				break;
			case ElementType.Grass:
				PokemonDamage = AttackDamage * GrassPower;
				break;

		}
		return Mathf.RoundToInt(PokemonDamage);
	}

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(3);

		int random = 0;
		random = Random.Range(1, 3);
		Debug.Log("deze Randomizer is voor later " + random);
		Attack1(Player);
		Phan_anim.SetBool("Attack", true);
	}
}