using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;



namespace test
{
    
    public partial class cheatmenu : Form
    {
        static string processName = "SCP - Containment Breach";

        IntPtr baseAddress;
        int mainAddress;
        int Offset98;
        int Godmode;
        int Noclip;
        int InfStam;
        int InfBlink;
        int Notarget;
        int Debughud;
        float Camerafog;
        int WireframeOffset1;
        int Wireframe;
        float Bloodloss;
        float SCP008State;
        float Injuries;
        int RDC;

        int PlayerOffset1;
        int PlayerOffset2;
        float PlayerX;
        float PlayerY;
        float PlayerZ;


        public cheatmenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer3.Start();
        }
        

        private void GodmodeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory god = new VAMemory(processName);

            if (GodmodeCheckBox.Checked)
                god.WriteInt32((IntPtr)Offset98 + 0x5b0, 1);
            else 
                god.WriteInt32((IntPtr)Offset98+ 0x5b0, 0);
        }

        private void NoclipCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory noclip = new VAMemory(processName);

            if (NoclipCheckbox.Checked)
                noclip.WriteInt32((IntPtr)Offset98+ 0x5b4, 1);
            else
                noclip.WriteInt32((IntPtr)Offset98 + 0x5b4, 0);
        }

        private void InfStamCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory stamina = new VAMemory(processName);

            if (InfStamCheckbox.Checked)
                stamina.WriteInt32((IntPtr)Offset98+ 0x924, 1);
            else
                stamina.WriteInt32((IntPtr)Offset98 + 0x924, 0);
        }

        private void BlinkCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory blink = new VAMemory(processName);

            if (BlinkCheckbox.Checked)
            {
                blink.WriteFloat((IntPtr)Offset98+ 0x390, 10000);
                blink.WriteFloat((IntPtr)Offset98 + 0x38c, 0);
            }
            else
                blink.WriteFloat((IntPtr)Offset98 + 0x390, 0);
        }

        private void NotargetCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory notarget = new VAMemory(processName);

            if (NotargetCheckbox.Checked)
                notarget.WriteInt32((IntPtr)Offset98 + 0xfd4, 1);
            else
                notarget.WriteInt32((IntPtr)Offset98 + 0xfd4, 0);
        }

        private void State008Button_Click(object sender, EventArgs e)
        {
            VAMemory S008 = new VAMemory(processName);

            S008.WriteFloat((IntPtr)Offset98+ 0x3f4, 0);
        }

        private void BloodlossInjuries_Click(object sender, EventArgs e)
        {
            VAMemory heal = new VAMemory(processName);

            heal.WriteFloat((IntPtr)Offset98 + 0x3f0, 0);

            heal.WriteFloat((IntPtr)Offset98 + 0x3ec, 0);
        }

        private void DebughudCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory debughud = new VAMemory(processName);

            if (DebughudCheckbox.Checked)
                debughud.WriteInt32((IntPtr)Offset98 + 0xad0, 1);
            else
                debughud.WriteInt32((IntPtr)Offset98 + 0xad0, 0);
        }

        private void CamerafogCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory fog = new VAMemory(processName);

            if (CamerafogCheckbox.Checked)
            {
                fog.WriteFloat((IntPtr)Offset98 + 0xb68, 10000);
                fog.WriteFloat((IntPtr)Offset98 + 0xb90, 10000);
            }
            else
            {
                fog.WriteFloat((IntPtr)Offset98 + 0xb68, 0.5f);
                fog.WriteFloat((IntPtr)Offset98 + 0xb90, 6);
            }
        }
        private void WireframeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory wire = new VAMemory(processName);

            if (WireframeCheckbox.Checked)
                wire.WriteInt32((IntPtr)WireframeOffset1 + 0x23f, 1);
            else
                wire.WriteInt32((IntPtr)WireframeOffset1+ 0x23f, 0);
        }

        private void RDCCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            VAMemory RDC = new VAMemory(processName);

            if (RDCCheckbox.Checked)
                RDC.WriteInt32((IntPtr)Offset98 + 0x12e8, 1);
            else 
                RDC.WriteInt32((IntPtr)Offset98+ 0x12e8, 0);
        }
        private void GammaSetButton_Click(object sender, EventArgs e)
        {
            VAMemory gamma = new VAMemory(processName);

            gamma.WriteFloat((IntPtr)Offset98 + 0xb4, float.Parse(GammaTextBox.Text));
        }

        private void MaxFPSSetButton_Click(object sender, EventArgs e)
        {
            VAMemory fps = new VAMemory(processName);

            fps.WriteInt32((IntPtr)Offset98 + 0x6c, Int32.Parse(MaxFPSTextBox.Text));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            VAMemory t1 = new VAMemory(processName);

            PlayerXLabel.Text = "X = " + PlayerX.ToString();
            PlayerYLabel.Text = "Y = " + PlayerY.ToString();
            PlayerZLabel.Text = "Z = " + PlayerZ.ToString();

            if (Godmode == 0)
                GodmodeLabel.Text = "Godmode is currently disabled.";
            else if (Godmode == 1)
                GodmodeLabel.Text = "Godmode is currently enabled.";

            if (Noclip == 1)
                NoclipLabel.Text = "Noclip is currently enabled.";
            else if (Noclip == 0)
                NoclipLabel.Text = "Noclip is currently disabled.";

            if (InfStam == 1)
                InfiniteStaminaLabel.Text = "Infinite stamina is currently enabled.";
            else if (InfStam == 0)
                InfiniteStaminaLabel.Text = "Infinite stamina is currently disabled.";

            if (InfBlink != 0)
                BlinkLabel.Text = "Infinite blink is currently enabled.";
            else if (InfBlink== 0)
                BlinkLabel.Text = "Infinite blink is currently disabled.";

            if (Notarget == 1)
                NotargetLabel.Text = "Notarget is currently enabled.";
            else if (Notarget == 0)
                NotargetLabel.Text = "Notarget is currently disabled.";

            if (Debughud == 1)
                DebughudLabel.Text = "Debughud is currently enabled.";
            else if (Debughud == 0)
                DebughudLabel.Text = "Debughud is currently disabled.";

            if (Camerafog == 0.5)
                CamerafogLabel.Text = "Camerafog is currently enabled.";
            else if (Camerafog != 0.5)
                CamerafogLabel.Text = "Camerafog is currently disabled.";

            if (RDC == 1)
                RDCLabel.Text = "Remote door control is currently enabled.";
            else if (RDC == 0)
                RDCLabel.Text = "Remote door control is currently disabled.";

            BloodlossLabel.Text = "Current health is " + (100 - Bloodloss).ToString() + ".";

            InjuriesLabel.Text = "Current injuries are " + Injuries.ToString() + ".";

            State008Label.Text = "Current SCP-008 state is " + SCP008State.ToString() + ".";

            if (Wireframe == 1)
                WireframeLabel.Text = "Wireframe is currently enabled.";
            else if (Wireframe == 0)
                WireframeLabel.Text = "Wireframe is currently disabled.";

            Thread.Sleep(5);
        }

        private void KillButton_Click(object sender, EventArgs e)
        {
            VAMemory kill = new VAMemory(processName);

            kill.WriteFloat((IntPtr)Offset98 + 0x3f0, 100);
        }

        private void OnOffLabel_Click(object sender, EventArgs e)
        {

        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Process[] isprocessRunning = Process.GetProcessesByName("SCP - Containment Breach");
            if (isprocessRunning.Length > 0)
            {
                foreach (Process process in isprocessRunning)
                {
                    ProcessModuleCollection oModules = process.Modules;

                    baseAddress = process.MainModule.BaseAddress;
                }

                if (baseAddress != null)
                {
                    VAMemory vars = new VAMemory(processName);

                    timer1.Start();
                    OnOffLabel.Text = "On";
                    OnOffLabel.ForeColor = System.Drawing.Color.LawnGreen;

                    mainAddress = vars.ReadInt32((IntPtr)baseAddress + 0x000f5400);
                    Offset98 = vars.ReadInt32((IntPtr)mainAddress + 0x98);
                    Godmode = vars.ReadInt32((IntPtr)Offset98 + 0x5b0);
                    Noclip = vars.ReadInt32((IntPtr)Offset98 + 0x5b4);
                    InfStam = vars.ReadInt32((IntPtr)Offset98 + 0x924);
                    InfBlink = vars.ReadInt32((IntPtr)Offset98 + 0x390);
                    Notarget = vars.ReadInt32((IntPtr)Offset98 + 0xfd4);
                    Debughud = vars.ReadInt32((IntPtr)Offset98 + 0xad0);
                    Camerafog = vars.ReadFloat((IntPtr)Offset98 + 0xb68);
                    WireframeOffset1 = vars.ReadInt32((IntPtr)mainAddress + 0xfdc);
                    Wireframe = vars.ReadInt32((IntPtr)WireframeOffset1 + 0x23f);
                    Bloodloss = vars.ReadFloat((IntPtr)Offset98 + 0x3f0);
                    SCP008State = vars.ReadFloat((IntPtr)Offset98 + 0x3f4);
                    Injuries = vars.ReadFloat((IntPtr)Offset98 + 0x3ec);
                    RDC = vars.ReadInt32((IntPtr)Offset98 + 0x12e8);

                    PlayerOffset1 = vars.ReadInt32((IntPtr)mainAddress + 0x160);
                    PlayerOffset2 = vars.ReadInt32((IntPtr)PlayerOffset1 + 0x140);
                    PlayerX = vars.ReadFloat((IntPtr)PlayerOffset2 + 0x40);
                    PlayerY = vars.ReadFloat((IntPtr)PlayerOffset2 + 0x44);
                    PlayerZ = vars.ReadFloat((IntPtr)PlayerOffset2 + 0x48);
                }

            }
            else
            {
                timer1.Stop();
                OnOffLabel.Text = "Off";
                OnOffLabel.ForeColor = System.Drawing.Color.DarkRed;
            }
        }

        private void LightModeCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (LightModeCheckbox.Checked)
            {
                this.BackColor = System.Drawing.Color.White;
                title.ForeColor = System.Drawing.Color.Black;
                StatusLabel.BackColor = System.Drawing.Color.White;
                StatusLabel.ForeColor = System.Drawing.Color.Black;
                OnOffLabel.BackColor = System.Drawing.Color.White;
                //tabPage4.BackColor = System.Drawing.Color.White;
                //label5.ForeColor = System.Drawing.Color.Black;
                //label7.ForeColor = System.Drawing.Color.Black;
                //label8.ForeColor = System.Drawing.Color.Black;
                //label9.ForeColor = System.Drawing.Color.Black;
                tabPage1.BackColor = System.Drawing.Color.White;
                GodmodeCheckBox.BackColor = System.Drawing.Color.White;
                GodmodeCheckBox.ForeColor = System.Drawing.Color.Black;
                GodmodeLabel.BackColor = System.Drawing.Color.White;
                GodmodeLabel.ForeColor = System.Drawing.Color.Black;
                NoclipCheckbox.BackColor = System.Drawing.Color.White;
                NoclipCheckbox.ForeColor = System.Drawing.Color.Black;
                NoclipLabel.BackColor = System.Drawing.Color.White;
                NoclipLabel.ForeColor = System.Drawing.Color.Black;
                InfStamCheckbox.BackColor = System.Drawing.Color.White;
                InfStamCheckbox.ForeColor = System.Drawing.Color.Black;
                InfiniteStaminaLabel.BackColor = System.Drawing.Color.White;
                InfiniteStaminaLabel.ForeColor = System.Drawing.Color.Black;
                BlinkCheckbox.BackColor = System.Drawing.Color.White;
                BlinkCheckbox.ForeColor = System.Drawing.Color.Black;
                BlinkLabel.BackColor = System.Drawing.Color.White;
                BlinkLabel.ForeColor = System.Drawing.Color.Black;
                NotargetCheckbox.BackColor = System.Drawing.Color.White;
                NotargetCheckbox.ForeColor = System.Drawing.Color.Black;
                NotargetLabel.BackColor = System.Drawing.Color.White;
                NotargetLabel.ForeColor = System.Drawing.Color.Black;
                DebughudCheckbox.BackColor = System.Drawing.Color.White;
                DebughudCheckbox.ForeColor = System.Drawing.Color.Black;
                DebughudLabel.BackColor = System.Drawing.Color.White;
                DebughudLabel.ForeColor = System.Drawing.Color.Black;
                CamerafogCheckbox.BackColor = System.Drawing.Color.White;
                CamerafogCheckbox.ForeColor = System.Drawing.Color.Black;
                CamerafogLabel.BackColor = System.Drawing.Color.White;
                CamerafogLabel.ForeColor = System.Drawing.Color.Black;
                WireframeCheckbox.BackColor = System.Drawing.Color.White;
                WireframeCheckbox.ForeColor = System.Drawing.Color.Black;
                WireframeLabel.BackColor = System.Drawing.Color.White;
                WireframeLabel.ForeColor = System.Drawing.Color.Black;
                BloodlossLabel.BackColor = System.Drawing.Color.White;
                BloodlossLabel.ForeColor = System.Drawing.Color.Black;
                InjuriesLabel.BackColor = System.Drawing.Color.White;
                InjuriesLabel.ForeColor = System.Drawing.Color.Black;
                State008Label.BackColor = System.Drawing.Color.White;
                State008Label.ForeColor = System.Drawing.Color.Black;
                RDCCheckbox.BackColor = System.Drawing.Color.White;
                RDCCheckbox.ForeColor = System.Drawing.Color.Black;
                RDCLabel.BackColor = System.Drawing.Color.White;
                RDCLabel.ForeColor = System.Drawing.Color.Black;
                PlayerCoordinatesLabel.BackColor = System.Drawing.Color.White;
                PlayerCoordinatesLabel.ForeColor = System.Drawing.Color.Black;
                PlayerXLabel.BackColor = System.Drawing.Color.White;
                PlayerXLabel.ForeColor = System.Drawing.Color.Black;
                PlayerYLabel.BackColor = System.Drawing.Color.White;
                PlayerYLabel.ForeColor = System.Drawing.Color.Black;
                PlayerZLabel.BackColor = System.Drawing.Color.White;
                PlayerZLabel.ForeColor = System.Drawing.Color.Black;
                tabPage2.BackColor = System.Drawing.Color.White;
                label1.BackColor = System.Drawing.Color.White;
                label1.ForeColor = System.Drawing.Color.Black;
                label2.BackColor = System.Drawing.Color.White;
                label2.ForeColor = System.Drawing.Color.Black;
                label3.BackColor = System.Drawing.Color.White;
                label3.ForeColor = System.Drawing.Color.Black;
                listBox1.BackColor = System.Drawing.Color.White;
                listBox1.ForeColor = System.Drawing.Color.Black;
                listBox2.BackColor = System.Drawing.Color.White;
                listBox2.ForeColor = System.Drawing.Color.Black;
                listBox3.BackColor = System.Drawing.Color.White;
                listBox3.ForeColor = System.Drawing.Color.Black;
                tabPage3.BackColor = System.Drawing.Color.White;
                GammaLabel.BackColor = System.Drawing.Color.White;
                GammaLabel.ForeColor = System.Drawing.Color.Black;
                GammaDefault.BackColor = System.Drawing.Color.White;
                GammaDefault.ForeColor = System.Drawing.Color.Black;
                MaxFPSlabel.BackColor = System.Drawing.Color.White;
                MaxFPSlabel.ForeColor = System.Drawing.Color.Black;
                //label10.BackColor = System.Drawing.Color.White;
                //label10.ForeColor = System.Drawing.Color.Black;
                LightModeCheckbox.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                this.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                title.ForeColor = System.Drawing.Color.White;
                StatusLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                StatusLabel.ForeColor = System.Drawing.Color.White;
                OnOffLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                //tabPage4.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                //label5.ForeColor = System.Drawing.Color.White;
                //label7.ForeColor = System.Drawing.Color.White;
                //label8.ForeColor = System.Drawing.Color.White;
                //label9.ForeColor = System.Drawing.Color.White;
                tabPage1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GodmodeCheckBox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GodmodeCheckBox.ForeColor = System.Drawing.Color.White;
                GodmodeLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GodmodeLabel.ForeColor = System.Drawing.Color.White;
                NoclipCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                NoclipCheckbox.ForeColor = System.Drawing.Color.White;
                NoclipLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                NoclipLabel.ForeColor = System.Drawing.Color.White;
                InfStamCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                InfStamCheckbox.ForeColor = System.Drawing.Color.White;
                InfiniteStaminaLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                InfiniteStaminaLabel.ForeColor = System.Drawing.Color.White;
                BlinkCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                BlinkCheckbox.ForeColor = System.Drawing.Color.White;
                BlinkLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                BlinkLabel.ForeColor = System.Drawing.Color.White;
                NotargetCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                NotargetCheckbox.ForeColor = System.Drawing.Color.White;
                NotargetLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                NotargetLabel.ForeColor = System.Drawing.Color.White;
                DebughudCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                DebughudCheckbox.ForeColor = System.Drawing.Color.White;
                DebughudLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                DebughudLabel.ForeColor = System.Drawing.Color.White;
                CamerafogCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                CamerafogCheckbox.ForeColor = System.Drawing.Color.White;
                CamerafogLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                CamerafogLabel.ForeColor = System.Drawing.Color.White;
                WireframeCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                WireframeCheckbox.ForeColor = System.Drawing.Color.White;
                WireframeLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                WireframeLabel.ForeColor = System.Drawing.Color.White;
                BloodlossLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                BloodlossLabel.ForeColor = System.Drawing.Color.White;
                InjuriesLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                InjuriesLabel.ForeColor = System.Drawing.Color.White;
                State008Label.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                State008Label.ForeColor = System.Drawing.Color.White;
                RDCCheckbox.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                RDCCheckbox.ForeColor = System.Drawing.Color.White;
                RDCLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                RDCLabel.ForeColor = System.Drawing.Color.White;
                PlayerCoordinatesLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                PlayerCoordinatesLabel.ForeColor = System.Drawing.Color.White;
                PlayerXLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                PlayerXLabel.ForeColor = System.Drawing.Color.White;
                PlayerYLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                PlayerYLabel.ForeColor = System.Drawing.Color.White;
                PlayerZLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                PlayerZLabel.ForeColor = System.Drawing.Color.White;
                tabPage2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                label1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                label1.ForeColor = System.Drawing.Color.White;
                label2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                label2.ForeColor = System.Drawing.Color.White;
                label3.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                label3.ForeColor = System.Drawing.Color.White;
                listBox1.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                listBox1.ForeColor = System.Drawing.Color.White;
                listBox2.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                listBox2.ForeColor = System.Drawing.Color.White;
                listBox3.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                listBox3.ForeColor = System.Drawing.Color.White;
                tabPage3.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GammaLabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GammaLabel.ForeColor = System.Drawing.Color.White;
                GammaDefault.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                GammaDefault.ForeColor = System.Drawing.Color.White;
                MaxFPSlabel.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                MaxFPSlabel.ForeColor = System.Drawing.Color.White;
                //label10.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                //label10.ForeColor = System.Drawing.Color.White;
                LightModeCheckbox.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
