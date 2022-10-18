using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
	[SerializeField]
	Text rawDamage;
	[SerializeField]
	Text fireDamage;
	[SerializeField]
	Text lightningDamage;

	public void SetValues(Spell s)
	{
		rawDamage.text = s.rawDamage.ToString() + " raw";
		fireDamage.text = s.fireDamage.ToString() + " fire";
		lightningDamage.text = s.lightningDamage.ToString() + " lightning";

		StartCoroutine(nameof(ClearTextAfterDelay));
	}

	IEnumerator ClearTextAfterDelay()
	{
		yield return new WaitForSecondsRealtime(3f);

		rawDamage.text = "";
		fireDamage.text = "";
		lightningDamage.text = "";
	}
}
