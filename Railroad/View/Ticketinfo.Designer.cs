namespace Railroad.View
{
    partial class Ticketinfo
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
            this.ticketNo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.memberno = new System.Windows.Forms.Label();
            this.membername = new System.Windows.Forms.Label();
            this.trainno = new System.Windows.Forms.Label();
            this.departure = new System.Windows.Forms.Label();
            this.destination = new System.Windows.Forms.Label();
            this.starttime = new System.Windows.Forms.Label();
            this.stoptime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ticketNo
            // 
            this.ticketNo.AutoSize = true;
            this.ticketNo.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ticketNo.Location = new System.Drawing.Point(302, 13);
            this.ticketNo.Name = "ticketNo";
            this.ticketNo.Size = new System.Drawing.Size(45, 15);
            this.ticketNo.TabIndex = 0;
            this.ticketNo.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(150, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "출발";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(340, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "도착";
            // 
            // memberno
            // 
            this.memberno.AutoSize = true;
            this.memberno.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.memberno.Location = new System.Drawing.Point(5, 9);
            this.memberno.Name = "memberno";
            this.memberno.Size = new System.Drawing.Size(45, 15);
            this.memberno.TabIndex = 0;
            this.memberno.Text = "label1";
            // 
            // membername
            // 
            this.membername.AutoSize = true;
            this.membername.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.membername.Location = new System.Drawing.Point(480, 9);
            this.membername.Name = "membername";
            this.membername.Size = new System.Drawing.Size(45, 15);
            this.membername.TabIndex = 0;
            this.membername.Text = "label1";
            this.membername.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // trainno
            // 
            this.trainno.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.trainno.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.trainno.Location = new System.Drawing.Point(392, 131);
            this.trainno.Name = "trainno";
            this.trainno.Size = new System.Drawing.Size(133, 15);
            this.trainno.TabIndex = 0;
            this.trainno.Text = "label1";
            this.trainno.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // departure
            // 
            this.departure.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.departure.Location = new System.Drawing.Point(127, 84);
            this.departure.Name = "departure";
            this.departure.Size = new System.Drawing.Size(83, 15);
            this.departure.TabIndex = 0;
            this.departure.Text = "label1";
            this.departure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // destination
            // 
            this.destination.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.destination.Location = new System.Drawing.Point(317, 84);
            this.destination.Name = "destination";
            this.destination.Size = new System.Drawing.Size(86, 15);
            this.destination.TabIndex = 0;
            this.destination.Text = "label1";
            this.destination.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // starttime
            // 
            this.starttime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.starttime.Location = new System.Drawing.Point(89, 113);
            this.starttime.Name = "starttime";
            this.starttime.Size = new System.Drawing.Size(159, 15);
            this.starttime.TabIndex = 0;
            this.starttime.Text = "label1";
            this.starttime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stoptime
            // 
            this.stoptime.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.stoptime.Location = new System.Drawing.Point(274, 113);
            this.stoptime.Name = "stoptime";
            this.stoptime.Size = new System.Drawing.Size(169, 15);
            this.stoptime.TabIndex = 0;
            this.stoptime.Text = "label1";
            this.stoptime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(214, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Railroad";
            // 
            // Ticketinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.membername);
            this.Controls.Add(this.memberno);
            this.Controls.Add(this.trainno);
            this.Controls.Add(this.destination);
            this.Controls.Add(this.stoptime);
            this.Controls.Add(this.starttime);
            this.Controls.Add(this.departure);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ticketNo);
            this.Name = "Ticketinfo";
            this.Size = new System.Drawing.Size(536, 155);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ticketNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label memberno;
        private System.Windows.Forms.Label membername;
        private System.Windows.Forms.Label trainno;
        private System.Windows.Forms.Label departure;
        private System.Windows.Forms.Label destination;
        private System.Windows.Forms.Label starttime;
        private System.Windows.Forms.Label stoptime;
        private System.Windows.Forms.Label label3;
    }
}
