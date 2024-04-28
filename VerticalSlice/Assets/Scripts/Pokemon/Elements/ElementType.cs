using System;
using UnityEngine;

public class ElementType : MonoBehaviour
{
	[Header("Elemental Power")]
	
	public const float physicPower = 1.35f;
	public const float ghostPower = 1.2f;
	public const float grassPower = 1.15f;
	
	[Flags]
	public enum ElementTypes
	{
		Physic = 1,
		Ghost = 2,
		Grass = 4
	}
}
