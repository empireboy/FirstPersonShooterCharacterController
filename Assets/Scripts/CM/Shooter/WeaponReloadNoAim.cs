using UnityEngine;
using CM.Orientation;

namespace CM.Shooter
{
	public class WeaponReloadNoAim : MonoBehaviour
	{
		[SerializeField] private Aim _aim;

		public void OnReloadStart()
		{
			_aim.StopAim();
			_aim.enabled = false;
		}

		public void OnReloadFinished()
		{
			_aim.enabled = true;
		}
	}
}