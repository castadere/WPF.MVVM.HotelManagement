using DynamicData;
using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Services
{
    public interface IDataService<TModel> where TModel : BaseModel
    {
        IObservableCache<TModel, int> WhenModelsChanged { get; }

        void AddOrUpdate(TModel model);

        void AddOrUpdate(IEnumerable<TModel> models);

        void Remove(int modelId);

        IEnumerable<TModel> GetAll();
    }
}
