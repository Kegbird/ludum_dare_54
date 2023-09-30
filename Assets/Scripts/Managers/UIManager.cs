using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
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
    }
}