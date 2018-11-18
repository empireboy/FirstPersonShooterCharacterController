using UnityEngine;

namespace CM.Movement
{
	public class RigidbodyMovementInput : RigidbodyMovementBase
	{
		[SerializeField] private string _horizontalAxis = "Horizontal";
		[SerializeField] private string _verticalAxis = "Vertical";

		private void Start()
		{
			horizontalAxis = _horizontalAxis;
			verticalAxis = _verticalAxis;
		}

		private void Update()
		{
			inputs = Vector3.zero;
			inputs.x = Input.GetAxis(horizontalAxis);
			inputs.z = Input.GetAxis(verticalAxis);
		}
	}
}