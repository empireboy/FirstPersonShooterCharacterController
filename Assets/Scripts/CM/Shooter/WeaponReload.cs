using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReload : MonoBehaviour
	{
		[SerializeField] private Ammo _ammo;

		private bool _isReloading = false;
		public bool IsReloading
		{
			get
			{
				return _isReloading;
			}
		}

		public void OnReload()
		{
			if (_ammo.CurrentClips > 0 && _ammo.CurrentClipSize < _ammo.ClipSize)
			{
				_isReloading = true;
				SendMessage("OnReloadStart", SendMessageOptions.DontRequireReceiver);
			}
		}

		public void FinishReloading()
		{
			_isReloading = false;

			_ammo.Reload();

			SendMessage("OnReloadFinished", SendMessageOptions.DontRequireReceiver);
		}
	}
}