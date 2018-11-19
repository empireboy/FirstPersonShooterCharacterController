using UnityEngine;
using UnityEngine.Events;

namespace CM.Orientation
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] private Vector3 _aimPosition;
		[SerializeField] private Vector3 _aimRotation;

		[SerializeField] private UnityEvent _onAimStart;
		[SerializeField] private UnityEvent _onAimStop;

		private void Update()
		{
			if (Input.GetMouseButtonDown(1))
			{
				GetComponent<TransformLock>().SetPosition(_aimPosition);
				GetComponent<TransformLock>().SetRotation(_aimRotation);

				_onAimStart.Invoke();
			}

			if (Input.GetMouseButtonUp(1))
			{
				GetComponent<TransformLock>().ResetTransform();

				_onAimStop.Invoke();
			}
		}
	}
}