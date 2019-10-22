using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLog;

namespace HP_log_nhapi
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filepath);

        private string m_strCurPath;
        private string m_strIniFile;
        private static Logger m_logger = LogManager.GetCurrentClassLogger();
        private List<string> m_arrPM = new List<string>();
        private Dictionary<string, List<string>> m_dicCode = new Dictionary<string, List<string>>();

        public Form1()
        {
            InitializeComponent();

            ReadIni();
        }

        private void ReadIni()
        {
            m_logger.Debug("START");
            StringBuilder retVal = new StringBuilder();

            string strSection = "ENV";

            string strCur = System.IO.Directory.GetCurrentDirectory();
            m_strCurPath = strCur;
            m_strIniFile = strCur + @"\env.ini";
            //GetPrivateProfileString(strSection, "IP", "210.183.186.15", retVal, 32, m_strIniFile);
            //ED_IP.Text = retVal.ToString(); retVal.Clear();
            GetPrivateProfileString(strSection, "ID", "", retVal, 32, m_strIniFile);
            ED_ID.Text = retVal.ToString(); retVal.Clear();

            int nCount = 0;
            strSection = "GROUP";
            GetPrivateProfileString(strSection, "COUNT", "0", retVal, 32, m_strIniFile);
            nCount = Convert.ToInt32(retVal.ToString()); retVal.Clear();
            if (nCount < 1)
                return;

            int i = 0;
            string strKey = "", strVal = "";
            for (i = 0; i < nCount; i++)
            {
                strKey = String.Format("{0:D2}", i);
                GetPrivateProfileString(strSection, strKey, "", retVal, 32, m_strIniFile);
                strVal = retVal.ToString(); retVal.Clear();
                m_arrPM.Add(strVal);
                LIST_PMCODE.Items.Add(strVal);
            }
        }

        private void WriteIni()
        {
            string strSection = "ENV";
            //WritePrivateProfileString(strSection, "IP", ED_IP.Text, m_strIniFile);
            WritePrivateProfileString(strSection, "ID", ED_ID.Text, m_strIniFile);

            if (m_arrPM.Count < 1)
                return;

            strSection = "GROUP";
            WritePrivateProfileString(strSection, "COUNT", m_arrPM.Count.ToString(), m_strIniFile);

            int i = 0;
            string strKey = "";
            for (i = 0; i < m_arrPM.Count; i++)
            {
                strKey = String.Format("{0:D2}", i);
                WritePrivateProfileString(strSection, strKey, m_arrPM[i], m_strIniFile);
            }
        }
    
        private void ED_PMCODE_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            string strText = ED_PMCODE.Text.Trim();
            if (strText.Length < 1)
                return;

            bool bFind = false;
            foreach(string it in m_arrPM)
            {
                if (strText == it)
                {
                    bFind = true;
                    break;
                }
            }

            if(bFind)
            {
                MessageBox.Show("Already Exist.");
                return;
            }

            LIST_PMCODE.Items.Add(strText);
            m_arrPM.Add(strText);
            ED_PMCODE.SelectAll();
        }

        private void LIST_PMCODE_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var result = MessageBox.Show("Delete Item?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
                return;

            string strItem = LIST_PMCODE.SelectedItems[0].ToString();
            LIST_PMCODE.Items.RemoveAt(LIST_PMCODE.SelectedIndex);
            m_arrPM.Remove(strItem);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            WriteIni();
        }

        private void BTN_LOGIN_Click(object sender, EventArgs e)
        {
            short nRet = axCommOCX1.OCommLogin(ED_ID.Text, ED_PWD.Text, ED_PWD2.Text);
            if(nRet >= 0)
            {
                axCommOCX1.OGetMasterFileFromServer();
            }
        }

        private void BTN_SB_Click(object sender, EventArgs e)
        {
            if (m_arrPM.Count < 1)
                return;

            axCommOCX1.OCommRemoveBrodAll();

            List<string> sbList = new List<string>();
            List<string> tempList;
            foreach (string arit in m_arrPM)
            {
                int idx = 0;
                tempList = m_dicCode[arit];
                foreach (string it in tempList)
                {
                    sbList.Add(it);

                    idx++;
                    if (idx > 2)
                        break;
                }
            }

            // 17:시세체결 20:호가
            foreach (string it in sbList)
            {
                axCommOCX1.OCommSetBrodReal(17, it);
                axCommOCX1.OCommSetBrodReal(20, it);
            }
        }

        private void axCommOCX1_OSocketStatus(object sender, AxCOMMOCXLib._DCommOCXEvents_OSocketStatusEvent e)
        {
            if (e.nStatus == 0)
                MessageBox.Show("socket 단절");

            //axCommOCX1.OGetMasterFileFromServer();
        }

        private void ReadMasterFile()
        {
            m_dicCode.Clear();

            List<string> tempList;
            string strCode = "", strLine = "", strGroup = "";
            string strFile = m_strCurPath + @"\data\jmcode.cod";
            System.IO.StreamReader file = new System.IO.StreamReader(strFile);

            while ((strLine = file.ReadLine()) != null)
            {
                strGroup = strLine.Substring(0, 5).TrimEnd();
                strCode = strLine.Substring(5, 10).TrimEnd();

                if (m_dicCode.ContainsKey(strGroup))
                    tempList = m_dicCode[strGroup];
                else
                {
                    tempList = new List<string>();
                    m_dicCode.Add(strGroup, tempList);
                }

                tempList.Add(strCode);
            }

            MessageBox.Show("Load Completed file.[jmcode.cod]");
            BTN_SB.Enabled = true;
            BTN_SBC.Enabled = true;

            //tempList = m_dicCode["6A"];
            //foreach (string it in tempList)
            //    MessageBox.Show(it);
        }

        private void axCommOCX1_ORecvMasterFile(object sender, AxCOMMOCXLib._DCommOCXEvents_ORecvMasterFileEvent e)
        {
            ReadMasterFile();
        }

        private void BTN_SBC_Click(object sender, EventArgs e)
        {
            axCommOCX1.OCommRemoveBrodAll();
        }

        private void axCommOCX1_ORecvRealData(object sender, AxCOMMOCXLib._DCommOCXEvents_ORecvRealDataEvent e)
        {
            m_logger.Info(e.szData);
        }
    }
}
