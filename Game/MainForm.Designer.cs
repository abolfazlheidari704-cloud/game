namespace Game
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label helpLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label livesLabel;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Panel boardPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.helpLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.livesLabel = new System.Windows.Forms.Label();
            this.messageLabel = new System.Windows.Forms.Label();
            this.restartButton = new System.Windows.Forms.Button();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(12, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(370, 23);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "بازی مبتدی - فقط با کیبورد (جهت‌ها)";
            // 
            // helpLabel
            // 
            this.helpLabel.AutoSize = true;
            this.helpLabel.Location = new System.Drawing.Point(13, 43);
            this.helpLabel.Name = "helpLabel";
            this.helpLabel.Size = new System.Drawing.Size(400, 13);
            this.helpLabel.TabIndex = 1;
            this.helpLabel.Text = "با کلیدهای Arrow حرکت کن، ستاره را بگیر و از بمب دوری کن. 5 امتیاز = برد";
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.scoreLabel.Location = new System.Drawing.Point(13, 73);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(69, 17);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.Text = "امتیاز: 0";
            // 
            // livesLabel
            // 
            this.livesLabel.AutoSize = true;
            this.livesLabel.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.livesLabel.Location = new System.Drawing.Point(120, 73);
            this.livesLabel.Name = "livesLabel";
            this.livesLabel.Size = new System.Drawing.Size(49, 17);
            this.livesLabel.TabIndex = 3;
            this.livesLabel.Text = "جان: 3";
            // 
            // messageLabel
            // 
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.messageLabel.Location = new System.Drawing.Point(13, 101);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(281, 14);
            this.messageLabel.TabIndex = 4;
            this.messageLabel.Text = "برای شروع یکی از کلیدهای جهت‌دار را بزن.";
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(441, 70);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(155, 29);
            this.restartButton.TabIndex = 5;
            this.restartButton.Text = "شروع دوباره";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // boardPanel
            // 
            this.boardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boardPanel.Location = new System.Drawing.Point(16, 130);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(576, 576);
            this.boardPanel.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 721);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.livesLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.helpLabel);
            this.Controls.Add(this.titleLabel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game - Beginner";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
