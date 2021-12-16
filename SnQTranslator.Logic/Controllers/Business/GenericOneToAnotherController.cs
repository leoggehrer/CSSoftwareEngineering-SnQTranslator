﻿//@CodeCopy
//MdStart
using SnQTranslator.Logic.Modules.Exception;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SnQTranslator.Logic.Controllers.Business
{
#if ACCOUNT_ON
    using SnQTranslator.Logic.Modules.Security;

    [Authorize(AllowModify = true)]
#endif
    internal abstract partial class GenericOneToAnotherController<C, E, TOne, TOneEntity, TAnother, TAnotherEntity> : BusinessControllerAdapter<C, E>
        where C : Contracts.IOneToAnother<TOne, TAnother>
        where E : Entities.OneToAnotherEntity<TOne, TOneEntity, TAnother, TAnotherEntity>, C, Contracts.ICopyable<C>, new()
        where TOne : Contracts.IIdentifiable, Contracts.ICopyable<TOne>
        where TOneEntity : Entities.IdentityEntity, TOne, Contracts.ICopyable<TOne>, new()
        where TAnother : Contracts.IIdentifiable, Contracts.ICopyable<TAnother>
        where TAnotherEntity : Entities.IdentityEntity, TAnother, Contracts.ICopyable<TAnother>, new()
    {
        static GenericOneToAnotherController()
        {
            ClassConstructing();
            ClassConstructed();
        }
        static partial void ClassConstructing();
        static partial void ClassConstructed();

        protected abstract GenericController<TOne, TOneEntity> OneEntityController { get; set; }
        protected abstract GenericController<TAnother, TAnotherEntity> AnotherEntityController { get; set; }

        public override bool IsTransient => true;

        public GenericOneToAnotherController(DataContext.IContext context) : base(context)
        {
            Constructing();
            Constructed();
        }
        partial void Constructing();
        partial void Constructed();
        public GenericOneToAnotherController(ControllerObject controller) : base(controller)
        {
            Constructing();
            Constructed();
        }

        protected virtual PropertyInfo GetNavigationToOne()
        {
            return typeof(TAnother).GetInterfaceProperty(typeof(TOneEntity).Name);
        }
        protected virtual PropertyInfo GetForeignKeyToOne()
        {
            return typeof(TAnother).GetInterfaceProperty($"{typeof(TOneEntity).Name}Id");
        }
        protected virtual async Task LoadAnotherAsync(E entity, int masterId)
        {
            var predicate = $"{typeof(TOneEntity).Name}Id == {masterId}";
            var qyr = await AnotherEntityController.QueryEntityAllAsync(predicate).ConfigureAwait(false);

            if (qyr.Any())
            {
                if (AnotherEntityController.IsTransient)
                {
                    var another = await AnotherEntityController.GetEntityByIdAsync(qyr.ElementAt(0).Id).ConfigureAwait(false);

                    entity.AnotherEntity = another;
                }
                else
                {
                    entity.AnotherEntity = qyr.ElementAt(0);
                }
            }
            else
            {
                entity.AnotherEntity.CopyProperties(new TAnotherEntity());
            }
        }
        protected virtual async Task<IEnumerable<TAnotherEntity>> QueryDetailsAsync(int masterId)
        {
            var result = new List<TAnotherEntity>();
            var predicate = $"{typeof(TOneEntity).Name}Id == {masterId}";
            var query = await AnotherEntityController.QueryEntityAllAsync(predicate).ConfigureAwait(false);

            foreach (var item in query)
            {
                var e = new TAnotherEntity();

                e.CopyProperties(item);
                result.Add(e);
            }
            return result;
        }

        #region Count
        internal override Task<int> ExecuteCountAsync()
        {
            return OneEntityController.ExecuteCountAsync();
        }
        internal override Task<int> ExecuteCountByAsync(string predicate)
        {
            return OneEntityController.ExecuteCountByAsync(predicate);
        }
        #endregion Count

        #region Query
        internal override async Task<E> ExecuteGetEntityByIdAsync(int id)
        {
            E result;
            var oneEntity = await OneEntityController.GetEntityByIdAsync(id).ConfigureAwait(false);

            if (oneEntity != null)
            {
                result = new E
                {
                    OneEntity = oneEntity
                };
                await LoadAnotherAsync(result, oneEntity.Id).ConfigureAwait(false);
            }
            else
            {
                throw new LogicException(ErrorType.InvalidId);
            }
            return result;
        }

        internal override async Task<IEnumerable<E>> ExecuteGetEntityAllAsync()
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteGetEntityAllAsync().ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }
        internal override async Task<IEnumerable<E>> ExecuteGetEntityAllAsync(string orderBy)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteGetEntityAllAsync(orderBy).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }

        internal override async Task<IEnumerable<E>> ExecuteGetEntityPageListAsync(int pageIndex, int pageSize)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteGetEntityPageListAsync(pageIndex, pageSize).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }
        internal override async Task<IEnumerable<E>> ExecuteGetEntityPageListAsync(string orderBy, int pageIndex, int pageSize)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteGetEntityPageListAsync(orderBy, pageIndex, pageSize).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }

        internal override async Task<IEnumerable<E>> ExecuteQueryEntityAllAsync(string predicate)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteQueryEntityAllAsync(predicate).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }
        internal override async Task<IEnumerable<E>> ExecuteQueryEntityAllAsync(string predicate, string orderBy)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteQueryEntityAllAsync(predicate, orderBy).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }

        internal override async Task<IEnumerable<E>> ExecuteQueryEntityPageListAsync(string predicate, int pageIndex, int pageSize)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteQueryEntityPageListAsync(predicate, pageIndex, pageSize).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }
        internal override async Task<IEnumerable<E>> ExecuteQueryEntityPageListAsync(string predicate, string orderBy, int pageIndex, int pageSize)
        {
            var result = new List<E>();
            var query = await OneEntityController.ExecuteQueryEntityPageListAsync(predicate, orderBy, pageIndex, pageSize).ConfigureAwait(false);

            foreach (var item in query)
            {
                var entity = new E();

                entity.OneItem.CopyProperties(item);
                await LoadAnotherAsync(entity, item.Id).ConfigureAwait(false);

                result.Add(entity);
            }
            return result;
        }
        #endregion Query

        #region Insert
        internal override async Task<E> ExecuteInsertEntityAsync(E entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneEntity.CheckArgument(nameof(entity.OneEntity));
            entity.AnotherEntity.CheckArgument(nameof(entity.AnotherEntity));

            entity.OneEntity = await OneEntityController.InsertEntityAsync(entity.OneEntity).ConfigureAwait(false);

            var pi = GetNavigationToOne();

            if (pi != null)
            {
                pi.SetValue(entity.AnotherEntity, entity.OneEntity);
            }
            entity.AnotherEntity = await AnotherEntityController.InsertEntityAsync(entity.AnotherEntity).ConfigureAwait(false);
            return entity;
        }
        #endregion Insert

        #region Update
        internal override async Task<E> ExecuteUpdateEntityAsync(E entity)
        {
            entity.CheckArgument(nameof(entity));
            entity.OneEntity.CheckArgument(nameof(entity.OneEntity));
            entity.AnotherEntity.CheckArgument(nameof(entity.AnotherEntity));

            entity.OneEntity = await OneEntityController.UpdateEntityAsync(entity.OneEntity).ConfigureAwait(false);

            if (entity.AnotherEntity.Id == 0)
            {
                var pi = GetForeignKeyToOne();

                if (pi != null)
                {
                    pi.SetValue(entity.AnotherEntity, entity.OneEntity.Id);
                }
                entity.AnotherEntity = await AnotherEntityController.InsertEntityAsync(entity.AnotherEntity).ConfigureAwait(false);
            }
            else
            {
                entity.AnotherEntity = await AnotherEntityController.UpdateEntityAsync(entity.AnotherEntity).ConfigureAwait(false);
            }
            return entity;
        }
        #endregion Update

        #region Delete
        internal override async Task<E> ExecuteDeleteEntityAsync(E entity)
        {
            if (entity.AnotherEntity.Id > 0)
            {
                await AnotherEntityController.DeleteEntityAsync(entity.AnotherEntity).ConfigureAwait(false);
            }
            await OneEntityController.DeleteEntityAsync(entity.OneEntity).ConfigureAwait(false);
            return entity;
        }
        #endregion Delete
    }
}
//MdEnd
