using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface ISeriesRepository<T>
    {
        List<T> ListSeries();

        T ReturnSeriesById(int id);

        void AddSeries(T entity);

        void RemoveSeries(int id);
        void UpdateSeries(int id, T entity);
        int NextId();
    }
}