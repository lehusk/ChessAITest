namespace ChTest.Models
{
    internal class Player
    {
        public GameSide GameSide { get; set; }
        public bool IsAIPlayer { get; set; }

        public Player(GameSide gameSide, bool isAI)
        {
            GameSide = gameSide;
            IsAIPlayer = isAI;
        }

        public Player(GameSide gameSide)
        {
            GameSide = gameSide;
            IsAIPlayer = false;
        }
    }
}