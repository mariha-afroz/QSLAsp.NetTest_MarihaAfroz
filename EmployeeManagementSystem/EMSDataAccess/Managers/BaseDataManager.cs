using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSDataAccess
{
    public abstract class BaseDataManager
    {
        protected EMSModel dbModel;

        public BaseDataManager(EMSModel model)
        {
            dbModel = model;
        }

        protected T FindEntity<T>(int primaryKey) where T : class
        {
            try
            {
                return dbModel.Set<T>().Find(primaryKey);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected bool AddUpdateEntity<T>(T entity, bool keepDettached = true) where T : class
        {
            try
            {
                if (dbModel.Entry<T>(entity).IsKeySet)
                    dbModel.Update<T>(entity);
                else
                    dbModel.Add<T>(entity);

                dbModel.SaveChanges();

                if (keepDettached)
                {
                    dbModel.Entry<T>(entity).State = EntityState.Detached;
                }

                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetListData<T>(string interpolatedStoredProc) where T : class
        {
            try
            {
                return dbModel.Set<T>().FromSqlRaw(interpolatedStoredProc).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());

                throw;
            }
        }

        protected bool ExecuteSqlInterpolated(System.FormattableString sql)
        {
            try
            {
                int val = dbModel.Database.ExecuteSqlInterpolated(sql);
                return val > 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }

        protected IList<T> GetListData<T>(string interpolatedStoredProc, params object[] parameters) where T : class
        {
            try
            {
                return dbModel.Set<T>().FromSqlRaw(interpolatedStoredProc, parameters).AsQueryable().ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
