using Project.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Android.Graphics.ImageDecoder;
//using static Android.Graphics.ImageDecoder;

namespace Project.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection _db;

        public IEnumerable<JobTitle> GetAllJobTitles()
        {
            return _db.Table<JobTitle>()
                .ToList();
        }

        public IEnumerable<Duty> GetJobDuties(int id)
        {
            return _db.Table<Duty>()
                .Where(t => t.JobId == id)
                .ToList();

        }

        public void Init()
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory,
                             "JobsDataBase.db");

            _db = new SQLiteConnection(dbPath);

            _db.CreateTable<JobTitle>();
            _db.CreateTable<Duty>();

            _db.DeleteAll<Duty>();
            _db.DeleteAll<JobTitle>();

            JobTitle jobTitle1 = new JobTitle("Analyst", "Bank");
            JobTitle jobTitle2 = new JobTitle("Consultant", "Bank");
            JobTitle jobTitle3 = new JobTitle("Accountant", "Bank");

            JobTitle jobTitle4 = new JobTitle("Waiter", "Cafe");
            JobTitle jobTitle5 = new JobTitle("Chef", "Restaurant");

            _db.Insert(jobTitle1);
            _db.Insert(jobTitle2);
            _db.Insert(jobTitle3);
            _db.Insert(jobTitle4);
            _db.Insert(jobTitle5);

            Duty duty1_1 = new Duty("Analize", 1);
            Duty duty1_2 = new Duty("Organize analytical support", 1);
            Duty duty1_3 = new Duty("Research", 1);

            Duty duty2_1 = new Duty("Give advice", 2);
            Duty duty2_2 = new Duty("Receive and distribute goods", 2);
            Duty duty2_3 = new Duty("Sale of goods", 2);
            Duty duty2_4 = new Duty("Reporting", 2);

            Duty duty3_1 = new Duty("Count", 3);
            Duty duty3_2 = new Duty("Work with tax", 3);
            Duty duty3_3 = new Duty("Keep records", 3);

            Duty duty4_1 = new Duty("Serve tables", 4);
            Duty duty4_2 = new Duty("Take orders", 4);
            Duty duty4_3 = new Duty("Serve meals", 4);
            Duty duty4_4 = new Duty("Provide invoice", 4);

            Duty duty5_1 = new Duty("Menu development", 5);
            Duty duty5_2 = new Duty("Procurement planning", 5);
            Duty duty5_3 = new Duty("Product selection", 5);
            Duty duty5_4 = new Duty("Cooking", 5);

            _db.Insert(duty1_1);
            _db.Insert(duty1_2);
            _db.Insert(duty1_3);

            _db.Insert(duty2_1);
            _db.Insert(duty2_2);
            _db.Insert(duty2_3);
            _db.Insert(duty2_4);

            _db.Insert(duty3_1);
            _db.Insert(duty3_2);
            _db.Insert(duty3_3);

            _db.Insert(duty4_1);
            _db.Insert(duty4_2);
            _db.Insert(duty4_3);
            _db.Insert(duty4_4);

            _db.Insert(duty5_1);
            _db.Insert(duty5_2);
            _db.Insert(duty5_3);
            _db.Insert(duty5_4);

        }
    }
}
