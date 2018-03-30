using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.DAL
{
    public class NewInterceptor : IDbCommandInterceptor
    {
        private static ILog log = LogManager.GetLogger(typeof(NewInterceptor));

        //定义一个静态只读的ConcurrentDictionary作为我们的记录仓储,考虑到数据访问时多线程的情况很常见,所以我们采用线程安全的ConcurrentDictionary

        static readonly ConcurrentDictionary<DbCommand, DateTime> MStartTime = new ConcurrentDictionary<DbCommand, DateTime>();

        //记录开始执行时的时间
        private static void OnStart(DbCommand command)
        {
            MStartTime.TryAdd(command, DateTime.Now);
        }

        private static void Log<T>(DbCommand command, DbCommandInterceptionContext<T> interceptionContext)
        {

            DateTime startTime;
            TimeSpan duration;
            //得到此command的开始时间
            MStartTime.TryRemove(command, out startTime);
            if (startTime != default(DateTime))
            {
                duration = DateTime.Now - startTime;
            }
            else
                duration = TimeSpan.Zero;

            var parameters = new StringBuilder();
            //循环获取执行语句的参数值
            foreach (DbParameter param in command.Parameters)
            {
                parameters.AppendLine(param.ParameterName + " " + param.DbType + " = " + param.Value);
            }

            //todo 过滤掉多次提交但执行为空的数据记录
            if (duration.TotalSeconds != 0)
            {
                if (interceptionContext.Exception != null)
                {
                    log.InfoFormat("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception.ToString());
                }
                else
                {
                    log.InfoFormat("\r\n执行时间:{0} 秒\r\n-->ScalarExecuted.Command:{1}\r\n", duration.TotalSeconds, command.CommandText);
                }
            }           
        }

        public void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            OnStart(command);
        }

        public void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {

            Log(command, interceptionContext);
        }

        public void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            OnStart(command);
        }
        public void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            Log(command, interceptionContext);
        }

        public void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {

            OnStart(command);
        }
    }
}
