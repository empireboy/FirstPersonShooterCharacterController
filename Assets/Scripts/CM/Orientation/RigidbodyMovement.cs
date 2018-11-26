using UnityEngine;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : RigidbodyMovementBase
	{
		[SerializeField] private float _speed = 5f;

		private Vector3 _input = Vector3.zero;

		private bool _isInputMagnitudeGettingBigger = false;
		private bool _isInputMagnitudeGettingSmaller = false;
		private float _previousInputMagnitude;

		private Rigidbody _rigidbody;
		private IInput _inputManager;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_inputManager = GetComponent<IInput>();
		}

		private void Start()
		{
			speed = _speed;
		}

		private void Update()
		{
			_input = _inputManager.GetInput();

			isMoving = (_input.magnitude > _previousInputMagnitude || _input.magnitude >= 1) ? true : false;

			_input = transform.TransformDirection(_input);
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

interface IInput
{
	Vector3 GetInput();
}