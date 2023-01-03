﻿using MyApp.Models;
using SQLite;

namespace MyApp
{
    public class AppRepository
    {
        // variable for sqlite connection
        private readonly SQLiteAsyncConnection conn;
        public static string DBpath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "data.db3");
        public string StatusMessage { get; set; } // mostly for debugging purposes
        public bool Stop { get; set; } = false;
        public UserManager manager { get; set; }

        //private async Task Init()
        //{
        //    if (conn != null)
        //    {
        //        return;
        //    }
        //    conn = new SQLiteAsyncConnection(DBpath);
        //    await conn.CreateTableAsync<Driver>();
        //    await conn.CreateTableAsync<Bus>();
        //}

        public AppRepository()
        {
            conn = new SQLiteAsyncConnection(DBpath);
            manager = new UserManager();
        }

        public async Task<List<Route>> GetAllRoutes()
        {
            try
            {
                //Init();
                return await conn.Table<Route>().ToListAsync();
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<BusStop>();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            try
            {
                return await conn.Table<Driver>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<Driver>();
        }

        public async Task<BusStop> GetStopByName(string name)
        {
            try
            {
                return await conn.Table<BusStop>().Where(stop => stop.Name == name).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new BusStop();
        }

        public async Task<Driver> GetDriverById(int id)
        {
            try
            {
                return await conn.Table<Driver>().Where(driver => driver.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new Driver();
        }

        public async Task<Route> GetRouteById(int id)
        {
            try
            {
                return await conn.Table<Route>().Where(route => route.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new Route();
        }

        public async Task<Bus> GetBusByDriver(int driverId)
        {
            try
            {
                return await conn.Table<Bus>().Where(bus => bus.DriverId == driverId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new Bus();
        }

        public async Task<Bus> GetBusByRoute(int routeId)
        {
            try
            {
                return await conn.Table<Bus>().Where(bus => bus.RouteId == routeId).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new Bus();
        }

        public async Task<List<Schedule>> GetScheduleByRoute(int routeId)
        {
            try
            {
                return await conn.Table<Schedule>().Where(schedule => schedule.RouteId == routeId).ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<Schedule>();
        }

        public async Task<List<Schedule>> GetScheduleByStop(int stopId)
        {
            try
            {
                return await conn.Table<Schedule>().Where(schedule => schedule.StopId == stopId).ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retreive data. {0}", ex.Message);
            }
            return new List<Schedule>();
        }

        public async Task<List<Temp>> GetClosestBuses(int stopID)
        {
            List<Schedule> schedules = await GetScheduleByStop(stopID);
            List<Temp> closest = new();
            foreach (Schedule schedule in schedules)
            {
                //changing time1 to DateTime
                Temp temp = new() { route = schedule.RouteId, time = Convert.ToDateTime(schedule.Time1) };
                closest.Add(temp);
            }

            if (closest.Count > 1)
            {
                // order by time
                return closest.OrderBy(a => a.time).ToList();
            }
            return closest;
        }

        public int CheckID(string Id)
        {
            int id;
            try
            {
                id = Convert.ToInt32(Id);
                if(id == 0)
                {
                    StatusMessage = "ID cannot be 0!";
                    return 0;
                }
            }
            catch (FormatException)
            {
                StatusMessage = "Please enter a number!";
                return 0;
            }
            return id;
        }

        public async Task UpdateDriverAsync(Driver driver)
        {
            int result;
            try
            {
                result = await conn.UpdateAsync(driver);
                StatusMessage = string.Format("{0} record(s) updated.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update driver. Error: {0}", ex.Message);
            }
        }

        public async Task UpdateBusAsync(Bus bus)
        {
            int result;
            try
            {
                result = await conn.UpdateAsync(bus);
                StatusMessage = string.Format("{0} record(s) updated.", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to update bus. Error: {0}", ex.Message);
            }
        }

        // to be used in getClosest()
        public class Temp{
            public int route { get; set; }
            public DateTime time { get; set; }
        }
    }
}
