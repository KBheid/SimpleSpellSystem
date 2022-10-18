using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class WalkState : State
{
	private bool movingForward;
	private bool movingBackwards;


	public WalkState(Rigidbody rb, Animator anim, StateChanged callback) : base(rb, anim, callback) { }

	public override void Input(KeyCode key, bool pressed)
	{
		base.Input(key, pressed);

		if (key == KeyCode.W)
		{
			movingForward = pressed;
		}
		if (key == KeyCode.S)
		{
			movingBackwards = pressed;
		}

		if (key == KeyCode.Space)
		{
			TransitionStates(new SpellShootState(_rb, animator, _stateChangedCallback));
		}
	}

	public override void Update(float deltaTime)
	{
		base.Update(deltaTime);

		if (movingForward)
		{
			_rb.AddForce(_rb.transform.forward * 500 * deltaTime);
		}
		if (movingBackwards)
		{
			_rb.AddForce(_rb.transform.forward * 500 * deltaTime * -1);
		}

		animator.SetBool("Moving", movingForward || movingBackwards);
	}
}
