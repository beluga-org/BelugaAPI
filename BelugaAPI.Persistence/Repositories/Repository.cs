using System.Linq.Expressions;
using BelugaAPI.Persistence.Context;
using BelugaAPI.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BelugaAPI.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly ApplicationDbContext Context;
    protected readonly DbSet<TEntity> _entities;

    public Repository(ApplicationDbContext context)
    {
        Context = context;
        _entities = Context.Set<TEntity>();
    }

    public TEntity Get(int id)
    {
        return _entities.Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _entities.ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.Where(predicate);
    }

    public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return _entities.SingleOrDefault(predicate);
    }

    public void Add(TEntity entity)
    {
        _entities.Add(entity);
    }


    public void AddRange(IEnumerable<TEntity> entities)
    {
        _entities.AddRange(entities);
    }

    public void Update(TEntity entity)
    {
        _entities.Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _entities.UpdateRange(entities);
    }


    public void Remove(TEntity entity)
    {
        _entities.Remove(entity);
    }

    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        _entities.RemoveRange(entities);
    }

    public void AddOrUpdate(TEntity entity, Expression<Func<TEntity, bool>> predicate)
    {
        var exists = _entities.Any(predicate);

        if (exists)
        {
            _entities.Update(entity);

        }
        else
        {
            _entities.Add(entity);
        }
    }

    public void Attach(TEntity entity)
    {
        _entities.Attach(entity);
    }
}   