namespace FruitNinjaWinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            speedLabel = new Label();
            pointsLabel = new Label();
            pointsChangeLabel = new Label();
            restartButton = new Button();
            SuspendLayout();
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.Location = new Point(12, 9);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(50, 15);
            speedLabel.TabIndex = 0;
            speedLabel.Text = "speed: 1";
            // 
            // pointsLabel
            // 
            pointsLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pointsLabel.AutoSize = true;
            pointsLabel.Location = new Point(728, 13);
            pointsLabel.Name = "pointsLabel";
            pointsLabel.Size = new Size(13, 15);
            pointsLabel.TabIndex = 1;
            pointsLabel.Text = "0";
            // 
            // pointsChangeLabel
            // 
            pointsChangeLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pointsChangeLabel.AutoSize = true;
            pointsChangeLabel.ForeColor = Color.Red;
            pointsChangeLabel.Location = new Point(763, 13);
            pointsChangeLabel.Name = "pointsChangeLabel";
            pointsChangeLabel.Size = new Size(0, 15);
            pointsChangeLabel.TabIndex = 1;
            // 
            // restartButton
            // 
            restartButton.Location = new Point(12, 38);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(111, 39);
            restartButton.TabIndex = 2;
            restartButton.Text = "restart";
            restartButton.UseVisualStyleBackColor = true;
            restartButton.Visible = false;
            restartButton.Click += restartButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(restartButton);
            Controls.Add(pointsChangeLabel);
            Controls.Add(pointsLabel);
            Controls.Add(speedLabel);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FruitNinja";
            MouseMove += MainForm_MouseMove;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label speedLabel;
        private Label pointsLabel;
        private Label pointsChangeLabel;
        private Button restartButton;
    }
}
