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
            if (current_stats._stress <= 30f)
                _head_animator.SetTrigger("low_stress");
            else if(current_stats._stress > 30f && current_stats._stress < 70f)
                _head_animator.SetTrigger("medium_stress");
            else if (current_stats._stress >= 70f)
                _head_animator.SetTrigger("high_stress");

            //Brow
            if (current_stats._happy <= 30f)
                _head_animator.SetTrigger("low_happy");
            else if (current_stats._happy > 30f && current_stats._happy < 70f)
                _head_animator.SetTrigger("medium_happy");
            else if (current_stats._happy >= 70f)
                _head_animator.SetTrigger("high_happy");
        }
    }
}
