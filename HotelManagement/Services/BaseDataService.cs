using DynamicData;
using HotelManagement.Models;
using System.Collections.Generic;

namespace HotelManagement.Services
{
    public abstract class BaseDataService<TModel> : IDataService<TModel> where TModel : BaseModel
    {
        private readonly SourceCache<TModel, int> _itemsSource = new SourceCache<TModel, int>(x => x.Id);

        public IObservableCache<TModel, int> WhenModelsChanged => _itemsSource.AsObservableCache();

        public virtual void AddOrUpdate(TModel model)
        {
            _itemsSource.AddOrUpdate(model);
        }

        public virtual void AddOrUpdate(IEnumerable<TModel> models)
        {
            _itemsSource.AddOrUpdate(models);
        }

        public virtual void Remove(int modelId)
        {
            _itemsSource.Remove(modelId);
        }

        public IEnumerable<TModel> GetAll()
        {
            return _itemsSource.Items;
        }
    }
}
