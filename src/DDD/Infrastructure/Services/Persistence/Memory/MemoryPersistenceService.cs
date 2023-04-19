﻿using System.Threading.Tasks;
using DDD.Application.Settings;
using DDD.Infrastructure.Ports.Adapters.Common.Translation.Converters;
using DDD.Logging;

namespace DDD.Infrastructure.Services.Persistence.Memory
{
	public class MemoryPersistenceService : PersistenceService
	{
		public MemoryPersistenceService(ISettings settings, ILogger logger, SerializerSettings serializerSettings) 
			: base("n/a", logger, serializerSettings)
		{
			
		}
		
		public override IConnection OpenConnection()
		{
			var conn = new MemoryConnection(_serializerSettings);
			conn.Open();
			return conn;
		}
		
		public override async Task<IConnection> OpenConnectionAsync()
		{
			var conn = new MemoryConnection(_serializerSettings);
			await conn.OpenAsync();
			return conn;
		}
		
		public override async Task StartAsync()
			=> await base.StartAsync();

		public override async Task StopAsync()
			=> await base.StopAsync();

		public override void EnsureDatabase()
		{
			
		}

		public override Task EnsureDatabaseAsync()
			=> Task.CompletedTask;
	}
}
