using System;
using System.Data;
using System.Data.SqlClient;


namespace ProductosDAL
{
	public class Conexion
	{

		public class conex
		{

			SqlConnection conexionBD;

			public conex() {
				conexionBD = new SqlConnection("Server=CR-LAP-STE-ARR;Database=ProductosPrueba;User ID=sa;Password=StevAP1998;");
			}

			public void ejecutarSentencia(String sentencia)
			{
				try
				{
					conexionBD.Open();
					SqlCommand comando = new SqlCommand(sentencia, conexionBD);
					comando.ExecuteNonQuery();
					conexionBD.Close();
				}
				catch (Exception e) {
					Console.WriteLine(e);
				}
			}

			public DataTable obtenerDatos(String sentencia) {
				SqlCommand cmd = new SqlCommand();
				DataTable dataTable = new DataTable();

				SqlDataAdapter sqlDA;
				conexionBD.Open();

				cmd.CommandText = sentencia;
				cmd.CommandType = CommandType.Text;
				cmd.Connection = conexionBD;

				sqlDA = new SqlDataAdapter(cmd);
				sqlDA.Fill(dataTable);

				conexionBD.Close();

				return dataTable;
			}

			public string verificarConexion()
			{
				conexionBD.Open();

				if (conexionBD.State == ConnectionState.Closed){
					return "La conexion fue fue efectuada";
				}
				else{
					return "La conexion no fue fue efectuada";
				}

			}
		}
	}



}
