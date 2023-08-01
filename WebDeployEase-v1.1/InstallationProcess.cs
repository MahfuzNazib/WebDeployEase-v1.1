using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void InstallationProcess_Load(object sender, EventArgs e)
        {
            if(CreateApplicationFolder())
            {
                MessageBox.Show("Application Created","Success", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private bool CreateApplicationFolder()
        {
            string applicationFullPath = Path.Combine(applicationFolderPath, applicationName);

            try
            {
                if(!Directory.Exists(applicationFullPath))
                {
                    Directory.CreateDirectory(applicationFullPath);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
    }
}
