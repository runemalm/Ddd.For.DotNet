﻿using OpenDDD.Infrastructure.Ports.Database;

namespace OpenDDD.Infrastructure.Ports.Adapters.Database.Memory
{
    public interface IMemoryDatabaseStore : IDatabaseStore, IDocumentDatabaseStore
    {
        
    }
}
