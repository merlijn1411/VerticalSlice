using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class TurnBaseManager : MonoBehaviour
{
	PlayerStats Player;
	EnemyStats Enemy;

	[Header("Attack Buttons")]
	[SerializeField] private Button AttackBtn1 = null;
	[SerializeField] private Button AttackBtn2 = null;
	[SerializeField] private Button AttackBtn3 = null;
	[SerializeField] private Button AttackBtn4 = null;

	//[SerializeField] private GameObject UICanvas = null;
	//[SerializeField] private GameObject CanvasStart = null;
	//[SerializeField] private GameObject CanvasAttack = null;

	[Header("Elemental Power")]
	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;

	[Header("Healthbars")]
	[SerializeField] private Healthbar Playerhealthbar;
	[SerializeField] private Healthbar Enemyhealthbar;

	private bool isplayerTurn = true;
	private bool IsInteractableButton = true;

	Animator Phan_anim;
	Animator Reu_anim;

	CameraAnimationController CamAttackTrigger;

	[Header("Player Particles")]
	public ParticleSystem PAttackParticle;
	public ParticleSystem PAttackParticleTake;

	[Header("Enemy Particles")]
	public ParticleSystem EAttackParticle;
	public ParticleSystem EAttackParticleTake;

	void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();

		Phan_anim = GameObject.Find("Phantump").GetComponent<Animator>();
		Reu_anim = GameObject.Find("Reuniclus").GetComponent<Animator>();

		CamAttackTrigger = GameObject.Find("camera animation pivot").GetComponent<CameraAnimationController>();

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
			Reu_anim.SetBool("Attack", true);
			PAttackParticle.Play();
			StartCoroutine(HurtDelay(Enemy));
		}
		else if (target == Player)
		{
			Phan_anim.SetBool("Attack", true);
			EAttackParticle.Play();
			StartCoroutine(HurtDelay(Player));
		}
		ChangeTurn();
	}

	public void BtnAttack1()
	{
		IsInteractable();
		StartCoroutine(CamTriggerPlayer());
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
			StartCoroutine(EnemyTurn());
		}
		else
		{
			//Invoke("ResetCanvas", 1);
		}
	}
	public void IsInteractable()
	{
		IsInteractableButton = !IsInteractableButton;

		if (!IsInteractableButton)
		{
			AttackBtn1.interactable = false;
			AttackBtn2.interactable = false;
			AttackBtn3.interactable = false;
			AttackBtn4.interactable = false;
		}
		else
		{
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

	public int CalculateDamage(int AttackDamage, ElementType.ElementTypes elementType)
	{
		float PokemonDamage = AttackDamage;
		switch (elementType)
		{
			case ElementType.ElementTypes.Physic:
				PokemonDamage = AttackDamage * PhysicPower;
				break;
			case ElementType.ElementTypes.Ghost:
				PokemonDamage = AttackDamage * GhostPower;
				break;
			case ElementType.ElementTypes.Grass:
				PokemonDamage = AttackDamage * GrassPower;
				break;
		}

		switch (elementType | elementType)
		{
			case ElementType.ElementTypes.Ghost | ElementType.ElementTypes.Grass:
				PokemonDamage = AttackDamage * GrassPower * GhostPower;
				break;
		}
		return Mathf.RoundToInt(PokemonDamage);
	}

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(10);

		int random = 0;
		random = Random.Range(1, 3);
		Debug.Log("deze Randomizer is voor later " + random);

		Attack1(Player);
	}

	public IEnumerator CamTriggerPlayer()
	{
		CamAttackTrigger.GetComponent<CameraAnimationController>().TriggerAnimation();
		yield return new WaitForSeconds(3f);

		Attack1(Enemy);
	}
	public IEnumerator HurtDelay(Component target)
	{
		yield return new WaitForSeconds(2f);

		if (target == Enemy)
		{
			PAttackParticleTake.Play();
			HurtEnemyTrigger();
		}
		else if (target == Player)
		{
			EAttackParticleTake.Play();
			HurtPlayerTrigger();

			IsInteractable();
		}
	}

	public void HurtEnemyTrigger()
	{
		Phan_anim.SetBool("Hurt", true);
		Enemy.CurrentHealth -= CalculateDamage(Player.AttackDamage, Player.typeElement);
		Enemyhealthbar.time = 0f;
		Invoke("PlayerIdleAnim", 0.1f);
		Invoke("EnemyIdleAnim", 0.8f);
	}
	public void HurtPlayerTrigger()
	{
		Reu_anim.SetBool("Hurt", true);
		Player.CurrentHealth -= CalculateDamage(Enemy.AttackDamage, Enemy.typeElement);
		Playerhealthbar.time = 0f;
		Invoke("EnemyIdleAnim", 0.1f);
		Invoke("PlayerIdleAnim", 0.8f);
	}
}