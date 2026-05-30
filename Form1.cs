namespace Calendar
{
    public partial class Form1 : Form
    {
        List<ListBox> listBoxes;
        public Form1()
        {
            InitializeComponent();
            listBoxes = new List<ListBox>();
            foreach (Control control in base.Controls)
            {
                if (control is ListBox)
                {
                    listBoxes.Add((ListBox)control);
                }
            }
        }
    }
}
