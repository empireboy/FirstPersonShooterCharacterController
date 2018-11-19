using UnityEngine;

namespace CM.FPS
{
	public class WeaponShoot : WeaponBase
	{
		protected override void OnShoot()
		{
			Debug.Log("Shooting");
		}
	}
}