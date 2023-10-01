﻿using UnityEngine;

namespace Utility
{
    public class Stats
    {
        public float _stress;
        public float _health;
        public float _money;
        public float _happy;

        public int _work;
        public int _overtime;
        public int _friends;
        public int _relation;
        public int _family;
        public int _hobby;
        public int _workout;
        public int _relax;

        public Stats(float stress, float health, float money, float happy, int work, int overtime, int friends, int relation, int family, int hobby, int workout, int relax)
        {
            _stress = stress;
            _health = health;
            _money = money;
            _happy = happy;
            _work = work;
            _overtime = overtime;
            _friends = friends;
            _relation = relation;
            _family = family;
            _hobby = hobby;
            _workout = workout;
            _relax = relax;
        }

        public void Evolve()
        {
            _stress = EvaluateStress();
            _health = EvaluateHealth();
            _money = EvaluateMoney();
            _happy = EvaluateHappy();
        }

        public void AutoIncreaseActivities()
        {
            if (_money <= ActivityConstants.MONEY_LOW_THRESHOLD)
            {
                _stress++;
                _happy--;
            }
            else if(_money >= ActivityConstants.MONEY_HIGH_THRESHOLD)
            {
                _happy++;
            }

            if(_health <= ActivityConstants.HEALTH_THRESHOLD)
            {
                _stress++;
            }

            if(_stress >= ActivityConstants.STRESS_HIGH_THRESHOLD)
            {
                _health--;
            }
            else if(_stress <= ActivityConstants.STRESS_LOW_THRESHOLD)
            {
                _health++;
            }
        }

        public void IncreaseActivity(ActivityEnum activity)
        {
            switch (activity)
            {
                case ActivityEnum.NONE:
                    break;
                case ActivityEnum.WORK:
                    _work++;
                    break;
                case ActivityEnum.OVERTIME:
                    _overtime++;
                    break;
                case ActivityEnum.FRIENDS:
                    _friends++;
                    break;
                case ActivityEnum.RELATION:
                    _relation++;
                    break;
                case ActivityEnum.FAMILY:
                    _family++;
                    break;
                case ActivityEnum.HOBBY:
                    _hobby++;
                    break;
                case ActivityEnum.WORKOUT:
                    _workout++;
                    break;
                case ActivityEnum.RELAX:
                    _relax++;
                    break;
            }
        }

        public void DecreaseActivity(ActivityEnum activity)
        {
            switch (activity)
            {
                case ActivityEnum.NONE:
                    break;
                case ActivityEnum.WORK:
                    _work--;
                    break;
                case ActivityEnum.OVERTIME:
                    _overtime--;
                    break;
                case ActivityEnum.FRIENDS:
                    _friends--;
                    break;
                case ActivityEnum.RELATION:
                    _relation--;
                    break;
                case ActivityEnum.FAMILY:
                    _family--;
                    break;
                case ActivityEnum.HOBBY:
                    _hobby--;
                    break;
                case ActivityEnum.WORKOUT:
                    _workout--;
                    break;
                case ActivityEnum.RELAX:
                    _relax--;
                    break;
            }
        }

        private float EvaluateStress()
        {
            float value = _stress +
                _work * ActivityConstants.WORK_STRESS_WEIGHT +
                _overtime * ActivityConstants.OVERTIME_STRESS_WEIGHT +
                _friends * ActivityConstants.FRIENDS_STRESS_WEIGHT +
                _relation * ActivityConstants.RELATION_STRESS_WEIGHT +
                (_family >= 4 ? _family*ActivityConstants.FAMILY_STRESS_WEIGHT : 0f) +
                _hobby * ActivityConstants.HOBBY_STRESS_WEIGHT +
                _workout * ActivityConstants.WORKOUT_STRESS_WEIGHT +
                _relax * ActivityConstants.RELAX_STRESS_WEIGHT;
            return Mathf.Clamp(value, 0, 100);
        }

        private float EvaluateHealth()
        {
            float value = _health +
                _overtime * ActivityConstants.OVERTIME_HEALTH_WEIGHT +
                _workout * ActivityConstants.WORKOUT_HEALTH_WEIGHT +
                _relax * ActivityConstants.RELAX_HEALTH_WEIGHT;
            return Mathf.Clamp(value, 0, 100);
        }

        private float EvaluateMoney()
        {
            float value = _money +
                _work * ActivityConstants.WORK_MONEY_WEIGHT +
                _overtime * ActivityConstants.OVERTIME_MONEY_WEIGHT +
                (_friends >= 4 ? _friends * ActivityConstants.FRIENDS_MONEY_WEIGHT : 0f) +
                _relation * ActivityConstants.RELATION_MONEY_WEIGHT +
                _hobby * ActivityConstants.HOBBY_MONEY_WEIGHT;
            return Mathf.Clamp(value, 0, 100);
        }

        private float EvaluateHappy()
        {
            float value = _happy +
                 (_work >= 4 ? _work * ActivityConstants.WORK_HAPPY_WEIGHT : 0f) +
                _overtime * ActivityConstants.OVERTIME_HAPPY_WEIGHT +
                _friends * ActivityConstants.FRIENDS_HAPPY_WEIGHT +
                _relation * ActivityConstants.RELATION_HAPPY_WEIGHT +
                _family * ActivityConstants.FAMILY_HAPPY_WEIGHT +
                _hobby * ActivityConstants.HOBBY_HAPPY_WEIGHT;
            return Mathf.Clamp(value, 0, 100);
        }
    }
}
