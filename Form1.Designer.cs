namespace OMR_scanner
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.mPictureBox = new System.Windows.Forms.PictureBox();
            this.answerbox = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.answer = new System.Windows.Forms.RichTextBox();
            this.point_ = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(116, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(293, 64);
            this.button1.TabIndex = 0;
            this.button1.Text = "파일 불러오기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(761, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "유의 사항: 이 프로그램은 베타 버전이므로(다른 OMR을 넣게 되면 작동을 안 할 수 있습니다.)\r\n 반드시 동봉한 OMR을 프린트하여 답안을 작" +
    "성하십시오.\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // mPictureBox
            // 
            this.mPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mPictureBox.Location = new System.Drawing.Point(12, 304);
            this.mPictureBox.Name = "mPictureBox";
            this.mPictureBox.Size = new System.Drawing.Size(1000, 400);
            this.mPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mPictureBox.TabIndex = 2;
            this.mPictureBox.TabStop = false;
            // 
            // answerbox
            // 
            this.answerbox.Location = new System.Drawing.Point(943, 12);
            this.answerbox.Name = "answerbox";
            this.answerbox.Size = new System.Drawing.Size(227, 243);
            this.answerbox.TabIndex = 3;
            this.answerbox.Text = "이곳에 답안이 표시됩니다.";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(789, 261);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(442, 22);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "점수를 동일시하여 채점(ex:4문제면 1문제당 25점)\r\n";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // answer
            // 
            this.answer.Location = new System.Drawing.Point(1176, 12);
            this.answer.Name = "answer";
            this.answer.Size = new System.Drawing.Size(227, 243);
            this.answer.TabIndex = 5;
            this.answer.Text = "정답을 입력하십시오.(\",\"로 구분)";
            this.answer.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // point_
            // 
            this.point_.Location = new System.Drawing.Point(1400, 12);
            this.point_.Name = "point_";
            this.point_.Size = new System.Drawing.Size(227, 243);
            this.point_.TabIndex = 6;
            this.point_.Text = "점수를 입력하십시오.(\",\"로 구분)";
            this.point_.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(493, 169);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 63);
            this.button2.TabIndex = 7;
            this.button2.Text = "채점";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(651, 188);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(162, 28);
            this.result.TabIndex = 8;
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1639, 1050);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.point_);
            this.Controls.Add(this.answer);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.answerbox);
            this.Controls.Add(this.mPictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "OMR master";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox mPictureBox;
        private System.Windows.Forms.RichTextBox answerbox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RichTextBox answer;
        private System.Windows.Forms.RichTextBox point_;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Timer timer3;
    }
}

