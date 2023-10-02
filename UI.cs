using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win10Context
{
    public partial class UI : Form
    {
        private bool is_key;
        private bool is_skey;
        private bool is_value;
        private bool is_deleted;
        public UI()
        {
            InitializeComponent();
        }

        private void restartExplorer()
        {
            foreach (var process in Process.GetProcessesByName("explorer"))
            {
                process.Kill();
            }

            Process.Start("explorer");
        }

        private void Restart()
        {
            Process.Start("shutdown.exe", "/r /t 10");
        }

        private void UI_Load(object sender, EventArgs e)
        {
            lblOS.Text = getOS.os_name;

            if(getOS.os_name == "Windows 10 Pro or earlier" || getOS.os_name == "failed")
            {
                lblMessage.Text = "Your OS Not Supported !";
                lblMessage.ForeColor = Color.Red;
            }
            is_key = getKeys.GetKeys();
            if (is_key)
            {
                lblMessage.Text = "Windows 10 Mode Activated";
                lblMessage.ForeColor = Color.Green;
                btnFunction.Text = "Deactivate";
            }
            else
            {
                lblMessage.Text = "Windows 11 Mode Activated";
                lblMessage.ForeColor = Color.Red;
                btnFunction.Text = "Activate";
            }
        }

        private void btnFunction_Click(object sender, EventArgs e)
        {
            if (btnFunction.Text == "Activate")
            {
                is_key = getKeys.GetKeys();
                if (!is_key)
                {
                    bool mainkey = createKeys.addMainKey();
                    if (mainkey)
                    {
                        is_skey = createKeys.addSecondKey();
                        if (is_skey)
                        {
                            createKeys.addDefaultValue();
                            if (!is_value)
                            {
                                DialogResult result = MessageBox.Show("Reboot is required to apply the changes. Do you want to restart now?", "Confirmation", MessageBoxButtons.YesNo);

                                if (result == DialogResult.Yes)
                                {
                                    Restart();
                                    btnFunction.Text = "Deactivate";
                                }
                                else
                                {
                                    lblMessage.Text = "Reboot is required !";
                                    btnFunction.Enabled = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                is_deleted = deleteKey.deleteRegKey();
                if (is_deleted)
                {
                    DialogResult result = MessageBox.Show("Reboot is required to apply the changes. Do you want to restart now?", "Confirmation", MessageBoxButtons.YesNo);

                    if (result == DialogResult.Yes)
                    {
                        Restart();
                        btnFunction.Text = "Activate";
                    }
                    else
                    {
                        lblMessage.Text = "Reboot is required !";
                        btnFunction.Enabled = false;
                    }

                }
            }
        }
    }
}
