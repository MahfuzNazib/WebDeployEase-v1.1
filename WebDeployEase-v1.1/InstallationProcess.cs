using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SqlServerService;

namespace WebDeployEase_v1._1
{
    public partial class InstallationProcess : Form
    {
        public string applicationName { get; set; }
        public string applicationFolderPath { get; set; }
        public string databaseName { get; set; }
        public string databaseUserName { get; set; }
        public string databasePassword { get; set; }

        public InstallationProcess()
        {
            InitializeComponent();
            //timerFirstMethodCall.Interval = 2000;
        }

        private void InstallationProcess_Load(object sender, EventArgs e)
        {
            picBoxErrorApplicationFolder.Visible = false;
            panelApplicationCreate.Visible = false;
            panelTryToLoginDefaultDatabase.Visible = false;

            timerFirstMethodCall.Start();
        }

        private void CreateApplicationFolder()
        {
            string applicationFullPath = Path.Combine(applicationFolderPath, applicationName);

            try
            {
                if(!Directory.Exists(applicationFullPath))
                {
                    Directory.CreateDirectory(applicationFullPath);
                    panelApplicationCreate.Visible = true;

                    TryToLoginIntoSqlServer();
                }
                else
                {
                    picBoxErrorApplicationFolder.Visible=true;
                    picBoxSuccessApplicationFolderCreate.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }


        private void TryToLoginIntoSqlServer()
        {
            Thread.Sleep(6000);

            bool sqlServiceIsRunning = SqlServerService.SqlServerServiceProcessor.IsMSSQLServiceRunning();

            if (sqlServiceIsRunning)
            {
                MessageBox.Show("Sql Service is Running");
            }
            else
            {
                MessageBox.Show("Sql Servicer is not Running");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timerFirstMethodCall_Tick(object sender, EventArgs e)
        {
            CreateApplicationFolder();
            timerFirstMethodCall.Stop();
        }
    }
}
