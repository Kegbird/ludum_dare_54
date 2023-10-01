using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utility;
using Image = UnityEngine.UI.Image;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private Image _black_screen;
        [SerializeField]
        private TextMeshProUGUI _stress_text;
        [SerializeField]
        private Image _stress_bar;
        [SerializeField]
        private TextMeshProUGUI _health_text;
        [SerializeField]
        private Image _health_bar;
        [SerializeField]
        private TextMeshProUGUI _money_text;
        [SerializeField]
        private Image _money_bar;
        [SerializeField]
        private TextMeshProUGUI _happy_text;
        [SerializeField]
        private Image _happy_bar;
        [SerializeField]
        private GameObject _active_activity_panel;
        [SerializeField]
        private Image _day_bar;
        [SerializeField]
        private Image[] _activity_buttons;
        [SerializeField]
        private Image[] _active_activity_buttons;

        private void Awake()
        {
            _active_activity_buttons = new Image[_active_activity_panel.transform.childCount];
            for (int i=0; i< _active_activity_panel.transform.childCount; i++)
                _active_activity_buttons[i] = _active_activity_panel.transform.GetChild(i).GetComponent<Image>();
        }

        public void UpdateDayBar(float seconds, float level_time)
        {
            _day_bar.fillAmount = seconds/level_time;
        }

        public void SetStressText(float stress)
        {
            _stress_text.text = stress.ToString();
        }

        public void SetStressBarFill(float stress)
        {
            _stress_bar.fillAmount = stress / 100f;
        }

        public void SetHealthText(float health)
        {
            _health_text.text = health.ToString();
        }

        public void SetHealthBarFill(float health)
        {
            _health_bar.fillAmount = health / 100f;
        }

        public void SetMoneyText(float money)
        {
            _money_text.text = money.ToString();
        }

        public void SetMoneyBarFill(float money)
        {
            _money_bar.fillAmount = money / 100f;
        }

        public void SetHappyText(float happy)
        {
            _happy_text.text = happy.ToString();
        }

        public void SetHappyBarFill(float happy)
        {
            _happy_bar.fillAmount = happy / 100f;
        }

        public void SetActivityButtonSelected(ActivityEnum activity)
        {
            int activity_index = (int)activity - 1;
            for(int i=0; i<_activity_buttons.Length; i++)
            {
                _activity_buttons[i].color = Color.white;
            }
            _activity_buttons[activity_index].color = Color.yellow;
        }

        public void UpdateActiveActivityButton(int index, ActivityEnum activity, bool interactable)
        {
            switch (activity)
            {
                case ActivityEnum.NONE:
                    break;
                case ActivityEnum.WORK:
                    _active_activity_buttons[index].color = Color.red;
                    break;
                case ActivityEnum.OVERTIME:
                    _active_activity_buttons[index].color = new Color(147f/255f, 27f / 255f, 36f / 255f);
                    break;
                case ActivityEnum.FRIENDS:
                    _active_activity_buttons[index].color = new Color(141f / 255f, 211f / 255f, 94f / 255f);
                    break;
                case ActivityEnum.RELATION:
                    _active_activity_buttons[index].color = new Color(211f / 255f, 155f / 255f, 209f / 255f);
                    break;
                case ActivityEnum.FAMILY:
                    _active_activity_buttons[index].color = Color.blue;
                    break;
                case ActivityEnum.HOBBY:
                    _active_activity_buttons[index].color = Color.yellow;
                    break;
                case ActivityEnum.WORKOUT:
                    _active_activity_buttons[index].color = new Color(211f / 255f, 123f / 255f, 29f / 255f);
                    break;
                case ActivityEnum.RELAX:
                    _active_activity_buttons[index].color = Color.cyan;
                    break;
            }
            _active_activity_buttons[index].GetComponent<Button>().interactable = interactable;
        }

        public int GetActiveActivityButtonsCount()
        {
            return _active_activity_panel.transform.childCount;
        }

        public IEnumerator HideBlackScreen()
        {
            _black_screen.raycastTarget = true;
            for (float i = 1f; i >= 0; i -= Time.deltaTime)
            {
                _black_screen.color = new Color(0, 0, 0, i / 1f);
                yield return new WaitForEndOfFrame();
            }
            _black_screen.color = new Color(0, 0, 0, 0f);
            _black_screen.raycastTarget = false;
        }

        public IEnumerator ShowBlackScreen()
        {
            _black_screen.raycastTarget = true;
            for (float i = 0; i <= 1f; i += Time.deltaTime)
            {
                _black_screen.color = new Color(0, 0, 0, i / 1f);
                yield return new WaitForEndOfFrame();
            }
            _black_screen.color = new Color(0, 0, 0, 1f);
            _black_screen.raycastTarget = false;
        }
    }
}