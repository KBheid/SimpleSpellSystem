using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListUp : SpellStage
{
	private readonly float ADJUSTMENT = 1f;

	protected override void ExitStage() { }

	public override void OnPeriodic(float deltaTime)
	{
		base.OnPeriodic(deltaTime);

		owner.direction += ADJUSTMENT * deltaTime * Vector3.up/stageRange;
	}

	public override SpellStage CreateCopy()
	{
		ListUp copy = new ListUp();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}
}
