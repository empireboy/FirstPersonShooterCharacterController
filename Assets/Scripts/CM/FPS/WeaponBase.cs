using UnityEngine;

namespace CM.FPS
{
	public abstract class WeaponBase : MonoBehaviour
	{
		protected virtual void OnReload() { }
		protected virtual void OnShoot() { }
	}
}