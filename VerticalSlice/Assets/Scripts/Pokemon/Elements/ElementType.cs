using System;
using UnityEngine;

public class ElementType : MonoBehaviour
{
	[Flags]
	public enum ElementTypes
	{
		Physic = 1,
		Ghost = 2,
		Grass = 4
	}
}
