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
                outputLabel.Visible = false;
                errorLabel.Text = error;
                errorLabel.Visible = true;
            }
            else
            {
                errorLabel.Visible = false;
                outputLabel.Text = HelloHelper.CreateHelloPhrase(username);
                outputLabel.Visible = true;
            }
        }
    }
}