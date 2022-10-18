using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : SpellStage
{
	private readonly float Delay = 0.35f;
	private float currentTime = 0f;

	private List<GameObject> createdObjects = new List<GameObject>();

	public override void OnPeriodic(float deltaTime)
	{
		base.OnPeriodic(deltaTime);

		currentTime += deltaTime;

		if (currentTime >= Delay)
		{
			GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			go.transform.position = owner.transform.position;
			createdObjects.Add(go);
		}
	}

	// Boilerplate
	public override SpellStage CreateCopy()
	{
		Trail copy = new Trail();
		copy.SetCallback(_stateChangedCallback);
		copy.SetSpell(owner);
		copy.SetNextStage(nextStage);
		copy.spellModifiers = CreateModifierCopies();
		return copy;
	}

	protected override void ExitStage()
	{
		foreach (GameObject go in createdObjects)
			GameObject.Destroy(go);
	}
}
