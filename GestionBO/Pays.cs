namespace GestionBO
{
    public class Pays
    {
        private int code;
        private string nom;
        private float augmentation;

        public Pays(int code, string nom, float augmentation)
        {
            this.code = code;
            this.nom = nom;
            this.augmentation = augmentation;
        }

        public int Code { get => code; set => code = value; }
        public string Nom { get => nom; set => nom = value; }
        public float Augmentation { get => augmentation; set => augmentation = value; }

    }
}
