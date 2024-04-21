using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TurnBaseManager : MonoBehaviour
{
	[SerializeField] private PokemonStats player;
	[SerializeField] private PokemonStats enemy;

	[Header("Attack Buttons")]
	private Button[] AttackButtons;

	[SerializeField] private GameObject UICanvas;
	[SerializeField] private GameObject CanvasStart;
	[SerializeField] private GameObject CanvasAttack;

	private DamageFormula damageFormula;

	[Header("Healthbars")]
	[SerializeField] private Healthbar Playerhealthbar;
	[SerializeField] private Healthbar Enemyhealthbar;

	public bool isplayerTurn = true;

	private PokemonAnimations PokemonAnimations;

	CameraAnimationController CamAttackTrigger;

	[Header("Dialogue Attributes")]
	[SerializeField] private Dialogue dialogueEnemy;
	[SerializeField] private TextPanelAnimation textAppear;

	[Header("Player Particles")]
	[SerializeField] private ParticleSystem PAttackParticle;
	[SerializeField] private ParticleSystem PAttackParticleTake;
	[SerializeField] private ParticleSystem RecoverParticles;

	[Header("Enemy Particles")]
	[SerializeField] private ParticleSystem EAttackParticle;
	[SerializeField] private ParticleSystem EAttackParticleTake;

	[Header("PshyshockParticles")]
	public UnityEvent psyshockActivate,psyshocTake;
	
	[Header("PlayerEvents")]
	public UnityEvent onMovePlayerChosen;
	public UnityEvent playerHasBeenHit;
	
	[Header("EnemyEvents")]
	public UnityEvent onMoveEnemyChosen;
	public UnityEvent enemyHasBeenHit;

	private void Awake()
	{
		damageFormula = GetComponent<DamageFormula>();
	}

	private void Start()
	{
		CamAttackTrigger = GameObject.Find("camera animation pivot").GetComponent<CameraAnimationController>();
	}
	private void Update()
	{
		// if (player.CurrentHealth <= 0)
		// {
		// 	Invoke("Playerdead", 3);
		// 	StopAllCoroutines();
		// }
		// else if (enemy.CurrentHealth <= 0)
		// {
		// 	CamAttackTrigger.GetComponent<CameraAnimationController>().DeadAnimationTrigger();
		// 	Invoke("Enemydead", 3);
		// 	StopAllCoroutines();
		// }
	}
	
	public void BtnAttack(int buttonIndex)
	{
		StartCoroutine(CamTriggerPlayer(buttonIndex));
	}
	public void BtnRecover(int buttonIndex)
	{
		StartCoroutine(Recover(buttonIndex));
		ChangeTurn();
	}
	private void Attack1(Component target)
	{
		if (target == enemy)
		{
			onMovePlayerChosen.Invoke();	
			PAttackParticle.Play();
			StartCoroutine(HurtDelay(enemy));
		}
		else if (target == player)
		{
			onMoveEnemyChosen.Invoke();
			EAttackParticle.Play();
			StartCoroutine(HurtDelay(player));
		}
		ChangeTurn();
	}
	private void PsyshockAttack(Component target)
	{
		if (target == enemy)
		{
			psyshockActivate.Invoke();
			onMovePlayerChosen.Invoke();
			psyshocTake.Invoke();

			HurtTrigger(enemy);

		}
		ChangeTurn();
	}
	private IEnumerator Recover(int buttonIndex)
	{
		yield return new WaitForSeconds(0.2f);
		UICanvas.SetActive(false);

		yield return new WaitForSeconds(3);

		if (buttonIndex == 2)
		{
			if (player.currentHealth <= player.maxHealth)
			{
				RecoverParticles.Play();
				yield return new WaitForSeconds(2.4f);

				player.currentHealth += (player.currentHealth / 2) + 20;

				Playerhealthbar.time = 0f;
			}
			else if (player.currentHealth >= player.maxHealth)
			{
				player.currentHealth = player.maxHealth;
			}
		}

	}

	private void ChangeTurn()
	{
		isplayerTurn = !isplayerTurn;

		if (!isplayerTurn)
			StartCoroutine(EnemyTurn());
		else
			Invoke("ResetCanvas", 1.5f);
		
	}

	public void ResetCanvas()
	{
		CanvasStart.SetActive(true);
		CanvasAttack.SetActive(false);
		UICanvas.SetActive(true);
	}

	

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(10);

		TextPanelAnimation textPanelAnimation = textAppear.GetComponent<TextPanelAnimation>();
		textPanelAnimation.GetComponent<TextPanelAnimation>().PanelAnimate();
		StartCoroutine(dialogueEnemy.GetComponent<Dialogue>().EnemyDialogueLine());

		yield return new WaitForSeconds(4);
		Attack1(player);
	}

	public IEnumerator CamTriggerPlayer(int buttonIndex)
	{
		yield return new WaitForSeconds(0.2f);
		UICanvas.SetActive(false);

		CamAttackTrigger.GetComponent<CameraAnimationController>().TriggerAnimation();
		yield return new WaitForSeconds(3f);

		if (buttonIndex == 0)
		{
			Attack1(enemy);
		}
		else if (buttonIndex == 1)
		{
			PsyshockAttack(enemy);
		}
	}
	public IEnumerator HurtDelay(Component target)
	{
		yield return new WaitForSeconds(2f);

		if (target == enemy)
		{
			PAttackParticleTake.Play();
			HurtTrigger(enemy);
		}
		else if (target == player)
		{
			EAttackParticleTake.Play();
			HurtTrigger(player);
		}
	}

	public void HurtTrigger(Component target)
	{
		if (target == player)
		{
			playerHasBeenHit.Invoke();
			StartCoroutine(ChangeHealthbar(player));
		}
		else if (target == enemy)
		{
			enemyHasBeenHit.Invoke();
			StartCoroutine(ChangeHealthbar(enemy));
		}
	}
	public IEnumerator ChangeHealthbar(Component target)
	{
		yield return new WaitForSeconds(1.75f);

		if (target == player)
		{
			player.currentHealth -= damageFormula.CalculateDamage(enemy.attackDamage, enemy.typeElement);
			Playerhealthbar.time = 0f;
		}
		else if (target == enemy)
		{
			enemy.currentHealth -= damageFormula.CalculateDamage(player.attackDamage, player.typeElement);
			Enemyhealthbar.time = 0f;
		}
		yield return new WaitForSeconds(3f);
	}

}