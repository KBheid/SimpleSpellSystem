using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalc : MonoBehaviour
{


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.TryGetComponent(out Goal goal))
		{
			goal.SetValues(GetComponent<Spell>());
		}
	}
}