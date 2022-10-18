using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mod_Gravity : SpellModifier
{
	public override SpellModifier CreateCopy()
	{
		Mod_Gravity grav = new Mod_Gravity();
		grav.owner = owner;
		return grav;
	}

	public override void OnApply()
	{
		owner.direction += Vector3.down * 2.0f;
	}

	public override void OnCollision(GameObject other)
	{
	}

	public override void OnPeriodic(float deltaTime)
	{
	}
}
