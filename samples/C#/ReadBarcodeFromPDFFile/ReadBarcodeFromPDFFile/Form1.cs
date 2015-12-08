using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Barcode;

namespace ReadBarcodeFromPDFFile
{
    public partial class Form1 : Form
    {
        private const int iFormatCount = 13;
        private int iCheckedFormatCount = iFormatCount;

        public Form1()
        {
            InitializeComponent();
        }

        private BarcodeFormat GetFormats()
        {
            BarcodeFormat? formats = null;
            if (chkCode39.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.CODE_39;
                else
                    formats = formats | BarcodeFormat.CODE_39;
            if (chkCode128.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.CODE_128;
                else
                    formats = formats | BarcodeFormat.CODE_128;
            if (chkCode93.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.CODE_93;
                else
                    formats = formats | BarcodeFormat.CODE_93;
            if (chkCodabar.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.CODABAR;
                else
                    formats = formats | BarcodeFormat.CODABAR;
            if (chkITF.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.ITF;
                else
                    formats = formats | BarcodeFormat.ITF;
            if (chkUPCA.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.UPC_A;
                else
                    formats = formats | BarcodeFormat.UPC_A;
            if (chkUPCE.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.UPC_E;
                else
                    formats = formats | BarcodeFormat.UPC_E;
            if (chkEAN8.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.EAN_8;
                else
                    formats = formats | BarcodeFormat.EAN_8;
            if (chkEAN13.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.EAN_13;
                else
                    formats = formats | BarcodeFormat.EAN_13;
            if (chkIndustrial25.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.INDUSTRIAL_25;
                else
                    formats = formats | BarcodeFormat.INDUSTRIAL_25;
            if (chkQRCode.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.QR_CODE;
                else
                    formats = formats | BarcodeFormat.QR_CODE;
            if (chkPDF417.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.PDF417;
                else
                    formats = formats | BarcodeFormat.PDF417;
            if (chkDatamatrix.Checked)
                if (!formats.HasValue)
                    formats = BarcodeFormat.DATAMATRIX;
                else
                    formats = formats | BarcodeFormat.DATAMATRIX;
            return !formats.HasValue ? BarcodeFormat.OneD | BarcodeFormat.QR_CODE | BarcodeFormat.PDF417 | BarcodeFormat.DATAMATRIX : formats.Value;
        }

        #region check barcode format radio

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            bool selectall = false;
            int count = gbBarcodeType.Controls.Count;
            for (int i = 0; i < count; i++)
                if (gbBarcodeType.Controls[i] is CheckBox)
                    if (!((CheckBox)gbBarcodeType.Controls[i]).Checked)
                    {
                        selectall = true;
                        break;
                    }

            for (int i = 0; i < count; i++)
                if (gbBarcodeType.Controls[i] is CheckBox)
                    ((CheckBox)gbBarcodeType.Controls[i]).Checked = selectall;

            if (selectall)
                btnSelectAll.Text = "Unselect All";
            else
                btnSelectAll.Text = "Select All";
        }

        private void chkFormat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = (CheckBox)sender;
            if (chkbox.Checked)
                iCheckedFormatCount++;
            else
                iCheckedFormatCount--;

            if (tbFileName.Text != null && tbFileName.Text.Trim().Length > 0 && iCheckedFormatCount > 0)
                btnRead.Enabled = true;
            else
            {
                btnRead.Enabled = false;
            }

            if (iCheckedFormatCount < iFormatCount)
                btnSelectAll.Text = "Select All";
            else
                btnSelectAll.Text = "Unselect All";
        }

        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "PDF Files(*.pdf)|*.pdf";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbFileName.Text = dlg.FileName;
                if (iCheckedFormatCount > 0)
                    btnRead.Enabled = true;
            }
        }

        private void tbMaximumNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b')
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(e.KeyChar.ToString());
                if (!char.IsDigit(e.KeyChar) || array.LongLength == 2) e.Handled = true;
                if ((tbMaximumNum.Text.Length == 0 || tbMaximumNum.SelectionLength == tbMaximumNum.Text.Length) && e.KeyChar == '0')
                    e.Handled = true;
            }
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                string strFile = tbFileName.Text.Trim();
                if (!System.IO.File.Exists(strFile))
                    throw new Exception(string.Format("The file ({0}) doesn't exist.", strFile));

                BarcodeReader reader = new Dynamsoft.Barcode.BarcodeReader();
                ReaderOptions ro = new ReaderOptions();
                ro.BarcodeFormats = GetFormats();
                ro.MaxBarcodesToReadPerPage = int.Parse(tbMaximumNum.Text);
                reader.ReaderOptions = ro;
                reader.LicenseKeys = "38B9B94D8B0E2B41DB1CC80A58946567";

                DateTime beforeRead = DateTime.Now;
                BarcodeResult[] barcodes = reader.DecodeFile(strFile);
                DateTime afterRead = DateTime.Now;
                double timeElapsed = (afterRead - beforeRead).TotalMilliseconds;
                ShowBarcodeResults(barcodes, timeElapsed);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Barcode Reader Demo", MessageBoxButtons.OK);
            }
            finally
            {
                //reader.Dispose();
            }
        }

        private void ShowBarcodeResults(BarcodeResult[] barcodeResults, double timeElapsed)
        {
            tbResults.Clear();

            if (barcodeResults != null && barcodeResults.Length > 0)
            {
                tbResults.AppendText(String.Format("Total barcode(s) found: {0}. Total time spent: {1} seconds\r\n\r\n", barcodeResults.Length, ((int)timeElapsed) / 1000.0f));
                for (int i = 0; i < barcodeResults.Length; i++)
                {
                    tbResults.AppendText(String.Format("  Barcode {0}:\r\n", i + 1));
                    tbResults.AppendText(String.Format("    Page: {0}\r\n", barcodeResults[i].PageNumber));
                    tbResults.AppendText(String.Format("    Type: {0}\r\n", barcodeResults[i].BarcodeFormat));
                    tbResults.AppendText(String.Format("    Value: {0}\r\n", barcodeResults[i].BarcodeText));
                    tbResults.AppendText(String.Format("    Region: {{Left: {0}, Top: {1}, Width: {2}, Height: {3}}}\r\n", barcodeResults[i].BoundingRect.Left, barcodeResults[i].BoundingRect.Top, barcodeResults[i].BoundingRect.Width, barcodeResults[i].BoundingRect.Height));
                    tbResults.AppendText("\r\n");
                }
                tbResults.SelectionStart = 0;
                tbResults.ScrollToCaret();
            }
            else
                tbResults.AppendText(String.Format("No barcode found. Total time spent: {0} seconds\r\n", (timeElapsed / 1000)));
        }

        private void tbFileName_TextChanged(object sender, EventArgs e)
        {
            if (tbFileName.Text.Length > 0)
                btnRead.Enabled = true;
            else
                btnRead.Enabled = false;
        }
    }
}
