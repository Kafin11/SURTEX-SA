using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SURTEX_SA
{
    public partial class empresa : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Cargar_emp();
            }
        }
        private void Cargar_emp()
        {
            //select * from a empleado
            var query = from E in dc.tbl_empresa select E;

            Grv_emp.DataSource = query;
            Grv_emp.DataBind();
        }
        private void limpiar()
        {
            Txt_dir.Text = Txt_ruc.Text = Txt_tel.Text = Txt_nom.Text = Txt_rep.Text = "";
            hdf_emp.Value = "";
        }
        protected void Lnk_Seleccionar_Click(object sender, EventArgs e)
        {

            int empid = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var query = (from E in dc.tbl_empresa where E.emp_id == empid select E).First();

            hdf_emp.Value = empid.ToString();
            Txt_ruc.Text = query.emp_ruc;
            Txt_rep.Text = query.emp_representante_legal;
            Txt_nom.Text = query.emp_nombre;
            Txt_dir.Text = query.emp_direccion;
            Txt_tel.Text = query.emp_telefono.ToString();
        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            var query = new tbl_empresa
            {

                 emp_ruc = Txt_ruc.Text,
                emp_representante_legal = Txt_rep.Text,
                emp_nombre = Txt_nom.Text,
                emp_direccion = Txt_dir.Text,
                emp_telefono = Convert.ToInt32(Txt_tel.Text),
                emp_estado = 'A'

            };
            dc.tbl_empresa.InsertOnSubmit(query);
            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos guardados')", true);
            Cargar_emp();
            limpiar();
        }

        protected void btn_actulizar_Click(object sender, EventArgs e)
        {
            var query = (from E in dc.tbl_empresa where E.emp_id == Convert.ToInt32(hdf_emp.Value) select E).First();
            query.emp_ruc = Txt_ruc.Text;
            query.emp_representante_legal = Txt_rep.Text;
            query.emp_nombre = Txt_nom.Text;
            query.emp_direccion = Txt_dir.Text;
            query.emp_telefono = Convert.ToInt32(Txt_tel.Text);
            query.emp_estado = 'C';


            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos modificados')", true);
            Cargar_emp();
            limpiar();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            var query = (from E in dc.tbl_empresa where E.emp_id == Convert.ToInt32(hdf_emp.Value) select E).First();
            dc.tbl_empresa.DeleteOnSubmit(query);


            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos Eliminados')", true);
            Cargar_emp();
            limpiar();
        }
    }
}