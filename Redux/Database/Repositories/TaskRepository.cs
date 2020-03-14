using System.Collections;
using System;
using System.Collections.Generic;
using Redux.Database.Domain;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using Redux.Structures;

namespace Redux.Database.Repositories
{
    public class TaskRepository : Repository<uint, DbTask>
    {
        public IList<DbTask> GetTasksByPlayerUID(uint uit)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria<DbTask>()
                    .Add(Restrictions.Eq("UID", uit))
                    .List<DbTask>();
                    
            }
        }
        public DbTask GetTasksByPlayerUID(uint _UID, int _type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session
                    .CreateCriteria<DbTask>()
                    .Add(Restrictions.Eq("UID", _UID))

                    .UniqueResult<DbTask>();
            }
        }

        
        public void UpdateTask(uint _count, uint _UID, int _type)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var t = session.CreateSQLQuery($"UPDATE `redux`.`tasks` SET `Count` = {_count} WHERE `Owner` = {_UID} AND `Type` = {_type}");
                t.ExecuteUpdate();
            }
        }
        public void CreateEntry(uint _UID, int _count, int _condition)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var t = session.CreateSQLQuery($"INSERT INTO tasks(`Owner`, Count,`Condition`) VALUES({_UID},{_count},{_condition})");
                t.ExecuteUpdate();
            }

        }
    }
}

