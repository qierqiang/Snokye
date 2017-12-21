using Snokye.VVM;
using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Snokye.VVM.Model
{
    public abstract class MappedViewModelBase : ViewModelBase
    {
        protected HashSet<string> PropertyNames;

        protected internal Dictionary<string, EntityObject> PropertyMappedEntity { get; private set; }
        protected internal Dictionary<string, string> PropertyMappedProperty { get; private set; }

        public MappedViewModelBase()
        {
            PropertyNames = new HashSet<string>(GetType().GetProperties().Select(p => p.Name));
            PropertyMappedEntity = new Dictionary<string, EntityObject>();
            PropertyMappedProperty = new Dictionary<string, string>();
        }

        public abstract void LoadByID(long id);

        public void Map<T>(string thisProperty, EntityObject entity, Expression<Func<T>> entityPropertySelector)
        {
            string entityProperty = ((MemberExpression)entityPropertySelector.Body).Member.Name;
            Map(thisProperty, entity, entityProperty);
        }

        public void Map(string thisProperty, EntityObject entity, string eneityProperty)
        {
            if (!PropertyNames.Contains(thisProperty))
            {
                throw new ArgumentException(this.GetType().FullName + " 不包含名为：" + thisProperty + " 的属性。");
            }

            PropertyMappedEntity.Add(thisProperty, entity);
            PropertyMappedProperty.Add(thisProperty, eneityProperty);
        }

        public void ChangeMappedEntity(string thisProperty, EntityObject newEntity)
        {
            EntityObject entity = PropertyMappedEntity[thisProperty];

            var query = from item in PropertyMappedEntity
                        where item.Value == entity
                        select item.Key;

            foreach (string p in query.ToArray())
                PropertyMappedEntity[p] = newEntity;
        }

        public void UpdateEntityMappedValue(EntityObject entity)
        {
            var query = from keyValueEntity in PropertyMappedEntity
                        where keyValueEntity.Value == entity
                        from keyValueProper in PropertyMappedProperty
                        where keyValueProper.Key == keyValueEntity.Key
                        select new
                        {
                            TargetProperty = GetType().GetProperty(keyValueProper.Key),
                            SourceProperty = entity.GetType().GetProperty(keyValueProper.Value)
                        };

            foreach (var item in query.Distinct())
            {
                item.TargetProperty.SetValue(this, item.SourceProperty.GetValue(entity, null), null);
            }
        }

        public void ReadMappedPropertyValues()
        {
            var query = from keyValueEntity in PropertyMappedEntity
                        from keyValueProper in PropertyMappedProperty
                        where keyValueEntity.Value != null
                        let o = new { thisp = keyValueProper.Key, entity = keyValueEntity.Value, ep = keyValueProper.Value }
                        select new
                        {
                            Key = this.GetType().GetProperty(o.thisp),
                            Value = o.entity.GetType().GetProperty(o.ep).GetValue(o.entity, null)
                        };

            foreach (var item in query.Distinct())
            {
                item.Key.SetValue(this, item.Value, null);
            }
        }

        public void WriteMappedPropertyValues()
        {
            var query = from keyValueEntity in PropertyMappedEntity
                        from keyValueProper in PropertyMappedProperty
                        where keyValueEntity.Value != null
                        let o = new { thisp = keyValueProper.Key, entity = keyValueEntity.Value, ep = keyValueProper.Value }
                        select new
                        {
                            Entity = o.entity,
                            Property = o.entity.GetType().GetProperty(o.ep),
                            Value = this.GetType().GetProperty(o.thisp).GetValue(this, null)
                        };

            foreach (var item in query.Distinct())
            {
                item.Property.SetValue(item.Entity, item.Value, null);
            }
        }
    }
}