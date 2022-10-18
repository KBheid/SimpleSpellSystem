using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod_LightningDamage : SpellModifier
{
	public override SpellModifier CreateCopy()
	{
		Mod_LightningDamage lightning = new Mod_LightningDamage();
		lightning.owner = owner;
		return lightning;
	}

	public override void OnApply()
	{
		float conversionDmg = owner.rawDamage * 0.5f;
		owner.rawDamage -= conversionDmg;
		owner.lightningDamage += conversionDmg;
	}

	public override void OnCollision(GameObject other)
	{
	}

	public override void OnPeriodic(float deltaTime)
	{
	}
}
