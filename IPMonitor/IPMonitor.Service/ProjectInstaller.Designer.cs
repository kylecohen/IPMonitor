﻿
namespace IPMonitor.Service
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IPMonitorProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.IPMonitorInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // IPMonitorProcessInstaller
            // 
            this.IPMonitorProcessInstaller.Password = null;
            this.IPMonitorProcessInstaller.Username = null;
            // 
            // IPMonitorInstaller
            // 
            this.IPMonitorInstaller.ServiceName = "IPMonitor";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.IPMonitorProcessInstaller,
            this.IPMonitorInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller IPMonitorProcessInstaller;
        private System.ServiceProcess.ServiceInstaller IPMonitorInstaller;
    }
}