using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
  public class SeriesRepository : ISeriesRepository<Series>
  {
    private List<Series> seriesList = new List<Series>();
    public void AddSeries(Series entity)
    {
        seriesList.Add(entity);
    }

    public List<Series> ListSeries()
    {
        return seriesList;
    }

    public int NextId()
    {
        return seriesList.Count;
    }

    public void RemoveSeries(int id)
    {
        seriesList[id].RemoveItem();
    }

    public Series ReturnSeriesById(int id)
    {
        return seriesList[id];
    }

    public void UpdateSeries(int id, Series entity)
    {
        seriesList[id] = entity;
    }
  }
}