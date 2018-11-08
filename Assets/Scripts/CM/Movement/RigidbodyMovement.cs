using UnityEngine;
using UnityEngine.Events;

namespace CM.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : MonoBehaviour
	{
		public float speed = 5f;

		[SerializeField] private string _horizontalAxis = "Horizontal";
		[SerializeField] private string _verticalAxis = "Vertical";

		[SerializeField] private UnityEvent _onMoveStart;
		[SerializeField] private UnityEvent _onMoveStop;

		private Rigidbody _rigidbody;
		private Vector3 _inputs = Vector3.zero;
		private float _previousInputMagnitude = 0;
		private bool _isMoving = false;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			_inputs = Vector3.zero;
			_inputs.x = Input.GetAxis(_horizontalAxis);
			_inputs.z = Input.GetAxis(_verticalAxis);

			bool biggerMagnitude = (_inputs.magnitude > _previousInputMagnitude || _inputs.magnitude >= 1);
			bool smallerMagnitude = (_inputs.magnitude < _previousInputMagnitude || _inputs.magnitude <= 0);

			if (biggerMagnitude && !_isMoving)
				_onMoveStart.Invoke();

			if (smallerMagnitude && _isMoving)
			{
				_onMoveStop.Invoke();
				Debug.Log("Movement Stopped");
				Debug.Log(_inputs.magnitude);
				Debug.Log(_previousInputMagnitude);
			}

			//if (_inputs.magnitude < _previousInputMagnitude)
				//Debug.Log("Magnitude is getting smaller or is equal to 0");

			_isMoving = (_inputs.magnitude > _previousInputMagnitude || _inputs.magnitude >= 1) ? true : false;

			_inputs = transform.TransformDirection(_inputs);

			_previousInputMagnitude = _inputs.magnitude;
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + _inputs * speed *  Time.fixedDeltaTime);
		}
	}
}