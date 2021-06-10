using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalAssignment
{
    public partial class Book : Form
    {
        private bool isNew = true;
        public Book()
        {
            InitializeComponent();
        }

        private void Book_Load(object sender, EventArgs e)
        {
            this.LoadCategory();
            this.LoadPublisher();
            this.LoadBooks();

        }
        private void LoadCategory()
        {
            string query = "select * from Category";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null)
                return;

            cmbCategory.DataSource = dt;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "ID";

        }

        private void LoadPublisher()
        {
            string query = "select * from Publisher";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null)
                return;

            cmbPublisher.DataSource = dt;
            cmbPublisher.DisplayMember = "Name";
            cmbPublisher.ValueMember = "ID";
        }
        private void LoadBooks()
        {
            string query = "select Book.*,Category.[Name] as 'Category',Publisher.[Name] as 'Publisher'" +
            " from Book join Category on Book.CategoryID = Category.ID join Publisher on Book.PublisherID = Publisher.ID";

            if (string.IsNullOrEmpty(txtSearch.Text) == false)
            {
                query = query + " and Book.[Name] like '%" + txtSearch.Text + "%'";
            }
            DataTable dt = DataAccess.GetData(query);

            if (dt == null)
                return;

            dgvBook.AutoGenerateColumns = false;
            dgvBook.DataSource = dt;
            dgvBook.Refresh();
            dgvBook.ClearSelection();
            this.NewBook();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.LoadBooks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            this.LoadBooks();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string bookName = txtBookName.Text;

            if (string.IsNullOrEmpty(bookName))
            {
                MessageBox.Show("Full Name required");
                txtBookName.Focus();
                return;
            }
            
            string author = txtAuthor.Text;

            if (string.IsNullOrEmpty(author))
            {
                MessageBox.Show("Author Name required");
                txtAuthor.Focus();
                return;
            }

            string category = cmbCategory.Text;

            if (string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Invalid Category");
                cmbCategory.Focus();
                return;
            }

            string version = " ";

            if (rbtnBangla.Checked == true)
            {
                version = "Bangla";
            }
            else if (rbtnEnglish.Checked == true)
            {
                version = "English";
            }
            else
            {
                MessageBox.Show("Invalid version");
                rbtnBangla.Focus();
                return;
            }

            string publisher = cmbPublisher.Text;

            if (string.IsNullOrEmpty(publisher))
            {
                MessageBox.Show("Invalid Publisher");
                cmbPublisher.Focus();
                return;
            }



            string query = " ";

            if (isNew == true)
            {
                query = "insert into Book(Name,Author,[Version],CategoryID,PublisherID) values" +
                  " ('"+bookName+"','"+author+"','" +version+ "'," +cmbCategory.SelectedValue+ "," +cmbPublisher.SelectedValue+ ") ";

            }

            else
            {
                query = "update Book set Name = '"+bookName+"',Author = '"+author+"',[Version] = '" +version+ "',"+
                    "CategoryID = " +cmbCategory.SelectedValue+ ",PublisherID = " +cmbPublisher.SelectedValue+ " where ID = " +txtID.Text+ " ";
            }
            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Inserted/updated");
                this.LoadBooks();
                this.NewBook();
            }
        }

        private void dgvBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string id = dgvBook.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtID.Text = id;
                this.LoadSingleBook();
            }
        }

        private void LoadSingleBook()
        {
            string query = "select * from Book where ID = " + txtID.Text + "";

            DataTable dt = DataAccess.GetData(query);

            if (dt == null)
            {
                return;
            }

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid ID");
                return;
            }

            isNew = false;

            txtBookName.Text = dt.Rows[0]["Name"].ToString();
            txtAuthor.Text = dt.Rows[0]["Author"].ToString();

            cmbCategory.SelectedValue = dt.Rows[0]["CategoryID"].ToString();

            string version = dt.Rows[0]["Version"].ToString();
            if (version == "Bangla")
            {
                rbtnBangla.Checked = true;
            }
            else if (version == "English")
            {
                rbtnEnglish.Checked = true;

            }

            cmbPublisher.SelectedValue = dt.Rows[0]["PublisherID"].ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.NewBook();
        }

        private void NewBook()
        {
            isNew = true;
            txtID.Text = " ";
            txtBookName.Text = " ";
            txtAuthor.Text = " ";
            cmbCategory.Text = " ";
            rbtnBangla.Checked = rbtnEnglish.Checked = false;
            cmbPublisher.Text = " ";
            dgvBook.ClearSelection();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (isNew == true)
            {
                MessageBox.Show("Load existing Data First");
                return;
            }
            string query = "delete from Book where ID = " + txtID.Text + "";

            if (DataAccess.ExecuteQuery(query) == true)
            {
                MessageBox.Show("Book Deleted");
                this.LoadBooks();
                this.NewBook();
            }
        
        }


    }
}
