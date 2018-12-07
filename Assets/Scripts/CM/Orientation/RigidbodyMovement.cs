using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : RigidbodyMovementBase
	{
		[SerializeField] private RigidbodyMovementInput _rigidbodyMovementInput;
		[SerializeField] private RigidbodyMovementAnimations _rigidbodyMovementAnimations;
		[SerializeField] private float _speed = 5f;
		[SerializeField] private float _sidewaysMovementFactor = 0.5f;

		private Vector3 _input = Vector3.zero;

		private bool _isInputMagnitudeGettingBigger = false;
		private bool _isInputMagnitudeGettingSmaller = false;
		private bool _sidewaysMovement = false;
		private float _previousInputMagnitude;

		private bool _isMoving = false;
		public bool IsMoving
		{
			get
			{
				return _isMoving;
			}
		}

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
			// Get input
			if (_rigidbodyMovementInput)
				_input = _rigidbodyMovementInput.GetInput();

			// Max magnitude of 1
			_input = Vector3.ClampMagnitude(_input, 1);

			// Slower or faster sideways movement
			_input = new Vector3(_input.x * _sidewaysMovementFactor, _input.y, _input.z);

			// Slower or faster sideways animation
			if (_rigidbodyMovementAnimations)
			{
				if (Mathf.Abs(_input.x) > 0 && !_sidewaysMovement)
				{
					_rigidbodyMovementAnimations.SetWalkSpeedMultiplier(_sidewaysMovementFactor);
					_sidewaysMovement = true;
				}
				else if (Mathf.Abs(_input.x) <= 0 && _sidewaysMovement)
				{
					_rigidbodyMovementAnimations.ResetWalkSpeedMultiplier();
					_sidewaysMovement = false;
				}
			}

			_isMoving = ((_input.magnitude > _previousInputMagnitude) || (Mathf.Approximately(_input.magnitude, _previousInputMagnitude) && _input.magnitude > 0)) ? true : false;

			_input = transform.TransformDirection(_input);
			_previousInputMagnitude = _input.magnitude;
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + _input * speed * Time.fixedDeltaTime);
		}

		public void SetSpeed(float spd)
		{
			speed = spd;
		}

		public void ResetSpeed()
		{
			speed = _speed;
		}
	}
}