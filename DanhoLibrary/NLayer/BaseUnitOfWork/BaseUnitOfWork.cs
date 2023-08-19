﻿using DanhoLibrary.NLayer.BaseUnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DanhoLibrary.NLayer;

internal class BaseUnitOfWork<TDbContext> : IBaseUnitOfWork, IDisposable
    where TDbContext : DbContext
{
    /// <param name="context">ApplicationDbContext</param>
    public BaseUnitOfWork(TDbContext context)
    {
        Context = context;
    }

    protected TDbContext Context { get; }

    void IDisposable.Dispose()
    {
        Context.Dispose();
        GC.SuppressFinalize(this);
    }

    public int SaveChanges() => Context.SaveChanges();
    public Task<int> SaveChangesAsync() => Context.SaveChangesAsync();
}