namespace ProcessPick
{
    partial class Form1
    {
	/// <summary>
	/// 必要なデザイナー変数です。
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// 使用中のリソースをすべてクリーンアップします。
	/// </summary>
	/// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
	protected override void Dispose(bool disposing)
	{
	    if (disposing && (components != null))
	    {
		components.Dispose();
	    }
	    base.Dispose(disposing);
	}

	#region Windows フォーム デザイナーで生成されたコード

	/// <summary>
	/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
	/// コード エディターで変更しないでください。
	/// </summary>
	private void InitializeComponent()
	{
	    this.components = new System.ComponentModel.Container();
	    this.button2 = new System.Windows.Forms.Button();
	    this.listBox1 = new System.Windows.Forms.ListBox();
	    this.txtServer = new System.Windows.Forms.TextBox();
	    this.txtDB = new System.Windows.Forms.TextBox();
	    this.txtUID = new System.Windows.Forms.TextBox();
	    this.txtPass = new System.Windows.Forms.TextBox();
	    this.label1 = new System.Windows.Forms.Label();
	    this.label2 = new System.Windows.Forms.Label();
	    this.label3 = new System.Windows.Forms.Label();
	    this.label4 = new System.Windows.Forms.Label();
	    this.button4 = new System.Windows.Forms.Button();
	    this.button1 = new System.Windows.Forms.Button();
	    this.button3 = new System.Windows.Forms.Button();
	    this.button5 = new System.Windows.Forms.Button();
	    this.timer1 = new System.Windows.Forms.Timer(this.components);
	    this.SuspendLayout();
	    // 
	    // button2
	    // 
	    this.button2.Location = new System.Drawing.Point(14, 314);
	    this.button2.Name = "button2";
	    this.button2.Size = new System.Drawing.Size(94, 23);
	    this.button2.TabIndex = 1;
	    this.button2.Text = "プロセスコピー";
	    this.button2.UseVisualStyleBackColor = true;
	    this.button2.Click += new System.EventHandler(this.button1_Click);
	    // 
	    // listBox1
	    // 
	    this.listBox1.FormattingEnabled = true;
	    this.listBox1.ItemHeight = 12;
	    this.listBox1.Location = new System.Drawing.Point(212, 12);
	    this.listBox1.Name = "listBox1";
	    this.listBox1.Size = new System.Drawing.Size(436, 412);
	    this.listBox1.TabIndex = 1;
	    this.listBox1.TabStop = false;
	    // 
	    // txtServer
	    // 
	    this.txtServer.Location = new System.Drawing.Point(79, 12);
	    this.txtServer.Name = "txtServer";
	    this.txtServer.Size = new System.Drawing.Size(114, 19);
	    this.txtServer.TabIndex = 2;
	    this.txtServer.TabStop = false;
	    this.txtServer.Text = "(local)";
	    // 
	    // txtDB
	    // 
	    this.txtDB.Location = new System.Drawing.Point(79, 37);
	    this.txtDB.Name = "txtDB";
	    this.txtDB.Size = new System.Drawing.Size(114, 19);
	    this.txtDB.TabIndex = 3;
	    this.txtDB.TabStop = false;
	    this.txtDB.Text = "ONAMBA";
	    // 
	    // txtUID
	    // 
	    this.txtUID.Location = new System.Drawing.Point(79, 62);
	    this.txtUID.Name = "txtUID";
	    this.txtUID.Size = new System.Drawing.Size(114, 19);
	    this.txtUID.TabIndex = 4;
	    this.txtUID.TabStop = false;
	    this.txtUID.Text = "ONAMBA";
	    // 
	    // txtPass
	    // 
	    this.txtPass.Location = new System.Drawing.Point(79, 87);
	    this.txtPass.Name = "txtPass";
	    this.txtPass.Size = new System.Drawing.Size(114, 19);
	    this.txtPass.TabIndex = 5;
	    this.txtPass.TabStop = false;
	    this.txtPass.Text = "ONAMBAONAMBA";
	    // 
	    // label1
	    // 
	    this.label1.AutoSize = true;
	    this.label1.Location = new System.Drawing.Point(12, 12);
	    this.label1.Name = "label1";
	    this.label1.Size = new System.Drawing.Size(63, 12);
	    this.label1.TabIndex = 6;
	    this.label1.Text = "サーバー名：";
	    // 
	    // label2
	    // 
	    this.label2.AutoSize = true;
	    this.label2.Location = new System.Drawing.Point(12, 40);
	    this.label2.Name = "label2";
	    this.label2.Size = new System.Drawing.Size(41, 12);
	    this.label2.TabIndex = 7;
	    this.label2.Text = "ＤＢ名：";
	    // 
	    // label3
	    // 
	    this.label3.AutoSize = true;
	    this.label3.Location = new System.Drawing.Point(12, 65);
	    this.label3.Name = "label3";
	    this.label3.Size = new System.Drawing.Size(51, 12);
	    this.label3.TabIndex = 8;
	    this.label3.Text = "ユーザー：";
	    // 
	    // label4
	    // 
	    this.label4.AutoSize = true;
	    this.label4.Location = new System.Drawing.Point(12, 90);
	    this.label4.Name = "label4";
	    this.label4.Size = new System.Drawing.Size(30, 12);
	    this.label4.TabIndex = 9;
	    this.label4.Text = "パス：";
	    // 
	    // button4
	    // 
	    this.button4.Location = new System.Drawing.Point(14, 372);
	    this.button4.Name = "button4";
	    this.button4.Size = new System.Drawing.Size(94, 23);
	    this.button4.TabIndex = 3;
	    this.button4.Text = "テーブルリネーム";
	    this.button4.UseVisualStyleBackColor = true;
	    this.button4.Click += new System.EventHandler(this.button2_Click);
	    // 
	    // button1
	    // 
	    this.button1.Location = new System.Drawing.Point(14, 285);
	    this.button1.Name = "button1";
	    this.button1.Size = new System.Drawing.Size(94, 23);
	    this.button1.TabIndex = 0;
	    this.button1.Text = "マスター読込";
	    this.button1.UseVisualStyleBackColor = true;
	    this.button1.Click += new System.EventHandler(this.button3_Click);
	    // 
	    // button3
	    // 
	    this.button3.Location = new System.Drawing.Point(14, 343);
	    this.button3.Name = "button3";
	    this.button3.Size = new System.Drawing.Size(94, 23);
	    this.button3.TabIndex = 2;
	    this.button3.Text = "テーブル初期化";
	    this.button3.UseVisualStyleBackColor = true;
	    this.button3.Click += new System.EventHandler(this.button4_Click);
	    // 
	    // button5
	    // 
	    this.button5.Location = new System.Drawing.Point(14, 401);
	    this.button5.Name = "button5";
	    this.button5.Size = new System.Drawing.Size(94, 23);
	    this.button5.TabIndex = 4;
	    this.button5.Text = "iniファイル書込";
	    this.button5.UseVisualStyleBackColor = true;
	    this.button5.Click += new System.EventHandler(this.button5_Click);
	    // 
	    // timer1
	    // 
	    this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
	    // 
	    // Form1
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(662, 440);
	    this.Controls.Add(this.button5);
	    this.Controls.Add(this.button3);
	    this.Controls.Add(this.button1);
	    this.Controls.Add(this.button4);
	    this.Controls.Add(this.label4);
	    this.Controls.Add(this.label3);
	    this.Controls.Add(this.label2);
	    this.Controls.Add(this.label1);
	    this.Controls.Add(this.txtPass);
	    this.Controls.Add(this.txtUID);
	    this.Controls.Add(this.txtDB);
	    this.Controls.Add(this.txtServer);
	    this.Controls.Add(this.listBox1);
	    this.Controls.Add(this.button2);
	    this.Name = "Form1";
	    this.Text = "Form1";
	    this.Load += new System.EventHandler(this.Form1_Load);
	    this.ResumeLayout(false);
	    this.PerformLayout();

	}

	#endregion

	private System.Windows.Forms.Button button2;
	private System.Windows.Forms.ListBox listBox1;
	private System.Windows.Forms.TextBox txtServer;
	private System.Windows.Forms.TextBox txtDB;
	private System.Windows.Forms.TextBox txtUID;
	private System.Windows.Forms.TextBox txtPass;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Button button4;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Button button3;
	private System.Windows.Forms.Button button5;
	private System.Windows.Forms.Timer timer1;
    }
}

