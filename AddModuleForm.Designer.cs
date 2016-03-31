namespace GradePerformancePredictorApplication
{
    partial class AddModuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ModuleLabel = new System.Windows.Forms.Label();
            this.ModuleCode = new System.Windows.Forms.Label();
            this.AssessmentsLabel = new System.Windows.Forms.Label();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.ModuleTextBox = new System.Windows.Forms.TextBox();
            this.ModuleCodeTextBox = new System.Windows.Forms.TextBox();
            this.CreditTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(274, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Add a Module";
            // 
            // ModuleLabel
            // 
            this.ModuleLabel.AutoSize = true;
            this.ModuleLabel.Location = new System.Drawing.Point(44, 91);
            this.ModuleLabel.Name = "ModuleLabel";
            this.ModuleLabel.Size = new System.Drawing.Size(42, 13);
            this.ModuleLabel.TabIndex = 1;
            this.ModuleLabel.Text = "Module";
            // 
            // ModuleCode
            // 
            this.ModuleCode.AutoSize = true;
            this.ModuleCode.Location = new System.Drawing.Point(44, 125);
            this.ModuleCode.Name = "ModuleCode";
            this.ModuleCode.Size = new System.Drawing.Size(70, 13);
            this.ModuleCode.TabIndex = 2;
            this.ModuleCode.Text = "Module Code";
            // 
            // AssessmentsLabel
            // 
            this.AssessmentsLabel.AutoSize = true;
            this.AssessmentsLabel.Location = new System.Drawing.Point(497, 91);
            this.AssessmentsLabel.Name = "AssessmentsLabel";
            this.AssessmentsLabel.Size = new System.Drawing.Size(100, 13);
            this.AssessmentsLabel.TabIndex = 3;
            this.AssessmentsLabel.Text = "Assessment Pattern";
            // 
            // CreditLabel
            // 
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.Location = new System.Drawing.Point(44, 160);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(64, 13);
            this.CreditLabel.TabIndex = 4;
            this.CreditLabel.Text = "Credit Value";
            // 
            // ModuleTextBox
            // 
            this.ModuleTextBox.Location = new System.Drawing.Point(159, 91);
            this.ModuleTextBox.Name = "ModuleTextBox";
            this.ModuleTextBox.Size = new System.Drawing.Size(100, 20);
            this.ModuleTextBox.TabIndex = 5;
            // 
            // ModuleCodeTextBox
            // 
            this.ModuleCodeTextBox.Location = new System.Drawing.Point(159, 125);
            this.ModuleCodeTextBox.Name = "ModuleCodeTextBox";
            this.ModuleCodeTextBox.Size = new System.Drawing.Size(100, 20);
            this.ModuleCodeTextBox.TabIndex = 6;
            // 
            // CreditTextBox
            // 
            this.CreditTextBox.Location = new System.Drawing.Point(159, 157);
            this.CreditTextBox.Name = "CreditTextBox";
            this.CreditTextBox.Size = new System.Drawing.Size(100, 20);
            this.CreditTextBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(44, 198);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "No. of Assessments";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(125, 251);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 22;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(484, 251);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 23;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(159, 198);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 28;
            // 
            // AddModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 385);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CreditTextBox);
            this.Controls.Add(this.ModuleCodeTextBox);
            this.Controls.Add(this.ModuleTextBox);
            this.Controls.Add(this.CreditLabel);
            this.Controls.Add(this.AssessmentsLabel);
            this.Controls.Add(this.ModuleCode);
            this.Controls.Add(this.ModuleLabel);
            this.Controls.Add(this.label1);
            this.Name = "AddModuleForm";
            this.Text = "AddModuleForm";
            this.Load += new System.EventHandler(this.AddModuleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ModuleLabel;
        private System.Windows.Forms.Label ModuleCode;
        private System.Windows.Forms.Label AssessmentsLabel;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.TextBox ModuleTextBox;
        private System.Windows.Forms.TextBox ModuleCodeTextBox;
        private System.Windows.Forms.TextBox CreditTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}