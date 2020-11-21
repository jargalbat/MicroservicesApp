﻿using System;
namespace CatalogAPI.Settings
{
    public interface ICatalogDatabaseSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string CollectionName { get; set; }
    }
}

