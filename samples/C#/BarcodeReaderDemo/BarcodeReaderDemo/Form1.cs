using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Barcode;
using System.Drawing.Imaging;
using System.IO;

namespace BarcodeReaderDemo_CSharp
{
    public partial class Form1 : Form
    {

        private bool m_bFitWindow = false;
        private Image m_data = null;
        private int iPageCount = 0;
        private List<int[]> m_results = new List<int[]>();
        private BarcodeResult[] m_barcodes = null;
        private int m_index = -1;
        private string filePath = null;
        private String lastOpenedDirectory = Application.ExecutablePath;
        private const int iFormatCount = 13;
        private int iCheckedFormatCount = iFormatCount;

        public bool FitWindow
        {
            get
            {
                return m_bFitWindow;
            }
            set
            {
                if (m_bFitWindow != value)
                {
                    m_bFitWindow = value;
                    if (m_bFitWindow)
                    {
                        panel1.AutoScroll = false;
                        imageViewer.SizeMode = PictureBoxSizeMode.Zoom;
                        imageViewer.Dock = DockStyle.Fill;
                    }
                    else
                    {
                        panel1.AutoScroll = true;
                        imageViewer.SizeMode = PictureBoxSizeMode.AutoSize;
                        imageViewer.Dock = DockStyle.None;
                    }
                    panel1.Refresh();
                }
            }
        }

        public int CurrentIndex
        {
            get
            {
                return m_index;
            }
            set
            {
                if (value >= 0 && value < iPageCount && m_index != value)
                {
                    m_index = value;
                    tbxCurrentImageIndex.Text = (value + 1).ToString();
                }
                SetImageViewerImage();
            }
        }

        public Form1()
        {
            InitializeComponent();
            chkFitWindow.Checked = true;
            int index = -1;
            lastOpenedDirectory.Replace('/', '\\');
            if ((index = lastOpenedDirectory.LastIndexOf("Samples")) > 0)
            {
                lastOpenedDirectory = lastOpenedDirectory.Substring(0, index);
                lastOpenedDirectory += "Images\\";
            }
            if (!System.IO.Directory.Exists(lastOpenedDirectory))
                lastOpenedDirectory = "";
        }

        private void chkFitWindow_CheckedChanged(object sender, EventArgs e)
        {
            FitWindow = chkFitWindow.Checked;
        }

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

        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
        public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

        Bitmap Clone(Bitmap img, PixelFormat format)
        {
            Bitmap bmp = null;
            BitmapData data = null;
            BitmapData data2 = null;
            try
            {
                data = img.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadOnly, format);
                int len = data.Stride * img.Height;
                bmp = new Bitmap(img.Width, img.Height, format);
                data2 = bmp.LockBits(new Rectangle(0, 0, img.Width, img.Height), ImageLockMode.ReadWrite, format);
                CopyMemory(data2.Scan0, data.Scan0, (uint)len);
                img.UnlockBits(data);
                bmp.UnlockBits(data2);
                data = null;
                data2 = null;
            }
            catch
            {
            }
            finally
            {
                if (data != null)
                    img.UnlockBits(data);
                if (data2 != null)
                    bmp.UnlockBits(data2);
            }

            return bmp;
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All Supported Images(*.BMP,*.PNG,*.JPEG,*.JPG,*.JPE,*.JFIF,*.TIF,*.TIFF,*.GIF)|*.BMP;*.PNG;*.JPEG;*.JPG;*.JPE;*.JFIF;*.TIF;*.TIFF;*.GIF|JPEG|*.JPG;*.JPEG;*.JPE;*.JFIF|BMP|*.BMP|PNG|*.PNG|TIFF|*.TIF;*.TIFF|GIF|*.GIF";
                dlg.InitialDirectory = lastOpenedDirectory;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    lastOpenedDirectory = System.IO.Directory.GetParent(dlg.FileName).FullName;
                    if (m_data != null)
                    {
                        m_data.Dispose();
                        m_data = null;
                        iPageCount = 0;
                    }
                    m_results.Clear();
                    tbResults.Clear();

                    this.Text = dlg.FileName;

                    filePath = dlg.FileName;

                    m_data = Image.FromFile(filePath);
                    if (m_data.RawFormat.Equals(ImageFormat.Gif))
                        iPageCount = 1;
                    else
                    {
                        iPageCount = m_data.GetFrameCount(new FrameDimension(m_data.FrameDimensionsList[0]));
                    }

