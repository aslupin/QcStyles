using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        string FileAss;
        string TextForUse;
        string StyleZix;
        string NameStyle;
        string[] TextSave;
        string TEXTD;
        string LogFile;
        List<string> _items = new List<string>();

        public Form1()
        {
            InitializeComponent();
           

           
        }
        // Function for find word
        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }


        private void button3_Click(object sender, EventArgs e)
        {

            // Browse File .ass (Subtitle)
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = LogFile;//@Logfile
            LogFile = fdlg.FileName;
            fdlg.Filter = "All Files (*.*)|*.*|ASS Files (*.ass)|*.ass";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
               
                FileAss = fdlg.FileName;


                // Input Style in list
                string[] Words = File.ReadAllLines(FileAss);
                int NumList = 0;
                for (int i = 0; i < Words.Length; i++)
                {
                    Words[i] = Words[i].Substring(0, Words[i].IndexOf(",") + 1);
                    string s1 = Words[i];
                    string s2 = "Style: ";
                    string s3 = "WrapStyle: ";
                    bool R, C;
                    R = s1.Contains(s2);
                    C = s1.Contains(s3);
                    if (R == true && C == false)
                    {
                        // MessageBox.Show(Words[i]);
                        Words[i] = Words[i].Replace("Style: ", "");
                        TextForUse = Words[i].Replace(",", "");
                        _items.Add(TextForUse);
                        NumList++;
                        listBox1.DataSource = null;
                        listBox1.DataSource = _items;
                    }


                }

                String[] lines2;
                lines2 = File.ReadAllLines(FileAss);
                for (int i = 0; i < lines2.Length; i++)
                {
                    TEXTD = TEXTD + lines2[i] + Environment.NewLine;
                }
            }

          


        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Filelog = LogFile;
        
        }
     
       
        // Select Styles in file

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            NameStyle = listBox1.GetItemText(listBox1.SelectedItem);
     
        }
        // Select Resolution
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
  
        }
        // Select Genres
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Select Storage
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        // Link

        private void button1_Click(object sender, EventArgs e)
        {
            //Process For Change
          


            // ACTION
         if (comboBox1.SelectedItem == "Action") {

                if (comboBox3.SelectedItem == "ZDefault - BOT")
                {
                    StyleZix = ",DilleniaUPC,75,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,-1,0,0,0,100,100,0,0,1,2,0,2,100,100,25,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - TOP")
                {
                    StyleZix = ",DilleniaUPC,75,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,-1,0,0,0,100,100,0,0,1,2,0,8,100,100,15,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - italics")
                {
                    StyleZix = ",DilleniaUPC,75,&H00FFFFFF,&H000000FF,&H00000000,&H00000000,-1,-1,0,0,100,100,0,0,1,2,0,2,100,100,15,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - flashback")
                {
                    StyleZix = ",DilleniaUPC,75,&H00FFFFFF,&H000000FF,&H006E6E6E,&H00000000,-1,0,0,0,100,100,0,0,1,2,0,2,100,100,15,1";
                }
         }
                // SCHOOL
             if (comboBox1.SelectedItem == "School") {

                if (comboBox3.SelectedItem == "ZDefault - BOT")
                {
                    StyleZix = ",Layiji MaHaNiYom V1.5 OT,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,0,0,0,100,100,0,0,1,2.4,0.4,2,0,0,35,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - TOP")
                {
                    StyleZix = ",Layiji MaHaNiYom V1.5 OT,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,0,0,0,100,100,0,0,1,2.4,0.4,8,0,0,15,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - italics")
                {
                    StyleZix = ",Layiji MaHaNiYom V1.5 OT,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,-1,0,0,100,100,0,0,1,2.4,0.4,2,0,0,35,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - flashback")
                {
                    StyleZix = ",Layiji MaHaNiYom V1.5 OT,70,&H00FFFFFF,&H000000FF,&H006E6E6E,&H00000000,0,0,0,0,100,100,0,0,1,2.4,0.4,2,0,0,35,1";
                }}


                 // SHOUJO
                 if (comboBox1.SelectedItem == "Shoujo") {

                if (comboBox3.SelectedItem == "ZDefault - BOT")
                {
                    StyleZix = ",Layiji MaHaNiYom BAO 1.2,75,&H00F1F4F9,&H000019FF,&H00000000,&HB4000000,-1,0,0,0,100,100,0,0,1,2.4,0.8,2,80,80,30,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - TOP")
                {
                    StyleZix = ",Layiji MaHaNiYom BAO 1.2,75,&H00F1F4F9,&H000019FF,&H00000000,&HB4000000,-1,0,0,0,100,100,0,0,1,2.4,0.8,8,80,80,15,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - italics")
                {
                    StyleZix = ",Layiji MaHaNiYom BAO 1.2,75,&H00F1F4F9,&H000019FF,&H00000000,&HB4000000,-1,-1,0,0,100,100,0,0,1,2.4,0.8,2,80,80,30,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - flashback")
                {
                    StyleZix = ",Layiji MaHaNiYom BAO 1.2,75,&H00F1F4F9,&H000019FF,&H006E6E6E,&HB4000000,-1,0,0,0,100,100,0,0,1,2.4,0.8,2,80,80,30,1";
                }
                 }
                    
                     // DRAMA
                if (comboBox1.SelectedItem == "Drama")
                {

                    if (comboBox3.SelectedItem == "ZDefault - BOT")
                    {
                        StyleZix = ",2005_iannnnnMTV,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,0,0,0,105,107,0,0,1,2.7,0.5,2,0,0,35,1";
                    }
                    if (comboBox3.SelectedItem == "ZDefault - TOP")
                    {
                        StyleZix = ",2005_iannnnnMTV,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,0,0,0,105,107,0,0,1,2.7,0.5,8,0,0,16,1";
                    }
                    if (comboBox3.SelectedItem == "ZDefault - italics")
                    {
                        StyleZix = ",2005_iannnnnMTV,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,0,-1,0,0,105,107,0,0,1,2.7,0.5,2,0,0,35,1";
                    }
                    if (comboBox3.SelectedItem == "ZDefault - flashback")
                    {
                        StyleZix = ",2005_iannnnnMTV,70,&H00FFFFFF,&H000000FF,&H006E6E6E,&H00000000,0,0,0,0,105,107,0,0,1,2.7,0.5,2,0,0,35,1";
                    }
                }

                         // NONE
                if (comboBox1.SelectedItem == "None") {

                if (comboBox3.SelectedItem == "ZDefault - BOT")
                {
                    StyleZix = ",TH Niramit AS,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,-1,0,0,0,107,105,0,0,1,2.7,0.5,2,0,0,35,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - TOP")
                {
                    StyleZix = ",TH Niramit AS,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,-1,0,0,0,107,105,0,0,1,2.7,0.5,8,0,0,16,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - italics")
                {
                    StyleZix = ",TH Niramit AS,70,&H00FFFFFF,&H000000FF,&H00020713,&H00000000,-1,-1,0,0,107,105,0,0,1,2.7,0.5,2,0,0,35,1";
                }
                if (comboBox3.SelectedItem == "ZDefault - flashback")
                {
                    StyleZix = ",TH Niramit AS,70,&H00FFFFFF,&H000000FF,&H006E6E6E,&H00000000,-1,0,0,0,107,105,0,0,1,2.7,0.5,2,0,0,35,1";
                }}
               
        
            


           /* List<string> found = new List<string>();
            string line;
            using (StreamReader file = new StreamReader(FileAss))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("NameStyle"))
                    {
                       // found.Add(line);
                       // Filed = line;
                    }
                }
            }*/

            // Change text
            //MessageBox.Show(NameStyle);
               // String Linetest = FileDialog();
               String[] lines;
             lines = File.ReadAllLines(FileAss);
            for (int i = 0; i < lines.Length; i++)
            {
                string s1 = lines[i];
                string s2 = "Style: " + NameStyle + ",";
                bool b0;
                bool b;
                b0 = TEXTD.Contains(s2);
                b = s1.Contains(s2);
                if (b == true)
                {
                   // MessageBox.Show(lines[i]);
                   // MessageBox.Show(TEXTD.Replace(lines[i], "Style: " + NameStyle + StyleZix));
                   TEXTD =  TEXTD.Replace(lines[i], "Style: " + NameStyle + StyleZix);
                   // MessageBox.Show(s2);
                  //  lines[i] = "Style: " + NameStyle + StyleZix;
                   // MessageBox.Show(lines[i]);
                }
              /*  if (b == true && b0 == true)
                {
                    TEXTD.Replace(s2, lines[i]);
                }*/
               // if(i==0)
               // TEXTD = TEXTD + lines[i] + Environment.NewLine;
              //  if(i!=0)

              

            }
           
           
        //   TextSave = lines;
         //  MessageBox.Show(TEXTD);
          
                 //  File.WriteAllLines(TEXTD, lines);
        }
        // Save as
        private void button2_Click(object sender, EventArgs e)
        {
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "ASS Files (*.ass)|*.ass";
            saveFileDialog1.Title = "Save as";
            saveFileDialog1.ShowDialog();


            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog1.OpenFile();
                // Saves the Image in the appropriate ImageFormat based upon the
                // File type selected in the dialog box.
                // NOTE that the FilterIndex property is one-based.
          

                fs.Close();
            }
            string name = saveFileDialog1.FileName;
            TEXTD = TEXTD.Replace(",0,0,0,,", "::Qc.Styles.01.ByAsLupin,0,0,0,,");
            File.WriteAllText(name, TEXTD);
         //   MessageBox.Show(TEXTD);
        
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogFile = Properties.Settings.Default.Filelog;
            this.WindowState = FormWindowState.Normal;
        }

      
        
             }}

    
