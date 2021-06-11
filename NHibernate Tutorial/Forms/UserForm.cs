using NHibernate;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NHibernate_Tutorial.Forms
{
    public partial class UserForm: Form
    {
        public JobForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            loadJobData();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            loadJobData();
        }

        private void loadJobData()
        {
            ISession session = SessionFactory.OpenSession;

            using (session)
            {
                IQuery query = session.CreateQuery("FROM Job");
                IList<Model.Job> empInfo = query.List<Model.Job>();
                dgViewEmployee.DataSource = empInfo;
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Model.Job jobData = new Model.Job();

            SetEmployeInfo(jobData);

            ISession session = SessionFactory.OpenSession;

            using (session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(jobData);
                        transaction.Commit();
                        loadJobData();

                        tJobName.Text = "";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }
                }
            }
        }

        private void SetEmployeInfo(Model.Job job)
        {
            job.JobName = tJobName.Text;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //to update data we will load current data to our textbox and then update
            ISession session = SessionFactory.OpenSession;

            using (session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Job WHERE Id = '" + IdTxtBx.Text + "'");
                        Model.Job jobData = query.List<Model.Job>()[0];
                        SetEmployeInfo(jobData);
                        session.Update(jobData);
                        transaction.Commit();

                        loadJobData();

                        IdTxtBx.Text = "";
                        tJobName.Text = "";
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        private void dgViewEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewEmployee.RowCount <= 1 || e.RowIndex < 0)
            {
                return;
            }

            string id = dgViewEmployee[0, e.RowIndex].Value.ToString();

            if (id == "")
                return;

            IList<Model.Job> empInfo = getDataFromJob(id);

            IdTxtBx.Text = empInfo[0].Id.ToString();
            tJobName.Text = empInfo[0].JobName.ToString();
        }

        private IList<Model.Job> getDataFromJob(string id)
        {
            ISession session = SessionFactory.OpenSession;

            using (session)
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        IQuery query = session.CreateQuery("FROM Job WHERE Id = '" + id + "'");
                        return query.List<Model.Job>();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw ex;
                    }
                }
            }
        }
    }
}
