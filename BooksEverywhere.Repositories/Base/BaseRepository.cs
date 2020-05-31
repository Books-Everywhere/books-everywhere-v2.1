using BooksEverywhere.Models.Repositories.Interfaces.Base;
using BooksEverywhere.Repositories.Infra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BooksEverywhere.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual async Task<IList<T>> Create(IList<T> itens)
        {
            UnitOfWork.BeginTransaction();

            try
            {
                foreach (var item in itens)
                    await UnitOfWork.Session.SaveOrUpdateAsync(item);
                await UnitOfWork.CommitTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await UnitOfWork.RollBackTransaction();
                throw;
            }
            return itens;
        }

        public virtual async Task<T> Create(T item)
        {
            UnitOfWork.BeginTransaction();
            try
            {
                await UnitOfWork.Session.SaveOrUpdateAsync(item);
                await UnitOfWork.CommitTransaction();
                await UnitOfWork.Session.RefreshAsync(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                await UnitOfWork.RollBackTransaction();
                throw;
            }
            return item;
        }

        public virtual async Task Delete(int id)
        {
            UnitOfWork.BeginTransaction();

            try
            {
                var item = await UnitOfWork.Session.GetAsync<T>(id);
                await UnitOfWork.Session.DeleteAsync(item);
                await UnitOfWork.CommitTransaction();
            }
            catch
            {
                await UnitOfWork.RollBackTransaction();
                throw;
            }
        }

        public virtual async Task Delete(T item)
        {
            UnitOfWork.BeginTransaction();

            try
            {
                await UnitOfWork.Session.DeleteAsync(item);
                await UnitOfWork.CommitTransaction();
            }
            catch
            {
                await UnitOfWork.RollBackTransaction();
                throw;
            }
        }

        public virtual async Task Delete(IList<T> itens)
        {
            if (itens != null && itens.Any())
            {
                UnitOfWork.BeginTransaction();

                try
                {
                    foreach (var item in itens)
                    {
                        await UnitOfWork.Session.DeleteAsync(item);
                    }

                    await UnitOfWork.CommitTransaction();
                }
                catch
                {
                    await UnitOfWork.RollBackTransaction();
                    throw;
                }
            }
        }

        public virtual async Task<T> Get(int id)
        {
            return await UnitOfWork.Session.GetAsync<T>(id);
        }

        public virtual async Task<T> Get(long id)
        {
            return await UnitOfWork.Session.GetAsync<T>(id);
        }

        public virtual async Task<T> Get(Guid id)
        {
            return await UnitOfWork.Session.GetAsync<T>(id);
        }

        public virtual async Task<int> Total()
        {
            return UnitOfWork.Session.Query<T>().Count();
        }

        public virtual async Task<IEnumerable<T>> List()
        {
            IQueryable<T> list = UnitOfWork.Session.Query<T>();
            return list.ToList();
        }

        //protected virtual IQueryable<T> Query(Expression<Func<T, bool>> where, Expression<Func<T, object>> sortField, PageableQuery pageableQuery)
        //{
        //    return UnitOfWork.Session.Query<T>()
        //        .Where(where)
        //        .SortBy(sortField, pageableQuery.Ordenacao)
        //        .Paginate(pageableQuery.Pagina, pageableQuery.ItensPorPagina);
        //}

        //protected virtual IQueryable<T> Query(PageableQuery pageableQuery)
        //{
        //    return UnitOfWork.Session.Query<T>()
        //        .Paginate(pageableQuery.Pagina, pageableQuery.ItensPorPagina);
        //}

        protected virtual IQueryable<T> Query(Expression<Func<T, bool>> where)
        {
            return UnitOfWork.Session.Query<T>().Where(where);
        }

        protected IQueryable<TSource> Query<TSource>()
        {
            return UnitOfWork.Session.Query<TSource>();
        }

        private static Expression<Func<TSource, bool>> GetExpression<TSource>(string propertyName, Guid idSaga)
        {
            var param = Expression.Parameter(typeof(TSource), "p");
            var parts = propertyName.Split('.');

            Expression parent = param;

            foreach (var part in parts)
            {
                parent = Expression.Property(parent, part);
            }

            var constant = Expression.Constant(idSaga);
            var conversion = Expression.Convert(parent, typeof(Guid));
            var expression = Expression.Equal(conversion, constant);
            return Expression.Lambda<Func<TSource, bool>>(expression, param);
        }

        public T GetById(Guid id)
        {
            return UnitOfWork.Session.Get<T>(id);
        }
    }
}
