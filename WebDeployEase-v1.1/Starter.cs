namespace WebDeployEase_v1._1
{
    public partial class Starter : Form
    {
        public Starter()
        {
            InitializeComponent();
        }

        private void btnFolderPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();

            if(folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK )
            {
                txtFolderPath.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                MessageBox.Show("Please Select a Valid Folder Path", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (UserInputValidation())
            {
                this.Hide();

                InstallationProcess installationProcess = new InstallationProcess();
                installationProcess.applicationName = txtApplicationName.Text;
                installationProcess.applicationFolderPath = txtFolderPath.Text;
                installationProcess.Show();
            }
        }

        private bool UserInputValidation()
        {
            if(string.IsNullOrEmpty(txtApplicationName.Text))
            {
                MessageBox.Show("Please Define Application Name","Invalid",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtFolderPath.Text))
            {
                MessageBox.Show("Please Define Application Folder Path", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtDatabaseName.Text))
            {
                MessageBox.Show("Please Define Database Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtDatabaseUserName.Text))
            {
                MessageBox.Show("Please Enter Database User Name", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(txtDatabasePassword.Text))
            {
                MessageBox.Show("Please Enter Database Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Starter_Load(object sender, EventArgs e)
        {

        }
    }
}