                    if (iPageCount > 0 && iCheckedFormatCount > 0)
                        btnRead.Enabled = true;
                    CurrentIndex = iPageCount - 1;
                    tbxTotalImageNum.Text = iPageCount.ToString();
                    if (iPageCount > 1)
                    {
                        EnableControls(picboxFirst);
                        EnableControls(picboxPrevious);
                        //EnableControls(picboxNext);
                        //EnableControls(picboxLast);
                    }
                    else
                    {
                        DisableControls(picboxFirst);
                        DisableControls(picboxPrevious);
                        DisableControls(picboxNext);
                        DisableControls(picboxLast);
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Barcode Reader Demo", MessageBoxButtons.OK);
            }
        }

        private void SetImageViewerImage()
        {
            if (imageViewer.Image != null)
            {
                Image img = imageViewer.Image;
                imageViewer.Image = null;
                img.Dispose();
            }

            if (m_index >= 0 && m_index < iPageCount)
            {
                Bitmap bmp = null;
                if (iPageCount > 1)
                {
                    Bitmap tempBmp = (Bitmap)m_data.Clone();
                    tempBmp.SelectActiveFrame(FrameDimension.Page, m_index);
                    PixelFormat format = tempBmp.PixelFormat;
                    if (((((uint)tempBmp.PixelFormat) >> 8) & 255) < 24)
                        format = PixelFormat.Format24bppRgb;
                    bmp = Clone(tempBmp, format);
                    tempBmp.Dispose();
                }
                else
                {
                    PixelFormat format = m_data.PixelFormat;
                    if (((((uint)m_data.PixelFormat) >> 8) & 255) < 24)
                        format = PixelFormat.Format24bppRgb;
                    bmp = Clone((Bitmap)m_data, format);
                }

                if (bmp != null)
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        if (m_index < m_results.Count)
                        {
                            int[] barcodeResults = m_results[m_index];
                            if (barcodeResults != null && barcodeResults.Length > 0)
                            {
                                float fsize = bmp.Width / 64f;
                                if (fsize < 12)
                                    fsize = 12;
                                Pen pen = new Pen(Color.Red, 1 > fsize / 6 ? 1 : fsize / 6);
                                Brush textBrush = new SolidBrush(Color.Blue);
                                Font textFont = new Font("Times New Roman", fsize, FontStyle.Bold);
                                for (int i = barcodeResults.Length - 1; i >= 0; i--)
                                {
                                    BarcodeResult barcodeResult = m_barcodes[barcodeResults[i]];
                                    if (barcodeResult != null)
                                    {
                                        Rectangle rect = barcodeResult.BoundingRect;
                                        g.DrawRectangle(pen, rect);
                                        string strText = "[" + (barcodeResults[i] + 1) + "] {" + barcodeResult.BarcodeText + "}";
                                        SizeF size = g.MeasureString(strText, textFont);
                                        int iHeight = ((int)size.Height + 1);
                                        g.DrawString(strText, textFont, textBrush, new Rectangle(rect.Left, rect.Top - iHeight < 0 ? 0 : rect.Top - iHeight, 0, iHeight), new StringFormat(StringFormatFlags.NoClip | StringFormatFlags.NoWrap));
                                    }
                                }
                                pen.Dispose();
                                textBrush.Dispose();
                                textFont.Dispose();
                            }
                        }

                        imageViewer.Image = bmp;
                    }
                }
            }
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

        private void btnRead_Click(object sender, EventArgs e)
        {
            if (imageViewer.Image != null)
            {
                //Rectangle rect = new Rectangle();
                BarcodeReader reader = new Dynamsoft.Barcode.BarcodeReader();
                try
                {
                    ReaderOptions ro = new ReaderOptions();
                    ro.BarcodeFormats = GetFormats();
                    ro.MaxBarcodesToReadPerPage = int.Parse(tbMaximumNum.Text);
                    reader.ReaderOptions = ro;
                    reader.LicenseKeys = "38B9B94D8B0E2B41DB1CC80A58946567";
                    DateTime beforeRead = DateTime.Now;
                    BarcodeResult[] barcodes = reader.DecodeFile(filePath);           
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
        }

        private void ShowBarcodeResults(BarcodeResult[] barcodeResults, double timeElapsed)
        {
            tbResults.Clear();
            m_results.Clear();
            m_barcodes = barcodeResults;

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

                int iLastPageNumber = int.MinValue + 10;
                int iStartIndex = barcodeResults.Length - 1;
                for (int i = 0; i < iPageCount; i++)
                    m_results.Add(null);
                for (int i = iStartIndex; i >= 0; i--)
                {
                    if (barcodeResults[i] != null)
                    {
                        if (barcodeResults[i].PageNumber != iLastPageNumber)
                        {
                            if (i != iStartIndex)
                            {
                                int iEnd = i > iStartIndex ? i - 1 : i + 1;
                                int iStart = iEnd > iStartIndex ? iStartIndex : iEnd;
                                iEnd = iEnd > iStartIndex ? iEnd : iStartIndex;
                                int[] resultsOnePage = new int[iEnd - iStart + 1];
                                for (int k = iStart; k <= iEnd; k++)
                                {
                                    resultsOnePage[k - iStart] = k;
                                }
                                m_results[iLastPageNumber-1] = resultsOnePage;
                            }
                            iStartIndex = i;
                            iLastPageNumber = barcodeResults[i].PageNumber;
                        }

                        if (i == 0)
                        {
                            int iStart = i > iStartIndex ? iStartIndex : i;
                            int iEnd = i > iStartIndex ? i : iStartIndex;
                            int[] resultsOnePage = new int[iEnd - iStart + 1];
                            for (int k = iStart; k <= iEnd; k++)
                            {
                                resultsOnePage[k - iStart] = k;
                            }
                            m_results[iLastPageNumber-1] = resultsOnePage;
                        }
                    }
                }
            }
            else
                tbResults.AppendText(String.Format("No barcode found. Total time spent: {0} seconds\r\n", (timeElapsed / 1000)));

            SetImageViewerImage();
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



        #region regist Event For All PictureBox Buttons
        private void picbox_MouseEnter(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
                }
            }
        }

        private void picbox_MouseLeave(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
                }
            }
        }

        private void picbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Down");
                }
            }
        }

        private void picbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox)
            {
                if ((sender as PictureBox).Enabled == true)
                {
                    (sender as PictureBox).Image =
                        (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Enter");
                }
            }

        }

        private void DisableControls(object sender)
        {
            if (sender is PictureBox)
            {
                (sender as PictureBox).Image =
                    (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Disabled");
                (sender as PictureBox).Enabled = false;
            }
            else
            {
                (sender as Control).Enabled = false;
            }
        }

        private void EnableControls(object sender)
        {
            if (sender is PictureBox)
            {
                (sender as PictureBox).Image =
                    (Image)Properties.Resources.ResourceManager.GetObject((sender as PictureBox).Name + "_Leave");
                (sender as PictureBox).Enabled = true;
            }
            else
            {
                (sender as Control).Enabled = true;
            }
        }

        private void picboxFirst_Click(object sender, EventArgs e)
        {
            if (picboxFirst.Enabled)
            {
                CurrentIndex = 0;
                DisableControls(picboxFirst);
                DisableControls(picboxPrevious);
                EnableControls(picboxNext);
                EnableControls(picboxLast);
            }
        }

        private void picboxLast_Click(object sender, EventArgs e)
        {
            if (picboxLast.Enabled)
            {
                CurrentIndex = iPageCount - 1;
                DisableControls(picboxLast);
                DisableControls(picboxNext);
                EnableControls(picboxPrevious);
                EnableControls(picboxFirst);
            }
        }

        private void picboxPrevious_Click(object sender, EventArgs e)
        {
            if (picboxPrevious.Enabled)
            {
                CurrentIndex--;
                if (CurrentIndex == 0)
                {
                    DisableControls(picboxFirst);
                    DisableControls(picboxPrevious);
                }
                EnableControls(picboxNext);
                EnableControls(picboxLast);
            }
        }

        private void picboxNext_Click(object sender, EventArgs e)
        {
            CurrentIndex++;
            if (picboxNext.Enabled)
            {
                if (CurrentIndex == iPageCount - 1)
                {
                    DisableControls(picboxLast);
                    DisableControls(picboxNext);
                }
                EnableControls(picboxPrevious);
                EnableControls(picboxFirst);
            }
        }

        #endregion

        private void chkFormat_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkbox = (CheckBox)sender;
            if (chkbox.Checked)
                iCheckedFormatCount++;
            else
                iCheckedFormatCount--;

            if (iPageCount > 0 && iCheckedFormatCount > 0)
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
    }
}
