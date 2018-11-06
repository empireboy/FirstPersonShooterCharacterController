using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CM.Movement
{
	[RequireComponent(typeof(Rigidbody))]
	public class RigidbodyMovement : MonoBehaviour
	{
		public float speed = 5f;

		[SerializeField] private string _horizontalAxis = "Horizontal";
		[SerializeField] private string _verticalAxis = "Vertical";

		private Rigidbody _rigidbody;
		private Vector3 _inputs = Vector3.zero;
		
		private void Awake()
		{
			_rigidbody = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			_inputs = Vector3.zero;
			_inputs.x = Input.GetAxis(_horizontalAxis);
			_inputs.z = Input.GetAxis(_verticalAxis);
		}

		private void FixedUpdate()
		{
			_rigidbody.MovePosition(_rigidbody.position + _inputs * speed * Time.fixedDeltaTime);
		}
	}
}