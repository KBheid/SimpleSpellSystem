using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class State
{
	public delegate void StateChanged(State state);

	protected Rigidbody _rb;
	protected Animator animator;

	protected StateChanged _stateChangedCallback;

	protected State(Rigidbody rb, Animator anim, StateChanged callback)
	{
		_rb = rb;
		animator = anim;
		_stateChangedCallback = callback;
	}

	protected virtual void OnEnterState() { }
	protected virtual void OnExitState() { }
	public virtual void Update(float deltaTime) { }
	// pressed 
	public virtual void Input(KeyCode key, bool pressed) { }

	protected virtual void TransitionStates(State state)
	{
		OnExitState();
		_stateChangedCallback(state);
		state.OnEnterState();
	}
}