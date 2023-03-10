using GestionBO;
using System.Data.SqlClient;

namespace GestionDAL
{
    public class PaysDAO
    {
        private static PaysDAO unPaysDAO;

        // Accesseur en lecture, renvoi une instance
        public static PaysDAO GetunPaysDAO()
        {
            if (unPaysDAO == null)
            {
                unPaysDAO = new PaysDAO();
            }
            return unPaysDAO;
        }

        // Cette méthode retourne une List contenant les objets pays contenus dans la table pays : VIEW
        public static List<Pays> GetPays()
        {
            int code;
            string nom;
            float augmentation;

            Pays unPays;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();

            // Création d'une liste vide d'objets Categorie
            List<Pays> lesPays = new List<Pays>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;
            cmd.CommandText = "SELECT * FROM pays";
            SqlDataReader monReader = cmd.ExecuteReader();

            // Remplissage de la liste
            while (monReader.Read())
            {
                code = Int32.Parse(monReader["id_pays"].ToString());

                if (monReader["nom"] == DBNull.Value)
                {
                    nom = default(string);
                }
                else
                {
                    nom = monReader["nom"].ToString();
                }

                augmentation = float.Parse(monReader["augmentation"].ToString());

                unPays = new Pays(code, nom, augmentation);
                lesPays.Add(unPays);
            }

            // Fermeture de la connexion
            monReader.Close();
            maConnexion.Close();
            return lesPays;
        }

        public static int GetCodePays(string nom)
        {
            int code;

            // Connexion à la BD
            SqlConnection maConnexion = ConnexionBD.GetConnexionBD().GetSqlConnexion();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = maConnexion;

            cmd.CommandText = "SELECT id_pays AS pays FROM pays WHERE nom = @nom";

            cmd.Parameters.Add(new SqlParameter("@nom", System.Data.SqlDbType.NVarChar, 255));
            cmd.Parameters["@nom"].Value = nom;

            //reader
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            code = (int)reader["pays"];
            reader.Close();

            // Fermeture de la connexion
            maConnexion.Close();

            code = code - 1;

            return code;
        }
    }
}
