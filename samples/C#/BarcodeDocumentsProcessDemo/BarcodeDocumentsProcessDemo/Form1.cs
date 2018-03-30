using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dynamsoft.Barcode;
using System.IO;
using System.Drawing.Imaging;

namespace BarcodeDocumentsProcessDemo
{
    public partial class Form1 : Form
    {
        private Mode mode = Mode.Rename; //initial mode
        private Label rdbSelectedFormat = null;//= lbCode39;
        string strMessageBoxCaption = "Barcode documents process demo";
        BarcodeReader barcodeReader = new BarcodeReader();
        string strRenameDocumentFolder = "";
        string strSplitDocumentFolder = "";
        string strClassifyDocumentFolder = "";
        Label lbRenameLastFormat = null;
        Label lbSplitLastFormat = null;
        Label lbClassifyLastFormat = null;
        private static string[] mBarcodeType = { "All_DEFAULT", "OneD_DEFAULT", "QR_CODE_DEFAULT", "PDF417_DEFAULT", "DATAMATRIX_DEFAULT", "CODE_39_DEFAULT", "CODE_128_DEFAULT", "CODE_93_DEFAULT", "CODABAR_DEFAULT", "ITF_DEFAULT", "INDUSTRIAL_25_DEFAULT", "EAN_13_DEFAULT", "EAN_8_DEFAULT", "UPC_A_DEFAULT", "UPC_E_DEFAULT" };
        private string format = "All_DEFAULT";
        /// <summary>
        /// Click to minimize the form
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_MINIMIZEBOX = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style | WS_MINIMIZEBOX;
                return cp;
            }
        }

        private string _lastOpenedDirectory;
        public Form1()
        {
            InitializeComponent();
            InitialDefaultValue();
            barcodeReader.LicenseKeys = "t0068MgAAAB75AhCCV4AnnJxVDPm6sarBJZlWZBH1OnCKBKCz+hts0EMMlaae8x/HzWTBIPkj34U0Zy57u5MlsurNPaDwGSs=";

            try
            {
                string _mSettingsFilePath = "E:\\Program Files (x86)\\Dynamsoft\\Barcode Reader 6.0\\Templates\\default_settings.json";
                barcodeReader.LoadSettingsFromFile(_mSettingsFilePath);
            }
            catch
            {
                MessageBox.Show("Failed to load the settings file, please check the file path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (!Directory.Exists(_lastOpenedDirectory))
                _lastOpenedDirectory = string.Empty;


        }

        private void InitialDefaultValue()
        {
            string strDesktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            if (strDesktop.EndsWith(Path.DirectorySeparatorChar.ToString()))
                tbOutputFolder.Text = strDesktop + "temp";
            else
                tbOutputFolder.Text = strDesktop + Path.DirectorySeparatorChar + "temp";

            lbRenameLastFormat = lbUnknown;
            lbSplitLastFormat = lbUnknown;
            lbClassifyLastFormat = lbUnknown;
            rdbSelectedFormat = lbUnknown;
            int index = Environment.CurrentDirectory.LastIndexOf("bin");
            if (index >= 0)
            {
                string dir = Environment.CurrentDirectory.Substring(0, index);
                dir += "Demo";
                if (Directory.Exists(dir))
                {
                    strRenameDocumentFolder = dir + Path.DirectorySeparatorChar + "Rename";
                    strSplitDocumentFolder = dir + Path.DirectorySeparatorChar + "Split";
                    strClassifyDocumentFolder = dir + Path.DirectorySeparatorChar + "Classify";
                    lbRenameLastFormat = lbEAN13;
                    lbSplitLastFormat = lbCode128;
                    lbClassifyLastFormat = lbCode39;
                }
            }

            Mode_Changed(rdbRename, null);
            //rdbSelectedFormat = lbCode39;
            //Format_Changed(rdbSelectedFormat, null);
            lbProcess.Focus();
            lbModeInfo.Visible = false;
        }


        #region title

        #region Move Window
        private Point m_mosPosition = Point.Empty;
        private void lbTitle_MouseDown(object sender, MouseEventArgs e)
        {
            m_mosPosition = new Point(-e.X, -e.Y);
        }

        private void lbTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point location = Control.MousePosition;
                location.Offset(m_mosPosition);
                this.Location = location;
            }
        }
        #endregion

        /// <summary>
        /// Close main window
        /// </summary>
        private void lbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// minimize main window
        /// </summary>
        private void lbMinimum_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        #endregion

        #region Mode

        enum Mode
        {
            Rename,
            Classify,
            Split
        }

        private void Mode_Changed(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            string tag = lb.Tag.ToString();
            picboxMode.Image = (Image)Properties.Resources.ResourceManager.GetObject(tag);
            lbRename.ForeColor = Color.Black;
            lbSplit.ForeColor = Color.Black;
            lbClassify.ForeColor = Color.Black;
            rdbRename.Image = Properties.Resources.radio_unchecked;
            rdbSplit.Image = Properties.Resources.radio_unchecked;
            rdbClassify.Image = Properties.Resources.radio_unchecked;
            switch (tag)
            {
                case "rename":
                    lbRename.ForeColor = Color.Green;
                    rdbRename.Image = Properties.Resources.radio_checked;
                    mode = Mode.Rename;
                    tbInputFolder.Text = strRenameDocumentFolder;
                    if (lbRenameLastFormat != null)
                        Format_Changed(lbRenameLastFormat, null);
                    break;
                case "split":
                    lbSplit.ForeColor = Color.Green;
                    rdbSplit.Image = Properties.Resources.radio_checked;
                    mode = Mode.Split;
                    tbInputFolder.Text = strSplitDocumentFolder;
                    if (lbSplitLastFormat != null)
                        Format_Changed(lbSplitLastFormat, null);
                    break;
                case "classify":
                    lbClassify.ForeColor = Color.Green;
                    rdbClassify.Image = Properties.Resources.radio_checked;
                    mode = Mode.Classify;
                    tbInputFolder.Text = strClassifyDocumentFolder;
                    if (lbClassifyLastFormat != null)
                        Format_Changed(lbClassifyLastFormat, null);
                    break;
                default:break;  
            }
        }

        #endregion

        #region Barcode Format

        private void Format_Changed(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            string tag = lb.Tag == null ? null : lb.Tag.ToString();
            if (tag == null || tag.Length == 0)
            {
                Point loc = lb.Location;
                loc.X = loc.X - 8;
                loc.Y = loc.Y + 8;
                Control control = GetChildAtPoint(loc);
                if (control is Label)
                    Format_Changed(control, null);
            }
            else if (tag.StartsWith("bf-"))
            {
                tag = tag.Substring(3);
                rdbSelectedFormat.Image = Properties.Resources.radio_unchecked;
                rdbSelectedFormat = lb;
                rdbSelectedFormat.Image = Properties.Resources.radio_checked;
                switch (tag)
                {
                    case "code 39":
                        format = mBarcodeType[5];
                        break;
                    case "code 93":
                        format = mBarcodeType[7];
                        break;
                    case "code 128":
                        format = mBarcodeType[6];
                        break;
                    case "codabar":
                        format = mBarcodeType[8];
                        break;
                    case "ean-13":
                        format = mBarcodeType[11];
                        break;
                    case "ean-8":
                        format = mBarcodeType[12];
                        break;
                    case "upc-a":
                        format = mBarcodeType[13];
                        break;
                    case "upc-e":
                        format = mBarcodeType[14];
                        break;
                    case "interleaved 2 of 5":
                        format = mBarcodeType[9];
                        break;
                    case "industrial 2 of 5":
                        format = mBarcodeType[10];
                        break;
                    case "qrcode":
                        format = mBarcodeType[2];
                        break;
                    case "pdf417":
                        format = mBarcodeType[3];
                        break;
                    case "datamatrix":
                        format = mBarcodeType[4];
                        break;
                    default: format = mBarcodeType[0]; break;
                }
            }
        }

        #endregion

        private void lbInputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.Description = "Select the folder where the documents are in.";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbInputFolder.Text = dlg.SelectedPath;
            }
        }

        private void lbOutputBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowNewFolderButton = true;
            dlg.Description = "Select the folder where the output documents will be put in.";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbOutputFolder.Text = dlg.SelectedPath;
            }
        }

        /// <summary>
        /// Process documents
        /// </summary>
        private void lbProcess_Click(object sender, EventArgs e)
        {
            // check settings
            string strInputFolder = tbInputFolder.Text.Trim();
            string strOutputFolder = tbOutputFolder.Text.Trim();
            if (strInputFolder.Length == 0)
            {
                MessageBox.Show("Input folder is not set.", strMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (strOutputFolder.Length == 0)
            {
                MessageBox.Show("Output folder is not set.", strMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(strInputFolder))
            {
                MessageBox.Show("Input folder doesn't exist.", strMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(strOutputFolder))
            {
                bool bReturn = true;
                if (MessageBox.Show("Output folder doesn't exist. Would you like to create it?", strMessageBoxCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(strOutputFolder);
                        bReturn = false;
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Failed to create folder. " + exp.Message, strMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                if (bReturn)
                    return;
            }

            //start processing
            tbLog.Clear();
            tbLog.AppendText("Start processing…\r\n");
            //tbLog.Refresh();
            switch (mode)
            {
                case Mode.Rename:
                    DoRename(strInputFolder, strOutputFolder);
                    strRenameDocumentFolder = strInputFolder;
                    lbRenameLastFormat = rdbSelectedFormat;
                    break;
                case Mode.Split:
                    DoSplit(strInputFolder, strOutputFolder);
                    strSplitDocumentFolder = strInputFolder;
                    lbSplitLastFormat = rdbSelectedFormat;
                    break;
                case Mode.Classify:
                    DoClassify(strInputFolder, strOutputFolder);
                    strClassifyDocumentFolder = strInputFolder;
                    lbClassifyLastFormat = rdbSelectedFormat;
                    break;
            }
        }

        /// <summary>
        /// Using barcode value to rename documents.
        /// </summary>
        /// <param name="strInputFolder">the path of folder that documents in</param>
        /// <param name="strOutputFolder">the path of folder that renamed documents saved in</param>
        private void DoRename(string strInputFolder, string strOutputFolder)
        {
            int iFileCount = 0;
            int iSuccCount = 0;
            DateTime dtStart = DateTime.Now;
            string[] files = Directory.GetFiles(strInputFolder);
            if (files != null)
            {
                foreach (string strFile in files)
                {
                    if (IsImageFile(strFile))
                    {
                        FileStream infs = null;
                        FileStream outfs = null;
                        try
                        {
                            iFileCount++;
                            int iDirectSeparator = strFile.LastIndexOf(Path.DirectorySeparatorChar);
                            string strFileName = strFile.Substring(iDirectSeparator + 1);
                            tbLog.AppendText(string.Format("\r\nProcessing file {0}\r\n", strFileName));
                            Bitmap bmp = (Bitmap)Bitmap.FromFile(strFile);

                            string[] Templates = barcodeReader.GetAllParameterTemplateNames();
                            bool bifcontian = false;
                            for (int i = 0; i < Templates.Length; i++)
                            {
                                if (format == Templates[i])
                                {
                                    bifcontian = true;
                                }
                            }
                            if (!bifcontian)
                            {
                                MessageBox.Show(("Failed to find the template named " + format + "."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            TextResult[] barcodes = barcodeReader.DecodeBitmap(bmp,format);//DecodeFile(strFile);
                            bmp.Dispose();
                            if (barcodes == null || barcodes.Length <= 0 )
                            {
                                tbLog.AppendText("There is no barcode on the first page\r\n");
                            }
                            else
                            {
                                tbLog.AppendText(string.Format("Page: {0}\r\n", barcodes[0].LocalizationResult.PageNumber));
                                tbLog.AppendText(string.Format("Barcode Value: {0}\r\n", barcodes[0].BarcodeText));
                                
                                //output file name
                                int iDot = strFileName.LastIndexOf('.');
                                string strOutputFileName = barcodes[0].BarcodeText + strFileName.Substring(iDot);
                                string strOutputFile = null;
                                if (strOutputFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                                    strOutputFile = strOutputFolder + strOutputFileName;
                                else
                                    strOutputFile = strOutputFolder + Path.DirectorySeparatorChar + strOutputFileName;
                                if (barcodes[0].BarcodeText.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
                                {
                                    tbLog.AppendText(string.Format("{0} contains character(s) that are not allowed in file names, skip renaming\r\n", barcodes[0].BarcodeText));
                                }
                                else
                                {
                                    if (File.Exists(strOutputFile))
                                    {
                                        tbLog.AppendText(string.Format("{0} exists, skip renaming {1}\r\n", strOutputFileName, strFileName));
                                    }
                                    else
                                    {
                                        infs = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                                        outfs = new FileStream(strOutputFile, FileMode.CreateNew);
                                        int size = 1 << 14;
                                        byte[] buffer = new byte[size];
                                        while (infs.Read(buffer, 0, size) > 0)
                                        {
                                            outfs.Write(buffer, 0, size);
                                        }
                                        infs.Close();
                                        outfs.Close();
                                        iSuccCount++;
                                        tbLog.AppendText(string.Format("Renamed to {0}\r\n", strOutputFileName));
                                    }
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            tbLog.AppendText(exp.Message + "\r\n");
                            if (infs != null)
                                infs.Close();
                            if (outfs != null)
                                outfs.Close();
                        }
                        tbLog.Refresh();
                    }
                }             
            }
            
            tbLog.AppendText("Completed\r\n");
            tbLog.AppendText(string.Format("Files Total: {0} file(s), Success: {1} file(s)\r\n", iFileCount, iSuccCount));
            tbLog.AppendText(string.Format("Total cost time: {0}ms", (int)(DateTime.Now - dtStart).TotalMilliseconds));
        }

        /// <summary>
        /// Using barcode value to split multi-page documents.
        /// </summary>
        /// <param name="strInputFolder">the path of folder that documents in</param>
        /// <param name="strOutputFolder">the path of folder that splitted documents saved in</param>
        private void DoSplit(string strInputFolder, string strOutputFolder)
        {
            int iFileCount = 0;
            int iSuccCount = 0;
            DateTime dtStart = DateTime.Now;
            string[] files = Directory.GetFiles(strInputFolder);
            if (files != null)
            {
                foreach (string strFile in files)
                {
                    if (IsImageFile(strFile))
                    {
                        try
                        {              
                            iFileCount++;
                            int iDirectSeparator = strFile.LastIndexOf(Path.DirectorySeparatorChar);
                            string strFileName = strFile.Substring(iDirectSeparator + 1);
                            tbLog.AppendText(string.Format("\r\nProcessing file {0}\r\n", strFileName));
                            if (!strFileName.EndsWith(".tiff", true, System.Globalization.CultureInfo.CurrentCulture) && 
                                !strFileName.EndsWith(".tif", true, System.Globalization.CultureInfo.CurrentCulture))
                            {
                                tbLog.AppendText("It's not a multi-page tiff file\r\n");
                                continue;
                            }

                            string[] Templates = barcodeReader.GetAllParameterTemplateNames();
                            bool bifcontian = false;
                            for (int i = 0; i < Templates.Length; i++)
                            {
                                if (format == Templates[i])
                                {
                                    bifcontian = true;
                                }
                            }
                            if (!bifcontian)
                            {
                                MessageBox.Show(("Failed to find the template named " + format + "."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            TextResult[] barcodes = barcodeReader.DecodeFile(strFile,format);
                            if (barcodes == null || barcodes.Length <= 0)
                            {
                                tbLog.AppendText("There is no barcode on the first page\r\n");
                            }
                            else
                            {
                                List<int> separators = new List<int>();
                                List<string> values = new List<string>();
                                List<string> splittedFileNames = new List<string>();
                                foreach (TextResult result in barcodes)
                                {
                                    if (result.LocalizationResult.PageNumber >= 0)
                                    {
                                        if (!separators.Contains(result.LocalizationResult.PageNumber))
                                        {
                                            separators.Add(result.LocalizationResult.PageNumber);
                                            values.Add(result.BarcodeText);
                                        }
                                    }
                                }

                                string strOutputDir = null;
                                if (strOutputFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                                    strOutputDir = strOutputFolder;
                                else
                                    strOutputDir = strOutputFolder + Path.DirectorySeparatorChar;

                                Image img = Image.FromFile(strFile);
                                int iFrameCount = 1;
                                FrameDimension dimension = FrameDimension.Page;
                                if (img.FrameDimensionsList != null && img.FrameDimensionsList.Length > 0)
                                {
                                    dimension = new FrameDimension(img.FrameDimensionsList[0]);
                                    iFrameCount = img.GetFrameCount(dimension);
                                }
                                if (iFrameCount <= 1)
                                {
                                    tbLog.AppendText("It's not a multi-page tiff file\r\n");
                                    continue;
                                }

                                bool bHaveExistFile = false;

                                for (int i = 1; i <= separators.Count; i++)
                                {
                                    int start = separators[i-1];
                                    int end = start;
                                    if (i != separators.Count)
                                        end = separators[i];
                                    else
                                        end = iFrameCount;

                                    tbLog.AppendText(string.Format("Page: {0}\r\n", separators[i - 1]));
                                    tbLog.AppendText(string.Format("Barcode Value: {0}\r\n", values[i-1]));
                                    
                                    string strOutputFileName = values[i - 1] + ".tiff";
                                    string strOutputFile = strOutputDir + strOutputFileName;

                                    if (File.Exists(strOutputFile))
                                    {
                                        bHaveExistFile = true;
                                        tbLog.AppendText(string.Format("{0} exists,skip splitting pages({1}-{2}) in {3}\r\n", strOutputFileName, start + 1, end, strFileName));
                                        continue;
                                    }
                                    
                                    ImageCodecInfo tiffCodeInfo = null;
                                    ImageCodecInfo[] codeinfos = ImageCodecInfo.GetImageDecoders();
                                    foreach (ImageCodecInfo codeinfo in codeinfos)
                                    {
                                        if (codeinfo.FormatID == ImageFormat.Tiff.Guid)
                                        {
                                            tiffCodeInfo = codeinfo;
                                            break;
                                        }
                                    }

                                    System.Drawing.Imaging.EncoderParameters encoderParams = null;
                                    if (end - start == 1)
                                    {
                                        encoderParams = new System.Drawing.Imaging.EncoderParameters(1);
                                        encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionLZW);
                                    }
                                    else
                                    {
                                        encoderParams = new System.Drawing.Imaging.EncoderParameters(2);
                                        encoderParams.Param[0] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)System.Drawing.Imaging.EncoderValue.CompressionLZW);
                                        encoderParams.Param[1] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)System.Drawing.Imaging.EncoderValue.MultiFrame);
                                    }

                                    img.SelectActiveFrame(dimension, start);
                                    img.Save(strOutputFile, tiffCodeInfo, encoderParams);
                                    start++;
                                    if (start < end)
                                    {
                                        encoderParams.Param[1] = new System.Drawing.Imaging.EncoderParameter(System.Drawing.Imaging.Encoder.SaveFlag, (long)System.Drawing.Imaging.EncoderValue.FrameDimensionPage);
                                        for (int k = start; k < end; k++)
                                        {
                                            img.SelectActiveFrame(dimension, k);
                                            img.SaveAdd(img, encoderParams);
                                        }
                                    }
                                    splittedFileNames.Add(strOutputFileName);
                                }

                                img.Dispose();
                                if (!bHaveExistFile)
                                    iSuccCount++;

                                string strFiles = null;
                                if (splittedFileNames.Count > 0)
                                {
                                    strFiles = splittedFileNames[0];
                                    for(int j = 1; j < splittedFileNames.Count; j++)
                                    {
                                        strFiles += "," + splittedFileNames[j];
                                    }
                                }
                                if (strFiles != null)
                                    tbLog.AppendText(string.Format("Splitted it to multiple files:{0}\r\n", strFiles));
                            }
                        }
                        catch (Exception exp)
                        {
                            tbLog.AppendText(exp.Message + "\r\n");
                        }
                        tbLog.Refresh();
                    }
                }
            }

            tbLog.AppendText("Completed\r\n");
            tbLog.AppendText(string.Format("Files Total: {0} file(s), Success: {1} file(s)\r\n", iFileCount, iSuccCount));
            tbLog.AppendText(string.Format("Total cost time: {0}ms", (int)(DateTime.Now - dtStart).TotalMilliseconds));
        }

        /// <summary>
        /// Using barcode value to classify documents.
        /// </summary>
        /// <param name="strInputFolder">the path of folder that documents in</param>
        /// <param name="strOutputFolder">the path of folder that classified documents saved in</param>
        private void DoClassify(string strInputFolder, string strOutputFolder)
        {
            int iFileCount = 0;
            int iSuccCount = 0;
            DateTime dtStart = DateTime.Now;
            string[] files = Directory.GetFiles(strInputFolder);
            if (files != null)
            {
                foreach (string strFile in files)
                {
                    if (IsImageFile(strFile))
                    {
                        FileStream infs = null;
                        FileStream outfs = null;
                        try
                        {
                            iFileCount++;
                            int iDirectSeparator = strFile.LastIndexOf(Path.DirectorySeparatorChar);
                            string strFileName = strFile.Substring(iDirectSeparator + 1);
                            tbLog.AppendText(string.Format("\r\nProcessing file {0}\r\n", strFileName));
                            Bitmap bmp = (Bitmap)Bitmap.FromFile(strFile);
                            string[] Templates = barcodeReader.GetAllParameterTemplateNames();
                            bool bifcontian = false;
                            for (int i = 0; i < Templates.Length; i++)
                            {
                                if (format == Templates[i])
                                {
                                    bifcontian = true;
                                }
                            }
                            if (!bifcontian)
                            {
                                MessageBox.Show(("Failed to find the template named " + format + "."), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            };
                            TextResult[] barcodes = barcodeReader.DecodeBitmap(bmp,format);
                            bmp.Dispose();
                            if (barcodes == null || barcodes.Length <= 0)
                            {
                                tbLog.AppendText("There is no barcode on the first page\r\n");
                            }
                            else
                            {
                                tbLog.AppendText(string.Format("Page: {0}\r\n", barcodes[0].LocalizationResult.PageNumber));
                                tbLog.AppendText(string.Format("Barcode Value: {0}\r\n", barcodes[0].BarcodeText));

                                if (barcodes[0].BarcodeText.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                                {
                                    //output dir
                                    string strOutDir = null;
                                    if (strOutputFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
                                        strOutDir = strOutputFolder + barcodes[0].BarcodeText + Path.DirectorySeparatorChar;
                                    else
                                        strOutDir = strOutputFolder + Path.DirectorySeparatorChar + barcodes[0].BarcodeText + Path.DirectorySeparatorChar;
                                    if (!Directory.Exists(strOutDir))
                                        Directory.CreateDirectory(strOutDir);
                                    //output file name
                                    string strOutputFile = strOutDir + strFileName;
                                    if (File.Exists(strOutputFile))
                                    {
                                        tbLog.AppendText(string.Format("{0} already exists in {1}, skip classifying\r\n", strFileName, barcodes[0].BarcodeText + Path.DirectorySeparatorChar));
                                    }
                                    else
                                    {
                                        infs = new FileStream(strFile, FileMode.Open, FileAccess.Read);
                                        outfs = new FileStream(strOutputFile, FileMode.CreateNew);
                                        int size = 1 << 14;
                                        byte[] buffer = new byte[size];
                                        while (infs.Read(buffer, 0, size) > 0)
                                        {
                                            outfs.Write(buffer, 0, size);
                                        }
                                        infs.Close();
                                        outfs.Close();
                                        iSuccCount++;
                                        tbLog.AppendText(string.Format("Copied it to the folder: {0}\r\n", strOutDir));
                                    }
                                }
                                else
                                {
                                    // not a valid directory name
                                    tbLog.AppendText(string.Format("{0} contains character(s) that are not allowed in folder names, skip classifying\r\n", barcodes[0].BarcodeText));
                                }
                            }
                        }
                        catch (Exception exp)
                        {
                            tbLog.AppendText(exp.Message + "\r\n");
                            if (infs != null)
                                infs.Close();
                            if (outfs != null)
                                outfs.Close();
                        }
                        tbLog.Refresh();
                    }
                }
            }

            tbLog.AppendText("Completed\r\n");
            tbLog.AppendText(string.Format("Files Total: {0} file(s), Success: {1} file(s)\r\n", iFileCount, iSuccCount));
            tbLog.AppendText(string.Format("Total cost time: {0}ms", (int)(DateTime.Now - dtStart).TotalMilliseconds));
        }


        private bool IsImageFile(string strFileName)
        {
            bool ret = false;
            if (strFileName != null)
            {
                strFileName = strFileName.ToLower();
                if (strFileName.EndsWith(".tiff") || strFileName.EndsWith(".tif") ||
                    strFileName.EndsWith(".jpeg") || strFileName.EndsWith(".jpg") || strFileName.EndsWith(".jpe") || strFileName.EndsWith(".jfif") ||
                    strFileName.EndsWith(".bmp") || strFileName.EndsWith(".png") || strFileName.EndsWith(".gif"))
                    ret = true;
                //int dotIndex = strFileName.LastIndexOf('.');
                //if (dotIndex > 0)
                //{
                //    string strFileExt = strFileName.Substring(dotIndex+1);
                //    if (strFileExt.Equals
                //    {
                //    }
                //}
            }
            return ret;
        }


        #region button mouse event

        private void lbButton_MouseEnter(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            string strTag = lb.Tag.ToString();
            lb.Image = (Image)Properties.Resources.ResourceManager.GetObject(strTag + "_enter");
        }

        private void lbButton_MouseLeave(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            string strTag = lb.Tag.ToString();
            lb.Image = (Image)Properties.Resources.ResourceManager.GetObject(strTag + "_normal");
        }

        private void lbButton_MouseDown(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            string strTag = lb.Tag.ToString();
            lb.Image = (Image)Properties.Resources.ResourceManager.GetObject(strTag + "_down");
        }

        private void lbButton_MouseUp(object sender, MouseEventArgs e)
        {
            Label lb = (Label)sender;
            string strTag = lb.Tag.ToString();
            lb.Image = (Image)Properties.Resources.ResourceManager.GetObject(strTag + "_enter");

            if (lb.Name.Contains("Browse"))
            {
                Point point = lb.PointToClient(Control.MousePosition);
                if (!lb.ClientRectangle.Contains(point))
                    lbButton_MouseLeave(lb, null);
            }
        }

        #endregion

        private void lbMode_MouseHover(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            if (lb != null && lb.Tag != null)
            {
                switch (lb.Tag.ToString())
                {
                    case "rename":
                        lbModeInfo.Text = "Use the barcodes on the first pages to rename the output documents.";
                        break;
                    case "split":
                        lbModeInfo.Text = "Use the barcodes found anywhere in the input file to create new documents.";
                        break;
                    case "classify":
                        lbModeInfo.Text = "Classify documents into individual output folders by barcodes on the first pages of the input files.";
                        break;
                    default: lbModeInfo.Text = ""; break;
                }

                if (lbModeInfo.Text != null && lbModeInfo.Text.Length > 0)
                {
                    lbModeInfo.Location = new Point(lb.Right + 10, lb.Top);
                    lbModeInfo.Visible = true;
                }
            }
        }

        private void lbMode_MouseLeave(object sender, EventArgs e)
        {
            if (lbModeInfo.Visible)
                lbModeInfo.Visible = false;
        }
    }
}
