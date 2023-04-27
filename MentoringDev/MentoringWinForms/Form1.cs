using LibraryProject;

namespace MentoringWinForms
{
    public partial class Form1 : Form
    {
        private const string error = "Username must be not null.";

        public Form1()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text;

            if (string.IsNullOrEmpty(username))
            {
                errorLabel.Text = error;
                errorLabel.Visible = true;
            }
            else
            {
                OutputLabel.Text = HelloHelper.CreateHelloPhrase(username);
                OutputLabel.Visible = true;
            }
        }
    }
}