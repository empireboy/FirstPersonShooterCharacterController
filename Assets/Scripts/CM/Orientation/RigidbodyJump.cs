using UnityEngine;
using UnityEngine.Events;

namespace CM.Orientation
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyJump : MonoBehaviour
	{
		public float jumpHeight = 5f;
		public float groundDistance = 0.2f;
		public LayerMask ground;

		[SerializeField] private Transform _groundChecker;
		[SerializeField] private string _jumpKey = "Jump";

		[SerializeField] private UnityEvent _onJumpStart;
		[SerializeField] private UnityEvent _onJumpStop;

		private Rigidbody _rigidbody;
		private Animator _animator;
		private bool _isGrounded = true;
		private bool _isJumpingPrevious = false;

		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
		}

		private void Update()
		{
			_isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);

			if (Input.GetButtonDown("Jump") && _isGrounded)
			{
				_rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
				_onJumpStart.Invoke();
			}

			if (_isJumpingPrevious && _isGrounded)
			{
				_onJumpStop.Invoke();
			}

			_isJumpingPrevious = (!_isGrounded) ? true : false;

			if (_animator)
				_animator.SetBool("IsGrounded", _isGrounded);
		}
	}
}