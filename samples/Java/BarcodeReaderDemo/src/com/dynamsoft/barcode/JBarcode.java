package com.dynamsoft.barcode;

import java.io.File;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.util.Properties;


public class JBarcode {
	
    static {

		try {
			// get arch
			Properties props = System.getProperties();
			String bits=String.valueOf(props.get("sun.arch.data.model"));
			if(bits.equals("32")){
				bits="86";
			}
			
			// Copy JNI dll to local temp path
			String jniName = "/DynamsoftBarcodeJNIx" + bits + ".dll";
			InputStream in = JBarcode.class.getResource(jniName).openStream();
			File jniFile = File.createTempFile("DynamsoftBarcodeJNI", ".dll");
			FileOutputStream out = new FileOutputStream(jniFile);
			
			int i;
			byte [] buf = new byte[1024];
			while((i=in.read(buf))!=-1) {
				out.write(buf,0,i);
			}
			
			in.close();
			out.close();
			jniFile.deleteOnExit();
			

			// Copy barcode dll to local temp path 
			String dependDllName = "DynamsoftBarcodeReaderx" + bits + ".dll";
			String dependDllPath = "/" + dependDllName;
			in = JBarcode.class.getResource(dependDllPath).openStream();
			File dependFile = new File(jniFile.getParentFile(), dependDllName);
			out = new FileOutputStream(dependFile);
			
			while((i=in.read(buf))!=-1) {
				out.write(buf,0,i);
			}
			
			in.close();
			out.close();
			dependFile.deleteOnExit();

			// Copy pdf dll to local temp path
			String pdfDllName = "DynamicPdf.dll";
			if(bits.equals("64")){
				pdfDllName = "DynamicPdfx64.dll";
			}
			String pdfDllPath = "/" + pdfDllName;
			in = JBarcode.class.getResource(pdfDllPath).openStream();
			File pdfFile = new File(jniFile.getParentFile(), pdfDllName);
			out = new FileOutputStream(pdfFile);

			while((i=in.read(buf))!=-1) {
				out.write(buf,0,i);
			}
			
			in.close();
			out.close();
			pdfFile.deleteOnExit();

			// load dll
			System.load(dependFile.toString());
			System.load(jniFile.toString());
			System.load(pdfFile.toString());
		}catch (Exception e) {
			System.err.println("load jni error!");
		}
    	
}
  
    public native static int DBR_InitLicense(
		String pLicense	//License Key
	);

    public native static int DBR_DecodeFile(
		String pFileName,
		
		int option_iMaxBarcodesNumPerPage,
		long option_lBarcodeFormat,
		
		tagBarcodeResultArray ppResults	//Barcode Results
	);	

    public native static int DBR_DecodeFileRect(
		String pFileName,

		int option_iMaxBarcodesNumPerPage,
		long option_lBarcodeFormat,
		
		int iRectLeft,			//Rectangle Left
		int iRectTop,			//Rectangle Top
		int iRectWidth,			//Rectangle 
		int iRectHeight,		//Rectangle 
		tagBarcodeResultArray ppResults	// Barcode Results
	);

    public native static int DBR_DecodeBuffer(
		byte[] pDIBBuffer,	//Buffer
        int iDIBSize,
        
		int option_iMaxBarcodesNumPerPage,
		long option_lBarcodeFormat,
		
        tagBarcodeResultArray ppResults	//Barcode Results
	);

    public native static int DBR_DecodeBufferRect(
		byte[] pDIBBuffer,	//Buffer
        int iDIBSize,	
        
		int option_iMaxBarcodesNumPerPage,
		long option_lBarcodeFormat,
		
        int iRectLeft,			//Rectangle Left
        int iRectTop,			//Rectangle Top
        int iRectWidth,			//Rectangle 
        int iRectHeight,		//Rectangle 
        tagBarcodeResultArray ppResults	//Barcode Results
	);


    public native static String DBR_GetErrorString(int iErrorCode);

}