using System;
using System.Collections.Generic;
using System.Data;
using ExamenP3_RiveraJoel.Models;
using Microsoft.Data.SqlClient;

namespace ExamenP3_RiveraJoel.Data
{
    public class OpinionesClienteDataAccessLayer
    {
        // Cadena de conexión a la base de datos
        string connectionString = "Server=PERSONAL\\SQL;Database=productos;User ID=sa;Password=admin;TrustServerCertificate=true;MultipleActiveResultSets=true";

        // Obtener todas las opiniones
        public List<OpinionesClientes> GetOpiniones()
        {
            List<OpinionesClientes> lst = new List<OpinionesClientes>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    OpinionesClientes opinion = new OpinionesClientes();
                    opinion.OpinionID = Convert.ToInt32(reader["OpinionID"]);
                    opinion.ClientED = Convert.ToInt32(reader["ClientED"]);
                    opinion.ProductD = reader["ProductD"] as int?;
                    opinion.Calificacion = Convert.ToInt32(reader["Calificacion"]);
                    opinion.Comentario = reader["Comentario"].ToString();
                    opinion.Fecha = Convert.ToDateTime(reader["Fecha"]);
                    lst.Add(opinion);
                }
                con.Close();
            }
            return lst;
        }

        // Obtener una opinión por su ID
        public OpinionesClientes GetOpinionByID(int opinionID)
        {
            OpinionesClientes opinion = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_SelectOne", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", opinionID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    opinion = new OpinionesClientes();
                    opinion.OpinionID = Convert.ToInt32(reader["OpinionID"]);
                    opinion.ClientED = Convert.ToInt32(reader["ClientED"]);
                    opinion.ProductD = reader["ProductD"] as int?;
                    opinion.Calificacion = Convert.ToInt32(reader["Calificacion"]);
                    opinion.Comentario = reader["Comentario"].ToString();
                    opinion.Fecha = Convert.ToDateTime(reader["Fecha"]);
                }
                con.Close();
            }
            return opinion;
        }

        // Agregar una opinión
        public void AddOpinion(OpinionesClientes opinion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClientED", opinion.ClientED);
                cmd.Parameters.AddWithValue("@ProductD", (object)opinion.ProductD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Actualizar una opinión
        public void UpdateOpinion(OpinionesClientes opinion)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", opinion.OpinionID);
                cmd.Parameters.AddWithValue("@ClientED", opinion.ClientED);
                cmd.Parameters.AddWithValue("@ProductD", (object)opinion.ProductD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Calificacion", opinion.Calificacion);
                cmd.Parameters.AddWithValue("@Comentario", opinion.Comentario);
                cmd.Parameters.AddWithValue("@Fecha", opinion.Fecha);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        // Eliminar una opinión
        public bool DeleteOpinion(int opinionID)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("opinionesCliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OpinionID", opinionID);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected > 0;
            }
        }
    }
}
