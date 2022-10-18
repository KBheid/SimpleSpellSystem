using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Straight : SpellStage
{
	// Boilerplate
	public override SpellStage CreateCopy()
	{
		Straight copy = new Straight();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}

	protected override void ExitStage() { }
}
