using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utility;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private UIManager _ui_manager;
        [SerializeField]
        private SoundManager _sound_manager;
        [SerializeField]
        private Stats[] _stats;
        [SerializeField]
        private bool _lose;
        [SerializeField]
        private ActivityEnum _selected_activity;
        [SerializeField]
        private ActivityEnum[] _active_activities;
        [SerializeField]
        private bool _first_move;
        [SerializeField]
        private float _simulation_step;
        [SerializeField]
        private bool _manual_quit;
        [SerializeField]
        private float _level_time;
        [SerializeField]
        private float _timer;
        [SerializeField]
        private int _stats_index;

        private void Awake()
        {
            CreateGameStats();
            _first_move = true;
            int button_count = _ui_manager.GetActiveActivityButtonsCount();
            _active_activities = new ActivityEnum[button_count];
            _selected_activity = ActivityEnum.NONE;
            _timer = _level_time;
            _ui_manager.UpdateWeekBar(_timer, _level_time);
            UpdateUiManagerAccordingStats();
        }

        private void Start()
        {
            StartCoroutine(_ui_manager.HideBlackScreen());
        }

        private void Update()
        {
            if (!_manual_quit && Input.GetKeyDown(KeyCode.Escape))
            {
                _manual_quit = true;
                StopAllCoroutines();
                StartCoroutine(QuitGame());
            }
        }

        private void CreateGameStats()
        {
            _stats = new Stats[1];
            _stats[0] = new Stats(0, 50, 50, 50, 0, 0, 0, 0, 0, 0, 0, 0, 1f/2f);
        }

        private IEnumerator GameSystem()
        {
            while (IsNotGameOver())
            {
                yield return new WaitForSeconds(_simulation_step);
                _timer -= 1;
                _ui_manager.UpdateWeekBar(_timer, _level_time);

                if (_timer == 0)
                {
                    //Win
                    break;
                }
                else
                {
                    _stats[_stats_index].Evolve();
                    _stats[_stats_index].AutoIncreaseActivities();
                    _stats[_stats_index].ClampAllStats();
                    UpdateUiManagerAccordingStats();
                }
            }
            //GameOver
        }

        private IEnumerator QuitGame()
        {
            StartCoroutine(_ui_manager.ShowBlackScreen());
            yield return StartCoroutine(_sound_manager.FadeThemeMusic());
            SceneManager.LoadScene(Constants.MAIN_MENU_SCENE_INDEX);
        }

        private bool IsNotGameOver()
        {
            return _stats[_stats_index]._money != 0 && _stats[_stats_index]._health != 0 && _stats[_stats_index]._stress != 100 && _stats[_stats_index]._happy != 0;
        }

        private void UpdateUiManagerAccordingStats()
        {
            _ui_manager.SetStressText(_stats[_stats_index]._stress);
            _ui_manager.SetStressBarFill(_stats[_stats_index]._stress);
            _ui_manager.SetHealthText(_stats[_stats_index]._health);
            _ui_manager.SetHealthBarFill(_stats[_stats_index]._health);
            _ui_manager.SetMoneyText(_stats[_stats_index]._money);
            _ui_manager.SetMoneyBarFill(_stats[_stats_index]._money);
            _ui_manager.SetHappyText(_stats[_stats_index]._happy);
            _ui_manager.SetHappyBarFill(_stats[_stats_index]._happy);
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
            _stats[_stats_index].DecreaseActivity(current_activity);
            _stats[_stats_index].IncreaseActivity(_selected_activity);
            _ui_manager.UpdateActiveActivityButton(index, _selected_activity);

        }
    }
}