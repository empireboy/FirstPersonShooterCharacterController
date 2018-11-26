using UnityEngine;
using CM.Orientation;

namespace CM.FPS
{
	public class WeaponInput : WeaponBase
	{
		[SerializeField] private TransformLock _weaponTransformLock;

		private void Update()
		{
			isShooting = (Input.GetButton("Fire1")) ? true : false;

			if (Input.GetButtonUp("Fire1")) _weaponTransformLock.ResetRandomizer();
		}
	}
}