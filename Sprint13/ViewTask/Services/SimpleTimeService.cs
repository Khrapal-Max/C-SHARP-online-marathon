namespace ViewTask.Services
{
    public class SimpleTimeService : ITimeService
    {
        /// <summary>
        /// Этот метод возвращает текущее время
        /// </summary>
        /// <returns></returns>
        public string GetTimeForTomorrow()
        {
            return System.DateTime.Today.AddDays(1).ToString("d");
        }
    }
}
