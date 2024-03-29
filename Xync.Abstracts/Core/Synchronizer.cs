﻿using System.Collections.Generic;
using System.Linq;

namespace Xync.Abstracts.Core
{
    public abstract class Synchronizer : ISynchronizer
    {
        public abstract string ConnectionString { get; }
        public static IList<ITable> Monitors { get; set; } = new List<ITable>();
        public abstract void ListenAll(bool forced = false);
        public abstract int Listen(string tblName);
        public virtual IList<ITable> this[string tblName,string schema="dbo"]
        {
            get
            {
                return Monitors.Where(x => x.Name == tblName && x.Schema==schema).ToList();
            }
        }

    }
}
