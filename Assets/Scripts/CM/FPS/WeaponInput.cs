using UnityEngine;

namespace CM.FPS
{
	public class WeaponInput : WeaponBase
	{
		private void Update()
		{
			isShooting = (Input.GetButton("Fire1")) ? true : false;
		}
	}
}