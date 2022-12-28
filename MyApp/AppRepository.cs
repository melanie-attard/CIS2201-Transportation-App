﻿using MyApp.Models;
using SQLite;
using System.IO;

namespace MyApp
{
    public class AppRepository
    {
        // variable for sqlite connection
        private readonly SQLiteAsyncConnection conn;
        public static string DBpath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db3");
        public string StatusMessage { get; set; }

        //private void Init()
        //{
        //    if (conn != null)
        //    {
        //        return;
        //    }
        //    conn = new SQLiteAsyncConnection(_DBpath);
        //}

        public AppRepository()
        {
            conn = new SQLiteAsyncConnection(DBpath);
        }

        public async Task<List<Route>> GetAllRoutes()
        {
            try
            {
                //Init();
                return await conn.Table<Route>().ToListAsync();
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<Route>();
        }

        public async Task<List<BusStop>> GetAllStops()
        {
            try
            {
                return await conn.Table<BusStop>().ToListAsync();
            }
            catch(Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<BusStop>();
        }
    }
}