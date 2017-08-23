using System.Windows.Forms;

namespace EmailClient
{
    public partial class MessageListItem : UserControl
    {
        public MessageListItem(string from, string subject)
        {
            InitializeComponent();

            //TODO add length checks so that long subjects etc. become "blablabla ..."
            fromLabel.Text = from;
            subjectLabel.Text = subject;
        }
    }
}
