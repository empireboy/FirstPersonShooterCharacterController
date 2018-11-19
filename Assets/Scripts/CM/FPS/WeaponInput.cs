using UnityEngine;

namespace CM.FPS
{
	public class WeaponInput : WeaponBase
	{
		private void Update()
		{
			if (Input.GetButton("Fire1"))
			{
				OnShoot();
			}
		}
	}
}