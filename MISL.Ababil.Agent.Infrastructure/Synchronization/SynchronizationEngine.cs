using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace MISL.Ababil.Agent.Infrastructure.Synchronization
{
    public class SynchronizationEngine
    {

        private static readonly Hashtable SyncronizationParameterTable = new Hashtable();
        private static readonly string LocalUserPath = Application.LocalUserAppDataPath + "\\";

        public static bool RegisterSyncrhonizer(ISynchronizable whatToSynchronize,
            SynchronizationType howToSynchronize, SynchronizationInterval whenToSynchronize, int syncPeriod)
        {

            if (whatToSynchronize == null) return false;
            if (howToSynchronize == SynchronizationType.None) return false;
            if (whenToSynchronize == SynchronizationInterval.Never) return false;
            if (syncPeriod < 1) return false;

            SynchronizationParameters syncronizationParameters = new SynchronizationParameters();

            syncronizationParameters.WhatToSynchronize = whatToSynchronize;
            syncronizationParameters.HowToSynchronize = howToSynchronize;
            syncronizationParameters.WhenToSynchronize = whenToSynchronize;
            syncronizationParameters.SynchronizationPeriod = syncPeriod;

            string name = whatToSynchronize.GetType().FullName;
            if (SyncronizationParameterTable.ContainsKey(name))
            {
                SyncronizationParameterTable[name] = whatToSynchronize;
            }
            else
            {
                SyncronizationParameterTable.Add(name, whatToSynchronize);
            }

            return true;
        }


        public static bool SaveSynchronizationData(ISynchronizable forWhom, object syncData)
        {
            if (forWhom == null) return false;
            if (syncData == null) return false;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string serializedData = JsonConvert.SerializeObject(syncData); //serializer.Serialize(syncData);

            try
            {
                File.WriteAllText(GetSynchronizedFileFullPath(forWhom), serializedData);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, StringTable.Synchronization_Data_Saving_Failed);
                return false;
            }

            return true;
        }

        private static string GetSynchronizedFileFullPath(ISynchronizable forWhom)
        {
            return LocalUserPath + forWhom.GetType().FullName;
        }

        public static bool IsExpired(ISynchronizable synchronizable)
        {
            if (synchronizable == null) return true;

            string fullPath = GetSynchronizedFileFullPath(synchronizable);
            
            if (!File.Exists(fullPath)) return true;

            if (Expired(File.GetLastWriteTime(fullPath), synchronizable.GetType().FullName)) return true;
            

            return false;
        }

        private static bool Expired(DateTime lastWriteTime, string fullName)
        {
            if (fullName == null) return true;
            if (!SyncronizationParameterTable.ContainsKey(fullName)) return false;

            SynchronizationParameters synchronizationParameters = SyncronizationParameterTable[fullName] as SynchronizationParameters;
            if (synchronizationParameters == null) return false;

            DateTime rightNow = DateTime.Now;
            DateTime NextSyncTime = rightNow;

            if (lastWriteTime > NextSyncTime) return false;

            int daysToGo;

            switch (@synchronizationParameters.WhenToSynchronize) 
            {
                case SynchronizationInterval.Seconds:
                    NextSyncTime =  lastWriteTime.AddSeconds(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Minutes:
                    NextSyncTime = lastWriteTime.AddMinutes(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Hours:
                    NextSyncTime = lastWriteTime.AddHours(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Days:
                    NextSyncTime = lastWriteTime.AddDays(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Weeks:
                    NextSyncTime = lastWriteTime.AddDays(synchronizationParameters.SynchronizationPeriod * 7);
                    break;
                case SynchronizationInterval.Months:
                    NextSyncTime = lastWriteTime.AddMonths(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Quarters:
                    NextSyncTime = lastWriteTime.AddMonths(synchronizationParameters.SynchronizationPeriod * 3);
                    break;
                case SynchronizationInterval.HalfYears:
                    NextSyncTime = lastWriteTime.AddMonths(synchronizationParameters.SynchronizationPeriod * 6);
                    break;
                case SynchronizationInterval.Annual:
                    NextSyncTime = lastWriteTime.AddYears(synchronizationParameters.SynchronizationPeriod);
                    break;
                case SynchronizationInterval.Immediate:
                    NextSyncTime = lastWriteTime;
                    break;

                case SynchronizationInterval.Never:
                    return false;
                    break;

                case SynchronizationInterval.DayOfWeek:

                    daysToGo = synchronizationParameters.SynchronizationPeriod - (int) rightNow.DayOfWeek;
        
                    if (daysToGo < 0) daysToGo += 7;

                    NextSyncTime = rightNow.AddDays(daysToGo);
                    
                    break;

                case SynchronizationInterval.DayOfMonth:

                    daysToGo = synchronizationParameters.SynchronizationPeriod - rightNow.Day;

                    int currentMonth = rightNow.Month;
                    daysToGo = CalculateDaysToAdd(daysToGo, currentMonth);

                    NextSyncTime = rightNow.AddDays(daysToGo);
                    break;

                case SynchronizationInterval.DayOfNthWeekOfMonth:

 //                   int currentWeek = (rightNow.Day - (int) rightNow.DayOfWeek)/(int) 7;

                    //NextSyncTime = lastWriteTime.AddMinutes(synchronizationParameters.SynchronizationPeriod);
                    break;

                default:
                    break;
            }



            return false;
        }

        private static int CalculateDaysToAdd(int daysToGo, int currentMonth)
        {
            if (daysToGo < 0)
            {
                if (currentMonth == 1 || currentMonth == 3 || currentMonth == 5 || currentMonth == 7 || currentMonth == 8 ||
                    currentMonth == 10 || currentMonth == 12)
                {
                    daysToGo += 31;
                }
                if (currentMonth == 4 || currentMonth == 6 || currentMonth == 9 || currentMonth == 11)
                {
                    daysToGo += 30;
                }
                else
                {
                    daysToGo += 30;
                }
            }
            return daysToGo;
        }
    }
}