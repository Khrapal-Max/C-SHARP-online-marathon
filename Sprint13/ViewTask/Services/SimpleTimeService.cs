namespace ViewTask.Services
{
    public class SimpleTimeService : ITimeService
    {
        /// <summary>
        /// Этот метод возвращает текущее время, в формате hh : mm : ss
        /// </summary>
        /// <returns></returns>
        public string GetTimeForTomorrow()
        {
            return System.DateTime.Today.AddDays(1).ToString("d");
        }
    }
}
