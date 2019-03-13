using System;
using System.Windows.Forms;

namespace Task1
{
    partial class MyForm
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
            this.btnPlus1 = new System.Windows.Forms.Button();
            this.btnMult2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.lblTxtTry = new System.Windows.Forms.Label();
            this.lblTryCount = new System.Windows.Forms.Label();
            this.lblTxtNumber = new System.Windows.Forms.Label();
            this.lblNumberTask = new System.Windows.Forms.Label();
            this.lblCurentNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPlus1
            // 
            this.btnPlus1.Location = new System.Drawing.Point(257, 12);
            this.btnPlus1.Name = "btnPlus1";
            this.btnPlus1.Size = new System.Drawing.Size(75, 23);
            this.btnPlus1.TabIndex = 0;
            this.btnPlus1.Text = "+1";
            this.btnPlus1.UseVisualStyleBackColor = true;
            this.btnPlus1.Click += new System.EventHandler(this.btnPlus1_Click);
            // 
            // btnMult2
            // 
            this.btnMult2.Location = new System.Drawing.Point(257, 41);
            this.btnMult2.Name = "btnMult2";
            this.btnMult2.Size = new System.Drawing.Size(75, 23);
            this.btnMult2.TabIndex = 1;
            this.btnMult2.Text = "x2";
            this.btnMult2.UseVisualStyleBackColor = true;
            this.btnMult2.Click += new System.EventHandler(this.btnMult2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(257, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Start";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTxtTry
            // 
            this.lblTxtTry.AutoSize = true;
            this.lblTxtTry.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTxtTry.Location = new System.Drawing.Point(12, 73);
            this.lblTxtTry.Name = "lblTxtTry";
            this.lblTxtTry.Size = new System.Drawing.Size(97, 20);
            this.lblTxtTry.TabIndex = 3;
            this.lblTxtTry.Text = "Шаг номер: ";
            // 
            // lblTryCount
            // 
            this.lblTryCount.AutoSize = true;
            this.lblTryCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTryCount.Location = new System.Drawing.Point(104, 75);
            this.lblTryCount.Name = "lblTryCount";
            this.lblTryCount.Size = new System.Drawing.Size(18, 20);
            this.lblTryCount.TabIndex = 4;
            this.lblTryCount.Text = "0";
            // 
            // lblTxtNumber
            // 
            this.lblTxtNumber.AutoSize = true;
            this.lblTxtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTxtNumber.Location = new System.Drawing.Point(12, 13);
            this.lblTxtNumber.Name = "lblTxtNumber";
            this.lblTxtNumber.Size = new System.Drawing.Size(140, 20);
            this.lblTxtNumber.TabIndex = 5;
            this.lblTxtNumber.Text = "Получите число: ";
            // 
            // lblNumberTask
            // 
            this.lblNumberTask.AutoSize = true;
            this.lblNumberTask.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.lblNumberTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNumberTask.Location = new System.Drawing.Point(147, 14);
            this.lblNumberTask.Name = "lblNumberTask";
            this.lblNumberTask.Size = new System.Drawing.Size(18, 20);
            this.lblNumberTask.TabIndex = 6;
            this.lblNumberTask.Text = "0";
            // 
            // lblCurentNumber
            // 
            this.lblCurentNumber.AutoSize = true;
            this.lblCurentNumber.BackColor = System.Drawing.Color.Transparent;
            this.lblCurentNumber.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.lblCurentNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCurentNumber.Location = new System.Drawing.Point(147, 46);
            this.lblCurentNumber.Name = "lblCurentNumber";
            this.lblCurentNumber.Size = new System.Drawing.Size(18, 20);
            this.lblCurentNumber.TabIndex = 8;
            this.lblCurentNumber.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Текущее число: ";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 106);
            this.Controls.Add(this.lblCurentNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblNumberTask);
            this.Controls.Add(this.lblTxtNumber);
            this.Controls.Add(this.lblTryCount);
            this.Controls.Add(this.lblTxtTry);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnMult2);
            this.Controls.Add(this.btnPlus1);
            this.Name = "MyForm";
            this.Text = "Удвоитель";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnPlus1;
        private Button btnMult2;
        private Button btnReset;
        private Label lblTxtTry;
        private Label lblTryCount;
        private Label lblTxtNumber;
        private Label lblNumberTask;
        private Label lblCurentNumber;
        private Label label2;
    }
}

