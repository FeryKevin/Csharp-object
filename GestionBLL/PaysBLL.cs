using GestionDAL;
using GestionBO;
using System.Configuration;


namespace GestionBLL
{
    public class PaysBLL
    {
        private static PaysBLL uneGestionPays; // objet BLL

        // Accesseur en lecture
        public static PaysBLL GetGestionUtilisateurs()
        {
            if (uneGestionPays == null)
            {
                uneGestionPays = new PaysBLL();
            }
            return uneGestionPays;
        }

        // Définit la chaîne de connexion grâce à la méthode SetchaineConnexion de la DAL
        public static void SetchaineConnexion(ConnectionStringSettings chset)
        {
            string chaine = chset.ConnectionString;
            ConnexionBD.GetConnexionBD().SetchaineConnexion(chaine);
        }

        // Méthode qui renvoit une List d'objets Utilisateur en faisant appel à la méthode GetCategorie() de la DAL : VIEW
        public static List<Pays> GetPays()
        {
            return PaysDAO.GetPays();
        }

        public static int GetCodePays(string nom)
        {
            return PaysDAO.GetCodePays(nom);
        }
    }
}
