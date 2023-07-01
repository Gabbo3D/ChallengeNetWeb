using System.Collections.Generic;
//using System.Data.Entity;
using System.Linq;
//using System.Data.Entity.Migrations;
//using System.Linq.Dynamic;
using System.Linq.Expressions;
using System;
//using EntityFramework.BulkExtensions;


namespace ATM_Challenge.DataAccess.Classes
{
    public class Generic
    {
        public static List<T> GetPaged<T>(IQueryable<T> query, int pageNumber, int PageSize, out int TotalPages) where T : class
        {
            Int32 iStart = (pageNumber - 1) * PageSize;
            int iEnd = iStart + PageSize;
            TotalPages = (int)Math.Ceiling(query.Count() / (decimal)PageSize);
            if (pageNumber < 1)
            {
                pageNumber = 1;
            }
            else if (pageNumber > TotalPages && TotalPages > 0)
            {
                pageNumber = TotalPages;
            }
            int pageIndex = pageNumber - 1;
            return query.Skip(PageSize * (pageNumber - 1)).Take(PageSize).ToList();
        }/*
        public static List<T> GetAll<T>() where T : class
        {
            return Common.DataContext.Set<T>().ToList();
        }
        //public static List<T> GetAllByOrder<T>(string Order) where T : class
        //{
        //    return Common.DataContext.Set<T>().OrderBy(Order).ToList();
        //}
        public static List<T> GetAllByOrder<T>(Expression<Func<T, string>> predicate) where T : class
        {
            return Common.DataContext.Set<T>().OrderBy(predicate).ToList();
        }
        public static T Single<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return Common.DataContext.Set<T>().FirstOrDefault(predicate);
        }
        
        public static void Save<T>(T entity, bool saveToDB = true) where T : class
        {
            Common.DataContext.Set<T>().AddOrUpdate(entity);
            if (saveToDB)
            {
                Common.DataContext.SaveChanges();
            }
        }
        public static void Attach<T>(T entity) where T : class
        {
            Common.DataContext.Set<T>().Attach(entity);
        }
        public static void Delete<T>(T entity, bool saveToDB = true) where T : class
        {
            Common.DataContext.Entry(entity).State = EntityState.Deleted;
            if (saveToDB)
            {
                Common.DataContext.SaveChanges();
            }
        }
        public static void SaveChanges()
        {
            Common.DataContext.SaveChanges();
        }
        //public static void SaveBulk<T>(List<T> list) where T : class
        //{
        //    Common.DataContext.BulkInsertOrUpdate(list);
        //}
        //public static void SaveBulkGetId<T>(List<T> list) where T : class
        //{
        //    Common.DataContext.BulkInsertOrUpdate(list.Distinct(), InsertOptions.OutputIdentity);
        //}
        //public static void DeleteBulk<T>(List<T> list) where T : class
        //{
        //    Common.DataContext.BulkDelete(list);
        //}

        public static DbContextTransaction BeginTransaction()
        {
            return Common.DataContext.Database.BeginTransaction();
        }
        public static DbContextTransaction GetCurrentTransaction()
        {
            return Common.DataContext.Database.CurrentTransaction;
        }
        public static void Detach<T>(List<T> list) where T : class
        {
            foreach (T obj in list)
            {
                Common.DataContext.Entry<T>(obj).State = EntityState.Detached;
            }
        }*/
    }
}

