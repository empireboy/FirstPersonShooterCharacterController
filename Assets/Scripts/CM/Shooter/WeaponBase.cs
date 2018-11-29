using UnityEngine;

namespace CM.Shooter
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