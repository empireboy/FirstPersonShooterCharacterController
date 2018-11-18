using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : RigidbodyMovementBase
	{
		[SerializeField] private float _speed = 5f;

		private bool _isInputMagnitudeGettingBigger = false;
		private bool _isInputMagnitudeGettingSmaller = false;
		private float _previousInputMagnitude;

		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			speed = _speed;
		}

		private void Update()
		{
			_isInputMagnitudeGettingBigger = (inputs.magnitude > _previousInputMagnitude && !Mathf.Approximately(inputs.magnitude, _previousInputMagnitude) || inputs.magnitude >= 1);
			_isInputMagnitudeGettingSmaller = (inputs.magnitude < _previousInputMagnitude && !Mathf.Approximately(inputs.magnitude, _previousInputMagnitude) || inputs.magnitude <= 0);

			if (_isInputMagnitudeGettingBigger && !IsMoving)
				OnMoveStart();

			if (_isInputMagnitudeGettingSmaller && IsMoving)
				OnMoveStop();

			isMoving = (inputs.magnitude > _previousInputMagnitude || inputs.magnitude >= 1) ? true : false;

			inputs = transform.TransformDirection(inputs);

			_previousInputMagnitude = inputs.magnitude;
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + inputs * speed * Time.fixedDeltaTime);
		}
	}
}