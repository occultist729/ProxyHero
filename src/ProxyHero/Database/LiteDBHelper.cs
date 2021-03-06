﻿using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyHero
{
    /// <summary>
    /// LiteDBHelper
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class LiteDBHelper<T> where T : new()
    {
        public static int Insert(T model, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                var col = db.GetCollection<T>(tableName);

                var value = col.Insert(model);
                return value.AsInt32;
            }
        }


        public static bool Update(T model, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection<T>(tableName);
                // Update a document inside a collection
                var success = col.Update(model);
                return success;
            }
        }

        public static bool Delete(int docId, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var success = col.Delete(docId);
                return success;
            }
        }

        public static T FindOne(Query query, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var doc = col.FindOne(query);
                return BsonHelper.BsonToObject.ConvertTo<T>(doc);
            }
        }

        public static bool Exists(Query query, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var doc = col.Exists(query);
                return doc;
            }
        }

        public static BsonDocument FindBsonById(int docId, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var doc = col.FindById(docId);
                return doc;
            }
        }

        public static T FindById(int docId, string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var doc = col.FindById(docId);
                return BsonHelper.BsonToObject.ConvertTo<T>(doc);
            }
        }

        public static IEnumerable<BsonDocument> FindBsonAll(string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection(tableName);
                var doc = col.FindAll();
                return doc;
            }
        }

        public static IEnumerable<T> FindAll(string tableName)
        {
            // Open data file (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get a collection (or create, if not exits)
                var col = db.GetCollection<T>(tableName);
                var docs = col.FindAll();
                return docs;
            }
        }

        public static int Count(string tableName)
        {
            // Open database (or create if not exits)
            using (var db = new LiteDatabase(Config.SettingDataFileName))
            {
                // Get Settingection collection
                var col = db.GetCollection<T>(tableName);

                return col.Count();
            }
        }
    }
}
