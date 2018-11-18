using UnityEngine;

namespace CM.Orientation
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] private Vector3 _aimPosition;
		[SerializeField] private Vector3 _aimRotation;

		private void Update()
		{
			if (Input.GetMouseButtonDown(1))
			{
				GetComponent<TransformLock>().SetPosition(_aimPosition);
				GetComponent<TransformLock>().SetRotation(_aimRotation);
			}

			if (Input.GetMouseButtonUp(1))
			{
				GetComponent<TransformLock>().ResetTransform();
			}
		}
	}
}