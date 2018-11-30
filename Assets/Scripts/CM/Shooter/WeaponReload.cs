using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReload : MonoBehaviour
	{
		[SerializeField] private Ammo _ammo;

		protected bool isReloading = false;
		public bool IsReloading
		{
			get
			{
				return isReloading;
			}
		}

		public void OnReload()
		{
			if (_ammo.CurrentClips > 0 && _ammo.CurrentClipSize < _ammo.ClipSize)
			{
				isReloading = true;
				SendMessage("OnReloadStart", SendMessageOptions.DontRequireReceiver);
			}
		}

		public void FinishReloading()
		{
			isReloading = false;

			_ammo.Reload();

			SendMessage("OnReloadFinished", SendMessageOptions.DontRequireReceiver);
		}
	}
}