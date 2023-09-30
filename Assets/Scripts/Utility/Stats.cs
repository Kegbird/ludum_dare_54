using System.Runtime.InteropServices.WindowsRuntime;

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

        public Stats(float stress, float health, float money, float happy)
        {
            _stress = stress;
            _health = health;
            _money = money;
            _happy = happy;

            _work = _overtime = _friends = _relation = _family = _hobby = _workout = _relation = 0;
        }

        public void Evolve()
        {
            _stress = EvaluateStress();
            _health = EvaluateHealth();
            _money = EvaluateMoney();
            _happy = EvaluateHappy();
        }

        private float EvaluateStress()
        {
            return _stress +
                _work * ActivityConstants.WORK_STRESS_WEIGHT +
                _overtime * ActivityConstants.OVERTIME_STRESS_WEIGHT +
                _friends * ActivityConstants.FRIENDS_STRESS_WEIGHT +
                _relation * ActivityConstants.RELATION_STRESS_WEIGHT +
                (_family >= 4 ? _family*ActivityConstants.FAMILY_STRESS_WEIGHT : 0f) +
                _hobby * ActivityConstants.HOBBY_STRESS_WEIGHT +
                _workout * ActivityConstants.WORKOUT_STRESS_WEIGHT +
                _relax * ActivityConstants.RELAX_STRESS_WEIGHT;
        }

        private float EvaluateHealth()
        {
            return _health +
                _overtime * ActivityConstants.OVERTIME_HEALTH_WEIGHT +
                _workout * ActivityConstants.WORKOUT_HEALTH_WEIGHT +
                _relax * ActivityConstants.RELAX_HEALTH_WEIGHT;
        }

        private float EvaluateMoney()
        {
            return _money +
                _work * ActivityConstants.WORK_MONEY_WEIGHT +
                _overtime * ActivityConstants.OVERTIME_MONEY_WEIGHT +
                (_friends >= 4 ? _friends * ActivityConstants.FRIENDS_MONEY_WEIGHT : 0f) +
                _relation * ActivityConstants.RELATION_MONEY_WEIGHT +
                _hobby * ActivityConstants.HOBBY_MONEY_WEIGHT;
        }

        private float EvaluateHappy()
        {
            return _happy +
                 (_work >= 4 ? _work * ActivityConstants.WORK_HAPPY_WEIGHT : 0f) +
                _overtime * ActivityConstants.OVERTIME_HAPPY_WEIGHT +
                _friends * ActivityConstants.FRIENDS_HAPPY_WEIGHT +
                _relation * ActivityConstants.RELATION_HAPPY_WEIGHT +
                _family * ActivityConstants.FAMILY_HAPPY_WEIGHT +
                _hobby * ActivityConstants.HOBBY_HAPPY_WEIGHT;// +
                //(_workout >= 4 ? _workout * ActivityConstants.WORKOUT_HAPPY_WEIGHT : 0f) +
                //_relax * ActivityConstants.RELAX_HAPPY_WEIGHT;
        }
    }
}
