using UnityEngine.Events;
using UnityEngine;

namespace CM.Orientation
{
	public class RigidbodyMovementEvents : RigidbodyMovementBase
	{
		[SerializeField] private UnityEvent _onMoveStart;
		[SerializeField] private UnityEvent _onMoveStop;

		protected override void OnMoveStart()
		{
			_onMoveStart.Invoke();
		}

		protected override void OnMoveStop()
		{
			_onMoveStop.Invoke();
		}
	}
}