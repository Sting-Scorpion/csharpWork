﻿namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.plusbutton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.minusbutton = new System.Windows.Forms.Button();
            this.multiplebutton = new System.Windows.Forms.Button();
            this.dividebutton = new System.Windows.Forms.Button();
            this.powerbutton = new System.Windows.Forms.Button();
            this.equalbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // plusbutton
            // 
            this.plusbutton.Location = new System.Drawing.Point(95, 142);
            this.plusbutton.Name = "plusbutton";
            this.plusbutton.Size = new System.Drawing.Size(64, 64);
            this.plusbutton.TabIndex = 0;
            this.plusbutton.Text = "+";
            this.plusbutton.UseVisualStyleBackColor = true;
            this.plusbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(95, 69);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(94, 25);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(243, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(94, 25);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(448, 69);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(125, 25);
            this.textBox3.TabIndex = 3;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // minusbutton
            // 
            this.minusbutton.Location = new System.Drawing.Point(216, 142);
            this.minusbutton.Name = "minusbutton";
            this.minusbutton.Size = new System.Drawing.Size(64, 64);
            this.minusbutton.TabIndex = 4;
            this.minusbutton.Text = "-";
            this.minusbutton.UseVisualStyleBackColor = true;
            this.minusbutton.Click += new System.EventHandler(this.minusbutton_Click);
            // 
            // multiplebutton
            // 
            this.multiplebutton.Location = new System.Drawing.Point(334, 142);
            this.multiplebutton.Name = "multiplebutton";
            this.multiplebutton.Size = new System.Drawing.Size(64, 64);
            this.multiplebutton.TabIndex = 5;
            this.multiplebutton.Text = "*";
            this.multiplebutton.UseVisualStyleBackColor = true;
            this.multiplebutton.Click += new System.EventHandler(this.multiplebutton_Click);
            // 
            // dividebutton
            // 
            this.dividebutton.Location = new System.Drawing.Point(465, 142);
            this.dividebutton.Name = "dividebutton";
            this.dividebutton.Size = new System.Drawing.Size(64, 64);
            this.dividebutton.TabIndex = 6;
            this.dividebutton.Text = "/";
            this.dividebutton.UseVisualStyleBackColor = true;
            this.dividebutton.Click += new System.EventHandler(this.dividebutton_Click);
            // 
            // powerbutton
            // 
            this.powerbutton.Location = new System.Drawing.Point(587, 142);
            this.powerbutton.Name = "powerbutton";
            this.powerbutton.Size = new System.Drawing.Size(64, 64);
            this.powerbutton.TabIndex = 7;
            this.powerbutton.Text = "^";
            this.powerbutton.UseVisualStyleBackColor = true;
            this.powerbutton.Click += new System.EventHandler(this.powerbutton_Click);
            // 
            // equalbutton
            // 
            this.equalbutton.Location = new System.Drawing.Point(148, 296);
            this.equalbutton.Name = "equalbutton";
            this.equalbutton.Size = new System.Drawing.Size(64, 64);
            this.equalbutton.TabIndex = 8;
            this.equalbutton.Text = "=";
            this.equalbutton.UseVisualStyleBackColor = true;
            this.equalbutton.Click += new System.EventHandler(this.equalbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.equalbutton);
            this.Controls.Add(this.powerbutton);
            this.Controls.Add(this.dividebutton);
            this.Controls.Add(this.multiplebutton);
            this.Controls.Add(this.minusbutton);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.plusbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button plusbutton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button minusbutton;
        private System.Windows.Forms.Button multiplebutton;
        private System.Windows.Forms.Button dividebutton;
        private System.Windows.Forms.Button powerbutton;
        private System.Windows.Forms.Button equalbutton;
    }
}

