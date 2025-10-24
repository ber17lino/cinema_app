using System;
using System.Windows.Forms;

namespace Cinema_APP
{
    internal static class Program
    {
        public static UserRole CurrentUserRole { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму входа
            using (var loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    CurrentUserRole = loginForm.SelectedRole;
                    Application.Run(new MainForm());
                }
            }
        }
    }

    public enum UserRole
    {
        Administrator,
        Cashier,
        Guest
    }
}