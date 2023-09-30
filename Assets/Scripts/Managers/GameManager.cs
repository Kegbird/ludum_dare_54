using System.Collections;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UIManager _ui_manager;
        private Stats _stats;
        [SerializeField]
        private bool _game_over;

        private void Start()
        {
            _stats = new Stats(50, 50, 50, 50);
            _stats._work = 5;
            _stats._overtime = 0;
            _stats._friends = 2;
            _stats._relation = 0;
            _stats._family = 2;
            _stats._hobby = 1;
            _stats._workout = 1;
            _stats._relax = 2;

            StartCoroutine(GameSystem());
        }

        private IEnumerator GameSystem()
        {
            while(!_game_over)
            {
                yield return new WaitForSeconds(1f);
                _stats.Evolve();
                _ui_manager.SetStressText(_stats._stress);
                _ui_manager.SetStressBarFill(_stats._stress);
                _ui_manager.SetHealthText(_stats._health);
                _ui_manager.SetHealthBarFill(_stats._health);
                _ui_manager.SetMoneyText(_stats._money);
                _ui_manager.SetMoneyBarFill(_stats._money);
                _ui_manager.SetHappyText(_stats._happy);
                _ui_manager.SetHappyBarFill(_stats._happy);
            }
        }
    }
}