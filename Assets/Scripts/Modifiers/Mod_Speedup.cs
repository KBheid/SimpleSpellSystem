using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod_Speedup : SpellModifier
{
	public override SpellModifier CreateCopy()
	{
		Mod_Speedup su = new Mod_Speedup();
		su.owner = owner;
		return su;
	}

	public override void OnApply()
	{
		owner.speed += 1.0f;
	}

	public override void OnCollision(GameObject other)
	{
	}

	public override void OnPeriodic(float deltaTime)
	{
	}
}
