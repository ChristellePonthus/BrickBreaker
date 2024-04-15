namespace CasseBriques
{
    public static class Contexte
    {
        public static int Score {  get; private set; } // Propriété
        public static int lives; // Variable
   

        public static void AddScore(int points)
        {
            Score += points;
        }

        static Contexte() 
        { 
            Score = 0;
            lives = 5;
        }
    }
}
