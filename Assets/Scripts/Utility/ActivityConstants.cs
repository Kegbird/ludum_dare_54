namespace Utility
{
    public static class ActivityConstants
    {
        //WORK
        public static readonly float WORK_STRESS_WEIGHT = 1/2f;
        public static readonly float WORK_MONEY_WEIGHT = 1f / 2f;
        public static readonly float WORK_HAPPY_WEIGHT = -1f/2f;
        //OVERTIME
        public static readonly float OVERTIME_MONEY_WEIGHT = 2f;
        public static readonly float OVERTIME_HAPPY_WEIGHT = -3f/2f;
        public static readonly float OVERTIME_STRESS_WEIGHT = 2f;
        public static readonly float OVERTIME_HEALTH_WEIGHT = -1f;
        //FRIENDS
        public static readonly float FRIENDS_STRESS_WEIGHT = -1f/2f;
        public static readonly float FRIENDS_MONEY_WEIGHT = -1/2f;
        public static readonly float FRIENDS_HAPPY_WEIGHT = 1f / 2f;
        //RELATION
        public static readonly float RELATION_STRESS_WEIGHT = 1f / 4f;
        public static readonly float RELATION_MONEY_WEIGHT = -1f;
        public static readonly float RELATION_HAPPY_WEIGHT = 3f/2f;
        //RELATION
        public static readonly float FAMILY_STRESS_WEIGHT = 1f / 2f;
        public static readonly float FAMILY_HAPPY_WEIGHT = 1f / 4f;
        //HOBBY
        public static readonly float HOBBY_STRESS_WEIGHT = -1f;
        public static readonly float HOBBY_MONEY_WEIGHT = -1f;
        public static readonly float HOBBY_HAPPY_WEIGHT = 1f / 2f;
        //WORKOUT
        public static readonly float WORKOUT_STRESS_WEIGHT = -1f/2f;
        //public static readonly float WORKOUT_HAPPY_WEIGHT = -1f / 4f;
        public static readonly float WORKOUT_HEALTH_WEIGHT = 1f/2f;
        //RELAX
        public static readonly float RELAX_STRESS_WEIGHT = -3f/2f;
        //public static readonly float RELAX_HAPPY_WEIGHT = -1f / 4f;
        public static readonly float RELAX_HEALTH_WEIGHT = 1f/4f;

    }
}
