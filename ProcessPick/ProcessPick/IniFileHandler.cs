using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ProcessPick
{
    class IniFileHandler
    {
	[DllImport("KERNEL32.DLL")]
	public static extern uint
		GetPrivateProfileString(string lpAppName,
		string lpKeyName, string lpDefault,
		StringBuilder lpReturnedString, uint nSize,
		string lpFileName);

	[DllImport("KERNEL32.DLL", EntryPoint = "GetPrivateProfileStringA")]
	public static extern uint
		GetPrivateProfileStringByByteArray(string lpAppName,
		string lpKeyName, string lpDefault,
		byte[] lpReturnedString, uint nSize,
		string lpFileName);

	[DllImport("KERNEL32.DLL")]
	public static extern uint
		GetPrivateProfileInt(string lpAppName,
		string lpKeyName, int nDefault, string lpFileName);

	[DllImport("KERNEL32.DLL")]
	public static extern uint WritePrivateProfileString(
		string lpAppName,
		string lpKeyName,
		string lpString,
		string lpFileName);

	public static string IniFilePath = "";

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所にある値（文字列）を読み込みます。</summary>
	/// <param name="section">
	///     読み込みに使用するセクション。</param>
	/// <param name="key">
	///     読み込みに使用するキー。</param>
	/// <param name="defvalue">
	///     デフォルトの値。</param>
	/// <returns>
	///     指定したセクションとキーに格納された値（文字列）。失敗時は defvalue。</returns>
	/// ---------------------------------------------------------------------------------------
	public static string ReadString(string section, string key, string defvalue)
	{
	    // 文字列を読み出す
	    StringBuilder sb = new StringBuilder(1024);
	    GetPrivateProfileString(section, key, defvalue, sb, (uint)sb.Capacity, IniFilePath);

	    return sb.ToString();
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所にある値（数値）を読み込みます。</summary>
	/// <param name="section">
	///     読み込みに使用するセクション。</param>
	/// <param name="key">
	///     読み込みに使用するキー。</param>
	/// <param name="defvalue">
	///     デフォルトの値。</param>
	/// <returns>
	///     指定したセクションとキーに格納された値（数値）。失敗時は defvalue。</returns>
	/// ---------------------------------------------------------------------------------------
	public static int ReadInteger(string section, string key, int defvalue)
	{
	    try
	    {
		// 文字列を読み出す
		StringBuilder sb = new StringBuilder(1024);
		GetPrivateProfileString(section, key, defvalue.ToString("D"), sb, (uint)sb.Capacity, IniFilePath);
		return int.Parse(sb.ToString());
	    }
	    catch
	    {
		return defvalue;
	    }

	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所にある値（実数値）を読み込みます。</summary>
	/// <param name="section">
	///     読み込みに使用するセクション。</param>
	/// <param name="key">
	///     読み込みに使用するキー。</param>
	/// <param name="defvalue">
	///     デフォルトの値。</param>
	/// <returns>
	///     指定したセクションとキーに格納された値（実数値）。失敗時は defvalue。</returns>
	/// ---------------------------------------------------------------------------------------
	public static float ReadFloat(string section, string key, float defvalue)
	{
	    // 文字列を読み出す
	    StringBuilder sb = new StringBuilder(1024);
	    GetPrivateProfileString(section, key, defvalue.ToString("F"), sb, (uint)sb.Capacity, IniFilePath);

	    return float.Parse(sb.ToString());
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所にある値（論理型）を読み込みます。</summary>
	/// <param name="section">
	///     読み込みに使用するセクション。</param>
	/// <param name="key">
	///     読み込みに使用するキー。</param>
	/// <param name="defvalue">
	///     デフォルトの値。</param>
	/// <returns>
	///     指定したセクションとキーに格納された値（論理型）。失敗時は defvalue。</returns>
	/// ---------------------------------------------------------------------------------------
	public static bool ReadBool(string section, string key, bool defvalue)
	{
	    int val = (int)GetPrivateProfileInt(section, key, Convert.ToInt32(defvalue), IniFilePath);

	    return Convert.ToBoolean(val);
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所に指定した値（文字列）を書き込みます。</summary>
	/// <param name="section">
	///     書き込みに使用するセクション。</param>
	/// <param name="key">
	///     書き込みに使用するキー。</param>
	/// <param name="value">
	///     書き込みに使用する値。</param>
	/// ---------------------------------------------------------------------------------------
	public static void WriteString(string section, string key, string value)
	{
	    WritePrivateProfileString(section, key, value, IniFilePath);
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所に指定した値（数値）を書き込みます。</summary>
	/// <param name="section">
	///     書き込みに使用するセクション。</param>
	/// <param name="key">
	///     書き込みに使用するキー。</param>
	/// <param name="value">
	///     書き込みに使用する値。</param>
	/// ---------------------------------------------------------------------------------------
	public static void WriteInteger(string section, string key, int value)
	{
	    WritePrivateProfileString(section, key, value.ToString(), IniFilePath);
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所に指定した値（実数値）を書き込みます。</summary>
	/// <param name="section">
	///     書き込みに使用するセクション。</param>
	/// <param name="key">
	///     書き込みに使用するキー。</param>
	/// <param name="value">
	///     書き込みに使用する値。</param>
	/// ---------------------------------------------------------------------------------------
	public static void WriteFloat(string section, string key, float value)
	{
	    WritePrivateProfileString(section, key, value.ToString("F"), IniFilePath);
	}

	/// ---------------------------------------------------------------------------------------
	/// <summary>
	///     指定したセクションとキーの場所に指定した値（論理型）を書き込みます。</summary>
	/// <param name="section">
	///     書き込みに使用するセクション。</param>
	/// <param name="key">
	///     書き込みに使用するキー。</param>
	/// <param name="value">
	///     書き込みに使用する値。</param>
	/// ---------------------------------------------------------------------------------------
	public static void WriteBool(string section, string key, bool value)
	{
	    WritePrivateProfileString(section, key, Convert.ToInt32(value).ToString(), IniFilePath);
	}
    }
}
