
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        public bool isFirstSession = true;
        public string language = "ru";
        public bool feedbackDone;
        public bool promptDone;

        // Ваши сохранения
        public int money = 1;
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[10];

        public Stars[] stars = new Stars[10];
        public int lastLevelIndex = 1;
    }

    [System.Serializable]
    public class Stars
    {
        public int stars;
    }
}
