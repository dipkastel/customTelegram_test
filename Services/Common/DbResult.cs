using System;

namespace Services.Common
{
    public class DbResult
    {
        public bool Success { get; set; }
        public Exception Exception { get; set; }
        public MessageType MessageType { get; set; }
        public int Count { get; set; }
        public string Info { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public DbResult()
        {
            MessageType = MessageType.None;
            DateTime = DateTime.Now;
            Success = false;
        }

        public DbResult<T> Copy<T>()
        {
            var result = new DbResult<T>
            {
                Success = Success,
                Exception = Exception,
                Count = Count,
                Info = Info,
                MessageType = MessageType
            };

            return result;
        }

        public static DbResult<U> From<T, U>(DbResult<T> dbr, U data = default)
        {
            var result = new DbResult<U>
            {
                Success = dbr.Success,
                Exception = dbr.Exception,
                Count = dbr.Count,
                Info = dbr.Info,
                MessageType = dbr.MessageType,
                Data = data
            };

            return result;
        }
    }

    public class DbResult<T> : DbResult
    {
        public T Data { get; set; }

        public DbResult()
        {
            MessageType = MessageType.None;
            DateTime = DateTime.Now;
            Success = false;
        }

        public DbResult(DbResult r)
        {
            Count = r.Count;
            Exception = r.Exception;
            Success = r.Success;
            MessageType = r.MessageType;
            Info = r.Info;
        }

        public DbResult(DbResult r, T data) : this(r)
        {
            Data = data;
        }

        public DbResult<TU> To<TU>()
        {
            var result = new DbResult<TU>
            {
                Data = (TU) Convert.ChangeType(Data, typeof(TU))
            };


            return result;
        }

        public DbResult Copy()
        {
            var result = new DbResult
            {
                Success = Success,
                Exception = Exception,
                Count = Count,
                Info = Info,
                MessageType = MessageType,
                DateTime = DateTime.Now
            };

            return result;
        }

        public DbResult<TR> Copy<TR>(TR data)
        {
            var result = new DbResult<TR>
            {
                Success = Success,
                Exception = Exception,
                Count = Count,
                Info = Info,
                MessageType = MessageType,
                DateTime = DateTime.Now,
                Data = data
            };

            return result;
        }
    }
}