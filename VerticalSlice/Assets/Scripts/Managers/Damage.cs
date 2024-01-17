using UnityEngine;

public class Damage : MonoBehaviour
{
	PlayerStats Player;
	EnemyStats Enemy;


	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.Find("Reuniclus").GetComponent<PlayerStats>();
		Enemy = GameObject.Find("Phantump").GetComponent<EnemyStats>();
	}

	// Update is called once per frame
	void Update()
	{
		DamageFormula();
	}

	void DamageFormula()
	{
		//EnemyStats stats = new EnemyStats();

		int atkDef = Enemy.AttackDamage / Enemy.Defends;
		float randDmg = Random.Range(81f, 100f) / 100;
		float damage = ((2 * 38 / 5 + 2) * Player.AttackDamage * atkDef / 50 + 2) * 1f * 1.5f * randDmg * 1.5f;

		Debug.Log(damage);
	}
}
