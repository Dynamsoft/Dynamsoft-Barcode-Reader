package com.dynamsoft.barcode;

public interface EnumBarCode {
	public long OneD = 0x3FFL;

	public long CODE_39 = 0x1L;
	public long CODE_128 = 0x2L;
	public long CODE_93 = 0x4L;
	public long CODABAR = 0x8L;
	public long ITF = 0x10L;
	public long EAN_13 = 0x20L;
	public long EAN_8 = 0x40L;
	public long UPC_A = 0x80L;
	public long UPC_E = 0x100L;
	public long INDUSTRIAL_25 = 0x200L;
	
	public long QR_CODE = 0x4000000L;
	public long PDF417 = 0x2000000L;
	public long DATAMATRIX = 0x8000000L;

}