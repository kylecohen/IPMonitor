
namespace IPMonitor.Service
{
    partial class IPMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IPMonitor));
            this.IPMonitorNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            // 
            // IPMonitorNotifyIcon
            // 
            this.IPMonitorNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.IPMonitorNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("IPMonitorNotifyIcon.Icon")));
            this.IPMonitorNotifyIcon.Text = "IP Monitor";
            this.IPMonitorNotifyIcon.Visible = true;
            this.IPMonitorNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.IPMonitorNotifyIcon_MouseDoubleClick);
            // 
            // IPMonitor
            // 
            this.ServiceName = "IPMonitor";

        }

        #endregion

        private System.Windows.Forms.NotifyIcon IPMonitorNotifyIcon;
    }
}
