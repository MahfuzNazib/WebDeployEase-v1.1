using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;


namespace SqlServerService
{
    public class SqlServerServiceProcessor
    {
        public static bool IsMSSQLServiceRunning()
        {
            string serviceName = "MSSQLSERVER";

            ServiceController serviceController = new ServiceController(serviceName);

            try
            {
                serviceController.Refresh(); // Refresh All The Service;

                ServiceControllerStatus status = serviceController.Status; // Get the MSSQLSERVER status
                
                if(status == ServiceControllerStatus.Running)
                {
                    return true;
                }
                else if(status == ServiceControllerStatus.Stopped || status == ServiceControllerStatus.Paused)
                {
                    serviceController.Start();
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));

                    return serviceController.Status == ServiceControllerStatus.Running;
                }
                else if(status == ServiceControllerStatus.StartPending || status == ServiceControllerStatus.ContinuePending)
                {
                    serviceController.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(10));

                    return serviceController.Status == ServiceControllerStatus.Running;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return false;
        }
    }
}