using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
	public State currentState;

	Animator _animator;
	Rigidbody _rb;

	// Start is called before the first frame update
	void Start()
	{
		_animator = GetComponent<Animator>();
		_rb = GetComponent<Rigidbody>();

		currentState = new WalkState(_rb, _animator, OnStateChange);
	}

	void OnStateChange(State state)
	{
		currentState = state;
	}

	// Update is called once per frame
	void Update()
	{
		float xMovement = Input.GetAxisRaw("Horizontal");
		float mouseXMovement = Input.GetAxis("Mouse X");
		float mouseYMovement = Input.GetAxis("Mouse Y");

		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + Vector3.up * mouseXMovement);

		currentState.Update(Time.deltaTime);
	}

	private void OnGUI()
	{
		// Send input to current state
		Event e = Event.current;

		switch (e.type)
		{
			case EventType.KeyDown:
				currentState.Input(e.keyCode, true);
				break;

			case EventType.KeyUp:
				currentState.Input(e.keyCode, false);
				break;
		}
	}

}
