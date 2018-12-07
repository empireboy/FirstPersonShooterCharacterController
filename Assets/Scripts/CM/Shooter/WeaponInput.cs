using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponInput : MonoBehaviour
	{
		[SerializeField] private TransformLock _weaponTransformLock;

		public string shootKey = "Shoot";
		public string reloadKey = "Reload";

		private void Update()
		{
			if (Input.GetButton(shootKey))
				SendMessage("Shoot", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonUp(shootKey))
				SendMessage("OnResetTransformLockRandomizer", SendMessageOptions.DontRequireReceiver);

			if (Input.GetButtonDown(reloadKey))
				SendMessage("OnReload", SendMessageOptions.DontRequireReceiver);
		}
	}
}