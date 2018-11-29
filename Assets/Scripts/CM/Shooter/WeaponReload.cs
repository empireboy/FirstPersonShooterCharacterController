using UnityEngine;

namespace CM.Shooter
{
	public class WeaponReload : MonoBehaviour
	{
		protected bool isReloading = false;
		public bool IsReloading
		{
			get
			{
				return isReloading;
			}
		}

		public void StartReloading()
		{
			isReloading = true;
			SendMessage("OnReloadStart", SendMessageOptions.DontRequireReceiver);
		}

		public void FinishReloading()
		{
			isReloading = false;
			SendMessage("OnReloadFinished", SendMessageOptions.DontRequireReceiver);
		}
	}
}