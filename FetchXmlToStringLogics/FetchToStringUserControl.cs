using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace FetchXmlToStringLogics
{
    /// <summary>
    /// User control class as per steps here: https://xrmtoolbox.codeplex.com/documentation
    /// </summary>
    /// <seealso cref="XrmToolBox.PluginBase" />
    public partial class FetchToStringUserControl : XrmToolBox.PluginBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FetchToStringUserControl"/> class.
        /// </summary>
        public FetchToStringUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnConvert control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            try
            {
                var inputFetchXmlValue = txtInput.Text;
                var fetchXmlToStringConvertorLogicsContainer = new FetchXmlToStringLogicsContainer();
                var outputString = fetchXmlToStringConvertorLogicsContainer.ConvertFetchXmlToString(inputFetchXmlValue);
                txtOutput.Text = outputString;
            }
            catch(Exception ex)
            {
                MessageBox.Show("An exception occurred in the plugin. Details: " + ex.Message);
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnCopy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            var outputTxt = txtOutput.Text;
            if(!string.IsNullOrWhiteSpace(outputTxt))
            {
                System.Windows.Forms.Clipboard.SetText(outputTxt);
                MessageBox.Show("Copied the output string!");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://in.linkedin.com/in/anurag-chatterjee-59b13179");
            Process.Start(sInfo);
        }
    }
}
