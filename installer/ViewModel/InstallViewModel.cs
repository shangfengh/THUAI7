﻿using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace installer.ViewModel
{
    internal class InstallViewModel : BaseViewModel
    {
        public InstallViewModel()
        {
            downloadPath = Downloader.Data.InstallPath;
            installEnabled = false;
            BrowseBtnClickedCommand = new RelayCommand(BrowseBtnClicked);
            CheckUpdBtnClickedCommand = new RelayCommand(CheckUpdBtnClicked);
            DownloadBtnClickedCommand = new RelayCommand(DownloadBtnClicked);
        }

        public Model.Downloader Downloader
        {
            get => MauiProgram.Downloader;
        }

        private string? debugAlert;
        public string? DebugAlert
        {
            get => debugAlert;
            set
            {
                debugAlert = value;
                OnPropertyChanged();
            }
        }
        private string downloadPath;
        public string DownloadPath
        {
            get => downloadPath;
            set
            {
                downloadPath = value;
                InstallEnabled = (value != Downloader.Data.InstallPath);
                OnPropertyChanged();
            }
        }

        public ICommand BrowseBtnClickedCommand { get; }
        private void BrowseBtnClicked()
        {
            DebugAlert = "Browse Button Clicked";
        }
        public ICommand CheckUpdBtnClickedCommand { get; }
        private async void CheckUpdBtnClicked()
        {
            DebugAlert = "Check Button Clicked";
            bool updated = await Task.Run(() => Downloader.CheckUpdate());
            if (updated)
            {

            }
            else
            {

            }
        }
        public ICommand DownloadBtnClickedCommand { get; }
        private async void DownloadBtnClicked()
        {
            DebugAlert = "Download Button Clicked";
            await Task.Run(() => Downloader.ResetInstallPath(downloadPath));
            await Task.Run(() => Downloader.Install());
            DownloadPath = Downloader.Data.InstallPath;
        }

        private bool installEnabled;
        public bool InstallEnabled
        {
            get => installEnabled;
            set
            {
                installEnabled = value;
                OnPropertyChanged("CheckEnabled");
                OnPropertyChanged();
            }
        }
        public bool CheckEnabled
        {
            get => !installEnabled;
        }

        private bool installEnabled;
        public bool InstallEnabled
        {
            get => installEnabled;
            set
            {
                installEnabled = value;
                OnPropertyChanged("CheckEnabled");
                OnPropertyChanged();
            }
        }
        public bool CheckEnabled
        {
            get => !installEnabled;
        }
    }
}
