using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LockScreen
{
    /// <summary>
    /// ChangePwd.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePwd : Window
    {
        public ChangePwd()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            string s_old = tbOrignalPwd.Password.Trim();
            string s_new = tbNewPwd.Password.Trim();
            if (string.IsNullOrEmpty(s_old))
            {
                MessageBox.Show("请输入原密码", "提示");
                return;
            }
            if (string.IsNullOrEmpty(s_new))
            {
                MessageBox.Show("请输入新密码", "提示");
                return;
            }
            string s_save = AppData.GetRegistry("lock_pwd", "");
            if(s_old!= s_save)
            {
                MessageBox.Show("原密码输入不正确，请重试", "提示");
                return;
            }

            if (s_old == s_new)
            {
                MessageBox.Show("原密码不能与新密码相同", "提示");
                return;
            }
            AppData.SetRegistry("lock_pwd", s_new);
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = false;
        }
    }
}
