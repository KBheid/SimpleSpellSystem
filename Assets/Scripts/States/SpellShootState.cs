using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class SpellShootState : State
{
	public delegate void ShootSpellInput();
	public static ShootSpellInput OnShootSpellInput;

	private readonly float TIME_UNTIL_RETURN_TO_WALK = 0.5f;

	private float currentTime = 0f;

	public SpellShootState(Rigidbody rb, Animator anim, StateChanged callback) : base(rb, anim, callback) { }

	protected override void OnEnterState()
	{
		base.OnEnterState();
		currentTime = 0f;

		OnShootSpellInput?.Invoke();
	}

	public override void Update(float deltaTime)
	{
		base.Update(deltaTime);

		currentTime += deltaTime;

		if (currentTime > TIME_UNTIL_RETURN_TO_WALK)
		{
			TransitionStates(new WalkState(_rb, animator, _stateChangedCallback));
		}
	}
}
