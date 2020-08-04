using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SURTEX_SA
{
    public partial class cargo : System.Web.UI.Page
    {
        private DataClasses1DataContext dc = new DataClasses1DataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_dep();
                Cargar_car();
            }
        }
        private void Cargar_car()
        {
            //select * from a empleado
            

            Grv_car.DataSource = dc.mostrar_cargo();
            Grv_car.DataBind();
        }
        private void cargar_dep()
        {
            var query = from D in dc.tbl_departamento select D;
            Dr_dep.DataTextField = "dep_nombre";
            Dr_dep.DataValueField = "dep_id";
            Dr_dep.DataSource = query;
            Dr_dep.DataBind();
            Dr_dep.Items.Insert(0, new ListItem("seleccione", "0"));
        }
        private void limpiar()
        {
            Txt_nom.Text = Txt_des.Text  = "";
            Dr_dep.SelectedValue = "0";
            hdf_car.Value = "";
        }
        protected void btn_guardar_Click(object sender, EventArgs e)
        {
            dc.guardar_cargo(Txt_nom.Text, Txt_des.Text, Convert.ToInt32(Dr_dep.SelectedValue));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos guardados')", true);
            Cargar_car();
            limpiar();
        }

        protected void btn_actulizar_Click(object sender, EventArgs e)
        {
            dc.modificar_cargo(Txt_nom.Text, Txt_des.Text, Convert.ToInt32(Dr_dep.SelectedValue), Convert.ToInt32(hdf_car.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos Modificados')", true);
            Cargar_car();
            limpiar();
        }

        protected void btn_eliminar_Click(object sender, EventArgs e)
        {
            dc.eliminar_cargo(Convert.ToInt32(hdf_car.Value));
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('datos Eliminados')", true);
            Cargar_car();
            limpiar();
        }

        protected void Lnk_Seleccionar_Click(object sender, EventArgs e)
        {
            int carid = Convert.ToInt32((sender as LinkButton).CommandArgument);

            var query = (from C in dc.tbl_cargo where C.car_id == carid select C).First();

            hdf_car.Value = carid.ToString();
            Txt_nom.Text = query.car_nombre;
            Txt_des.Text = query.car_descripcion;
            Dr_dep.SelectedValue = query.dep_id.ToString();
        }
    }
}