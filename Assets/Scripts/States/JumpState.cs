using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class JumpState : State
{
	private float _delayBeforeJump = 0.1f;
	private float _delayed = 0f;
	private bool _forceApplied = false;

	public JumpState(Rigidbody rb, Animator anim, StateChanged callback) : base(rb, anim, callback) { }

	public override void Update(float deltaTime)
	{
		base.Update(deltaTime);

		_delayed += deltaTime;

		if (_delayed < _delayBeforeJump)
			return;

		if (!_forceApplied)
		{
			_rb.AddForce(new Vector3(0, 0, 100));
			_forceApplied = true;
		}


		if (_rb.velocity.y < -0.5f)
		{
			TransitionStates(new FallState(_rb, animator, _stateChangedCallback));
		}
	}

	protected override void OnEnterState()
	{
		base.OnEnterState();

		animator.SetTrigger("BeginJump");
		animator.SetBool("Grounded", false);
	}
}