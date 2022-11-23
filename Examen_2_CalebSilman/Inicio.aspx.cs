using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_2_CalebSilman
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String s = System.Configuration.ConfigurationManager.ConnectionStrings["base_de_datosConnectionString"].ConnectionString;
            SqlConnection conexion = new SqlConnection(s);
            conexion.Open();
            SqlCommand comando = new SqlCommand(" INSERT INTO Venta (Cajero, Maquina, Producto) values ('" + DCajeros.SelectedItem + "','" + DMaquinas.SelectedItem + "', '" + DProductos.SelectedItem + "' )", conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            
        }
        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["base_de_datosConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Venta.Fecha, Nombre_cajero, Productos.Nombre_producto, Productos.Precio, Maquinas_Registradoras.Piso\r\nfrom (((Venta\r\n" +
                    "inner join Productos on Venta.Producto = Productos.Codigo_productos)\r\n" +
                    "inner join Maquinas_Registradoras on Venta.Maquina = Maquinas_Registradoras.Codigo_MaquinaReg)\r\n" +
                    "inner join Cajeros on Venta.Cajero = Cajeros.Codigo_cajero)"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
    }
}