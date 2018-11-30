using UnityEngine;

namespace CM.Shooter
{
	public class Ammo : MonoBehaviour
	{
		[SerializeField] private float _clipSize = 25;
		[SerializeField] private float _clips = 5;

		private float _currentClipSize;
		public float ClipSize
		{
			get
			{
				return _currentClipSize;
			}
		}

		private void Start()
		{
			_currentClipSize = _clipSize;
		}

		public void ReduceClipSize()
		{
			_currentClipSize--;
		}
	}
}