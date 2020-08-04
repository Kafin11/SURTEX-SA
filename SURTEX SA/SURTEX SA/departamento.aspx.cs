using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SURTEX_SA
{
    public partial class departamento : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cargar_dep();
                cargar_emp();
            }
        }

        private void Cargar_dep()
        {
            //select * from a empleado
            var query = from D in dc.tbl_departamento select D;

            Grv_dep.DataSource = query;
            Grv_dep.DataBind();
        }
        private void cargar_emp()
        {
            var query = from E in dc.tbl_empresa select E;
            Dr_emp.DataTextField = "emp_nombre";
            Dr_emp.DataValueField = "emp_id";
            Dr_emp.DataSource = query;
            Dr_emp.DataBind();
            Dr_emp.Items.Insert(0, new ListItem("seleccione", "0"));
        }
        private void limpiar()
        {
            Txt_des.Text = Txt_ape.Text = Txt_nom.Text  = Txt_dep.Text = "";
            Dr_emp.SelectedValue = "0";
            hdf_dep.Value = "";
        }

        protected void Lnk_Seleccionar_Click(object sender, EventArgs e)
        {
            int depid = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var query = (from D in dc.tbl_departamento where D.dep_id == depid select D).First();

            hdf_dep.Value = depid.ToString();
            Txt_dep.Text = query.dep_nombre;
            Txt_nom.Text = query.dep_nombre_jefe;
            Txt_ape.Text = query.dep_apellido_jefe;
            Txt_des.Text = query.dep_descripcion;
            Dr_emp.SelectedValue = query.emp_id.ToString();


        }

        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            var query = new tbl_departamento
            {

             dep_nombre = Txt_dep.Text,
             dep_nombre_jefe = Txt_nom.Text,
             dep_apellido_jefe = Txt_ape.Text,
             dep_descripcion=Txt_des.Text,
             emp_id=Convert.ToInt32(Dr_emp.SelectedValue),
             dep_estado='A'

             };
            dc.tbl_departamento.InsertOnSubmit(query);
            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos guardados')", true);
            Cargar_dep();
            limpiar();

        }

        protected void btn_actulizar_Click(object sender, EventArgs e)
        {
            var query = (from D in dc.tbl_departamento where D.dep_id == Convert.ToInt32(hdf_dep.Value) select D).First();
            query.dep_nombre = Txt_dep.Text;
            query.dep_nombre_jefe = Txt_nom.Text;
            query.dep_apellido_jefe = Txt_ape.Text;
            query.dep_descripcion = Txt_des.Text;
            query.emp_id = Convert.ToInt32(Dr_emp.SelectedValue);
            query.dep_estado = 'C';


            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos modificados')", true);
            Cargar_dep();
            limpiar();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            var query = (from D in dc.tbl_departamento where D.dep_id == Convert.ToInt32(hdf_dep.Value) select D).First();
            dc.tbl_departamento.DeleteOnSubmit(query);

            dc.SubmitChanges();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos Eliminados')", true);
            Cargar_dep();
            limpiar();
        }
    }
}