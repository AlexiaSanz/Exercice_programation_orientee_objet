using System;
using System.Collections.Generic;

namespace exo_personnes
{
    interface IAffichable
    {
        void Afficher();

    }
    class TablesMultiplication : IAffichable
    {
        int numero;

        public TablesMultiplication (int numero)
        {
            this.numero = numero;
        }

        public void Afficher()
        {
            Console.WriteLine(" Table de multiplication de " + numero);

            for (int i = 0; i < 11; i++)
            {
                int resultat = i * numero;
                Console.WriteLine($" {i} x {numero} = {resultat}");
            }
        }
    }
    class Enfant : Etudiant
    {
        string classeEcole;
        Dictionary<string, float> notes;

        public Enfant (string nom, int age, string classeEcole, Dictionary<string, float> notes = null) : base (nom, age, null)
        {
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();

            Console.WriteLine("  En classe de " + classeEcole);

            if (notes != null && notes.Count > 0)
            {
                Console.WriteLine("  Notes de l'élève :");
                foreach (var note in notes)
                {
                    Console.WriteLine($"     {note.Key} : {note.Value} / 10");
                }
            }

            AfficherProf();
        }
    }
    class Etudiant : Personne
    {
        string infosEtudes;
        public Personne professeurPrincipal;

        public Etudiant(string nom, int age, string infosEtudes, Personne professeurPrincipal = null) : base (nom, age)
        {
            this.infosEtudes = infosEtudes;
            this.professeurPrincipal = professeurPrincipal;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();

            Console.WriteLine("  Etudiant en " + infosEtudes);
            AfficherProf();
        }

        protected void AfficherProf()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine("    Professeur principal : ");
                professeurPrincipal.Afficher();
            }
        }
    }
    class Personne : IAffichable
    {
        static int nombreDePersonnes = 0;
        protected string nom;
        protected int age;
        string emploi;
        protected int numeroPersonne;

        public Personne(string nom, int age, string emploi = null)
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;

            this.numeroPersonne = nombreDePersonnes;
        }

        public virtual void  Afficher()
        {
            AfficherNomEtAge();

            if (emploi == null || emploi == "")
            {
                Console.WriteLine("  Aucun emploi spécifié");
            }
            else
            Console.WriteLine("  Emploi : " + emploi);
        }

        protected void AfficherNomEtAge()
        {
            Console.WriteLine("Personne N° " + numeroPersonne);
            Console.WriteLine("Nom : " + nom);
            Console.WriteLine("  Age : " + age + " ans");
        }

        public static void AfficherNombrePersonnes()
        {
            Console.WriteLine("Nombre total de personnes : " + nombreDePersonnes);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new List<IAffichable>
             {
                 new Enfant("Riri", 8, "CE1"),
                 new Etudiant ("Hamlet", 19, "philo"),
                 new Personne ("Picsou", 56, "Banquier"),
                 new Personne ("Dracula", 348, "Croque-mort"),
                 new TablesMultiplication(2)

             };

             foreach (var element in elements)
             {   
                 element.Afficher();
             }
             //Personne.AfficherNombrePersonnes(); 

           /* var personne1 = new Personne ( "Chouchou", 45, "Transformiste");
            var personne2 = new Etudiant("Hamlet", 19, "vengeance familiale");
            personne2.professeurPrincipal = new Personne("Crochet", 58, "professeur en vengeance");

            var personne4 = new Enfant("Riri", 8, "CE1", new Dictionary<string, float> { { "Maths", 5f }, { "Français", 8.5f }, { "Géo", 4.8f } });
            personne4.professeurPrincipal = new Personne("Dingo", 38, "Professeuf de dingueuries");

            personne1.Afficher();
            personne2.Afficher();
            personne4.Afficher();
            
            var table2 = new TablesMultiplication(2);
            table2.Afficher();*/
        }
    }
}
