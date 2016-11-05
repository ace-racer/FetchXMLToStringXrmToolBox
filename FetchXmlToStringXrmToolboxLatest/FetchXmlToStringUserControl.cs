using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility.Interfaces;
using XrmToolBox.Extensibility;
using System.Diagnostics;

namespace FetchXmlToStringXrmToolboxLatest
{
    public partial class FetchXmlToStringUserControl : PluginControlBase
    {
        public FetchXmlToStringUserControl()
        {
            InitializeComponent();
        }

        private void BtnCopy_Click(object sender, EventArgs e)
        {
            var outputTxt = txtOutput.Text;
            if (!string.IsNullOrWhiteSpace(outputTxt))
            {
                System.Windows.Forms.Clipboard.SetText(outputTxt);
                MessageBox.Show("Copied the output string!");
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {          
            try
            {
                var inputFetchXmlValue = txtInput.Text;
                var fetchXmlToStringConvertorLogicsContainer = new FetchXmlToStringLogicsContainer();
                var outputString = fetchXmlToStringConvertorLogicsContainer.ConvertFetchXmlToString(inputFetchXmlValue);
                txtOutput.Text = outputString;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An exception occurred in the plugin. Details: " + ex.Message);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://in.linkedin.com/in/anurag-chatterjee-59b13179");
            Process.Start(sInfo);
        }
    }
}
