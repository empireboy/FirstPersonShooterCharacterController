using UnityEngine;

namespace CM.Previous
{
	public class PreviousAnimatorStateInfo : PreviousValue<AnimatorStateInfo>
	{
		private Animator _animator;

		public PreviousAnimatorStateInfo(Animator animator)
		{
			_animator = animator;
		}

		public override void OnValueUpdate()
		{
			value = _animator.GetCurrentAnimatorStateInfo(0);
		}
	}
}