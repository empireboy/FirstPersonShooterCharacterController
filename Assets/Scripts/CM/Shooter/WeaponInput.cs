using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponInput : MonoBehaviour
	{
		[SerializeField] private TransformLock _weaponTransformLock;

		private void Update()
		{
			if (Input.GetButton("Fire1"))
				SendMessage("Shoot", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonUp("Fire1"))
				SendMessage("OnResetTransformLockRandomizer", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonDown("Reload"))
				SendMessage("OnReload", SendMessageOptions.DontRequireReceiver);
		}
	}
}