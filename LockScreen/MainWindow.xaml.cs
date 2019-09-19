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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LockScreen
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            this.WindowState = WindowState.Maximized;

            string s_code = AppData.GetRegistry("lock_pwd", "");
            if (string.IsNullOrEmpty(s_code))
            {
                AppData.SetRegistry("lock_pwd", "123456");
                MessageBox.Show("初始密码是123456，请在主界面修改密码！", "提示");
            }
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tbPwd.Focus();
        }

        private void btnUnlock_Click(object sender, RoutedEventArgs e)
        {

            string s_code = AppData.GetRegistry("lock_pwd", "");
            string s_input = tbPwd.Password.Trim();

            if (s_code != s_input)
            {
                MessageBox.Show("密码错误，解锁失败！", "提示");
                return;
            }
            this.Close();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            var form = new ChangePwd();
            form.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            form.ShowDialog();
        }
    }
}
