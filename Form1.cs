using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;

namespace ProcessAdmin_19._08
{
    public partial class Admin : Form
    {
        private List<string> _processNames { get; set; }
        private List<Process> _processList { get; set; }
        private List<AllowedProcess> _allowedProcesses { get; set; }
        public string _pathBlocked { get; set; }
        public string _pathAllowed { get; set; }
        private bool _running { get; set; }
        public Admin()
        {
            InitializeComponent();
            WriteRegStartTime();
            FormClosing += (s, e) =>
            {
                _running = !_running;
                File.WriteAllText(_pathBlocked, JsonSerializer.Serialize(this.BlockedProcesses.Items));
                File.WriteAllText(_pathAllowed, JsonSerializer.Serialize(this.AllowedProcesses.Items));
            };
            _pathBlocked = $"{Environment.CurrentDirectory}\\RestrictedPrograms.json";
            _pathAllowed = $"{Environment.CurrentDirectory}\\AllowedPrograms.json";
            ReadBlockedProcesses();
            ReadAllowedProcesses();
            _running = true;
            foreach (Process item in Process.GetProcesses())
            {
                if (!this.ExistingProcesses.Items.Contains(item.ProcessName))
                {
                    this.ExistingProcesses.Items.Add(item.ProcessName);
                }
            }
            RunBlock();
            Shown += RenewList;
        }

        private void ReadBlockedProcesses()
        {
            if (File.Exists(_pathBlocked))
            {
                string jsonStr = File.ReadAllText(_pathBlocked);
                _processNames = JsonSerializer.Deserialize<List<string>>(jsonStr);
                _processNames.ForEach(p => this.BlockedProcesses.Items.Add(p));
            }
        }

        private void ReadAllowedProcesses()
        {
            if (File.Exists(_pathAllowed))
            {
                string jsonStr = File.ReadAllText(_pathAllowed);
                _allowedProcesses = JsonSerializer.Deserialize<List<AllowedProcess>>(jsonStr);
                _allowedProcesses.ForEach(p => this.AllowedProcesses.Items.Add(p));
            }
        }

        private void BlockProcessClick(object sender, EventArgs e)
        {
            this.BlockedProcesses.Items.Add(this.ExistingProcesses.SelectedItem);
            this.ExistingProcesses.Items.Remove(this.BlockedProcesses.SelectedItem);
        }

        private void WriteRegStartTime()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey AdminStartTime = currentUserKey.CreateSubKey("AdminStartTime");
            AdminStartTime.SetValue("LastLaunchTime", $"{DateTime.Now}");
            AdminStartTime.Close();
            currentUserKey.Close();
        }

        private void BlockProcessExeClick(object sender, EventArgs e)
        {
            string temp = "";
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "exe files(*.exe)|*.exe|All files(*.*)|*.*";
            if (fileDialog.ShowDialog() == DialogResult.Cancel) return;
            temp = fileDialog.FileName;
            temp = temp.Substring(temp.LastIndexOf('\\') + 1, temp.Length - temp.LastIndexOf('\\') - 1);
            temp = temp.Substring(0, temp.IndexOf('.'));
            this.BlockedProcesses.Items.Add(temp);
        }

        private void UnblockProcessClick(object sender, EventArgs e)
        {
            this.BlockedProcesses.Items.Remove(this.BlockedProcesses.SelectedItem);
        }

        private void RenewList(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    this.ExistingProcesses.Invoke(() =>
                    {
                        this.ExistingProcesses.Items.Clear();
                        _processList.ForEach(p =>
                        {
                            if (!this.ExistingProcesses.Items.Contains(p.ProcessName))
                            {
                                this.ExistingProcesses.Items.Add(p.ProcessName);
                            }
                        });
                    });
                    Thread.Sleep(5000);
                }
            });
        }

        private void RunBlock()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    _processList = Process.GetProcesses().ToList();
                    foreach (Process process in _processList)
                    {
                        foreach (var i in this.BlockedProcesses.Items)
                        {
                            if (i.Equals(process.ProcessName)) process.Kill();
                        }
                    }
                    if (!_running) break;
                }
            });
        }
    }
}