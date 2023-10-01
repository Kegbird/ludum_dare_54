using UnityEngine;
using Utility;

namespace Managers
{
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField]
        private Animator _head_animator;

        public void UpdateHeadAnimator(Stats current_stats)
        {
            //Eyes
            if (current_stats._stress <= 20f)
                _head_animator.SetTrigger("low_stress");
            else if(current_stats._stress > 20f && current_stats._stress < 80f)
                _head_animator.SetTrigger("medium_stress");
            else if (current_stats._stress >= 80f)
                _head_animator.SetTrigger("high_stress");

            //Brow
            if (current_stats._happy <= 20f)
                _head_animator.SetTrigger("low_happy");
            else if (current_stats._happy > 20f && current_stats._happy < 80f)
                _head_animator.SetTrigger("medium_happy");
            else if (current_stats._happy >= 80f)
                _head_animator.SetTrigger("high_happy");
        }
    }
}
