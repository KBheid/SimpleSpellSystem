using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : SpellStage
{
	protected override void ExitStage() {

		Spell s1 = owner.CreateCopy();
		Spell s2 = owner.CreateCopy();

		s1.direction += Vector3.left;
		s2.direction += Vector3.left * -1;

	}

	// Boilerplate
	public override SpellStage CreateCopy()
	{
		Split copy = new Split();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}
}
