﻿namespace Railroad.View
{
    partial class Traininfo
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

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ticketbtn = new System.Windows.Forms.Button();
            this.trainNo = new System.Windows.Forms.Label();
            this.departure = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(27, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "기차번호";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(153, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "출발";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(263, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "도착";
            // 
            // ticketbtn
            // 
            this.ticketbtn.Location = new System.Drawing.Point(357, 13);
            this.ticketbtn.Name = "ticketbtn";
            this.ticketbtn.Size = new System.Drawing.Size(108, 68);
            this.ticketbtn.TabIndex = 1;
            this.ticketbtn.Text = "예매하기";
            this.ticketbtn.UseVisualStyleBackColor = true;
            // 
            // trainNo
            // 
            this.trainNo.AutoSize = true;
            this.trainNo.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.trainNo.Location = new System.Drawing.Point(37, 51);
            this.trainNo.Name = "trainNo";
            this.trainNo.Size = new System.Drawing.Size(43, 15);
            this.trainNo.TabIndex = 2;
            this.trainNo.Text = "label4";
            // 
            // departure
            // 
            this.departure.AutoSize = true;
            this.departure.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.departure.Location = new System.Drawing.Point(116, 49);
            this.departure.Name = "departure";
            this.departure.Size = new System.Drawing.Size(41, 14);
            this.departure.TabIndex = 2;
            this.departure.Text = "label4";
            this.departure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.departure.Click += new System.EventHandler(this.departure_Click);
            // 
            // destination
            // 
            this.destination.AutoSize = true;
            this.destination.Font = new System.Drawing.Font("나눔고딕", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destination.Location = new System.Drawing.Point(227, 48);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(41, 14);
            this.destination.TabIndex = 2;
            this.destination.Text = "label4";
            this.destination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Traininfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.destination);
            this.Controls.Add(this.departure);
            this.Controls.Add(this.trainNo);
            this.Controls.Add(this.ticketbtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Traininfo";
            this.Size = new System.Drawing.Size(483, 93);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button ticketbtn;
        private System.Windows.Forms.Label trainNo;
        private System.Windows.Forms.Label departure;
        private System.Windows.Forms.Label destination;
    }
}
