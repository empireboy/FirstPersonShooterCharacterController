using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : MovementBase
	{
		[SerializeField] private MovementInputBase _movementInput;
		[SerializeField] private MovementAnimationsBase _movementAnimations;
		[SerializeField] public float speed = 5f;
		[SerializeField] private float _sidewaysMovementFactor = 0.5f;

		private Vector3 _input = Vector3.zero;

		private bool _isInputMagnitudeGettingBigger = false;
		private bool _isInputMagnitudeGettingSmaller = false;
		private bool _sidewaysMovement = false;
		private float _previousInputMagnitude;

		private float _currentSpeed;

		private Rigidbody _rigidbody;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			_currentSpeed = speed;
		}

		private void Update()
		{
			// Get input
			if (_movementInput)
				_input = _movementInput.GetInput();

			// Max magnitude of 1
			_input = Vector3.ClampMagnitude(_input, 1);

			// Slower or faster sideways movement
			_input = new Vector3(_input.x * _sidewaysMovementFactor, _input.y, _input.z);

			// Slower or faster sideways animation
			if (_movementAnimations)
			{
				if (Mathf.Abs(_input.x) > 0 && !_sidewaysMovement)
				{
					_movementAnimations.SetWalkSpeedMultiplier(_sidewaysMovementFactor);
					_sidewaysMovement = true;
				}
				else if (Mathf.Abs(_input.x) <= 0 && _sidewaysMovement)
				{
					_movementAnimations.ResetWalkSpeedMultiplier();
					_sidewaysMovement = false;
				}
			}

			isMoving = ((_input.magnitude > _previousInputMagnitude) || (Mathf.Approximately(_input.magnitude, _previousInputMagnitude) && _input.magnitude > 0)) ? true : false;

			_input = transform.TransformDirection(_input);
			_previousInputMagnitude = _input.magnitude;
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + _input * _currentSpeed * Time.fixedDeltaTime);
		}

		public void SetSpeed(float spd)
		{
			_currentSpeed = spd;
		}

		public void ResetSpeed()
		{
			_currentSpeed = speed;
		}
	}
}