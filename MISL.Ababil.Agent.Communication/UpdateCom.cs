using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using MISL.Ababil.Agent.Infrastructure.Behavior;
using MISL.Ababil.Agent.Infrastructure.Validation;

namespace MISL.Ababil.Agent.Communication
{
    public class UpdateCom
    {
        public const string CurrentVersion = "0.60";
        private const string VersionParameterName = "latestversion";
        private const string UpdateForcedParameterName = "forceupdate";
        private const string SetupUrlParameterName = "latestsetup";
        private const string PathSeparator = "\\";
        private const string FileNamePrependSpace = " ";
        private const string SetupFileExtension = ".exe";
        private const string SetupFileNamePrepended = "Agent Banking Setup";

        private static int _downloadPercentage;
        private static bool _downloadCompleted;

        private static string _setupFileName;


        private static readonly List<ISoftwareUpdateObserver> Observers = new List<ISoftwareUpdateObserver>();

        public static bool IsUpdateaAvailable()
        {
            return GetLatestVersion() > GetCurrentVersion();
        }

        public static double GetLatestVersion()
        {
            var serverCurrentVersionText = ConfigCom.GetServerConfigParameter(VersionParameterName);

            if (!ValidationManager.ValidateDecimal(serverCurrentVersionText)) return GetCurrentVersion();

            var serverCurrentVersion = double.Parse(serverCurrentVersionText);
            return serverCurrentVersion;
        }

        private static double GetCurrentVersion()
        {
            if (!ValidationManager.ValidateDecimal(CurrentVersion)) return 0;

            var currentVersion = double.Parse(CurrentVersion);
            return currentVersion;
        }

        public static bool IsUpdateForced()
        {
            bool updateForced;

            string updateForcedText = ConfigCom.GetServerConfigParameter(UpdateForcedParameterName);

            var successfullyParsed = bool.TryParse(updateForcedText, out updateForced);

            if (successfullyParsed)
            {
                return updateForced;
            }

            return false;
        }

        public static string GetUpdateUrl()
        {
            return ConfigCom.GetServerConfigParameter(SetupUrlParameterName);
        }

        public static bool InitiateUpdate()
        {
            WebClient downloader = new WebClient();
            _downloadPercentage = 0;
            _downloadCompleted = false;
            try
            {
                _setupFileName = Application.LocalUserAppDataPath + PathSeparator + SetupFileNamePrepended + FileNamePrependSpace +
                    GetLatestVersion() + SetupFileExtension;
                downloader.DownloadFileAsync(new Uri(GetUpdateUrl()), _setupFileName);
                downloader.DownloadProgressChanged += DownloadProgressed;
                downloader.DownloadFileCompleted += DownloadCompleted;
                return true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return false;
            }
        }

        private static void DownloadCompleted(object sender, AsyncCompletedEventArgs asyncCompletedEventArgs)
        {
            Exception exception = asyncCompletedEventArgs.Error;
            if (exception != null)
            {
                MessageBox.Show(exception.Message);
            }
            _downloadCompleted = true;
            UpdateObservers(true, 100);
        }

        private static void DownloadProgressed(object sender, DownloadProgressChangedEventArgs downloadProgressChangedEventArgs)
        {
            _downloadPercentage = downloadProgressChangedEventArgs.ProgressPercentage;
            UpdateObservers(false, _downloadPercentage);
        }



        public static int GetUpdatePercentage()
        {
            return _downloadPercentage;
        }

        public static bool IsDownloadCompleted()
        {
            return _downloadCompleted;
        }

        public static void RegisterUpdateObserver(ISoftwareUpdateObserver observer)
        {
            Observers.Add(observer);
        }

        public static void ClearUpdateObservers()
        {
            Observers.Clear();
        }

        private static void UpdateObservers(bool completed, int percentage)
        {
            foreach (ISoftwareUpdateObserver observer in Observers)
            {
                if (observer != null)
                {
                    try
                    {
                        if (completed) observer.Completed(_setupFileName);
                        if (percentage > 0) observer.Progressed(percentage);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);

                    }
                }
            }
        }

    }
}