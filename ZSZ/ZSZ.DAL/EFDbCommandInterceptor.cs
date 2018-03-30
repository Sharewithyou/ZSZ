using log4net;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure.Interception;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZSZ.DAL
{
    public class EFDbCommandInterceptor : DbCommandInterceptor
    {
        private static ILog log = LogManager.GetLogger(typeof(EFDbCommandInterceptor));
        /// <summary>
        /// 计时器
        /// </summary>
        public volatile Stopwatch watch = new Stopwatch();

        public override void NonQueryExecuting(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            base.NonQueryExecuting(command, interceptionContext);
            watch.Restart();
        }

        public override void NonQueryExecuted(DbCommand command, DbCommandInterceptionContext<int> interceptionContext)
        {
            watch.Stop();
            if (interceptionContext.Exception != null)
            {
                WriteLog(string.Format("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception.ToString()));
            }
            else
            {
                WriteLog(string.Format("\r\n执行时间:{0} 毫秒\r\n-->ScalarExecuted.Command:{1}\r\n", watch.ElapsedMilliseconds, command.CommandText));
            }
            base.NonQueryExecuted(command, interceptionContext);
        }

        public override void ScalarExecuting(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            base.ScalarExecuting(command, interceptionContext);
            watch.Restart();
        }

        public override void ScalarExecuted(DbCommand command, DbCommandInterceptionContext<object> interceptionContext)
        {
            watch.Stop();
            if (interceptionContext.Exception != null)
            {
                WriteLog(string.Format("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception.ToString()));
            }
            else
            {
                WriteLog(string.Format("\r\n执行时间:{0} 毫秒\r\n-->ScalarExecuted.Command:{1}\r\n", watch.ElapsedMilliseconds, command.CommandText));
            }
            base.ScalarExecuted(command, interceptionContext);
        }

        public override void ReaderExecuting(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            base.ReaderExecuting(command, interceptionContext);
            watch.Restart();
        }

        public override void ReaderExecuted(DbCommand command, DbCommandInterceptionContext<DbDataReader> interceptionContext)
        {
            watch.Stop();
            if (interceptionContext.Exception != null)
            {
                WriteLog(string.Format("Exception:{1} \r\n --> Error executing command: {0}", command.CommandText, interceptionContext.Exception.ToString()));
            }
            else
            {
                WriteLog(string.Format("\r\n执行时间:{0} 毫秒\r\n-->ScalarExecuted.Command:{1}\r\n", watch.ElapsedMilliseconds, command.CommandText));
            }
            base.ReaderExecuted(command, interceptionContext);
        }
        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="msg">消息</param>
        private void WriteLog(string msg)
        {
            //指定true表示追加
            //using (TextWriter writer = new StreamWriter("Db.log", true))
            //{
            //    writer.WriteLine(msg);
            //}
            log.Info(msg);
        }
    }
}
