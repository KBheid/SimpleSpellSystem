using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class FallState : State
{
	public FallState(Rigidbody rb, Animator anim, StateChanged callback) : base(rb, anim, callback) { }

	public override void Update(float deltaTime)
	{
		base.Update(deltaTime);

		Vector2 pos = _rb.transform.position;
		pos.y -= 0.015f;

		bool hit = Physics.BoxCast(pos, new Vector3(0.15f, 3f, 0.15f), Vector3.down, Quaternion.identity, 0.05f, layerMask: LayerMask.GetMask("Wall"));
		if (hit)
		{
			TransitionStates(new WalkState(_rb, animator, _stateChangedCallback));
		}
	}

	protected override void OnEnterState()
	{
		base.OnEnterState();
		animator.SetTrigger("BeginFall");
	}

	protected override void OnExitState()
	{
		base.OnExitState();
		animator.SetBool("Grounded", true);
	}
}