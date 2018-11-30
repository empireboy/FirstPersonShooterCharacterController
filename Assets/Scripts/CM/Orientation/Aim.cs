using UnityEngine;
using UnityEngine.Events;

namespace CM.Orientation
{
	public class Aim : MonoBehaviour
	{
		[SerializeField] private TransformLock _transformLock;
		[SerializeField] private TransformLockData _transformLockData;

		[SerializeField] private UnityEvent _onAimStart;
		[SerializeField] private UnityEvent _onAimStop;

		private void Update()
		{
			if (Input.GetMouseButtonDown(1))
			{
				GetComponent<TransformLock>().Set(_transformLockData);

				_onAimStart.Invoke();
			}

			if (Input.GetMouseButtonUp(1))
			{
				_onAimStop.Invoke();
			}
		}
	}
}