using System.Collections;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UIManager _ui_manager;
        [SerializeField]
        private Stats _stats;
        [SerializeField]
        private bool _lose;
        [SerializeField]
        private ActivityEnum _selected_activity;
        [SerializeField]
        private ActivityEnum[] _active_activities;
        [SerializeField]
        private bool _first_move;
        [SerializeField]
        private float _timer_seconds;

        private void Awake()
        {
            _first_move = true;
            _ui_manager.UpdateTimer(_timer_seconds);
            int button_count = _ui_manager.GetActiveActivityButtonsCount();
            _active_activities = new ActivityEnum[button_count];
            _selected_activity = ActivityEnum.NONE;
            UpdateUiManagerAccordingStats();
        }

        private void Start()
        {
            StartCoroutine(_ui_manager.HideBlackScreen());
        }

        private IEnumerator GameSystem()
        {
            while (IsNotGameOver())
            {
                yield return new WaitForSeconds(1f);
                _timer_seconds--;
                _ui_manager.UpdateTimer(_timer_seconds);

                if (_timer_seconds == 0)
                {
                    //Win
                    break;
                }
                else
                {
                    _stats.Evolve();
                    UpdateUiManagerAccordingStats();
                }
            }
            //GameOver
        }

        private bool IsNotGameOver()
        {
            return _stats._money != 0 && _stats._health != 0 && _stats._stress != 100 && _stats._happy != 0;
        }

        private void UpdateUiManagerAccordingStats()
        {
            _ui_manager.SetStressText(_stats._stress);
            _ui_manager.SetStressBarFill(_stats._stress);
            _ui_manager.SetHealthText(_stats._health);
            _ui_manager.SetHealthBarFill(_stats._health);
            _ui_manager.SetMoneyText(_stats._money);
            _ui_manager.SetMoneyBarFill(_stats._money);
            _ui_manager.SetHappyText(_stats._happy);
            _ui_manager.SetHappyBarFill(_stats._happy);
        }

        public void SetSelectedActivity(int activity)
        {
            _selected_activity = (ActivityEnum) activity;
            _ui_manager.SetActivityButtonSelected(_selected_activity);
        }

        public void SetActiveActivity(int index)
        {
            if (_selected_activity == ActivityEnum.NONE)
                return;

            if(_first_move)
            { 
                StartCoroutine(GameSystem());
                _first_move = false;
            }

            ActivityEnum current_activity = _active_activities[index];
            _active_activities[index] = _selected_activity;
            _stats.DecreaseActivity(current_activity);
            _stats.IncreaseActivity(_selected_activity);
            _ui_manager.UpdateActiveActivityButton(index, _selected_activity);

        }
    }
}