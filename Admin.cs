using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text.Json;
using System.Windows.Forms;

namespace ProcessAdmin_19._08
{
    public partial class Admin : Form
    {
        private List<Process> _processList { get; set; }
        private List<AllowedProcess> _allowedProcesses { get; set; }
        public string _pathProcesses { get; set; }
        private bool _running { get; set; }
        public Admin()
        {
            InitializeComponent();
            CheckIfBGRunning();
            WriteRegStartTime();
            FormClosing += (s, e) =>
            {
                _running = !_running;
                WriteProcesses();
            };
            string t = Application.ExecutablePath;
            _pathProcesses = $"{Application.ExecutablePath.Substring(0, t.LastIndexOf('\\'))}\\Rules.json";
            ReadProcesses();
            _running = true;
            foreach (Process item in Process.GetProcesses())
            {
                if (!this.ExistingProcesses.Items.Contains(item.ProcessName))
                {
                    this.ExistingProcesses.Items.Add(item.ProcessName);
                }
            }
            RunBlock();
            RunCheck();
            ResetTimers();
            Load += RenewList;
        }

        private void CheckIfBGRunning()
        {
            if (_processList == null) return;
            int pos = Environment.ProcessPath.LastIndexOf('\\') + 1;
            int count = Environment.ProcessPath.Count() - 4 - pos;
            Process temp = _processList.FirstOrDefault(p => p.ProcessName.Equals(Environment.ProcessPath.Substring(pos, count)));
            if (temp != null) temp.Kill();
        }

        private void ReadProcesses()
        {
            if (File.Exists(_pathProcesses))
            {
                string jsonStr = File.ReadAllText(_pathProcesses);
                _allowedProcesses = JsonSerializer.Deserialize<List<AllowedProcess>>(jsonStr);
                _allowedProcesses.ForEach(p => this.ProcessesWithRules.Items.Add(p.ProcessName));
            }
            else
            {
                _allowedProcesses = new List<AllowedProcess>();
            }
        }

        private void WriteProcesses()
        {
            lock (new object())
            {
                File.WriteAllText(_pathProcesses, JsonSerializer.Serialize(_allowedProcesses));
            }
        }

        private void AddRule(string procName)
        {
            AllowedProcess temp = new AllowedProcess(procName, 0);
            _allowedProcesses.Add(temp);
        }

        private void SetAllowedTimeClick(object sender, EventArgs e)
        {
            _allowedProcesses.FirstOrDefault(p => p.ProcessName.Equals(this.ProcessesWithRules.SelectedItem.ToString())).AllowedTime = (int)this.TimeAllowed_nud.Value * 60;
        }

        private void AllowedTimeSelectedChanged(object sender, EventArgs e)
        {
            if (this.ProcessesWithRules.SelectedItem == null) return;
            this.ProcessName_tb.Text = this.ProcessesWithRules.SelectedItem.ToString();
            this.MaxLifeTime_tb.Text = (_allowedProcesses.FirstOrDefault(p => p.ProcessName.Equals(this.ProcessesWithRules.SelectedItem.ToString())).AllowedTime / 60).ToString();
            this.LeftLifeTime_tb.Text = (_allowedProcesses.FirstOrDefault(p => p.ProcessName.Equals(this.ProcessesWithRules.SelectedItem.ToString())).WorkTime / 60).ToString();
        }

        private void BlockProcessClick(object sender, EventArgs e)
        {
            if (this.ProcessesWithRules.Items.Contains(this.ExistingProcesses.SelectedItem)) return;
            AddRule(this.ExistingProcesses.SelectedItem.ToString());
            var t = this.ExistingProcesses.SelectedItem;
            this.ProcessesWithRules.Items.Add(t);
            this.ExistingProcesses.Items.Remove(t);
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
            if (this.ProcessesWithRules.Items.Contains(temp)) return;
            this.ProcessesWithRules.Items.Add(temp);
            AddRule(temp);
        }

        private void UnblockProcessClick(object sender, EventArgs e)
        {
            this.ProcessesWithRules.Items.Remove(this.ProcessesWithRules.SelectedItem);
        }

        private void RunClick(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo("D:\\Projects\\TestCompatibility\\bin\\Debug\\BGKiller.exe");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            psi.Arguments = _pathProcesses;
            Process.Start(psi);
            _running = !_running;
            this.Hide();
        }

        private void RenewList(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    Thread.Sleep(20000);
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
                    int pos = Environment.ProcessPath.LastIndexOf('\\') + 1;
                    int count = Environment.ProcessPath.Count() - 4 - pos;
                    foreach (Process process in _processList)
                    {
                        foreach (AllowedProcess p in _allowedProcesses)
                        {
                            if (p.ProcessName.Equals(Environment.ProcessPath.Substring(pos, count))) continue;
                            if (p.ProcessName.Equals(process.ProcessName) && p.AllowedTime <= p.WorkTime)
                            {
                                foreach (Process temp in Process.GetProcessesByName(p.ProcessName))
                                {
                                    temp.Kill();
                                }
                                WriteProcesses();
                            }
                        }
                    }
                    if (!_running) break;
                }
            });
        }

        private void RunCheck()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    foreach (AllowedProcess p in _allowedProcesses)
                    {
                        if (Process.GetProcesses().Any(proc => proc.ProcessName.Equals(p.ProcessName))) p.WorkTime++;
                    }
                    WriteProcesses();
                    Thread.Sleep(1000);
                }
            });
        }

        private void ResetTimers()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (DateTime.Now.ToLongTimeString().Equals("00:00:00"))
                    {
                        foreach (AllowedProcess p in _allowedProcesses)
                        {
                            p.WorkTime = 0;
                        }
                        WriteProcesses();
                    }
                    Thread.Sleep(1000);
                }
            });
        }

        private void WriteRegStartTime()
        {
            RegistryKey currentUserKey = Registry.CurrentUser;
            RegistryKey AdminStartTime = currentUserKey.CreateSubKey("AdminStartTime");
            AdminStartTime.SetValue("LastLaunchTime", $"{DateTime.Now}");
            AdminStartTime.Close();
            currentUserKey.Close();
        }
    }
}