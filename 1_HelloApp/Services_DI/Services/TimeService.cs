using System;
namespace Services_DI.Services
{
    public class TimeService
    {
        public string GetTime() => DateTime.Now.ToString("dd.MM.yyyy");
    }
}
