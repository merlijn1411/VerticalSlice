using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TurnBaseManager : ButtonFinder
{
	PlayerStats Player;
	EnemyStats Enemy;

	[Header("Attack Buttons")]
	private Button[] AttackButtons;
	private int AttackButtonsIndex = 4;

	[SerializeField] private GameObject UICanvas = null;
	[SerializeField] private GameObject CanvasStart = null;
	[SerializeField] private GameObject CanvasAttack = null;

	[Header("Elemental Power")]
	[SerializeField] private float PhysicPower;
	[SerializeField] private float GhostPower;
	[SerializeField] private float GrassPower;

	[Header("Healthbars")]
	[SerializeField] private Healthbar Playerhealthbar;
	[SerializeField] private Healthbar Enemyhealthbar;

	private bool isplayerTurn = true;

	Animator Phan_anim;
	Animator Reu_anim;

	CameraAnimationController CamAttackTrigger;

	[SerializeField] private Dialogue dialogueEnemy;
	[SerializeField] private TextPanelAnimation textAppear;

	[Header("Player Particles")]
	public ParticleSystem PAttackParticle;
	public ParticleSystem PAttackParticleTake;
	public ParticleSystem RecoverParticles;

	[Header("Enemy Particles")]
	public ParticleSystem EAttackParticle;
	public ParticleSystem EAttackParticleTake;

	private void Awake()
	{
		AttackButtons = ButtonFinder.FindButtons("Canvas", "Buttons", "Canvas(Attacks)", "Button Attack", AttackButtonsIndex);
	}

	private void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();

		Phan_anim = GameObject.Find("Phantump").GetComponent<Animator>();
		Reu_anim = GameObject.Find("Reuniclus").GetComponent<Animator>();

		CamAttackTrigger = GameObject.Find("camera animation pivot").GetComponent<CameraAnimationController>();

		for (int i = 0; i < AttackButtons.Length; i++)
		{
			int buttonIndex = i;
			AttackButtons[i].onClick.AddListener(() => CamTriggerPlayer(AttackButtons[buttonIndex]));
		}
	}
	private void Update()
	{
		if (Player.CurrentHealth <= 0)
		{
			Invoke("Playerdead", 3);
			StopAllCoroutines();
		}
		else if (Enemy.CurrentHealth <= 0)
		{
			CamAttackTrigger.GetComponent<CameraAnimationController>().DeadAnimationTrigger();
			Invoke("Enemydead", 3);
			StopAllCoroutines();
		}
	}
	public void Playerdead()
	{
		Reu_anim.SetTrigger("Die");
	}
	public void Enemydead()
	{
		Phan_anim.SetTrigger("Die");
	}
	public void BtnAttack(int buttonIndex)
	{
		StartCoroutine(CamTriggerPlayer(AttackButtons[buttonIndex]));
	}
	public void BtnRecover(int buttonIndex)
	{
		StartCoroutine(Recover(AttackButtons[buttonIndex]));
		ChangeTurn();
	}
	private void Attack1(Component target)
	{
		if (target == Enemy)
		{
			Reu_anim.SetTrigger("Attack");
			PAttackParticle.Play();
			StartCoroutine(HurtDelay(Enemy));
		}
		else if (target == Player)
		{
			Phan_anim.SetTrigger("Attack");
			EAttackParticle.Play();
			StartCoroutine(HurtDelay(Player));
		}
		ChangeTurn();
	}
	private void PsyshockAttack(Component target)
	{
		if (target == Enemy)
		{
			Player.GetComponent<PlayerStats>().PlayPsyshockAnim();
			Reu_anim.SetTrigger("Attack");
			Enemy.GetComponent<EnemyStats>().PsyshockAnimtake();

			HurtTrigger(Enemy);

		}
		ChangeTurn();
	}
	private IEnumerator Recover(Button ChooseButton)
	{
		yield return new WaitForSeconds(3);
		if (ChooseButton == AttackButtons[3])
		{
			RecoverParticles.Play();
			yield return new WaitForSeconds(2.4f);
			Player.CurrentHealth += (Player.CurrentHealth / 2) + 20;
			Playerhealthbar.time = 0f;
		}
	}

	private void ChangeTurn()
	{
		isplayerTurn = !isplayerTurn;

		if (!isplayerTurn)
		{
			UICanvas.SetActive(false);
			StartCoroutine(EnemyTurn());
		}
		else
		{
			Invoke("ResetCanvas", 1);
		}
	}

	public void ResetCanvas()
	{
		CanvasStart.SetActive(true);
		CanvasAttack.SetActive(false);
		UICanvas.SetActive(true);
	}

	public int CalculateDamage(float damage, ElementType.ElementTypes elementType)
	{
		float randDmg = Random.Range(81f, 100f) / 100;
		if (!isplayerTurn)
		{
			int atkDef = Enemy.AttackDamage / Enemy.Defends;
			damage = ((2 * Player.level / 5 + 2) * Player.AttackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		}
		else
		{
			int atkDef = Player.AttackDamage / Player.Defends;
			damage = ((2 * Enemy.level / 5 + 2) * Enemy.AttackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;
		}
		float PokemonDamage = damage;

		switch (elementType)
		{
			case ElementType.ElementTypes.Physic:
				PokemonDamage = damage * PhysicPower;
				break;
			case ElementType.ElementTypes.Ghost:
				PokemonDamage = damage * GhostPower;
				break;
			case ElementType.ElementTypes.Grass:
				PokemonDamage = damage * GrassPower;
				break;
		}
		return Mathf.RoundToInt(PokemonDamage);
	}

	private IEnumerator EnemyTurn()
	{
		yield return new WaitForSeconds(10);

		TextPanelAnimation textPanelAnimation = textAppear.GetComponent<TextPanelAnimation>();
		textPanelAnimation.GetComponent<TextPanelAnimation>().PanelAnimate();
		StartCoroutine(dialogueEnemy.GetComponent<Dialogue>().EnemyDialogueLine());

		yield return new WaitForSeconds(4);
		Attack1(Player);
	}

	public IEnumerator CamTriggerPlayer(Button Buttonchoose)
	{
		CamAttackTrigger.GetComponent<CameraAnimationController>().TriggerAnimation();
		yield return new WaitForSeconds(3f);

		if (Buttonchoose == AttackButtons[1])
		{
			Attack1(Enemy);
		}
		if (Buttonchoose == AttackButtons[2])
		{
			PsyshockAttack(Enemy);
		}
	}
	public IEnumerator HurtDelay(Component target)
	{
		yield return new WaitForSeconds(2f);

		if (target == Enemy)
		{
			PAttackParticleTake.Play();
			HurtTrigger(Enemy);
		}
		else if (target == Player)
		{
			EAttackParticleTake.Play();
			HurtTrigger(Player);

		}
	}

	public void HurtTrigger(Component target)
	{
		if (target == Player)
		{
			Reu_anim.SetTrigger("Hurt");
			StartCoroutine(ChangeHealthbar(Player));
		}
		else if (target == Enemy)
		{
			Phan_anim.SetTrigger("Hurt");
			StartCoroutine(ChangeHealthbar(Enemy));
		}
	}
	public IEnumerator ChangeHealthbar(Component target)
	{
		yield return new WaitForSeconds(1.75f);

		if (target == Player)
		{
			Player.CurrentHealth -= CalculateDamage(Enemy.AttackDamage, Enemy.typeElement);
			Playerhealthbar.time = 0f;
		}
		else if (target == Enemy)
		{
			Enemy.CurrentHealth -= CalculateDamage(Player.AttackDamage, Player.typeElement);
			Enemyhealthbar.time = 0f;
		}
		yield return new WaitForSeconds(3f);
	}

}