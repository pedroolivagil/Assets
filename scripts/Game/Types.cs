public abstract class Types{
    public abstract class RolUsers{
        public static readonly int Admin = 0;
        public static readonly int Mod = 1;
        public static readonly int User = 2;
    }

    public abstract class Reward{
        public static readonly int Exp = 1;
        public static readonly int Gold = 2;
        public static readonly int Vessel = 3;
        public static readonly int Item = 4;
    }

    public abstract class CrewSide{
        public static readonly int Corsair = 1;
        public static readonly int Navy = 2;
        public static readonly int Pirate = 3;
        public static readonly int Neutral = 4;
    }
}