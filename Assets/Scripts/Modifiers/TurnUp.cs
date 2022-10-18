using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnUp : SpellStage
{
	protected override void EnterStage()
	{
		base.EnterStage();

		owner.direction += Vector3.up;
	}

	protected override void ExitStage() { }

	public override SpellStage CreateCopy()
	{
		TurnUp copy = new TurnUp();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}
}
