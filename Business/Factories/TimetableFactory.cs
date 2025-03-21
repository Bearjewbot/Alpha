using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class TimetableFactory
{
    public static Timetable MapTimetable(TimetableEntity entity)
    {
        var timetable = new Timetable
        {
            StartDate = entity.StartDate,
            EndDate = entity.EndDate
        };

        return timetable;
    }
}