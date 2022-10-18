using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDown : SpellStage
{
	private readonly float ADJUSTMENT = 1f;

	protected override void ExitStage() { }

	public override void OnPeriodic(float deltaTime)
	{
		base.OnPeriodic(deltaTime);

		owner.direction += ADJUSTMENT * deltaTime * Vector3.up/stageRange * -1;
	}
	
	public override SpellStage CreateCopy()
	{
		ListDown copy = new ListDown();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}
}
