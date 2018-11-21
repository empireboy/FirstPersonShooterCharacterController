using UnityEngine;

namespace CM.FPS
{
	public abstract class WeaponBase : MonoBehaviour
	{
		protected static bool isShooting = false;
		public static bool IsShooting
		{
			get
			{
				return isShooting;
			}
		}
	}
}