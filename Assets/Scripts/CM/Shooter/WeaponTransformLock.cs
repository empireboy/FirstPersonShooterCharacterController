using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponTransformLock : MonoBehaviour
	{
		[SerializeField] private TransformLock _weaponTransformLock;
		[SerializeField] private TransformLockData _weaponTransformLockData;

		private void Start()
		{
			_weaponTransformLock.Set(_weaponTransformLockData);
		}

		public void OnShoot()
		{
			_weaponTransformLock.UpdateRandomTransform();
		}
	}
}