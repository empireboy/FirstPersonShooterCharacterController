using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyJump : MonoBehaviour
	{
		public float jumpHeight = 5f;
		public float groundDistance = 0.2f;
		public LayerMask ground;

		[SerializeField] private Transform _groundChecker;
		[SerializeField] private string _jumpKey = "Jump";

		private Rigidbody _rigidbody;
		private bool _isGrounded = true;
		
		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			_isGrounded = Physics.CheckSphere(_groundChecker.position, groundDistance, ground, QueryTriggerInteraction.Ignore);

			if (Input.GetButtonDown("Jump") && _isGrounded)
			{
				_rigidbody.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
			}
		}
	}
}