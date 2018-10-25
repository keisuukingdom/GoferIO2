using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ProcessPick
{
    public partial class Form1 : Form
    {
	//DB Openflg
	bool bOpenDatabaseflg = false;
	//DB情報
	public static string sServerName = string.Empty;
	private string sDBName = string.Empty;
	private string sUID = string.Empty;
	private string sPass = string.Empty;
	//DBコネクション
	SqlConnection oSqlconnection = new SqlConnection();
	//ログ書き込み
	private string swWriteLog = string.Empty;

	//mprocessデータ保存用リスト
	private List<string[]> lstMprocess = new List<string[]>();
	//M_iniFileデータ保存用リスト
	private List<string[]> lstMini = new List<string[]>();
	//フォルダパス保存用
	private string sFolder = string.Empty;

	//AlarmHisフラグ
	private int iAlarmHisflg = 0;

	//プロセスフォルダ名
	private string stProcessDir = string.Empty;

	//ドライブフラグ
	private string stDrive = @"C:\";

	enum enminifle :int 
	{
	    GroupName=0,
	    FolderName,
	    ProcessName,
	    IniFileName,
	    SectionName,
	    ItmeName,
	    Value
	}

	public Form1()
	{
	    InitializeComponent();
	}

	private void Form1_Load(object sender, EventArgs e)
	{
	
	   

	    
	   
	   

	   

	    
	}


	private bool OpenDatabase()
	{
	    bool bOpen = false;
	    try
	    {

		//接続文字列の生成
		String sConnString = string.Empty;
		sConnString += "Persist Security Info = False;";
		sConnString += String.Format("Data Source = {0};", txtServer.Text.ToString());
		sConnString += String.Format("Database = {0};", txtDB.Text.ToString());
		sConnString += String.Format("User ID = {0};", txtUID.Text.ToString());
		sConnString += String.Format("Password= {0};", txtPass.Text.ToString());

		oSqlconnection = new SqlConnection(sConnString);
		//データベース接続
		oSqlconnection.Open();
		bOpen = true;

	    }
	    catch (Exception ex)
	    {   //メッセージボックスを表示する

		MessageBox.Show(ex.ToString());
	    }
	    return bOpen;
	}

	private void button1_Click(object sender, EventArgs e)
	{

	    listBox1.BackColor = Color.White;
	    DialogResult result = MessageBox.Show("T_AlarmHisテーブルを使用する案件ですか？",
		       "質問",
		       MessageBoxButtons.YesNoCancel,
		       MessageBoxIcon.Exclamation,
		       MessageBoxDefaultButton.Button2);
	    


	    //何が選択されたか調べる
	    if (result == DialogResult.Yes)
	    {
		iAlarmHisflg = 1;
		stProcessDir = "process_AlarmHis";
	    }
	    else if (result == DialogResult.No)
	    {
		//「いいえ」が選択された時
		iAlarmHisflg = 0;
		stProcessDir = "process";
	    }
	    else if (result == DialogResult.Cancel)
	    {
		return;
	    }


	    DialogResult result2 = MessageBox.Show("Dドライブのあるロガーですか？",
		   "質問",
		   MessageBoxButtons.YesNoCancel,
		   MessageBoxIcon.Exclamation,
		   MessageBoxDefaultButton.Button2);
	    //何が選択されたか調べる
	    if (result2 == DialogResult.Yes)
	    {
		stDrive = @"D:\";
	    }
	    else if (result2 == DialogResult.No)
	    {
		//「いいえ」が選択された時
		stDrive = @"C:\";
	    }
	    else if (result2 == DialogResult.Cancel)
	    {
		return;
	    }


	    try
	    {
		//DataBaseが閉じている場合、オープンする。
		if (bOpenDatabaseflg == false)
		{
		    if (OpenDatabase() == true)
		    {
			bOpenDatabaseflg = true;
		    }
		    else
		    {
			listBox1.Items.Add("データベースの接続に失敗しました。接続情報および、ＤＢが存在することを確認してください。");
			return;
		    }
		}

		//マスター取得
		//if (masterget() == false)
		//{
		//    listBox1.Items.Add("M_Processテーブル読込失敗");
		//    return;
		//}
		//listBox1.Items.Add("M_Processテーブル読込完了");

		////表示用、レポート用テーブルの取得
		//if (RepDispget() == false)
		//{
		//    listBox1.Items.Add("表示、レポートテーブル読込失敗");
		//    return;
		//}
		//listBox1.Items.Add("表示、レポートテーブル読込成功");
		//this.Refresh();


		//コピー元のprocessフォルダの確認
		if (System.IO.Directory.Exists(stProcessDir))
		{
		    //コピー先にprocessフォルダがあれば削除
		    if (System.IO.Directory.Exists(stDrive + stProcessDir))
		    {
			// フォルダをすべて削除する
			Delete(stDrive + stProcessDir);
			
		    }
		    //processフォルダをコピー
		    Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(
			stProcessDir, stDrive + stProcessDir,
			Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
			Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing);
		}
		else
		{
		    MessageBox.Show("コピー元のprocessフォルダをこのプログラムと同じ階層に配置してください。");
		    return;
		}

		listBox1.Items.Add("コピー元フォルダ確認ＯＫ");


		// processフォルダ (ディレクトリ) が存在しているかどうか確認する
		if (System.IO.Directory.Exists(@"C:\" + stProcessDir + @"\"))
		{
		    if (System.IO.Directory.Exists(@"D:\" + stProcessDir + @"\"))
		    {
			MessageBox.Show("processフォルダはCもしくはDのいずれかに配置してください。");
			return;
		    }
		    else
		    {
			listBox1.Items.Add("Processフォルダ確認完了");
			sFolder = @"C:\" + stProcessDir + @"\";
		    }
		}
		else
		{
		    if (System.IO.Directory.Exists(@"D:\" + stProcessDir + @"\"))
		    {
			listBox1.Items.Add("Processフォルダ確認完了");
			sFolder = @"D:\" + stProcessDir + @"\";
		    }
		    else
		    {
			MessageBox.Show("processフォルダをCもしくはDのいずれかに配置してください。");
			return;
		    }
		}
		listBox1.Items.Add("プロセスフォルダ有無完了");
		this.Refresh();
		
		//processフォルダ直下の各フォルダの初期化　（ファイルを削除）
		for (int i = 0; i < lstMprocess.Count - 2; i++)
		{
		    string sprocesssFolder = sFolder + lstMprocess[i][5].ToString();
		    DirectoryInfo target = new DirectoryInfo(sprocesssFolder);
		    //ファイル消す
		    foreach (FileInfo file in target.GetFiles())
		    {
			file.Delete();
		    }
		}
		listBox1.Items.Add("ファイル削除完了");
		this.Refresh();	
		
		//プロセスのコピー　unuseフォルダから上の階層へコピー
		for (int i = 0; i < lstMprocess.Count-2 ; i++)
		{
		    string sprocesssFolder = sFolder + lstMprocess[i][5].ToString();
		    //exeの移動
		    string ssourceexeFile = string.Empty;
		    string sDirectFile = string.Empty;
		    if (lstMprocess[i][11].ToString().Equals("StartProc") == true)
		    {
			ssourceexeFile = sprocesssFolder + @"\UnUse\" + lstMprocess[i][11] + @"2.exe";
			sDirectFile = sprocesssFolder + @"\" + lstMprocess[i][11] + @"2.exe";
		    }
		    else
		    {
			ssourceexeFile = sprocesssFolder + @"\UnUse\" + lstMprocess[i][11] + @".exe";
			sDirectFile = sprocesssFolder + @"\" + lstMprocess[i][11] + @".exe";
		    }
		  
		    if (System.IO.File.Exists(ssourceexeFile))
		    {
			
			System.IO.File.Copy(ssourceexeFile, sDirectFile, true);

		    }
		    //iniファイル等の移動
		    for (int j = 0; j < 5; j++)
		    {
			if (String.IsNullOrEmpty(lstMprocess[i][12 + j].ToString()) == false)
			{
			    string ssourceFile = sprocesssFolder + @"\UnUse\" + lstMprocess[i][12 + j];
			    string siniDirectFile = sprocesssFolder + @"\" + lstMprocess[i][12 + j];
			    if (System.IO.File.Exists(ssourceFile))
			    {
				
				System.IO.File.Copy(ssourceFile, siniDirectFile, true);

			    }
			    else
			    {
				MessageBox.Show(ssourceFile + "がみつかりませんでした。");
			    }
			}

		    }
		}
		listBox1.Items.Add("プロセスファイル移動完了");
		this.Refresh();
		
		////テーブル名を初期化　UnUseをつける
		//if (UnUseTableName() == true)
		//{
		//    listBox1.Items.Add("テーブル名初期化完了");
		//}
		//this.Refresh();

		////テーブル名変更　UnUseを削除
		//if (renametable() == true)
		//{
		//    listBox1.Items.Add("テーブル名変更完了");
		//}
		//listBox1.Items.Add("正常終了");
		//listBox1.BackColor = Color.LimeGreen;
	    }
	    catch (Exception ex)
	    {
		listBox1.Items.Add(ex.Message);
		listBox1.Items.Add("異常終了：処理が完了していないため最初からやりなおしてください。");
		listBox1.BackColor = Color.Red;
	    }
	}

	private bool UnUseTableName()
	{
	    bool bRet = false;
	    try
	    {
		//テーブルのリネーム
		for (int i = 0; i < lstMprocess.Count ; i++)
		{

		    for (int j = 19; j < 47; j++)
		    {
			
			if (lstMprocess[i][j].ToString().Equals("M_Process") == true)
			    continue;
			string strsql = "if object_id(\'" + lstMprocess[i][j].ToString() + "\') is not null  exec sp_rename \'" + lstMprocess[i][j].ToString() + "\', \'" + "UnUsed_" + lstMprocess[i][j].ToString() + "\'";
			SqlCommand cmd = new SqlCommand(strsql, oSqlconnection);
			SqlDataReader dr;

			dr = cmd.ExecuteReader();

			dr.Close();
			cmd.Dispose();

		    }

		}




	    }
	    catch 
	    {
		return bRet;
	    }
	    bRet = true;
	    return bRet;
	    
	}

	private bool renametable()
	{
	    bool bRet = false;
	    
	    try
	    {
		//テーブルのリネーム
		for (int i = 0; i < lstMprocess.Count ; i++)
		{
		   
		    for (int j = 19; j < 47; j++)
		    {
			if (iAlarmHisflg == 1)
			{
			    if ((lstMprocess[i][j].ToString().Equals("T_STRAlarm") == true) ||
				(lstMprocess[i][j].ToString().Equals("T_PCSAlarm") == true) ||
				(lstMprocess[i][j].ToString().Equals("T_CATAlarm") == true) ||
				(lstMprocess[i][j].ToString().Equals("T_SystemAlarm") == true) ||
				(lstMprocess[i][j].ToString().Equals("T_ModAlarm") == true))
			    {
				continue;
			    }
			}
			else
			{
			    if (lstMprocess[i][j].ToString().Equals("T_AlarmHis") == true)
			    {
				continue;
			    }
			}
			string strsql = "if object_id(\'UnUsed_" + lstMprocess[i][j].ToString() + "\') is not null  exec sp_rename \'" + "UnUsed_" + lstMprocess[i][j].ToString() + "\', \'" + lstMprocess[i][j].ToString() + "\'";
			SqlCommand cmd = new SqlCommand(strsql, oSqlconnection);
			SqlDataReader dr;

			dr = cmd.ExecuteReader();

			dr.Close();
			cmd.Dispose();
			
		    }

		}
		

	
		
	    }
	    catch 
	    {
		return bRet;
	    }
	    bRet = true;
	    return bRet;
	}



	


	//Assetsディレクトリ以下にあるTestディレクトリを削除
	/// <summary>
	/// 指定したディレクトリとその中身を全て削除する
	/// </summary>
	public static void Delete(string targetDirectoryPath)
	{
	    try
	    {
		if (!Directory.Exists(targetDirectoryPath))
		{
		    return;
		}

		//ディレクトリ以外の全ファイルを削除
		string[] filePaths = Directory.GetFiles(targetDirectoryPath);
		foreach (string filePath in filePaths)
		{
		    File.SetAttributes(filePath, FileAttributes.Normal);
		    File.Delete(filePath);
		}
		System.Threading.Thread.Sleep(10);
		//ディレクトリの中のディレクトリも再帰的に削除
		string[] directoryPaths = Directory.GetDirectories(targetDirectoryPath);
		foreach (string directoryPath in directoryPaths)
		{
		    Delete(directoryPath);
		}
		System.Threading.Thread.Sleep(30);
		//中が空になったらディレクトリ自身も削除
		Directory.Delete(targetDirectoryPath, false);
		//System.Threading.Thread.Sleep(10);
	    }
	    catch (Exception ex)
	    {
		MessageBox.Show(targetDirectoryPath + "  " + ex.ToString());
	    }
	}

	/// <summary>
	/// 表示レポートテーブル取得
	/// </summary>
	/// <returns></returns>
	private bool　RepDispget()
	{
	    bool bRet = false;
	    string strsql = "select * from M_FilePick where ProcessName = 'DISP' or ProcessName = 'REPORT'";
	  
	    try
	    {
		
		SqlCommand cmd = new SqlCommand(strsql, oSqlconnection);
		SqlDataReader rd = cmd.ExecuteReader();

		while (rd.Read())
		{
		    string[] strmprocess = new string[47];
		    for (int i = 11; i < 47; i++)
		    {
			strmprocess[i] = rd[i-11].ToString();
		    }

		    lstMprocess.Add(strmprocess);
		}
		rd.Dispose();
		cmd.Dispose();
	    }
	    catch 
	    {
		return bRet;
	    }
	    bRet = true;
	    return bRet;
	}

	/// <summary>
	/// マスターテーブル取得
	/// </summary>
	/// <returns></returns>
	private bool masterget()
	{
	    bool bRet = false;
	    string strsql = "select * from M_Process inner join M_FilePick "
			    + "on M_Process.Process=M_FilePick.ProcessName "
			    + " where M_Process.Enable=1 order by ProcessID";
	    try
	    {
		lstMprocess.Clear();
		SqlCommand cmd = new SqlCommand(strsql, oSqlconnection);
		SqlDataReader rd = cmd.ExecuteReader();

		while (rd.Read())
		{
		    string[] strmprocess = new string[rd.FieldCount - 1];
		    for (int i = 0; i < rd.FieldCount - 1; i++)
		    {
			strmprocess[i] = rd[i].ToString();
		    }

		    lstMprocess.Add(strmprocess);
		}
		rd.Dispose();
		cmd.Dispose();
	    }
	    catch 
	    {
		return bRet;
	    }
	    bRet = true;
	    return bRet;
	}
	/// <summary>
	/// マスターテーブル取得
	/// </summary>
	/// <returns></returns>
	private bool masterIniget()
	{
	    bool bRet = false;

	     string strsql = "select * from M_IniFile inner join M_Process "
			    + "on M_Process.Process=M_IniFile.ProcessName "
			    + " where M_Process.Enable=1 order by ProcessID";
	    try
	    {
		lstMini.Clear();
		SqlCommand cmd = new SqlCommand(strsql, oSqlconnection);
		SqlDataReader rd = cmd.ExecuteReader();

		while (rd.Read())
		{
		    string[] strmprocess = new string[rd.FieldCount - 1];
		    for (int i = 0; i < rd.FieldCount - 1; i++)
		    {
			strmprocess[i] = rd[i].ToString();
		    }

		    lstMini.Add(strmprocess);
		}
		rd.Dispose();
		cmd.Dispose();
	    }catch
	    {
		return bRet;
	    }

	    bRet = true;
	    return bRet;
	}

	private void button2_Click(object sender, EventArgs e)
	{
	    try
	    {
		

		//テーブル名変更　UnUseを削除
		if (renametable() == true)
		{
		    listBox1.Items.Add("テーブル名変更完了");
		}
		
		
	    }
	    catch (Exception ex)
	    {
		MessageBox.Show(ex.ToString());
	    }
	}

	private void button3_Click(object sender, EventArgs e)
	{
	    try
	    {
		listBox1.Items.Clear();
		lstMprocess.Clear();
		lstMini.Clear();
		//DataBaseが閉じている場合、オープンする。
		if (bOpenDatabaseflg == false)
		{
		    if (OpenDatabase() == true)
		    {
			bOpenDatabaseflg = true;
		    }
		    else
		    {
			listBox1.Items.Add("データベースの接続に失敗しました。接続情報および、ＤＢが存在することを確認してください。");
			return;
		    }
		}

		//マスター取得
		if (masterget() == false)
		{
		    listBox1.Items.Add("M_Processテーブル読込失敗");
		    return;
		}
		listBox1.Items.Add("M_Processテーブル読込完了");

		if (masterIniget() == false)
		{
		    listBox1.Items.Add("M_IniFileテーブル読込失敗");
		    return;
		}

		//表示用、レポート用テーブルの取得
		if (RepDispget() == false)
		{
		    listBox1.Items.Add("表示、レポートテーブル読込失敗");
		    return;
		}
		listBox1.Items.Add("表示、レポートテーブル読込成功");
		this.Refresh();
	    }
	    catch (Exception ex)
	    {
		MessageBox.Show(ex.ToString());
	    }

	    timer1.Enabled = true;
	}

	private void button4_Click(object sender, EventArgs e)
	{
	    try
	    {
		//テーブル名を初期化　UnUseをつける
		if (UnUseTableName() == true)
		{
		    listBox1.Items.Add("テーブル名初期化完了");
		}
		this.Refresh();
	    }
	    catch (Exception ex)
	    {
		MessageBox.Show(ex.ToString());
	    }
	}

	private void button5_Click(object sender, EventArgs e)
	{
	    try{

		string inputText;

		inputText = Microsoft.VisualBasic.Interaction.InputBox(
		    "システムＩＤを入力してください。", "システムＩＤ iniファイル書込み", "9999", 200, 100);
	
		for (int i = 0; i < lstMini.Count; i++)
		{
		    string StproccesfldPass = stDrive + "process\\" + lstMini[i][(int)enminifle.FolderName].ToString() + "\\" + lstMini[i][(int)enminifle.IniFileName].ToString();
		    if (File.Exists(StproccesfldPass))
		    {

			IniFileHandler.IniFilePath = StproccesfldPass;
			IniFileHandler.WriteString(lstMini[i][(int)enminifle.SectionName].ToString(), lstMini[i][(int)enminifle.ItmeName], inputText);
		    }
		}

	    }catch(Exception ex)
	    {
		MessageBox.Show(ex.ToString());
		return;
	    }
	    listBox1.Items.Add("システムＩＤ書込み完了");
	    listBox1.Items.Add("正常終了");
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
	    try
	    {
		timer1.Enabled = false;
		this.SelectNextControl(this.button1, true, true, true, true);
		button2.PerformClick();
		this.SelectNextControl(this.button2, true, true, true, true);
		button3.PerformClick();
		this.SelectNextControl(this.button3, true, true, true, true);
		button4.PerformClick();
		this.SelectNextControl(this.button4, true, true, true, true);
		button5.PerformClick();
		this.SelectNextControl(this.button5, true, true, true, true);
	    }
	    catch(Exception ex)
	    {
		listBox1.BackColor = Color.Red;
		MessageBox.Show("異常終了"+ ex.ToString()) ;
	    }
	    listBox1.BackColor = Color.LimeGreen;
	    
	}
    }



    
}
