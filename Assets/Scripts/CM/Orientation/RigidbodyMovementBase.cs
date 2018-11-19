using UnityEngine;

namespace CM.Orientation
{
	public abstract class RigidbodyMovementBase : MonoBehaviour
	{
		public static float speed = 5f;

		protected static string horizontalAxis = "Horizontal";
		protected static string verticalAxis = "Vertical";

		protected static Vector3 inputs = Vector3.zero;
		protected static bool isMoving = false;
		public static bool IsMoving
		{
			get
			{
				return isMoving;
			}
		}

		protected virtual void OnMoveStart() { }
		protected virtual void OnMoveStop() { }
	}
}