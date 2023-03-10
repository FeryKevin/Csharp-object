namespace GestionBO
{
    public class Produit
    {
        private int code;
        private string libelle;
        private float prix;
        private Categorie categorie;
        private Pays pays;

        public Produit(int code, string libelle, float prix, Categorie categorie, Pays pays)
        {
            this.code = code;
            this.libelle = libelle;
            this.prix = prix;
            this.categorie = categorie;
            this.pays = pays;
        }

        public int Code { get => code; set => code = value; }
        public string Libelle { get => libelle; set => libelle = value; }
        public float Prix { get => prix; set => prix = value; }
        public Categorie Categorie { get => categorie; set => categorie = value; }
        public Pays Pays { get => pays; set => pays = value; }
    }
}
