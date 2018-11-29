using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponInput : WeaponBase
	{
		[SerializeField] private TransformLock _weaponTransformLock;

		private void Update()
		{
			isShooting = (Input.GetButton("Fire1")) ? true : false;

			if (Input.GetButtonUp("Fire1"))
				_weaponTransformLock.ResetRandomizer();

			if (Input.GetButtonDown("Reload"))
				SendMessage("OnReload", SendMessageOptions.DontRequireReceiver);
		}
	}
}